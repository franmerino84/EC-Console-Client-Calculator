using AutoMapper;
using EC.Console.Client.Calculator.Services.Resolvers.Multiplications.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Multiplications.Exceptions;
using EC.Console.Client.Calculator.Services.Resolvers.Multiplications;
using EC.Console.Client.Calculator.Services.Resolvers;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;

namespace EC.Console.Client.Calculator.Test.Services.Resolvers.Multiplications
{

    [TestFixture]
    [Category(Category.Unit)]
    public class MultiplicationResolverTests
    {
        private MultiplicationResolver _resolver;
        private Mock<IApiManager> _apiManagerMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _apiManagerMock = new Mock<IApiManager>();
            _mapperMock = new Mock<IMapper>();
            _resolver = new MultiplicationResolver(_apiManagerMock.Object, _mapperMock.Object);
        }

        [Test]
        public void Resolve_Less_Than_Two_Arguments_Throws_MultiplicationRequiresAtLeastTwoArgumentsException()
        {
            Assert.ThrowsAsync<MultiplicationRequiresAtLeastTwoArgumentsException>(() => _resolver.Resolve(new List<string> { "1" }, "trackingId"));
        }

        [Test]
        public void Resolve_Not_Integer_Arguments_Throws_MultiplicationRequiresIntegerArgumentsException()
        {
            Assert.ThrowsAsync<MultiplicationRequiresIntegerArgumentsException>(() => _resolver.Resolve(new List<string> { "hello", "world" }, "trackingId"));
        }

        [Test]
        public async Task Resolve_Calls_ApiManager_PostAsync()
        {
            var arguments = new List<string> { "2", "3" };
            var trackingId = "trackingId";

            await _resolver.Resolve(arguments, trackingId);

            _apiManagerMock.Verify(x =>
                x.PostAsync<MultiplicationRequestDto, MultiplicationResponseDto>("calculator/mult",
                    It.Is<MultiplicationRequestDto>(y => y.Factors.Contains(2) && y.Factors.Contains(3)), trackingId));
        }

        [Test]
        public async Task Resolver_Calls_Map_Over_Post_Result()
        {
            var arguments = new List<string> { "2", "3" };
            var trackingId = "trackingId";
            var responseDto = new MultiplicationResponseDto(6);

            _apiManagerMock.Setup(x => x.PostAsync<MultiplicationRequestDto, MultiplicationResponseDto>(It.IsAny<string>(), It.IsAny<MultiplicationRequestDto>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            await _resolver.Resolve(arguments, trackingId);

            _mapperMock.Verify(x => x.Map<MultiplicationResponse>(responseDto));
        }

        [Test]
        public async Task Resolver_Returns_Mapped_Response()
        {
            var arguments = new List<string> { "2", "3" };
            var trackingId = "trackingId";
            var responseDto = new MultiplicationResponseDto(6);
            var response = new MultiplicationResponse(6);

            _apiManagerMock.Setup(x => x.PostAsync<MultiplicationRequestDto, MultiplicationResponseDto>(It.IsAny<string>(), It.IsAny<MultiplicationRequestDto>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            _mapperMock.Setup(x => x.Map<MultiplicationResponse>(It.IsAny<MultiplicationResponseDto>())).Returns(response);

            var result = await _resolver.Resolve(arguments, trackingId);

            Assert.That(result, Is.EqualTo(response));
        }
    }
}
