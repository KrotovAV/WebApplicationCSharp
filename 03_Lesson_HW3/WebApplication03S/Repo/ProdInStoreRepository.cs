using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using WebApplication03HW3.Abstraction;
using WebApplication03HW3.Models.DTO;
using WebApplication03HW3.Models;

namespace WebApplication03HW3.Repo
{
    public class ProdInStoreRepository : IProdInStoreRepository
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ProdInStoreRepository(IMapper mapper, IMemoryCache cache)
        {
            _mapper = mapper;
            _cache = cache;
        }

        public IEnumerable<ProdInStoreDto> GetRecords()
        {
            if (_cache.TryGetValue("prodInStores", out List<ProdInStoreDto>? records))
            {
                return records;
            }

            using (var context = new DBContext())
            {
                var recordsList = context.ProdInStores.Select(x => _mapper.Map<ProdInStoreDto>(x)).ToList();
                _cache.Set("prodInStores", recordsList, TimeSpan.FromMinutes(30));
                return recordsList;
            }
        }

        public int AddRecord(ProdInStoreDto record)
        {
            using (var context = new DBContext())
            {
                var entityRecord = context.ProdInStores.FirstOrDefault(
                    x => x.IdStore == record.IdStore &&
                    x.IdProduct == record.IdProduct);
                if (entityRecord == null)
                {
                    entityRecord = _mapper.Map<Models.ProdInStore>(record);
                    context.ProdInStores.Add(entityRecord);
                    context.SaveChanges();
                    _cache.Remove("prodInStores");
                }
                return entityRecord.Id;
            }
        }
        public bool DeleteRecord(int id)
        {
            using (var context = new DBContext())
            {

                ProdInStore entityRecord = context.ProdInStores.FirstOrDefault(x => x.Id == id && x.Count == 0)!;
                if (entityRecord == null)
                    return false;

                context.ProdInStores.Remove(entityRecord);
                context.SaveChanges();
                _cache.Remove("prodInStores");
                return true;
            }
        }

        public bool OrderProdFromStore(int prodId, int storeId, int count)
        {
            using (var context = new DBContext())
            {
                ProdInStore entityRecord = context.ProdInStores.FirstOrDefault(x => x.IdStore == storeId && x.IdProduct == prodId)!;
                if (entityRecord == null)
                    return false;

                entityRecord.Count = entityRecord.Count - count;
                context.SaveChanges();
                _cache.Remove("prodInStores");
                return true;
            }
        }

    }
}
