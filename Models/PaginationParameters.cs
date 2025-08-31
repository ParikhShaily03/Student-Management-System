

namespace Student_Management_System.Models
{
    public class PaginationParameters
    {
        public string? SortField { get; set; }
        public string? SortOrder { get; set; } = "asc"; // "asc" or "desc"
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public List<ColumnFilter>? Filters { get; set; }
        public string SearchTerm { get; set; }
    }

    

    public class ColumnFilter
    {
        public string ColumnName { get; set; }
        public string FilterValue { get; set; }
        public string Operator { get; set; } = "contains"; // can be "equals", "contains", "startsWith", "endsWith"
    }


}
