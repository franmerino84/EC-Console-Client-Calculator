using AutoMapper;
using EC.Console.Client.Calculator.Services.Resolvers.Subtractions.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Subtractions.Exceptions;
using EC.Console.Client.Calculator.Services.Resolvers.Subtractions;
using EC.Console.Client.Calculator.Services.Resolvers;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;

namespace EC.Console.Client.Calculator.Test.Services.Resolvers.Subtractions
{

    [TestFixture]
    [Category(Category.Unit)]
    public class SubtractionResolverTests
    {
        private SubtractionResolver _resolver;
        private Mock<IApiManager> _apiManagerMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _apiManagerMock = new Mock<IApiManager>();
            _mapperMock = new Mock<IMapper>();
            _resolver = new SubtractionResolver(_apiManagerMock.Object, _mapperMock.Object);
        }

        [Test]
        public void Resolve_Not_Two_Arguments_Throws_SubtractionRequiresTwoArgumentsException()
        {
            Assert.ThrowsAsync<SubtractionRequiresTwoArgumentsException>(() => _resolver.Resolve(new List<string> { "1" }, "trackingId"));
        }

        [Test]
        public void Resolve_Not_Integer_Arguments_Throws_SubtractionRequiresIntegerArgumentsException()
        {
            Assert.ThrowsAsync<SubtractionRequiresIntegerArgumentsException>(() => _resolver.Resolve(new List<string> { "hello", "world" }, "trackingId"));
        }

        [Test]
        public async Task Resolve_Calls_ApiManager_PostAsync()
        {
            var arguments = new List<string> { "5", "2" };
            var trackingId = "trackingId";

            await _resolver.Resolve(arguments, trackingId);

            _apiManagerMock.Verify(x =>
                x.PostAsync<SubtractionRequestDto, SubtractionResponseDto>(
                    "calculator/sub",
                    It.Is<SubtractionRequestDto>(y => y.Minuend == 5 && y.Subtrahend == 2),
                    trackingId));
        }

        [Test]
        public async Task Resolver_Calls_Map_Over_Post_Result()
        {
            var arguments = new List<string> { "5", "2" };
            var trackingId = "trackingId";
            var responseDto = new SubtractionResponseDto(3);

            _apiManagerMock.Setup(x => x.PostAsync<SubtractionRequestDto, SubtractionResponseDto>(It.IsAny<string>(), It.IsAny<SubtractionRequestDto>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            await _resolver.Resolve(arguments, trackingId);

            _mapperMock.Verify(x => x.Map<SubtractionResponse>(responseDto));
        }

        [Test]
        public async Task Resolver_Returns_Mapped_Response()
        {
            var arguments = new List<string> { "5", "2" };
            var trackingId = "trackingId";
            var responseDto = new SubtractionResponseDto(3);
            var response = new SubtractionResponse(3);

            _apiManagerMock.Setup(x => x.PostAsync<SubtractionRequestDto, SubtractionResponseDto>(It.IsAny<string>(), It.IsAny<SubtractionRequestDto>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            _mapperMock.Setup(x => x.Map<SubtractionResponse>(It.IsAny<SubtractionResponseDto>())).Returns(response);

            var result = await _resolver.Resolve(arguments, trackingId);

            Assert.That(result, Is.EqualTo(response));
        }
    }
}
