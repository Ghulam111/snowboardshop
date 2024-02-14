using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductToReturnDtos>()
            .ForMember(u => u.ProductBrand, o=> o.MapFrom( s=> s.ProductBrand.Name))
            .ForMember(u => u.ProductType, o=> o.MapFrom( s=> s.ProductType.Name))
            .ForMember( u => u.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }

    }
}