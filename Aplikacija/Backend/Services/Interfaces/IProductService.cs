using Core.Entities;
using Core.Entities.OrderAggregate;
using Services.DTO;
using Services.PaginationHelpers;

namespace Services.Interfaces
{
    public interface IProductService
    {
        public Task<PagedList<Product>> GetAllAsync(ProductParams productParams);
        public Task<Product> GetByIdAsync(int id);
        public Task<(Product, bool)> CreateProductAsync(CreateProductDTO productDTO);
        public Task<List<string>> GetTypes();
        public Task<List<string>> GetBrands();
        public Task<bool> UpdateProductAsync(UpdateProductDTO productDTO, Product product);
        public Task<bool> RemoveProductAsync(Product product);
        Task<List<Product>> GetProductsAsync(List<OrderItem> items);
    }
}