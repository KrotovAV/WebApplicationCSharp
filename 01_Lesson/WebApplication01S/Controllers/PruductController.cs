using Microsoft.AspNetCore.Mvc;
using WebApplication01S.Models;

namespace WebApplication01S.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class PruductController : ControllerBase
    {
    //**********
        
         [HttpGet("getProduct")]
         public IActionResult GetProducts()
         {
             try
             {
                 using (var context = new ProductContext())
                 {
                     var products = context.Products.Select(x => new Product()
                     {
                         Id = x.Id,
                         Name = x.Name,
                         Description = x.Description
                     });
                     return Ok(products);
                 }
             }
             catch
             {
                 return StatusCode(500);
             }            
         }
        
        [HttpPost("addProduct")]
        public ActionResult AddProduct(string name, string description, int groupId)
        {
            try
            {
                using (var context = new ProductContext())
                {
                    if (context.Products.Count(x => x.Name.ToLower() == name.ToLower()) > 0)
                    {
                        return StatusCode(409);
                    }
                    else
                    {
                        context.Products.Add(new Product { 
                            Name = name, 
                            Description = description, 
                            GroupId = groupId 
                        });
                        context.SaveChanges();
                    }
                }
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        
        [HttpPost("putProduct")]
        public IActionResult PutProducts([FromQuery] string name,string description, int groupId, int cost)
        {
            try
            {
                using (var context = new ProductContext())
                {
                    if (!context.Products.Any(x => x.Name.ToLower().Equals(name)))
                    {
                        context.Add(new Product()
                        {
                            Name = name,
                            Description = description,
                            Cost = cost,
                            GroupId = groupId
                            
                        });
                        context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(409);
                    }                        
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
        
     //*********

        //[HttpGet("getProduct")]
        //public IActionResult GetProducts([FromQuery] string name)
        ////public IActionResult GetProducts()
        //{
        //    try
        //    {

        //        using (var context = new ProductContext())
        //        {
        //            if (!context.Products.Any(x => x.Name.ToLower().Equals(name)))
        //            {
        //                var product = context.Products.Select(x => new Product()
        //                {
        //                    Id = x.Id,
        //                    Name = x.Name,
        //                    Description = x.Description
        //                });
        //                return Ok(product);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //            //var product = context.Products.Select(x => new Product()
        //            //{
        //            //    Id = x.Id,
        //            //    Name = x.Name,
        //            //    Description = x.Description
        //            //});
        //            //return Ok(product);
        //        }
        //    }
        //    catch
        //    {
        //        return StatusCode(500);
        //    }
        //}


        //[HttpPost("putProduct")]
        //public IActionResult PutProducts([FromQuery] string name, string description, int groupId, int cost)
        //{
        //    try
        //    {
        //        using (var context = new ProductContext())
        //        {
        //            if (!context.Products.Any(x => x.Name.ToLower().Equals(name)))
        //            {
        //                context.Add(new Product()
        //                {
        //                    Name = name,
        //                    Description = description,
        //                    Cost = cost,
        //                    GroupID = groupId
        //                });
        //                context.SaveChanges();
        //                return Ok();
        //            }
        //            else
        //            {
        //                return StatusCode(409);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        return StatusCode(500);
        //    }
        //}


        [HttpDelete("deleteProduct")]
        public IActionResult DeleteProduct([FromQuery] int id)
        {
            try
            {
                using (var context = new ProductContext())
                {
                    if (!context.Products.Any(x => x.Id == id))
                    {
                        return NotFound();
                    }

                    Product product = context.Products.FirstOrDefault(x => x.Id == id)!;
                    context.Products.Remove(product);
                    context.SaveChanges();

                    return Ok();
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("addProductPrice")]
        public IActionResult AddProductPrice([FromQuery] int id, int cost)
        {
            try
            {
                using (var context = new ProductContext())
                {
                    if (!context.Products.Any(x => x.Id == id))
                    {
                        return NotFound();
                    }

                    Product product = context.Products.FirstOrDefault(x => x.Id == id)!;
                    product.Cost = cost;
                    context.SaveChanges();

                    return Ok();
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
