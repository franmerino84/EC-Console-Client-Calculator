using EC.Console.Client.Calculator.Services.Resolvers;
using EC.Console.Client.Calculator.Test.Helpers;
using Moq;
using Moq.Protected;

#pragma warning disable CS8602 // Dereference of a possibly null reference.


namespace EC.Console.Client.Calculator.Test.Services.Api
{

    [TestFixture]
    [Category(Category.Unit)]
    public class ApiManagerTests
    {
        private ApiManager _manager;
        private Mock<HttpMessageHandler> _handlerMock;
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _handlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_handlerMock.Object)
            {
                BaseAddress = new Uri("https://www.baseaddress.com")
            };
            _manager = new ApiManager(_httpClient);
        }

        [Test]
        public async Task PostAsync_Returns_Deserialized_Response()
        {
            var endpoint = "endpoint";
            var body = new RequestDto("hello", "world");
            var trackingId = "trackingId";

            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(@"{""ResponseField1"":""farewell"",""ResponseField2"":""friends""}")
            };

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var result = await _manager.PostAsync<RequestDto, ResponseDto>(endpoint, body, trackingId);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResponseField1, Is.EqualTo("farewell"));
                Assert.That(result.ResponseField2, Is.EqualTo("friends"));
            });
        }

        [Test]
        public async Task PostAsync_Calls_HttpClient_Post_Endpoint_With_Serialized_Body()
        {
            var endpoint = "endpoint";
            var body = new RequestDto("hello", "world");
            var trackingId = "trackingId";

            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(@"{""ResponseField1"":""farewell"",""ResponseField2"":""friends""}")
            };

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var result = await _manager.PostAsync<RequestDto, ResponseDto>(endpoint, body, trackingId);

            _handlerMock.Protected()
                .Verify("SendAsync", Times.AtLeastOnce(),
                    ItExpr.Is<HttpRequestMessage>(x =>
                        x.Method == HttpMethod.Post &&
                        x.Content.ReadAsStringAsync().Result.Contains("hello") &&
                        x.Content.ReadAsStringAsync().Result.Contains("world") &&
                        new Uri("https://www.baseaddress.com/endpoint").Equals(x.RequestUri)),
                    ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public async Task PostAsync_Calls_HttpClient_Post_With_Tracking_Header()
        {
            var endpoint = "endpoint";
            var body = new RequestDto("hello", "world");
            var trackingId = "trackingId";

            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(@"{""ResponseField1"":""farewell"",""ResponseField2"":""friends""}")
            };

            _handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var result = await _manager.PostAsync<RequestDto, ResponseDto>(endpoint, body, trackingId);

            _handlerMock.Protected()
                .Verify("SendAsync", Times.AtLeastOnce(),
                    ItExpr.Is<HttpRequestMessage>(x =>
                        x.Headers.First(x => x.Key == "X-Evi-Tracking-Id").Value.Contains(trackingId)),
                    ItExpr.IsAny<CancellationToken>());
        }

        private class RequestDto
        {
            public RequestDto(string requestField1, string requestField2)
            {
                RequestField1 = requestField1;
                RequestField2 = requestField2;
            }

            public string RequestField1 { get; set; }
            public string RequestField2 { get; set; }
        }

        private class ResponseDto
        {
            public ResponseDto(string responseField1, string responseField2)
            {
                ResponseField1 = responseField1;
                ResponseField2 = responseField2;
            }

            public string ResponseField1 { get; set; }
            public string ResponseField2 { get; set; }
        }


    }
}

#pragma warning restore CS8602 // Dereference of a possibly null reference.
