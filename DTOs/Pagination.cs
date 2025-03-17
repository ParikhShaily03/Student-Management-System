using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public class PaginationParameters
    {
        private int _pageSize = 5;

        public int PageNumber { get; set; } = 1;

        // Limit the maximum page size to 10.
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > 10 ? 10 : value);
        }
    }

    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}

