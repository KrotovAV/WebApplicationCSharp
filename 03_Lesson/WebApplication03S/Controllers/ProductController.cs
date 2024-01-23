
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;

using WebApplication03S.Models;
using WebApplication03S.Models.DTO;
using WebApplication03S.Abstraction;
using Microsoft.Extensions.Caching.Memory;

namespace WebApplication03S.Controllers
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

        //3-----

        [HttpGet("get_stores")]
        public IActionResult GetStores()
        {
            var stores = _productRepository.GetStores();
            return Ok(stores);
        }

        [HttpPost("add_store")]
        public IActionResult AddStore([FromBody] StoreDto storeDto)
        {
            var result = _productRepository.AddStore(storeDto);
            return Ok(result);
        }

        [HttpDelete("delete_store")]
        public ActionResult Deletestore(int id)
        {
            var res = _productRepository.DeleteStore(id);
            if (res == false)
                return StatusCode(500);
            return Ok($"Delete ok! id = {id}");
        }

        //3----


        //[HttpGet("get_products_CSV")]
        //public FileContentResult GetCSV()
        //{
        //    var content = _productRepository.GetProductsCSV();

        //    return File(new System.Text.UTF8Encoding().GetBytes(content), "text/csv", "Products.csv");
        //}

        //[HttpGet("get_cache_CSV_Url")]
        //public ActionResult<string> GetCacheCSVUrl()
        //{
        //    var result = _productRepository.GetСacheStatCSV();

        //    if (result is not null)
        //    {
        //        var fileName = $"products{DateTime.Now.ToBinary()}.csv";

        //        System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", fileName), result);

        //        return "https://" + Request.Host.ToString() + "/static/" + fileName;
        //    }

        //    return StatusCode(500);
        //}

    }
}
