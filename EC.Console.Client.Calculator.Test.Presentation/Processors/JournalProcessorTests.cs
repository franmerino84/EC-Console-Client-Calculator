using EC.Console.Client.Calculator.Presentation.Processors;
using EC.Console.Client.Calculator.Services.Resolvers.Journals;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;

namespace EC.Console.Client.Calculator.Test.Presentation.Processors
{

    [TestFixture]
    [Category(Category.Unit)]
    public class JournalProcessorTests
    {
        private JournalProcessor _processor;
        private Mock<IOperationResolver<JournalResponse>> _resolverMock;

        [SetUp]
        public void Setup()
        {
            _resolverMock = new Mock<IOperationResolver<JournalResponse>>();
            _processor = new JournalProcessor(_resolverMock.Object);
        }

        [Test]
        public async Task Process_Calls_Resolver()
        {
            var arguments = new List<string>
            {
                "trackingId",
            };

            var response = new JournalResponse(new List<JournalQueryOperation>());

            _resolverMock.Setup(x => x.Resolve(arguments, null)).ReturnsAsync(response);

            await _processor.Process(arguments, null);

            _resolverMock.Verify(x => x.Resolve(arguments, null));
        }

        [Test]
        public async Task Process_Console_Prints_Journal_Operations()
        {
            var arguments = new List<string>
            {
                "trackingId",
            };

            var operations = new List<JournalQueryOperation>
            {
                new JournalQueryOperation("operation1", "calculation1", new DateTime(2001,2,3,4,5,6)),
                new JournalQueryOperation("operation2", "calculation2", new DateTime(2002,3,4,5,6,7)),
            };

            var response = new JournalResponse(operations);

            _resolverMock.Setup(x => x.Resolve(arguments, null)).ReturnsAsync(response);

            var stringWriter = new StringWriter();
            System.Console.SetOut(stringWriter);

            await _processor.Process(arguments, null);

            var stringsWritten = stringWriter.ToString().Split("\r\n");

            Assert.Multiple(() =>
            {
                Assert.That(stringsWritten, Does.Contain($"03/02/2001 4:05:06 (operation1): calculation1"));
                Assert.That(stringsWritten, Does.Contain($"04/03/2002 5:06:07 (operation2): calculation2"));
            });
        }
    }
}
