using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management_System.Service
{
    public interface IChatService
    {
        Task<ChatMessage> SendMessageAsync(string fromUserId, string toUserId, string message);
        Task<IEnumerable<ChatMessage>> GetMessagesAsync(string currentUserId, string otherUserId);
        Task<bool> MarkMessageAsReadAsync(int messageId, string currentUserId);
    }
    public class ChatService : IChatService
    {
        private readonly ApplicationDbContext _context;

        public ChatService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ChatMessage> SendMessageAsync(string fromUserId, string toUserId, string message)
        {
            var chatMessage = new ChatMessage
            {
                SenderId = fromUserId,
                ReceiverId = toUserId,
                Message = message,
                SentAt = DateTime.UtcNow,
                IsRead = false
            };

            _context.ChatMessages.Add(chatMessage);
            await _context.SaveChangesAsync();
            return chatMessage;
        }

        public async Task<IEnumerable<ChatMessage>> GetMessagesAsync(string currentUserId, string otherUserId)
        {
            return await _context.ChatMessages
                .Where(m =>
                    (m.SenderId == currentUserId && m.ReceiverId == otherUserId) ||
                    (m.SenderId == otherUserId && m.ReceiverId == currentUserId))
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

        public async Task<bool> MarkMessageAsReadAsync(int messageId, string currentUserId)
        {
            var message = await _context.ChatMessages.FindAsync(messageId);
            if (message == null || message.ReceiverId != currentUserId)
                return false;

            message.IsRead = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }

}