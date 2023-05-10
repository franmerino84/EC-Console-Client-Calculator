using EC.Console.Client.Calculator.Presentation.Processors;
using EC.Console.Client.Calculator.Services.Resolvers.Subtractions;
using EC.Console.Client.Calculator.Services.Resolvers.Subtractions.Dtos;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;

namespace EC.Console.Client.Calculator.Test.Presentation.Processors
{

    [TestFixture]
    [Category(Category.Unit)]
    public class SubtractionProcessorTests
    {
        private SubtractionProcessor _processor;
        private Mock<IOperationResolver<SubtractionResponse>> _resolverMock;

        [SetUp]
        public void Setup()
        {
            _resolverMock = new Mock<IOperationResolver<SubtractionResponse>>();
            _processor = new SubtractionProcessor(_resolverMock.Object);
        }

        [Test]
        public async Task Process_Calls_Resolver()
        {
            var arguments = new List<string>
            {
                "5",
                "3"
            };
            var trackingId = "trackingId";

            var response = new SubtractionResponse(2);

            _resolverMock.Setup(x => x.Resolve(arguments, trackingId)).ReturnsAsync(response);

            await _processor.Process(arguments, trackingId);

            _resolverMock.Verify(x => x.Resolve(arguments, trackingId));
        }

        [Test]
        public async Task Process_Console_Prints_Difference()
        {
            var arguments = new List<string>
            {
                "5",
                "3"
            };
            var trackingId = "trackingId";

            var difference = 2;
            var response = new SubtractionResponse(difference);

            _resolverMock.Setup(x => x.Resolve(arguments, trackingId)).ReturnsAsync(response);

            var stringWriter = new StringWriter();
            System.Console.SetOut(stringWriter);

            await _processor.Process(arguments, trackingId);

            var stringWritten = stringWriter.ToString().Replace("\r", string.Empty).Replace("\n", string.Empty);

            Assert.That(stringWritten, Is.EqualTo(difference.ToString()));
        }
    }
}
