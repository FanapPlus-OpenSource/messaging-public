using System;
using System.Collections.Generic;
using System.Text;
using FanapPlus.Ghasedak.Client.Models.Exensions;
using FanapPlus.Ghasedak.Client.Models.Outgoing;
using FanapPlus.Ghasedak.Client.Models.Outgoing.InlineModels;

namespace FanapPlus.Ghasedak.Client.Models.Mappers
{
    public static class OutgoingMessageMappers
    {
        internal static InlineGhasedakOutgoingMessageRequest MapToInlineGhasedakOutgoingMessageRequest(
            this GhasedakOutgoingMessageRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return new InlineGhasedakOutgoingMessageRequest
            {
                Date = request.Date.ToGhasedakFormatDateString(),
                Uid = request.Uid,
                Messages = request.Messages.ToInlineGhasedakContentMessage(),
            };
        }

        internal static IEnumerable<InlineGhasedakContentMessage> ToInlineGhasedakContentMessage(
            this IEnumerable<GhasedakContentMessage> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            var list = new List<InlineGhasedakContentMessage>();

            foreach (var item in items)
            {
                list.Add(item.ToInlineGhasedakContentMessage());
            }

            return list;
        }

        internal static InlineGhasedakContentMessage ToInlineGhasedakContentMessage(
            this GhasedakContentMessage item)
        {
            return new InlineGhasedakContentMessage
            {
                Sid = item.Sid,
                AccountId = item.AccountId,
                ChannelType = item.ChannelType,
                Content = item.Content,
                MessageType = item.MessageType,
                Priority = item.Priority,
                ReplyTo = item.ReplyTo
            };
        }
    }
}
