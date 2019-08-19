using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FanapPlus.Ghasedak.Client.Models;
using FanapPlus.Ghasedak.Client.Models.Exensions;
using FanapPlus.Ghasedak.Client.Models.Mappers;
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

            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            _httpClient = new HttpClient(handler) { BaseAddress = baseAddressUri };
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

            var inlineMessage = message.MapToInlineGhasedakOutgoingMessageRequest();
            inlineMessage.SignWith(options.PrivateKey);
            var content = inlineMessage.CreateContent();

            var httpResponse = await _httpClient.PostAsync("/api/v6.0/message/post", content);

            await CheckSuccessStatusCodeAndThrowIfUnsuccessful(httpResponse);

            var ghasedakResponseString = await httpResponse.Content.ReadAsStringAsync();
            var ghasedakResponse = serializer.DeserializeFromString(ghasedakResponseString);

            return ghasedakResponse;
        }

        public async Task<GhasedakSendResponse> SendAsync(GhasedakOutgoingMessageRequest message, string privateKey)
        {
            return await SendAsync(message, new GhasedakOptions {PrivateKey = privateKey});
        }


        public async Task<GhasedakSendResponse> SendAsync(GhasedakOutgoingBulkMessageRequest message, GhasedakOptions options)
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

            var inlineMessage = message.MapToInlineGhasedakOutgoingBulkMessageRequest();
            inlineMessage.SignWith(options.PrivateKey);
            var content = inlineMessage.CreateContent();

            var httpResponse = await _httpClient.PostAsync("/api/v6.0/message/post", content);

            await CheckSuccessStatusCodeAndThrowIfUnsuccessful(httpResponse);

            var ghasedakResponseString = await httpResponse.Content.ReadAsStringAsync();
            var ghasedakResponse = serializer.DeserializeFromString(ghasedakResponseString);

            return ghasedakResponse;
        }

        public async Task<GhasedakSendResponse> SendAsync(GhasedakOutgoingBulkMessageRequest message, string privateKey)
        {
            return await SendAsync(message, new GhasedakOptions { PrivateKey = privateKey });
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