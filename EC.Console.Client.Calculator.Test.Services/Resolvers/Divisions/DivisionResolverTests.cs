using AutoMapper;
using EC.Console.Client.Calculator.Services.Resolvers.Divisions.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Divisions.Exceptions;
using EC.Console.Client.Calculator.Services.Resolvers.Divisions;
using EC.Console.Client.Calculator.Services.Resolvers;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;

namespace EC.Console.Client.Calculator.Test.Services.Resolvers.Divisions
{

    [TestFixture]
    [Category(Category.Unit)]
    public class DivisionResolverTests
    {
        private DivisionResolver _resolver;
        private Mock<IApiManager> _apiManagerMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _apiManagerMock = new Mock<IApiManager>();
            _mapperMock = new Mock<IMapper>();
            _resolver = new DivisionResolver(_apiManagerMock.Object, _mapperMock.Object);
        }

        [Test]
        public void Resolve_Not_Two_Arguments_Throws_DivisionRequiresTwoArgumentsException()
        {
            Assert.ThrowsAsync<DivisionRequiresTwoArgumentsException>(() => _resolver.Resolve(new List<string> { "1" }, "trackingId"));
        }

        [Test]
        public void Resolve_Not_Integer_Arguments_Throws_DivisionRequiresIntegerArgumentsException()
        {
            Assert.ThrowsAsync<DivisionRequiresIntegerArgumentsException>(() => _resolver.Resolve(new List<string> { "hello", "world" }, "trackingId"));
        }

        [Test]
        public async Task Resolve_Calls_ApiManager_PostAsync()
        {
            var arguments = new List<string> { "5", "2" };
            var trackingId = "trackingId";

            await _resolver.Resolve(arguments, trackingId);

            _apiManagerMock.Verify(x =>
                x.PostAsync<DivisionRequestDto, DivisionResponseDto>(
                    "calculator/div",                    
                    It.Is<DivisionRequestDto>(y => y.Dividend == 5 && y.Divisor == 2),                     
                    trackingId));                    
        }

        [Test]
        public async Task Resolver_Calls_Map_Over_Post_Result()
        {
            var arguments = new List<string> { "5", "2" };
            var trackingId = "trackingId";
            var responseDto = new DivisionResponseDto(2, 1);

            _apiManagerMock.Setup(x => x.PostAsync<DivisionRequestDto, DivisionResponseDto>(It.IsAny<string>(), It.IsAny<DivisionRequestDto>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            await _resolver.Resolve(arguments, trackingId);

            _mapperMock.Verify(x => x.Map<DivisionResponse>(responseDto));
        }

        [Test]
        public async Task Resolver_Returns_Mapped_Response()
        {
            var arguments = new List<string> { "5", "2" };
            var trackingId = "trackingId";
            var responseDto = new DivisionResponseDto(2, 1);
            var response = new DivisionResponse(2, 1);

            _apiManagerMock.Setup(x => x.PostAsync<DivisionRequestDto, DivisionResponseDto>(It.IsAny<string>(), It.IsAny<DivisionRequestDto>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            _mapperMock.Setup(x => x.Map<DivisionResponse>(It.IsAny<DivisionResponseDto>())).Returns(response);

            var result = await _resolver.Resolve(arguments, trackingId);

            Assert.That(result, Is.EqualTo(response));
        }
    }
}
