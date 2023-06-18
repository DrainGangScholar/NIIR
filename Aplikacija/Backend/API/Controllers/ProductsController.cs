using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Extensions;
using Services.Interfaces;
using Services.PaginationHelpers;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
 
        private readonly IProductService _service;
        
        private readonly IBasketService _basketService;

        public ProductsController(IProductService productService, IBasketService basketService)
        {
            _service = productService;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<Product>>> GetProducts([FromQuery] ProductParams productParams)
        {
            var products = await _service.GetAllAsync(productParams);

            if (products.Count == 0)
                return NotFound();

            Response.AddPaginationHeader(products.MetaData);

            return products;
        }
        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            var brands = await _service.GetBrands();

            var types = await _service.GetTypes();

            return Ok(new { brands, types });
        }
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null) return NotFound();

            return product;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromForm]CreateProductDTO productDTO)
        {
            var _result = await _service.CreateProductAsync(productDTO);

            var result = _result.Item2;

            var product = _result.Item1;

            if (result) return CreatedAtRoute("GetProduct", new { Id = product.Id }, product);

            return BadRequest(new ProblemDetails { Title = "Problem creating product" });
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult> UpdateProduct([FromForm]UpdateProductDTO productDTO)
        {
            var product = await _service.GetByIdAsync(productDTO.Id);

            if (product == null) return NotFound();

            var result = await _service.UpdateProductAsync(productDTO, product);

            if (result) return NoContent();

            return BadRequest(new ProblemDetails { Title = "Problem updating product" });
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null) return NotFound();

            var baskets = await _basketService.RemoveItemInBaskets(product);

            var result = await _service.RemoveProductAsync(product);

            if (result) return Ok();

            return BadRequest(new ProblemDetails { Title = "Problem deleting product" });

        }
    }
}
