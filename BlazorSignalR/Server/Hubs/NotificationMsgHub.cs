using BlazorSignalR.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalR.Server.Hubs
{
    public class NotificationMsgHub : Hub
    {
        public async Task SenNotificationMsg()
        {
            await Clients.All.SendAsync("ReceiveNotificationMsg");
        }

        public async Task SenNotificationType(NotificationType type)
        {
            await Clients.All.SendAsync("ReceiveNotificationType", type);
        }
    }
}
