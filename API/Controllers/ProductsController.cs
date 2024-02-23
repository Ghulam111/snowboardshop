using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http.HttpResults;
using API.Dtos;
using AutoMapper;
using API.Helpers;

namespace API.Controllers
{
   
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _prductBrandRepo;
        private readonly IGenericRepository<ProductType> _prodctTypeRepo;
        private readonly IMapper _mapper;
        
        public ProductsController(IGenericRepository<Product> productsRepo,IGenericRepository<ProductBrand> prductBrandRepo,
         IGenericRepository<ProductType> prodctTypeRepo, IMapper mapper)
        {
            _mapper = mapper;
            _prodctTypeRepo = prodctTypeRepo;
            _prductBrandRepo = prductBrandRepo;
            _productsRepo = productsRepo;
            
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDtos>>> GetProducts(
            [FromQuery]ProductSpecParams productParams)
        {
            var spec  = new ProductsWithTypesAndBrandsSpecifications(productParams);

            var countSpec = new ProductWithFiltersforCountSpecification(productParams);

            var totalItems = await _productsRepo.CountAsync(countSpec);

            var productslist = await _productsRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDtos>>(productslist);

            return Ok( new Pagination<ProductToReturnDtos>(productParams.pageIndex,productParams.PageSize,totalItems,data));
            
       

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDtos>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecifications(id);

           var productItem = await  _productsRepo.GetEntitybySpec(spec);

           return _mapper.Map<Product,ProductToReturnDtos>(productItem);
           
        //     new ProductToReturnDtos
        //    {
        //     Id  = productItem.Id,
        //     Name = productItem.Name,
        //     Description = productItem.Description,
        //     Price = productItem.Price,
        //     PictureUrl = productItem.PictureUrl,
        //     ProductType = productItem.ProductType.Name,
        //     ProductBrand = productItem.ProductBrand.Name

        //    };

        //    return Ok(productItem);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _prductBrandRepo.GetAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _prodctTypeRepo.GetAllAsync());
        }
    }
}