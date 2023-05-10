using AutoMapper;
using EC.Console.Client.Calculator.Services.Resolvers;
using EC.Console.Client.Calculator.Services.Resolvers.Journals;
using EC.Console.Client.Calculator.Services.Resolvers.Journals.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Journals.Exceptions;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;

namespace EC.Console.Client.Calculator.Test.Services.Resolvers.Journals
{

    [TestFixture]
    [Category(Category.Unit)]
    public class JournalResolverTests
    {
        private JournalResolver _resolver;
        private Mock<IApiManager> _apiManagerMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _apiManagerMock = new Mock<IApiManager>();
            _mapperMock = new Mock<IMapper>();
            _resolver = new JournalResolver(_apiManagerMock.Object, _mapperMock.Object);
        }

        [Test]
        public void Resolve_Not_One_Arguments_Throws_JournalRequiresTwoArgumentsException()
        {
            Assert.ThrowsAsync<JournalRequiresOneArgumentException>(() => _resolver.Resolve(new List<string> { "1", "2" }, null));
        }

        [Test]
        public async Task Resolve_Calls_ApiManager_PostAsync()
        {
            var arguments = new List<string> { "trackingId" };           

            await _resolver.Resolve(arguments, null);

            _apiManagerMock.Verify(x =>
                x.PostAsync<JournalRequestDto, JournalResponseDto>(
                    "journal/query",
                    It.Is<JournalRequestDto>(y => y.Id == "trackingId"),
                    null));
        }

        [Test]
        public async Task Resolver_Calls_Map_Over_Post_Result()
        {
            var arguments = new List<string> { "trackingId" };

            var responseDto = new JournalResponseDto(
                new List<JournalQueryOperationDto> { 
                    new JournalQueryOperationDto("operation1", "calculation1", new DateTime(2001,2,3)) ,
                    new JournalQueryOperationDto("operation2", "calculation2", new DateTime(2002,3,4))
                }
                );

            _apiManagerMock.Setup(x => x.PostAsync<JournalRequestDto, JournalResponseDto>(It.IsAny<string>(), It.IsAny<JournalRequestDto>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            await _resolver.Resolve(arguments, null);

            _mapperMock.Verify(x => x.Map<JournalResponse>(responseDto));
        }

        [Test]
        public async Task Resolver_Returns_Mapped_Response()
        {
            var arguments = new List<string> { "trackingId" };
            var trackingId = "trackingId";
            var responseDto = new JournalResponseDto(
                new List<JournalQueryOperationDto> {
                    new JournalQueryOperationDto("operation1", "calculation1", new DateTime(2001,2,3)) ,
                    new JournalQueryOperationDto("operation2", "calculation2", new DateTime(2002,3,4))
                }
                );
            var response =  new JournalResponse(
                new List<JournalQueryOperation> {
                    new JournalQueryOperation("operation1", "calculation1", new DateTime(2001,2,3)) ,
                    new JournalQueryOperation("operation2", "calculation2", new DateTime(2002,3,4))
                }
                );

            _apiManagerMock.Setup(x => x.PostAsync<JournalRequestDto, JournalResponseDto>(It.IsAny<string>(), It.IsAny<JournalRequestDto>(), It.IsAny<string>()))
                .ReturnsAsync(responseDto);

            _mapperMock.Setup(x => x.Map<JournalResponse>(It.IsAny<JournalResponseDto>())).Returns(response);

            var result = await _resolver.Resolve(arguments, trackingId);

            Assert.That(result, Is.EqualTo(response));
        }
    }
}
