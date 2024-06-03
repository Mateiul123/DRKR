using Microsoft.AspNet.SignalR;

namespace DRKR
{
    public class NotificationHub : Hub
    {
        public static void Send(string message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.displayNotification(message);
        }
    }
}
