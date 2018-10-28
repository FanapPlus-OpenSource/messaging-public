using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ServiceStack.Text;

namespace FanapPlus.Ghasedak.Client.Models.Exensions
{
    internal static class HttpContextExtensions
    {
        internal static HttpContent CreateContent<T>(this T message)
        {
            var serializer = new JsonSerializer<T>();

            var content = new StringContent(serializer.SerializeToString(message), Encoding.UTF8, "application/json");

            return content;
        }
    }
}
