using EC.Console.Client.Calculator.Presentation.Processors;
using EC.Console.Client.Calculator.Services.Resolvers.Divisions;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;

namespace EC.Console.Client.Calculator.Test.Presentation.Processors
{

    [TestFixture]
    [Category(Category.Unit)]
    public class DivisionProcessorTests
    {
        private DivisionProcessor _processor;
        private Mock<IOperationResolver<DivisionResponse>> _resolverMock;

        [SetUp]
        public void Setup()
        {
            _resolverMock = new Mock<IOperationResolver<DivisionResponse>>();
            _processor = new DivisionProcessor(_resolverMock.Object);
        }

        [Test]
        public async Task Process_Calls_Resolver()
        {
            var arguments = new List<string>
            {
                "5",
                "2"
            };
            var trackingId = "trackingId";

            var response = new DivisionResponse(2,1);

            _resolverMock.Setup(x => x.Resolve(arguments, trackingId)).ReturnsAsync(response);

            await _processor.Process(arguments, trackingId);

            _resolverMock.Verify(x => x.Resolve(arguments, trackingId));
        }

        [Test]
        public async Task Process_Console_Prints_Quotient_And_Remainder()
        {
            var arguments = new List<string>
            {
                "5",
                "2"
            };
            var trackingId = "trackingId";

            var quotient = 2;
            var remainder = 1;
            var response = new DivisionResponse(quotient, remainder);

            _resolverMock.Setup(x => x.Resolve(arguments, trackingId)).ReturnsAsync(response);

            var stringWriter = new StringWriter();
            System.Console.SetOut(stringWriter);

            await _processor.Process(arguments, trackingId);

            var stringWritten = stringWriter.ToString().Replace("\r", string.Empty).Replace("\n", string.Empty);

            Assert.That(stringWritten, Is.EqualTo($"Quotient: {quotient}. Remainder: {remainder}"));
        }
    }
}
