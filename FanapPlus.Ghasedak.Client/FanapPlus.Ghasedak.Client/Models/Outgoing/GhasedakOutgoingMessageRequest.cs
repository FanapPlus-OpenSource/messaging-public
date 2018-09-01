using System.Collections.Generic;

namespace FanapPlus.Ghasedak.Client.Models.Outgoing
{
    public class GhasedakOutgoingMessageRequest
    {
        public string Uid { get; set; }
        public string Date { get; set; }
        public IEnumerable<GhasedakContentMessage> Messages { get; set; }
    }
}