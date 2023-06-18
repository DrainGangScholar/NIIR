using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Services.PaginationHelpers
{
    public static class ProductPagination
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> query, string orderBy)
        {
            return query = orderBy switch
            {
                "price" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name)
            };
        }
        public static IQueryable<Product> Search(this IQueryable<Product> query, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return query;
            return query.Where(p => p.Name.ToLower().Contains(searchTerm.Trim().ToLower()));
        }
        public static IQueryable<Product> Filter(this IQueryable<Product> query, string brands, string types)
        {
            var brandList = new List<String>();
            var typeList = new List<String>();
            if (!string.IsNullOrWhiteSpace(brands))
                brandList.AddRange(brands.ToLower().Split(',').ToList());
            if (!string.IsNullOrWhiteSpace(types))
                typeList.AddRange(types.ToLower().Split(',').ToList());
            query = query.Where(p => brandList.Count == 0 || p.QuantityInStock == 0 || brandList.Contains(p.Brand.ToLower()));
            query = query.Where(p => typeList.Count == 0 || p.QuantityInStock == 0 || typeList.Contains(p.Type.ToLower()));
            return query;
        }
    }
}