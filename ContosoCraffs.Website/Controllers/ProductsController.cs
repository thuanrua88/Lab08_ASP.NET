//Video 8
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCraffs.Website.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ContosoCraffs.Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductSevice = productService;
        }

        public JsonFileProductService ProductSevice { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductSevice.GetProducts();
        }

        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string productId, [FromQuery] int rating)
        {
            ProductSevice.AddRating(productId, rating);
            return Ok();
        }
    }
}
