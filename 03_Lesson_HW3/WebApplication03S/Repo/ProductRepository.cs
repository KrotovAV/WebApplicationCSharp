using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using WebApplication03HW3.Abstraction;
using WebApplication03HW3.Models.DTO;
using WebApplication03HW3.Models;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.Reflection;

namespace WebApplication03HW3.Repo
{
    public class ProductRepository// : IProductRepository
    {
        //private readonly IMapper _mapper;
        //private readonly IMemoryCache _cache;

        //public ProductRepository(IMapper mapper, IMemoryCache cache)
        //{
        //    _mapper = mapper;
        //    _cache = cache;
        //}

        //public int AddGroup(GroupDto group)
        //{
        //    using (var context = new DBContext())
        //    {
        //        var entityGroup = context.Groups.FirstOrDefault(x => x.Name.ToLower() == group.Name.ToLower());
        //        if (entityGroup == null)
        //        {
        //            entityGroup = _mapper.Map<Models.Group>(group);
        //            context.Groups.Add(entityGroup);
        //            context.SaveChanges();
        //            _cache.Remove("groups");
        //        }
        //        return entityGroup.Id;
        //    }
        //}

        //public bool DeleteGroup(int id)
        //{
        //    using (var context = new DBContext())
        //    {
        //        Group entityGroup = context.Groups.FirstOrDefault(x => x.Id == id)!;
        //        if (entityGroup == null)
        //            return false;

        //        context.Groups.Remove(entityGroup);
        //        context.SaveChanges();
        //        _cache.Remove("groups");
        //        return true;
        //    }
        //}

        //public int AddProduct(ProductDto product)
        //{
        //    using (var context = new DBContext())
        //    {
        //        var entityProduct = context.Products.FirstOrDefault(x => x.Name.ToLower() == product.Name.ToLower());
        //        if (entityProduct == null)
        //        {
        //            entityProduct = _mapper.Map<Models.Product>(product);
        //            context.Products.Add(entityProduct);
        //            context.SaveChanges();
        //            _cache.Remove("products");
        //        }
        //        return entityProduct.Id;
        //    }
        //}

        //public IEnumerable<GroupDto> GetGroups()
        //{
        //    if (_cache.TryGetValue("groups", out List<GroupDto>? groups))
        //    {
        //        return groups;
        //    }

        //    using (var context = new DBContext())
        //    {
        //        var groupsList = context.Groups.Select(x => _mapper.Map<GroupDto>(x)).ToList();
        //        _cache.Set("groups", groupsList, TimeSpan.FromMinutes(30));
        //        return groupsList;
        //    }
        //}

        //public IEnumerable<ProductDto> GetProducts()
        //{
        //    if (_cache.TryGetValue("products", out List<ProductDto>? products))
        //    {
        //        return products;
        //    }

        //    using (var context = new DBContext())
        //    {
        //        var productList = context.Products.Select(x => _mapper.Map<ProductDto>(x)).ToList();
        //        _cache.Set("product", productList, TimeSpan.FromMinutes(30));
        //        return productList;

        //    }
        //}

        //public bool DeleteProduct(int id)
        //{
        //    List<Product> products = new List<Product>();
        //    using (var context = new DBContext())
        //    {
        //        var cat = context.Groups.ToList();
        //        products = context.Products.ToList();
        //        var obj = products.FirstOrDefault(x => x.Id == id);
        //        if (obj is null)
        //            return false;

        //        context.Products.Remove(obj);
        //        context.SaveChanges();
        //        _cache.Remove("products");
        //        return true;
        //    }
        //}
        //3-------------------

        //public IEnumerable<StoreDto> GetStores()
        //{
        //    if (_cache.TryGetValue("stores", out List<StoreDto>? stores))
        //    {
        //        return stores;
        //    }

        //    using (var context = new DBContext())
        //    {
        //        var storesList = context.Stores.Select(x => _mapper.Map<StoreDto>(x)).ToList();
        //        _cache.Set("stores", storesList, TimeSpan.FromMinutes(30));
        //        return storesList;
        //    }
        //}

        //public int AddStore(StoreDto store)
        //{
        //    using (var context = new DBContext())
        //    {
        //        var entityStore = context.Stores.FirstOrDefault(x => x.Name.ToLower() == store.Name.ToLower());
        //        if (entityStore == null)
        //        {
                    
        //            entityStore = _mapper.Map<Models.Store>(store);
        //            context.Stores.Add(entityStore);
        //            context.SaveChanges();
        //            _cache.Remove("stores");
        //        }
        //        return entityStore.Id;
        //    }
        //}
        //public bool DeleteStore(int id)
        //{
        //    using (var context = new DBContext())
        //    {
        //        Store entityStore = context.Stores.FirstOrDefault(x => x.Id == id)!;
        //        if (entityStore == null)
        //            return false;

        //        context.Stores.Remove(entityStore);
        //        context.SaveChanges();
        //        _cache.Remove("stores");
        //        return true;
        //    }
        //}

        //3-------------------
        //public string GetProductsCSV()
        //{
        //    var sb = new StringBuilder();
        //    var products = GetProducts();

        //    foreach (var product in products)
        //    {
        //        sb.AppendLine($"{product.Id},{product.Name}, {product.Description}");
        //    }

        //    return sb.ToString();
        //}



        //public string GetСacheStatCSV()
        //{
        //    var curCache = _cache.GetCurrentStatistics();
        //    var sb = new StringBuilder();
        //    sb.AppendLine($"CurrentEntryCount, {curCache.CurrentEntryCount.ToString()}")
        //      .AppendLine($"CurrentEstimatedSize, {curCache.CurrentEstimatedSize.ToString()}")
        //      .AppendLine($"TotalHits, {curCache.TotalHits.ToString()}")
        //      .AppendLine($"TotalMisses, {curCache.TotalMisses.ToString()}");
        //    return sb.ToString();
        //}

    }
}
