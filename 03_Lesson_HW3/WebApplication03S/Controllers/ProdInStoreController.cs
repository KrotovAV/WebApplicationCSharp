using Microsoft.AspNetCore.Mvc;
using WebApplication03HW3.Abstraction;
using WebApplication03HW3.Models;
using WebApplication03HW3.Models.DTO;
using WebApplication03HW3.Products;
using WebApplication03HW3.Repo;
using WebApplication03HW3.Stores;

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
        //----------------------------
        [HttpPost("order_prod_from_store")]
        public async Task<ActionResult> OrderProdFromStore(int prodId, int storeId, int count)
        {
            var prodExistTask = new ProductClient().Exists(prodId);
            var storeExistTask = new StoreClient().Exists(storeId);

            var prodExist = await prodExistTask;
            var storeExist = await storeExistTask;

            if (!prodExist)
                return StatusCode(500);// "Product not found!" ;
            if (!storeExist)
                return StatusCode(500);// "Store not found!" };

            var result = _prodInStoreRepository.OrderProdFromStore(prodId, storeId, count);
            if (result == false)
                return StatusCode(500);
            return Ok($"Order done");
        }


        //----------------
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
