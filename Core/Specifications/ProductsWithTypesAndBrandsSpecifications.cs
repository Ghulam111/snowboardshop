using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecifications : ConcreteSpecifications<Product>
    {
        public ProductsWithTypesAndBrandsSpecifications(ProductSpecParams productParams)
        :base (x => 
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
        (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) && 
        (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
        )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderby(x => x.Name);
            ApplyPagging(productParams.PageSize *(productParams.pageIndex -1),productParams.PageSize);
            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case  "priceAsc":
                    AddOrderby(x => x.Price);
                    break;

                    case "priceDesc":
                    AddOrderbyDescending(x => x.Price);
                    break;

                    default:
                    AddOrderby( n => n.Name);
                    break;
                }
            }
            
        }

        public ProductsWithTypesAndBrandsSpecifications(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}