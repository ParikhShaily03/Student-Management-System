using System.Collections.Generic;

namespace Student_Management_System.Models.DTOs
{
    public class PagedResult<T>
    {

        public IEnumerable<T> Items { get; set; }  // List of paginated items
        public int TotalCount { get; set; }  // Total number of records in DB
    }
}
