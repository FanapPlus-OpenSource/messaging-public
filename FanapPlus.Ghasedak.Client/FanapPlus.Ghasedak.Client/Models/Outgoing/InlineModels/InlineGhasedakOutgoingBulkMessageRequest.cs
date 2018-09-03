using System;
using System.Collections.Generic;
using System.Text;

namespace FanapPlus.Ghasedak.Client.Models.Outgoing.InlineModels
{
    internal class InlineGhasedakOutgoingBulkMessageRequest
    {

        public string Sid { get; set; }
        public string Content { get; set; }
        public MessageType MessageType { get; set; }
        public ChannelType ChannelType { get; set; }
        public MessagePriority Priority { get; set; }
        public string ExpirationTime { get; set; }
        public string Uid { get; set; }
        public string Date { get; set; }
        public IEnumerable<InlineGhasedakContentBulkMessage> Messages { get; set; }
    }
}
