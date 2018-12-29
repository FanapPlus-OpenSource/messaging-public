using System.Collections.Generic;

namespace FanapPlus.Ghasedak.Client.Models.Outgoing.InlineModels
{
    internal class InlineGhasedakContentMessage
    {
        public string Sid { get; set; }
        public string AccountId { get; set; }
        public string Content { get; set; }
        public MessageType MessageType { get; set; }
        public ChannelType ChannelType { get; set; }
        public MessagePriority Priority { get; set; }
        public string ExpirationTime { get; set; }
        public string ReplyTo { get; set; }
        public string Signature { get; set; }
        public List<string> Tags { get; set; }
        public string UserPhoneNumber { get; internal set; }
        public long? SyncDeliveryTimeout { get; set; }
    }
}