using Microsoft.AspNetCore.Mvc;
using WebApplication03HW3.Abstraction;
using WebApplication03HW3.Models.DTO;
using WebApplication03HW3.Repo;

namespace WebApplication03HW3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdInStoreController : ControllerBase
    {

        private readonly IProdInStoreRepository _prodInStoreRepository;

        public ProdInStoreController(IProdInStoreRepository prodInStoreRepository)
        {
            _prodInStoreRepository = prodInStoreRepository;
        }

        [HttpGet("get_records")]
        public IActionResult GetRecords()
        {
            var stores = _prodInStoreRepository.GetRecords();
            return Ok(stores);
        }

        [HttpPost("add_record")]
        public IActionResult AddRecord([FromBody] ProdInStoreDto record)
        {
            var result = _prodInStoreRepository.AddRecord(record);
            return Ok(result);
        }

        [HttpDelete("delete_records")]
        public ActionResult DeleteRecord(int id)
        {
            var res = _prodInStoreRepository.DeleteRecord(id);
            if (res == false)
                return StatusCode(500);
            return Ok($"Delete ok! id = {id}");
        }


    }
}
