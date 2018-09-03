using System;

namespace FanapPlus.Ghasedak.Client.Models.Exensions
{
    public static class DateTimeExtensions
    {
        public static string ToGhasedakFormatDateString(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }
    }
}
