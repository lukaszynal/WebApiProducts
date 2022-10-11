using WebApiProducts.Models;

namespace WebApiProducts.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> productItems = new List<Product>();

        public List<Product> GetProducts()
        {
            return this.productItems;
        }

        public Product GetProduct(string id)
        {
            int productIndex = this.productItems.FindIndex(p => string.CompareOrdinal(p.Id, id) == 0);
            if (productIndex >= 0)
            {
                return this.productItems[productIndex];
            }

            throw new Exception($"Product with id='{id}' is not found.");
        }

        public Product AddProduct(Product productItem)
        {
            this.productItems.Add(productItem);
            return productItem;
        }

        public string DeleteProduct(string id)
        {
            int productIndex = this.productItems.FindIndex(p => string.CompareOrdinal(p.Id, id) == 0);
            if (productIndex >= 0)
            {
                this.productItems.RemoveAt(productIndex);
            }

            return id;
        }

        public Product UpdateProduct(string id, Product productItem)
        {
            int productIndex = this.productItems.FindIndex(p => string.CompareOrdinal(p.Id, id) == 0);
            if (productIndex >= 0)
            {
                this.productItems[productIndex] = productItem;
            }

            return productItem;
        }
    }
}
