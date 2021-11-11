using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace tmsang.application
{
    public interface IHubClient
    {
        Task BroadcastMessage(MessageInstance msg);
    }

    public class SignalrHub : Hub<IHubClient>
    {
        public async Task BroadcastMessage(MessageInstance msg)
        {
            await Clients.All.BroadcastMessage(msg);
        }
    }

    public class MessageInstance
    {
        public string Timestamp { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
    }
}
