using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helper
{
    public class QueryObjects
    {
        // Filtering parameters
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;

        // Sorting parameters
        public string? SortBy { get; set; } = null;
        // true for ascending, false for descending
        public bool IsSortAscending { get; set; } = false; 

        // Pagination parameters
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 2;
    }
}
