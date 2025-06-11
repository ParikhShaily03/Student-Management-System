using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Hubs;
using Student_Management_System.Models;
using System;
using System.Threading.Tasks;


namespace Student_Management_System.Service
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string userId, string title, string message);
    }

    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(ApplicationDbContext context, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task SendNotificationAsync(string userId, string title, string message)
        {
            // Save to DB
            var notification = new Notification
            {
                UserId = userId,
                Title = title,
                Message = message,
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();

            // Push via SignalR
            await _hubContext.Clients.User(userId).SendAsync("ReceiveNotification", new
            {
                Title = title,
                Message = message,
                CreatedAt = notification.CreatedAt
            });
        }
    
}
}
