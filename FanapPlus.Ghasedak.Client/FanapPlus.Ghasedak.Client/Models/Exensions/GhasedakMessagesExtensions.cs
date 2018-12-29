using System;
using System.Security.Cryptography;
using System.Text;
using FanapPlus.Ghasedak.Client.Models.Outgoing;
using FanapPlus.Ghasedak.Client.Models.Outgoing.InlineModels;

namespace FanapPlus.Ghasedak.Client.Models.Exensions
{
    internal static class GhasedakMessagesExtensions
    {

        internal static void SignWith(this InlineGhasedakOutgoingBulkMessageRequest request, string key)
        {
            if (request?.Messages == null)
            {
                return;
            }

            foreach (var message in request.Messages)
            {
                message.Signature = SignText(string.Join(",",
                    request.Date,
                    request.Uid,
                    request.Sid,
                    request.ChannelType.ToString(),
                    request.MessageType.ToString(),
                    message.AccountId,
                    request.Content), key);
            }
        }


        internal static void SignWith(this InlineGhasedakOutgoingMessageRequest request, string key)
        {
            if (request?.Messages == null)
            {
                return;
            }

            foreach (var message in request.Messages)
            {
                message.Signature = SignText(string.Join(",",
                    request.Date,
                    request.Uid,
                    message.Sid,
                    message.ChannelType.ToString(),
                    message.MessageType.ToString(),
                    message.AccountId ?? message.UserPhoneNumber,
                    message.Content), key);
            }
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
