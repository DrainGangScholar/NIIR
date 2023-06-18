using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.PaginationHelpers
{
    public class ProductParams : PaginationParams
    {
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public string Brands { get; set; }
        public string Types { get; set; }
    }
}