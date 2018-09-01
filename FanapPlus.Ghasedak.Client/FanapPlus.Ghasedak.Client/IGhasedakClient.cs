using System.Threading.Tasks;
using FanapPlus.Ghasedak.Client.Models;
using FanapPlus.Ghasedak.Client.Models.Outgoing;

namespace FanapPlus.Ghasedak.Client
{
    public interface IGhasedakClient
    {
        Task<GhasedakSendResponse> Send(GhasedakOutgoingMessageRequest sendMessageRequest);
    }
}