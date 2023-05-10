using EC.Console.Client.Calculator.Presentation.Client;
using EC.Console.Client.Calculator.Presentation.Processors;
using EC.Console.Client.Calculator.Presentation.Processors.Factory;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;

namespace EC.Console.Client.Calculator.Test.Presentation.Client
{

    [TestFixture]
    [Category(Category.Unit)]
    public class CalculatorClientTests
    {
        private CalculatorClient _client;
        private Mock<IOperationProcessorFactory> _factoryMock;

        [SetUp]
        public void SetUp()
        {
            _factoryMock = new Mock<IOperationProcessorFactory>();
            _client = new CalculatorClient(_factoryMock.Object);
        }

        [Test]
        public async Task Process_Calls_Factory_Build_With_Operation_Argument()
        {
            var operation = "operation";

            _factoryMock.Setup(x=>x.Build(It.IsAny<string>())).Returns(Mock.Of<IOperationProcessor>());

            await _client.Process(new CalculatorClientConsoleArguments { Operation = operation });

            _factoryMock.Verify(x => x.Build(operation));
        }

        [Test]
        public async Task Process_Calls_Processor_Process_Built_By_Factory()
        {
            var operation = "operation";

            var processorMock = new Mock<IOperationProcessor>();
            _factoryMock.Setup(x => x.Build(It.IsAny<string>())).Returns(processorMock.Object);

            var arguments = new CalculatorClientConsoleArguments 
            { 
                Operation = operation, 
                Arguments = new List<string> { "1", "2" }, 
                TrackingId = "trackingId" 
            };

            await _client.Process(arguments);

            processorMock.Verify(x => x.Process(arguments.Arguments, arguments.TrackingId));
        }
    }
}
