using System;
using System.Collections.Generic;
using FanapPlus.Ghasedak.Client;
using FanapPlus.Ghasedak.Client.Models;
using FanapPlus.Ghasedak.Client.Models.Outgoing;
using Xunit;

namespace FanapPlus.Ghasedak.Client.Tests
{
    public class RunTest
    {
        public static string TemproraryMockPrivateKey = "YourKey";
        
        [Fact(Skip = "It runs against actual service.")]
        public async System.Threading.Tasks.Task Send_Start_GhasedakAsync()
        {
            var config = new ProductGhasedakConfiguration();

            var client = new GhasedakClient(config);

            try
            {
                var result = await client.SendAsync(new Models.Outgoing.GhasedakOutgoingMessageRequest
            {
                Date = DateTime.UtcNow,
                Uid = Guid.NewGuid().ToString("N"),

                Messages = new List<GhasedakContentMessage> {
                        new GhasedakContentMessage
                        {
                            UserPhoneNumber = "YourPhone",
                            ChannelType = ChannelType.Pardis,
                            Priority = MessagePriority.High,
                            Sid = "YourSid",
                            MessageType = MessageType.Verification,
                        }
                    }
            }, TemproraryMockPrivateKey);
            }
            catch (System.Exception ex)
            {
                
                throw;
            }
        }

        [Fact(Skip = "It runs against actual service.")]
        public async System.Threading.Tasks.Task Send_Commit_GhasedakAsync()
        {
            var config = new ProductGhasedakConfiguration();
            var client = new GhasedakClient(config);

            try
            {
                var result = await client.SendAsync(new Models.Outgoing.GhasedakOutgoingMessageRequest
                {
                    Date = DateTime.UtcNow,
                    Uid = Guid.NewGuid().ToString("N"),
                    SyncDeliveryTimeout = "10000",
                    Messages = new List<GhasedakContentMessage> {
                        new GhasedakContentMessage
                        {
                            UserPhoneNumber = "YourPhone",
                            ChannelType = ChannelType.Pardis,
                            Priority = MessagePriority.High,
                            Content = "YourPin",
                            Sid = "YourSid", 
                            MessageType = MessageType.Subscription,
                        }
                    }
                }, TemproraryMockPrivateKey);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }

}