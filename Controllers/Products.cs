using dotnet_101.DTOs;
using dotnet_101.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_101.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            var dtos = products.Select(p => new ProductDto(p.Id,p.Name,p.Price,p.Category.Name));
            
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var p = await _productRepository.GetByIdAsync(id);
            
            if(p is null) return NotFound();

            var dto = new ProductDto(p.Id,p.Name,p.Price,p.Category.Name);
            
            return Ok(dto);
        }
    
    }
}