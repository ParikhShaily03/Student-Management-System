// Controllers/ChatController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management_System.Data;
using Student_Management_System.Model;
using Student_Management_System.Models;
using Student_Management_System.Repositories.Irepositories;
using Student_Management_System.Service;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Student_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IUser<User> _userRepository;


        public ChatController(IChatService chatService, IUser<User> userRepository)
        {
            _chatService = chatService;
            _userRepository = userRepository;
        }

        [HttpGet("messages/{userId}")]
        public async Task<IActionResult> GetMessages(string userId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == null)
                return Unauthorized();

            var messages = await _chatService.GetMessagesAsync(currentUserId, userId);
            return Ok(messages);
        }

        [HttpPost("mark-read/{messageId}")]
        public async Task<IActionResult> MarkMessageAsRead(int messageId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = await _chatService.MarkMessageAsReadAsync(messageId, currentUserId);
            if (!success)
                return NotFound();

            return Ok(new { message = "Message marked as read." });
        }

        [HttpPost("messages")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto dto)
        {
            var fromUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (fromUserId == null)
                return Unauthorized();

            if (string.IsNullOrWhiteSpace(dto.ToUserId) || string.IsNullOrWhiteSpace(dto.Message))
                return BadRequest("Receiver ID and message are required.");

            var chatMessage = await _chatService.SendMessageAsync(fromUserId, dto.ToUserId, dto.Message);
            return Ok(chatMessage);
        }

        [HttpGet("contacts")]
        public async Task<IActionResult> GetChatContacts()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == null)
                return Unauthorized();

            var contacts = await _userRepository.GetChatContactsAsync(currentUserId);
            return Ok(new { users = contacts });
        }


    }

}
