

using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.ExternalServices;
using Services.Interfaces;
using Services.PaginationHelpers;

namespace Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly StoreContext _context;

        public readonly ImageService _imageService;
        private readonly IMapper _mapper;

        public ProductService(StoreContext context, IMapper mapper,ImageService imageService)
        {
            _imageService=imageService;
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagedList<Product>> GetAllAsync(ProductParams productParams)
        {
            var query = _context.Products
                .Filter(productParams.Brands, productParams.Types)
                .Search(productParams.SearchTerm)
                .Sort(productParams.OrderBy)
                .AsQueryable();
            return await PagedList<Product>.ToPagedList(query, productParams.PageNumber, productParams.PageSize);
        }
        public async Task<List<string>> GetBrands()
        {
            return await _context.Products
                .Select(p => p.Brand).Distinct().ToListAsync();
        }
        public async Task<List<string>> GetTypes()
        {
            return await _context.Products
                .Select(p => p.Type).Distinct().ToListAsync();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .FindAsync(id);
        }

        public async Task<(Product, bool)> CreateProductAsync(CreateProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            
            if (productDTO.File != null)
            {
                var imageResult = await _imageService.AddImageAsync(productDTO.File);
                //if (imageResult.Error != null) 
                //    return BadRequest(new ProblemDetails{Title = imageResult.Error.Message});
                product.PictureUrl = imageResult.SecureUrl.ToString();
                product.PublicId = imageResult.PublicId;
            }

            await _context.Products.AddAsync(product);
            var result = await _context.SaveChangesAsync() > 0;
            return (product, result);
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDTO productDTO, Product product)
        {
            _mapper.Map(productDTO, product);
            if (productDTO.File != null) 
            {
                var imageResult = await _imageService.AddImageAsync(productDTO.File);

                // if (imageResult.Error != null) 
                //     return BadRequest(new ProblemDetails{Title = imageResult.Error.Message});

                    if (!string.IsNullOrEmpty(product.PublicId)) await _imageService.DeleteImageAsync(product.PublicId);
                
                product.PictureUrl = imageResult.SecureUrl.ToString();
                product.PublicId = imageResult.PublicId;

            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveProductAsync(Product product)
        {
            _context.Products.Remove(product);
            
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Product>> GetProductsAsync(List<OrderItem> items)
        {
            return await _context.Products
            .Join(items,
                product => product.Id,
                item => item.ItemOrdered.ProductId,
                (product, item) => product)//za ocuvanje redosleda
            .ToListAsync();
        }
    }
}
