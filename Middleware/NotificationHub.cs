using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Student_Management_System.Hubs
{
    public class NotificationHub : Hub
    {
        // Send notification to a specific user
        public async Task SendNotification(string userId, string message)
        {
            await Clients.User(userId).SendAsync("ReceiveNotification", message);
        }

      
    }
}
