using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Controllers
{
    [Route("api/[controller]")] // baseUrl/api/Product
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            return new Product { Id = id };
        }

        [HttpGet]
        public ActionResult<Product> GetAll()
        {
            return new Product { Id = 10 };
        }

        [HttpPost("static")]
        public ActionResult<Product> AddProduct(Product product)
        {
            return new Product();
        }

        [HttpPost]
        public ActionResult<Product> AddProduct02(Product product)
        {
            return new Product();
        }

        [HttpPut]
        public ActionResult<Product> UpdateProduct(Product product)
        {
            return new Product();
        }

        [HttpDelete]
        public ActionResult<Product> DeleteProduct(Product product)
        {
            return new Product();
        }
    }
}
