using System;
using System.Security.Cryptography;
using System.Text;
using FanapPlus.Ghasedak.Client.Models.Outgoing;

namespace FanapPlus.Ghasedak.Client.Models.Exensions
{
    public static class GhasedakMessagesExtensions
    {
        public static void SignWith(this GhasedakMultipleOutgoingMessageRequest request, string key)
        {
            request?.Messages?.ForEach(c =>
            {
                c.Signature = SignText(string.Join(",",
                    request.Date,
                    request.Uid,
                    request.Sid,
                    request.ChannelType.ToString(),
                    request.MessageType.ToString(),
                    c.AccountId,
                    request.Content), key);
            });
        }

        private static string SignText(string signable, string privateKey)
        {
            string encodedSignature;
            using (var provider = new RSACryptoServiceProvider(new CspParameters { ProviderType = 1 }))
            {
                RsaCryptoServiceProviderExtensions.FromXmlString(provider, privateKey);
                var bytes = Encoding.UTF8.GetBytes(signable);
                var signedBytes = provider.SignData(bytes, "SHA1");
                encodedSignature = Convert.ToBase64String(signedBytes);
            }

            return encodedSignature;
        }
    }
}
