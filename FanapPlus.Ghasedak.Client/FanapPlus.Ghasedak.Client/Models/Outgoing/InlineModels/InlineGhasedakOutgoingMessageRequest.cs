using System.Collections.Generic;

namespace FanapPlus.Ghasedak.Client.Models.Outgoing.InlineModels
{
    internal class InlineGhasedakOutgoingMessageRequest
    {
        public string Uid { get; set; }
        public string Date { get; set; }
        public IEnumerable<InlineGhasedakContentMessage> Messages { get; set; }
        public string SyncDeliveryTimeout { get; set; }
    }
}