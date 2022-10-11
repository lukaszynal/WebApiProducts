using Microsoft.AspNetCore.Mvc;
using WebApiProducts.Models;
using WebApiProducts.Services;

namespace WebApiProducts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class ProductsController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IProductService productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        [HttpGet("/api/products")]
        public ActionResult<List<Product>> GetProducts()
        {
            return this.productService.GetProducts();
        }

        [HttpPost("/api/products")]
        public ActionResult<Product> AddProduct(Product product)
        {
            this.productService.AddProduct(product);
            return product;
        }

        [HttpGet("/api/products/{id}")]
        public ActionResult<Product> GetProduct(string id)
        {
            this.logger.LogInformation($"GetProduct({id})");

            try
            {
                var product = this.productService.GetProduct(id);
                this.logger.LogInformation($"GetProduct({id}) returned a product.", product);
                return product;
            }
            catch (Exception e)
            {
                this.logger.LogError("Unable to get product information", e);
                return this.StatusCode(404);
            }
        }

        [HttpDelete("/api/products/{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {
            this.productService.DeleteProduct(id);
            return id;
        }

        [HttpPut("/api/products/{id}")]
        public ActionResult<Product> UpdateProduct(string id, Product product)
        {
            this.productService.UpdateProduct(id, product);
            return product;
        }
    }

}
