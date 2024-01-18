using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using WebApplication02HW.Abstraction;
using WebApplication02HW.Models.DTO;
using WebApplication02HW.Models;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.Reflection;

namespace WebApplication02HW.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ProductRepository(IMapper mapper, IMemoryCache cache)
        {
            _mapper = mapper;
            _cache = cache;
        }

        public int AddGroup(GroupDto group)
        {
            using (var context = new ProductContext())
            {
                var entityGroup = context.Groups.FirstOrDefault(x => x.Name.ToLower() == group.Name.ToLower());
                if (entityGroup == null)
                {
                    entityGroup = _mapper.Map<Models.Group>(group);
                    context.Groups.Add(entityGroup);
                    context.SaveChanges();
                    _cache.Remove("groups");
                }
                return entityGroup.Id;
            }
        }

        public bool DeleteGroup(int id)
        {
            using (var context = new ProductContext())
            {
                Group entityGroup = context.Groups.FirstOrDefault(x => x.Id == id)!;
                if (entityGroup == null)
                    return false;

                context.Groups.Remove(entityGroup);
                context.SaveChanges();
                _cache.Remove("groups");
                return true;
            }
        }

        public int AddProduct(ProductDto product)
        {
            using (var context = new ProductContext())
            {
                var entityProduct = context.Products.FirstOrDefault(x => x.Name.ToLower() == product.Name.ToLower());
                if (entityProduct == null)
                {
                    entityProduct = _mapper.Map<Models.Product>(product);
                    context.Products.Add(entityProduct);
                    context.SaveChanges();
                    _cache.Remove("products");
                }
                return entityProduct.Id;
            }
        }

        public IEnumerable<GroupDto> GetGroups()
        {
            if (_cache.TryGetValue("groups", out List<GroupDto>? groups))
            {
                return groups;
            }

            using (var context = new ProductContext())
            {
                var groupsList = context.Groups.Select(x => _mapper.Map<GroupDto>(x)).ToList();
                _cache.Set("groups", groupsList, TimeSpan.FromMinutes(30));
                return groupsList;
            }
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            if (_cache.TryGetValue("products", out List<ProductDto>? products))
            {
                return products;
            }

            using (var context = new ProductContext())
            {
                var productList = context.Products.Select(x => _mapper.Map<ProductDto>(x)).ToList();
                _cache.Set("product", productList, TimeSpan.FromMinutes(30));
                return productList;

            }
        }

        public bool DeleteProduct(int id)
        {
            List<Product> products = new List<Product>();
            using (var context = new ProductContext())
            {
                var cat = context.Groups.ToList();
                products = context.Products.ToList();
                var obj = products.FirstOrDefault(x => x.Id == id);
                if (obj is null)
                    return false;

                context.Products.Remove(obj);
                context.SaveChanges();
                _cache.Remove("products");
                return true;
            }
        }

        public string GetProductsCSV()
        {
            var sb = new StringBuilder();
            var products = GetProducts();

            foreach (var product in products)
            {
                sb.AppendLine($"{product.Id},{product.Name}, {product.Description}");
            }

            return sb.ToString();
        }

        public string GetСacheStatCSV()
        {
            var curCache = _cache.GetCurrentStatistics();
            var sb = new StringBuilder();
            sb.AppendLine($"CurrentEntryCount, {curCache.CurrentEntryCount.ToString()}")
              .AppendLine($"CurrentEstimatedSize, {curCache.CurrentEstimatedSize.ToString()}")
              .AppendLine($"TotalHits, {curCache.TotalHits.ToString()}")
              .AppendLine($"TotalMisses, {curCache.TotalMisses.ToString()}");
            return sb.ToString();
        }

    }
}
