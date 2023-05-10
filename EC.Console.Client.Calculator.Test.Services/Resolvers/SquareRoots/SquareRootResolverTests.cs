using AutoMapper;
using EC.Console.Client.Calculator.Services.Resolvers.SquareRoots.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.SquareRoots.Exceptions;
using EC.Console.Client.Calculator.Services.Resolvers.SquareRoots;
using EC.Console.Client.Calculator.Services.Resolvers;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;

namespace EC.Console.Client.Calculator.Test.Services.Resolvers.SquareRoots
{

    [TestFixture]
    [Category(Category.Unit)]
    public class SquareRootResolverTests
    {
        private SquareRootResolver _resolver;
        private Mock<IApiManager> _apiManagerMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _apiManagerMock = new Mock<IApiManager>();
            _mapperMock = new Mock<IMapper>();
            _resolver = new SquareRootResolver(_apiManagerMock.Object, _mapperMock.Object);
        }

        [Test]
        public void Resolve_Not_One_Argument_Throws_SquareRootRequiresOneArgumentsException()
        {
            Assert.ThrowsAsync<SquareRootRequiresOneArgumentException>(() => _resolver.Resolve(new List<string> { "1", "2" }, "trackingId"));
        }

        [Test]
        public void Resolve_Not_Integer_Arguments_Throws_SquareRootRequiresIntegerArgumentsException()
        {
            Assert.ThrowsAsync<SquareRootRequiresIntegerArgumentsException>(() => _resolver.Resolve(new List<string> { "hello" }, "trackingId"));
        }

        [Test]
        public async Task Resolve_Calls_ApiManager_PostAsync()
        {
            var arguments = new List<string> { "9" };
            var trackingId = "trackingId";

            await _resolver.Resolve(arguments, trackingId);

            _apiManagerMock.Verify(x =>
                x.PostAsync<SquareRootRequestDto, SquareRootResponseDto>(
                    "calculator/sqrt",
                    It.Is<SquareRootRequestDto>(y => y.Number == 9),
                    trackingId));
        }

        [Test]
        public async Task Resolver_Calls_Map_Over_Post_Result()
        {
            var arguments = new List<string> { "9" };
            var trackingId = "trackingId";
            var responseDto = new SquareRootResponseDto(3);

            _apiManagerMock.Setup(x => x.PostAsync<SquareRootRequestDto, SquareRootResponseDto>(It.IsAny<string>(), It.IsAny<SquareRootRequestDto>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            await _resolver.Resolve(arguments, trackingId);

            _mapperMock.Verify(x => x.Map<SquareRootResponse>(responseDto));
        }

        [Test]
        public async Task Resolver_Returns_Mapped_Response()
        {
            var arguments = new List<string> { "9" };
            var trackingId = "trackingId";
            var responseDto = new SquareRootResponseDto(3);
            var response = new SquareRootResponse(3);

            _apiManagerMock.Setup(x => x.PostAsync<SquareRootRequestDto, SquareRootResponseDto>(It.IsAny<string>(), It.IsAny<SquareRootRequestDto>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            _mapperMock.Setup(x => x.Map<SquareRootResponse>(It.IsAny<SquareRootResponseDto>())).Returns(response);

            var result = await _resolver.Resolve(arguments, trackingId);

            Assert.That(result, Is.EqualTo(response));
        }
    }
}
