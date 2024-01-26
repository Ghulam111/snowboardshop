using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext)
        {
            if (!storeContext.ProductBrands.Any())
            {
                var brandsdata = File.ReadAllText("../Infrastructure/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);
                storeContext.ProductBrands.AddRange(brands);

            }
            if (!storeContext.ProductTypes.Any())
            {
                var typesdata = File.ReadAllText("../Infrastructure/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);
                storeContext.ProductTypes.AddRange(types);

            }
            if (!storeContext.Products.Any())
            {
                var productsdata = File.ReadAllText("../Infrastructure/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsdata);
                storeContext.Products.AddRange(products);

            }

            if (storeContext.ChangeTracker.HasChanges()) await storeContext.SaveChangesAsync();

        }
    }
}