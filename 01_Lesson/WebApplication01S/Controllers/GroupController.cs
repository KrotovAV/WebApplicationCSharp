using Microsoft.AspNetCore.Mvc;
using WebApplication01S.Models;

namespace WebApplication01S.Controllers 
{

    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        [HttpPost("addGroup")]
        public IActionResult AddGroup([FromQuery] string name)
        {
            try
            {
                using (var context = new ProductContext())
                {
                    if (!context.Group.Any(x => x.Name.ToLower().Equals(name)))
                    {
                        context.Add(new Group()
                        {
                            Name = name

                        });
                        context.SaveChanges();
                        return Ok();
                    }

                    return StatusCode(409);

                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("deleteGroup")]
        public IActionResult DeleteGroup([FromQuery] int id)
        {
            try
            {
                using (var context = new ProductContext())
                {
                    if (!context.Group.Any(x => x.Id == id))
                    {
                        return NotFound();
                    }

                    Group product = context.Group.FirstOrDefault(x => x.Id == id)!;
                    context.Group.Remove(product);
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
