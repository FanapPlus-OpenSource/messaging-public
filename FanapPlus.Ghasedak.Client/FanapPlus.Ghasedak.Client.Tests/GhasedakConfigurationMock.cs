using FanapPlus.Ghasedak.Client.Models;

namespace FanapPlus.Ghasedak.Client.Tests
{
    public class ProductGhasedakConfiguration: IGhasedakConfiguration {
        public string BaseUrl =>
            "https://xcp.appson.ir";
    }
}