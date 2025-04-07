

namespace Student_Management_System.Models
{
    public class PaginationParameters
    {
        public string? SortField { get; set; }
        public string? SortOrder { get; set; } = "asc"; // "asc" or "desc"
        public int PageNumber { get; set; } = 1;  // Default Page Number
        public int PageSize { get; set; } = 10;   // Default Page Size (10 items per page)
    }
}
