using API.Dtos;
using AutoMapper;
using AutoMapper.Execution;
using Core.Entities;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDtos, string>

    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }


        
        public string Resolve(Product source, ProductToReturnDtos destination, string destMember, ResolutionContext context)
        {
           if(source.PictureUrl != null)
           {
            return _config["ApiUrl"] + source.PictureUrl;
           }

           return null;
        }

    }
}