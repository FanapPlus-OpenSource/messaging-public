namespace FanapPlus.Ghasedak.Client.Models.Incoming
{
    public class GhasedakIncomingMessage
    {
        public string Muid { get; set; }
        public string AccountId { get; set; }
        public string Status { get; set; }
        public string Sid { get; set; }
        public ChannelType ChannelType { get; set; }
        public string Reason { get; set; }
        public string Permanent { get; set; }
    }
}