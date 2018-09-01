using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FanapPlus.Ghasedak.Client.Models;
using FanapPlus.Ghasedak.Client.Models.Exensions;
using FanapPlus.Ghasedak.Client.Models.Outgoing;
using ServiceStack.Text;

namespace FanapPlus.Ghasedak.Client
{
    public class GhasedakClient : IGhasedakClient
    {
        private readonly IGhasedakConfiguration _config;
        private readonly HttpClient _httpClient;

        public GhasedakClient(IGhasedakConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));

            if (string.IsNullOrEmpty(config.BaseUrl))
            {
                throw new ArgumentNullException(nameof(_config.BaseUrl));
            }

            if (string.IsNullOrWhiteSpace(_config.PrivateKey))
            {
                throw new ArgumentNullException(nameof(_config.PrivateKey));
            }

            if (!Uri.TryCreate(config.BaseUrl, UriKind.Absolute, out var baseAddressUri))
            {
                throw new ArgumentException("invalid url format", nameof(_config.BaseUrl));
            }

            _httpClient = new HttpClient { BaseAddress = baseAddressUri };
        }


        public async Task<GhasedakSendResponse> Send(GhasedakOutgoingMessageRequest message)
        {
            var serializer = new JsonSerializer<GhasedakSendResponse>();
            message.SignWith(_config.PrivateKey);
            var content = CreateContent(message);

            var httpResponse = await _httpClient.PostAsync("/api/v5.0/message/post", content);

            await CheckSuccessStatusCodeAndThrowIfUnsuccessful(httpResponse);

            var ghasedakResponseString = await httpResponse.Content.ReadAsStringAsync();
            var ghasedakResponse = serializer.DeserializeFromString(ghasedakResponseString);

            return ghasedakResponse;

        }
        private async Task CheckSuccessStatusCodeAndThrowIfUnsuccessful(HttpResponseMessage httpResponse)
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                return;
            }

            if (!httpResponse.IsSuccessStatusCode)
            {
                var errorString = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception($"Error while callin ghasedak api: {errorString} \n\rHttpStatusCode: {httpResponse.StatusCode}");
            }
            

            httpResponse.EnsureSuccessStatusCode();
        }

        private static HttpContent CreateContent<T>(T message)
        {
            var serializer = new JsonSerializer<T>();

            var content = new StringContent(serializer.SerializeToString(message), Encoding.UTF8, "application/json");

            return content;
        }
    }
}