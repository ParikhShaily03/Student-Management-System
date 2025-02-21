using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public  class ApiLogger
    {
        private static readonly ConcurrentQueue<string> _logs = new();
        public int Id { get; set; }  // ✅ Primary Key
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public static void Log(string message)
        {
            var logEntry = $"{DateTime.UtcNow}: {message}";
            _logs.Enqueue(logEntry);
        }

        public static IEnumerable<string> GetLogs()
        {
            return _logs.ToArray();
        }
    }
}
