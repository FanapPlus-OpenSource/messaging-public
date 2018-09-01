using System;
using System.Collections.Generic;
using FanapPlus.Ghasedak.Client.Models.Outgoing.InlineModels;

namespace FanapPlus.Ghasedak.Client.Models.Outgoing
{
    public class GhasedakOutgoingMessageRequest
    {
        public string Uid { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<GhasedakContentMessage> Messages { get; set; }
    }
}