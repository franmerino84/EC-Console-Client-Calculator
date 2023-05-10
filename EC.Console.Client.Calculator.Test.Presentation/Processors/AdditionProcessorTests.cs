using EC.Console.Client.Calculator.Presentation.Processors;
using EC.Console.Client.Calculator.Services.Resolvers.Additions.Dtos;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;

namespace EC.Console.Client.Calculator.Test.Presentation.Processors
{
    [TestFixture]
    [Category(Category.Unit)]
    public class AdditionProcessorTests
    {
        private AdditionProcessor _processor;
        private Mock<IOperationResolver<AdditionResponse>> _resolverMock;

        [SetUp]
        public void Setup()
        {
            _resolverMock = new Mock<IOperationResolver<AdditionResponse>>();
            _processor = new AdditionProcessor(_resolverMock.Object);
        }

        [Test]
        public async Task Process_Calls_Resolver()
        {
            var arguments = new List<string>
            {
                "2",
                "3"
            };
            var trackingId = "trackingId";

            var response = new AdditionResponse(5);

            _resolverMock.Setup(x => x.Resolve(arguments, trackingId)).ReturnsAsync(response);

            await _processor.Process(arguments, trackingId);

            _resolverMock.Verify(x=>x.Resolve(arguments,trackingId));
        }

        [Test]
        public async Task Process_Console_Prints_Sum()
        {
            var arguments = new List<string>
            {
                "2",
                "3"
            };
            var trackingId = "trackingId";

            var sum = 5;
            var response = new AdditionResponse(sum);

            _resolverMock.Setup(x => x.Resolve(arguments, trackingId)).ReturnsAsync(response);
            
            var stringWriter = new StringWriter();
            System.Console.SetOut(stringWriter);

            await _processor.Process(arguments, trackingId);

            var stringWritten = stringWriter.ToString().Replace("\r",string.Empty).Replace("\n", string.Empty);

            Assert.That(stringWritten, Is.EqualTo(sum.ToString()));            
        }
    }
}
