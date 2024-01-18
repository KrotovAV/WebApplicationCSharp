using Microsoft.AspNetCore.Mvc;
using WebApplication02S.Abstraction;
using WebApplication02S.Models;
using WebApplication02S.Models.DTO;
using WebApplication02S.Repo;

namespace WebApplication01S.Controllers 
{

    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        //-------------
        private readonly IGroupRepository _groupRepository;
       
        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [HttpGet("GetGroups")]
        public ActionResult GetGroups()
        {
            var res = _groupRepository.GetGroups();
            return Ok(res);
        }

        [HttpPut("AddGroup")]
        public ActionResult AddGroup([FromBody] GroupDto categoryDTO)
        {
            var res = _groupRepository.AddGroup(categoryDTO);
            return Ok($"Test Add {res}!");
        }

        [HttpDelete("DeleteGroup")]
        public ActionResult DeleteGroup(int id)
        {
            var res = _groupRepository.DeleteGroup(id);
            if (res == false)
                return StatusCode(500);
            return Ok($"Delete ok! id = {id}");
        }
        //*********************

        [HttpGet("get_groups")]
        public IActionResult GetGroups2()
        {
            var groups = _groupRepository.GetGroups();
            return Ok(groups);
        }

        [HttpPost("add_group")]
        public IActionResult AddGroup2([FromBody] GroupDto groupDto)
        {
            var result = _groupRepository.AddGroup(groupDto);
            return Ok(result);
        }

        //***********************






        //----------
        //[HttpPost("addGroup")]
        //public IActionResult AddGroup([FromQuery] string name)
        //{
        //    try
        //    {
        //        using (var context = new ProductContext())
        //        {
        //            if (!context.Groups.Any(x => x.Name.ToLower().Equals(name)))
        //            {
        //                context.Add(new Group()
        //                {
        //                    Name = name

        //                });
        //                context.SaveChanges();
        //                return Ok();
        //            }

        //            return StatusCode(409);

        //        }
        //    }
        //    catch
        //    {
        //        return StatusCode(500);
        //    }
        //}

        //[HttpDelete("deleteGroup")]
        //public IActionResult DeleteGroup([FromQuery] int id)
        //{
        //    try
        //    {
        //        using (var context = new ProductContext())
        //        {
        //            if (!context.Groups.Any(x => x.Id == id))
        //            {
        //                return NotFound();
        //            }

        //            Group product = context.Groups.FirstOrDefault(x => x.Id == id)!;
        //            context.Groups.Remove(product);
        //            context.SaveChanges();

        //            return Ok();
        //        }
        //    }
        //    catch
        //    {
        //        return StatusCode(500);
        //    }
        //}
    }
}
