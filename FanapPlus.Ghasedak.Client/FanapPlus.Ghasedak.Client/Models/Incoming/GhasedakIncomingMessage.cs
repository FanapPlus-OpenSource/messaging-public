using System;

namespace FanapPlus.Ghasedak.Client.Models.Incoming
{
    public class GhasedakIncomingMessage
    {
        public string Muid { get; set; }
        public string Sid { get; set; }
        public DateTime ReceiveTime { get; set; }
        public ChannelType ChannelType { get; set; }
        public string Channel { get; set; }
        public string Actor { get; set; }
        public string AccountId { get; set; }
        public string UserPhoneNumber { get; set; }
        public MessageType MessageType { get; set; }
        public string Content { get; set; }
        public string Signature { get; set; }
    }
}