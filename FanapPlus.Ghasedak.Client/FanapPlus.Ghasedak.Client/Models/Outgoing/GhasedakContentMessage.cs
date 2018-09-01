namespace FanapPlus.Ghasedak.Client.Models.Outgoing
{
    public class GhasedakContentMessage
    {
        public string Sid { get; set; }
        public string AccountId { get; set; }
        public string Content { get; set; }
        public MessageType MessageType { get; set; }
        public ChannelType ChannelType { get; set; }
        public MessagePriority Priority { get; set; }
        public string ReplyTo { get; set; }
        public string Signature { get; set; }
    }
}