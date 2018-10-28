using System;
using System.Collections.Generic;
using System.Text;
using FanapPlus.Ghasedak.Client.Models.Incoming;

namespace FanapPlus.Ghasedak.Client.Models.Exensions
{
    public static class GhasedakDeliveryMessageExtensions
    {
        public static bool IsPermanent(this GhasedakDeliveryMessage delivery)
        {
            bool.TryParse(delivery.Permanent, out var result);
            return result;
        }
    }
}
