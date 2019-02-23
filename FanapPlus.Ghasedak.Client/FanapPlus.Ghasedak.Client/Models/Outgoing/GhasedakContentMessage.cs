using System;
using System.Collections.Generic;

namespace FanapPlus.Ghasedak.Client.Models.Outgoing
{
    public class GhasedakContentMessage
    {
        public GhasedakContentMessage()
        {
            Tags = new List<string>();
        }
        public string Sid { get; set; }
        public string AccountId { get; set; }
        public string Content { get; set; }
        public MessageType MessageType { get; set; }
        public ChannelType ChannelType { get; set; }
        public MessagePriority Priority { get; set; }
        public DateTime? ExpirationTime { get; set; }
        public string ReplyTo { get; set; }
        public List<string> Tags { get; set; }
        public string UserPhoneNumber { get; set; }
        public string AppId { get; internal set; }
    }
}