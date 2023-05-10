using EC.Console.Client.Calculator.Presentation.Processors;
using EC.Console.Client.Calculator.Services.Resolvers.SquareRoots;
using EC.Console.Client.Calculator.Services.Resolvers.SquareRoots.Dtos;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;

namespace EC.Console.Client.Calculator.Test.Presentation.Processors
{

    [TestFixture]
    [Category(Category.Unit)]
    public class SquareRootProcessorTests
    {
        private SquareRootProcessor _processor;
        private Mock<IOperationResolver<SquareRootResponse>> _resolverMock;

        [SetUp]
        public void Setup()
        {
            _resolverMock = new Mock<IOperationResolver<SquareRootResponse>>();
            _processor = new SquareRootProcessor(_resolverMock.Object);
        }

        [Test]
        public async Task Process_Calls_Resolver()
        {
            var arguments = new List<string>
            {
                "25"              
            };
            var trackingId = "trackingId";

            var response = new SquareRootResponse(5);

            _resolverMock.Setup(x => x.Resolve(arguments, trackingId)).ReturnsAsync(response);

            await _processor.Process(arguments, trackingId);

            _resolverMock.Verify(x => x.Resolve(arguments, trackingId));
        }

        [Test]
        public async Task Process_Console_Prints_Square()
        {
            var arguments = new List<string>
            {
                "25"                
            };
            var trackingId = "trackingId";

            var square = 5;
            var response = new SquareRootResponse(square);

            _resolverMock.Setup(x => x.Resolve(arguments, trackingId)).ReturnsAsync(response);

            var stringWriter = new StringWriter();
            System.Console.SetOut(stringWriter);

            await _processor.Process(arguments, trackingId);

            var stringWritten = stringWriter.ToString().Replace("\r", string.Empty).Replace("\n", string.Empty);

            Assert.That(stringWritten, Is.EqualTo(square.ToString()));
        }
    }
}
