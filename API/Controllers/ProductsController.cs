using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _products;
        public ProductsController(IProductRepository products)
        {
            _products = products;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
          var productslist = await _products.GetProductsAsync();

          return Ok(productslist);
            

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
           var productItem = await  _products.GetProductbyIdAsync(id);

           return Ok(productItem);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _products.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _products.GetProductTypesAsync());
        }
    }
}