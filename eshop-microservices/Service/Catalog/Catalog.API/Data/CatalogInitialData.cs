using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            // Marten UPSERT will cater for existing records
            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
        {
            new Product()
            {
                Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                Name = "IPhone X",
                Category = new List<string> { "Smart Phone" },
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-1.png",
                Price = 950.00M
            },
            new Product()
            {
                Id = new Guid("da2fd609-d754-4feb-8acd-c4aaea68eeb9"),
                Name = "Samsung Galaxy S10",
                Category = new List<string> { "Smart Phone" },
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-2.png",
                Price = 900.00M
            },
            new Product()
            {
                Id = new Guid("2902c7ee-54b3-4225-9666-681fd832cde5"),
                Name = "Huawei Mate 20 Pro",
                Category = new List<string> { "Smart Phone" },
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-3.png",
                Price = 850.00M
            },
            new Product()
            {
                Id = new Guid("c74c10b3-0ee5-4a1b-a0f2-9c47e9e9b1f5"),
                Name = "Apple Airpods",
                Category = new List<string> { "Accessories" },
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-4.png",
                Price = 150.00M
            },
            new Product()
            {
                Id = new Guid("6fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Name = "Apple Watch Series 4",
                Category = new List<string> { "Accessories" },
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-5.png",
                Price = 350.00M
            },
            new Product()
            {
                Id = new Guid("7fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Name = "Samsung Galaxy Watch",
                Category = new List<string> { "Accessories" },
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                ImageFile = "product-6.png",
                Price = 300.00M
            }
        };
    }
}

