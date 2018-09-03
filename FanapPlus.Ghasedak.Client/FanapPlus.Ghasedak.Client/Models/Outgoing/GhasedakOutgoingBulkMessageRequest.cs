using System;
using System.Collections.Generic;
using System.Text;

namespace FanapPlus.Ghasedak.Client.Models.Outgoing
{
    public class GhasedakOutgoingBulkMessageRequest
    {
        public GhasedakOutgoingBulkMessageRequest()
        {
            Uid = Guid.NewGuid().ToString("N");
            Date = DateTime.UtcNow;
            
        }
        public string Sid { get; set; }
        public string Content { get; set; }
        public MessageType MessageType { get; set; }
        public ChannelType ChannelType { get; set; }
        public MessagePriority Priority { get; set; }
        public DateTime? ExpirationTime { get; set; }
        public string Uid { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<GhasedakContentBulkMessage> Messages { get; set; }
    }
}
