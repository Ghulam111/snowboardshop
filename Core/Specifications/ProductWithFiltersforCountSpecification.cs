using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersforCountSpecification : ConcreteSpecifications<Product>
    {
        public ProductWithFiltersforCountSpecification(ProductSpecParams productParams) : base(x =>
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower() == productParams.Search) &&
        (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
        (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
        )
        {
            
        }

    }
}