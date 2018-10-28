using System;
using System.Collections.Generic;
using System.Linq;
using FanapPlus.Ghasedak.Client.Models.Exensions;
using FanapPlus.Ghasedak.Client.Models.Outgoing;
using FanapPlus.Ghasedak.Client.Models.Outgoing.InlineModels;

namespace FanapPlus.Ghasedak.Client.Models.Mappers
{
    public static class OutgoingBulkMessageMappers
    {
        internal static InlineGhasedakOutgoingBulkMessageRequest MapToInlineGhasedakOutgoingBulkMessageRequest(
            this GhasedakOutgoingBulkMessageRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var result = new InlineGhasedakOutgoingBulkMessageRequest
            {
                Date = request.Date.ToGhasedakFormatDateString(),
                Uid = request.Uid,
                Sid = request.Sid,
                ChannelType = request.ChannelType,
                Content = request.Content,
                MessageType = request.MessageType,
                Priority = request.Priority,
                ExpirationTime = request.ExpirationTime?.ToGhasedakFormatDateString(),
                Messages = request.Messages.ToInlineGhasedakContentBulkMessage()
            };

            if (request.Tags != null && request.Tags.Any())
            {
                result.Tags = request.Tags;
            }

            return result;
        }

        internal static IEnumerable<InlineGhasedakContentBulkMessage> ToInlineGhasedakContentBulkMessage(
            this IEnumerable<GhasedakContentBulkMessage> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            return items.Select(item => item.ToInlineGhasedakContentBulkMessage()).ToList();
        }

        internal static InlineGhasedakContentBulkMessage ToInlineGhasedakContentBulkMessage(
            this GhasedakContentBulkMessage item)
        {
            return new InlineGhasedakContentBulkMessage
            {
                AccountId = item.AccountId
            };
        }
    }
}