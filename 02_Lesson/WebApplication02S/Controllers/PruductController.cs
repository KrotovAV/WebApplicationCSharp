using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;
using WebApplication02S.Abstraction;
using WebApplication02S.Models;
using WebApplication02S.Models.DTO;

namespace WebApplication01S.Controllers
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
        //----
        [HttpGet("GetProducts")]
        public ActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();
            return Ok(products);
        }
        [HttpPut("AddProduct")]
        public ActionResult AddProduct([FromBody] ProductDto productDto)
        {
            int idProduct = _productRepository.AddProduct(productDto);
            return Ok(idProduct);
        }
        [HttpDelete("DeleteProduct")]
        public ActionResult DeleteProduct(int id)
        {
            var res = _productRepository.DeleteProduct(id);
            if (res == false)
                return StatusCode(500);
            return Ok($"Delete ok! id = {id}");
        }

        [HttpPut("AddProductCost")]
        public ActionResult AddProductCost(int id, int cost)
        {
            bool result = _productRepository.AddProductCost(id, cost);
            if (result == false)
                return StatusCode(500);
            return Ok($"Add price ok! id = {id}, price = {cost}");
        }



        //----------------
        //**************************************
        //[HttpGet("get_products")]
        //public IActionResult GetProducts2()
        //{
        //    var products = _productRepository.GetProducts();
        //    return Ok(products);
        //}

        //[HttpGet("get_groups")]
        //public IActionResult GetGroups()
        //{
        //    var groups = _productRepository.GetGroups();
        //    return Ok(groups);
        //}

        //[HttpPost("add_product")]
        //public IActionResult AddProduct2([FromBody] ProductDto productDto)
        //{
        //    var result = _productRepository.AddProduct(productDto);
        //    return Ok(result);
        //}

        //[HttpPost("add_group")]
        //public IActionResult AddGroup([FromBody] GroupDto groupDto)
        //{
        //    var result = _productRepository.AddGroup(groupDto);
        //    return Ok(result);
        //}

        //**************************************





    }
}
