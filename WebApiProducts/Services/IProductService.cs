using WebApiProducts.Models;

namespace WebApiProducts.Services
{
    public interface IProductService
    {
        public List<Product> GetProducts();

        public Product GetProduct(string id);

        public Product AddProduct(Product productItem);

        public string DeleteProduct(string id);

        public Product UpdateProduct(string id, Product productItem);
    }
}
