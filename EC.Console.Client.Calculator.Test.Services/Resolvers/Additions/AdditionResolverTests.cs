﻿using AutoMapper;
using EC.Console.Client.Calculator.Services.Resolvers;
using EC.Console.Client.Calculator.Services.Resolvers.Additions;
using EC.Console.Client.Calculator.Services.Resolvers.Additions.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Additions.Exceptions;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;

namespace EC.Console.Client.Calculator.Test.Services.Resolvers.Additions
{

    [TestFixture]
    [Category(Category.Unit)]
    public class AdditionResolverTests
    {
        private AdditionResolver _resolver;
        private Mock<IApiManager> _apiManagerMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _apiManagerMock = new Mock<IApiManager>();
            _mapperMock = new Mock<IMapper>();
            _resolver = new AdditionResolver(_apiManagerMock.Object, _mapperMock.Object);
        }

        [Test]
        public void Resolve_Less_Than_Two_Arguments_Throws_AdditionRequiresAtLeastTwoArgumentsException()
        {
            Assert.ThrowsAsync<AdditionRequiresAtLeastTwoArgumentsException>(() => _resolver.Resolve(new List<string> { "1" }, "trackingId"));
        }

        [Test]
        public void Resolve_Not_Integer_Arguments_Throws_AdditionRequiresIntegerArgumentsException()
        {
            Assert.ThrowsAsync<AdditionRequiresIntegerArgumentsException>(() => _resolver.Resolve(new List<string> { "hello", "world" }, "trackingId"));
        }

        [Test]
        public async Task Resolve_Calls_ApiManager_PostAsync()
        {
            var arguments = new List<string> { "2", "3" };
            var trackingId = "trackingId";
            
            await _resolver.Resolve(arguments, trackingId);

            _apiManagerMock.Verify(x => 
                x.PostAsync<AdditionRequestDto, AdditionResponseDto>("calculator/add", 
                    It.Is<AdditionRequestDto>(y => y.Addends.Contains(2) && y.Addends.Contains(3)), trackingId));
        }

        [Test]
        public async Task Resolver_Calls_Map_Over_Post_Result()
        {
            var arguments = new List<string> { "2", "3" };
            var trackingId = "trackingId";
            var responseDto = new AdditionResponseDto(5);

            _apiManagerMock.Setup(x => x.PostAsync<AdditionRequestDto, AdditionResponseDto>(It.IsAny<string>(), It.IsAny<AdditionRequestDto>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            await _resolver.Resolve(arguments, trackingId);

            _mapperMock.Verify(x => x.Map<AdditionResponse>(responseDto));
        }

        [Test]
        public async Task Resolver_Returns_Mapped_Response()
        {
            var arguments = new List<string> { "2", "3" };
            var trackingId = "trackingId";
            var responseDto = new AdditionResponseDto(5);
            var response = new AdditionResponse(5);

            _apiManagerMock.Setup(x => x.PostAsync<AdditionRequestDto, AdditionResponseDto>(It.IsAny<string>(), It.IsAny<AdditionRequestDto>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            _mapperMock.Setup(x => x.Map<AdditionResponse>(It.IsAny<AdditionResponseDto>())).Returns(response);

            var result = await _resolver.Resolve(arguments, trackingId);

            Assert.That(result, Is.EqualTo(response));
        }
    }
}
