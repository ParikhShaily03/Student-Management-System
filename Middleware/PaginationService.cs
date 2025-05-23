using Microsoft.EntityFrameworkCore;
using Student_Management_System.Model;
using Student_Management_System.Models;
using Student_Management_System.Models.DTOs;
using System.Linq.Dynamic.Core;


namespace Student_Management_System.Middleware
{
    public class PaginationService<T> where T : class
    {
        private readonly IQueryable<T> _query;

        public PaginationService(IQueryable<T> query)
        {
            _query = query;
        }

        public async Task<Student_Management_System.Models.DTOs.PagedResult<T>> ApplyPaginationAsync(PaginationParameters paginationParameters, string search = "")
        {
            // Apply search filter if provided
            var filteredQuery = ApplySearch(_query, search);

            // Get total count before pagination
            int totalCount = await filteredQuery.CountAsync();

            // Apply sorting
            var sortedQuery = ApplySorting(filteredQuery, paginationParameters.SortField, paginationParameters.SortOrder);

            // Apply pagination
            var paginatedItems = await ApplyPagination(sortedQuery, paginationParameters.PageNumber, paginationParameters.PageSize)
                .ToListAsync();

            return new Student_Management_System.Models.DTOs.PagedResult<T>
            {
                Items = paginatedItems,
                TotalCount = totalCount
            };
        }

        private IQueryable<T> ApplySearch(IQueryable<T> query, string search)
        {
            if (string.IsNullOrEmpty(search)) return query;

            search = search.ToLower();

            // This is a simplified version - you'll need to customize this based on your entity properties
            // For more complex scenarios, consider using Dynamic LINQ or System.Linq.Dynamic.Core
            if (typeof(T) == typeof(User))
            {
                var userQuery = query as IQueryable<User>;
                return (IQueryable<T>)userQuery.Where(u =>
                    u.Name.ToLower().Contains(search) ||
                    u.Email.ToLower().Contains(search) ||
                    u.Department.ToLower().Contains(search) ||
                    u.UserName.ToLower().Contains(search)
                );
            }

            // Default behavior if no specific type handling
            return query;
        }

        private IQueryable<T> ApplySorting(IQueryable<T> query, string sortField, string sortOrder)
        {
            if (string.IsNullOrEmpty(sortField)) return query;

            // Determine sort direction
            var isDescending = sortOrder?.ToLower() == "desc";
            var direction = isDescending ? "DESC" : "ASC";

            // Use Dynamic LINQ for sorting
            try
            {
                return query.OrderBy($"{sortField} {direction}");
            }
            catch
            {
                // Fallback to no sorting if the field is invalid
                return query;
            }
        }

        private IQueryable<T> ApplyPagination(IQueryable<T> query, int pageNumber, int pageSize)
        {
            // Ensure valid page values
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            return query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
