# A .NET implementaion of Ghasedak API

Here you can find an .NET implementaion of Ghasedak API (version 5). To use it you must create an instance of `GhasedakClient`:

    IGhasedakClient client = new GhasedakClient(new GhasedakConfiguration());
    
It receives an object that is inherited from `IGhasedakConfiguration` interface. Here is it's simple implementation:

    public class GhasedakConfiguration : IGhasedakConfiguration
    {
        public string BaseUrl => "https://xcp.appson.ir/";
    }

And you can use it like this:

    var outgoingMultipleMessage = new GhasedakOutgoingMessageRequest
    {
        Date = DateTime.UtcNow,
        Uid = Guid.NewGuid().ToString("N"),
        Messages = new List<GhasedakContentMessage>()
        {
            new GhasedakContentMessage
            {
                Sid = "YourGhasedakSID",
                AccountId = "UserAccountId",
                ChannelType = ChannelType.Pardis,
                Content = "My content goes hear",
                MessageType = Ghasedak.Client.Models.MessageType.Content,
                Priority = MessagePriority.Low,
            }
        }
    };
    var result = await client.SendAsync(outgoingMultipleMessage, "YourGhasedakPrivateKey");
