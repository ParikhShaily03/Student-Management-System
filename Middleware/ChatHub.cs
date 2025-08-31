using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Student_Management_System.Service;

namespace Student_Management_System.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(string toUserId, string message)
        {
            var fromUserId = Context.UserIdentifier; // Uses the authenticated user's ID
            if (fromUserId == null) return;

            // Save message to DB
            var savedMessage = await _chatService.SendMessageAsync(fromUserId, toUserId, message);

            // Send the message to the receiver if connected
            await Clients.User(toUserId).SendAsync("ReceiveMessage", new
            {
                fromUserId = savedMessage.SenderId,
                message = savedMessage.Message,
                sentAt = savedMessage.SentAt
            });

            // Optionally, also send to the sender so they see their own message appear
            await Clients.User(fromUserId).SendAsync("ReceiveMessage", new
            {
                fromUserId = savedMessage.SenderId,
                message = savedMessage.Message,
                sentAt = savedMessage.SentAt
            });
        }
    }
}
