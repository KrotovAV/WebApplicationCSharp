
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;

using WebApplication03HW.Models;
using WebApplication03HW.Models.DTO;
using WebApplication03HW.Abstraction;
using Microsoft.Extensions.Caching.Memory;

namespace WebApplication03HW.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("get_products")]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpPost("add_product")]
        public IActionResult AddProduct([FromBody] ProductDto productDto)
        {
            var result = _productRepository.AddProduct(productDto);
            return Ok(result);
        }

        [HttpDelete("delete_product")]
        public ActionResult DeleteProduct(int id)
        {
            var res = _productRepository.DeleteProduct(id);
            if (res == false)
                return StatusCode(500);
            return Ok($"Delete ok! id = {id}");
        }

        [HttpGet("get_groups")]
        public IActionResult GetGroups()
        {
            var groups = _productRepository.GetGroups();
            return Ok(groups);
        }

        [HttpPost("add_group")]
        public IActionResult AddGroup([FromBody] GroupDto groupDto)
        {
            var result = _productRepository.AddGroup(groupDto);
            return Ok(result);
        }

        [HttpDelete("delete_group")]
        public ActionResult DeleteGroup(int id)
        {
            var res = _productRepository.DeleteGroup(id);
            if (res == false)
                return StatusCode(500);
            return Ok($"Delete ok! id = {id}");
        }


    }
}
