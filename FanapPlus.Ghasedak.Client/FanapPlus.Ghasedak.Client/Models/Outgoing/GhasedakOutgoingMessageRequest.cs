using System;
using System.Collections.Generic;
using FanapPlus.Ghasedak.Client.Models.Outgoing.InlineModels;

namespace FanapPlus.Ghasedak.Client.Models.Outgoing
{
    public class GhasedakOutgoingMessageRequest
    {
        public GhasedakOutgoingMessageRequest()
        {
            Uid = Guid.NewGuid().ToString("N");
            Date = DateTime.UtcNow;
        }
        public string Uid { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<GhasedakContentMessage> Messages { get; set; }
    }
}