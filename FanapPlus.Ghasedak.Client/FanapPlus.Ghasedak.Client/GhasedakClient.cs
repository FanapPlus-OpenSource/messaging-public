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


            if (!Uri.TryCreate(config.BaseUrl, UriKind.Absolute, out var baseAddressUri))
            {
                throw new ArgumentException("invalid url format", nameof(_config.BaseUrl));
            }

            _httpClient = new HttpClient { BaseAddress = baseAddressUri };
        }


        public async Task<GhasedakSendResponse> SendAsync(GhasedakOutgoingMessageRequest message, GhasedakOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            if (string.IsNullOrWhiteSpace(options.PrivateKey))
            {
                throw new ArgumentNullException(nameof(options.PrivateKey));
            }

            var serializer = new JsonSerializer<GhasedakSendResponse>();
            message.SignWith(options.PrivateKey);
            var content = message.CreateContent();

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

        
    }
}