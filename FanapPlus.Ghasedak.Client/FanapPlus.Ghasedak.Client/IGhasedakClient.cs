using System.Threading.Tasks;
using FanapPlus.Ghasedak.Client.Models;
using FanapPlus.Ghasedak.Client.Models.Outgoing;

namespace FanapPlus.Ghasedak.Client
{
    public interface IGhasedakClient
    {
        Task<GhasedakSendResponse> SendAsync(GhasedakOutgoingMessageRequest message, GhasedakOptions options);
        Task<GhasedakSendResponse> SendAsync(GhasedakOutgoingMessageRequest message, string privateKey);
        Task<GhasedakSendResponse> SendAsync(GhasedakOutgoingBulkMessageRequest message, GhasedakOptions options);
        Task<GhasedakSendResponse> SendAsync(GhasedakOutgoingBulkMessageRequest message, string privateKey);
    }
}