using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using WebApplication02S.Abstraction;
using WebApplication02S.Models.DTO;
using WebApplication02S.Models;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace WebApplication02S.Repo
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

        //-------------------------
    
        public IEnumerable<ProductDto> GetProducts()
        {
            if (_cache.TryGetValue("products", out List<ProductDto> products))
            {
                return products;

            }
            using (var context = new ProductContext())
            {
                var productList = context.Products.Select(x => _mapper.Map<ProductDto>(x)).ToList();
                _cache.Set("products", productList, TimeSpan.FromMinutes(30));
                return productList;

            }
        }

        public int AddProduct(ProductDto productDto)
        {
            using (var context = new ProductContext())
            {
                var cat = context.Groups.ToList();
                var products = context.Products.ToList();
                var res = products.FirstOrDefault(x => x.Name.ToLower() == productDto.Name.ToLower());
                if (res is null)
                {
                    _cache.Remove("products");
                    res = new Product() { Name = productDto.Name, Description = productDto.Description, Cost = productDto.Cost, GroupId = productDto.GroupId };
                    context.Products.Add(res);
                    context.SaveChanges();
                }
                return res.Id;
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


        public bool AddProductCost(int id, int cost)
        {
            using (var context = new ProductContext())
            {
                var cat = context.Groups.ToList();
                var products = context.Products.ToList();
                var res = products.FirstOrDefault(x => x.Id == id);
                if (res is null)
                    return false;
                res.Cost = cost;

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


        //--------------------
        //public int AddProduct(ProbuctDto product)
        //{
        //    using (var context = new ProductContext())
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



        //public IEnumerable<ProbuctDto> GetProducts()
        //{
        //    if (_cache.TryGetValue("products", out List<ProbuctDto> products))
        //    {
        //        return products;

        //    }
        //    using (var context = new ProductContext())
        //    {
        //        var productList = context.Products.Select(x => _mapper.Map<ProbuctDto>(x)).ToList();
        //        _cache.Set("product", productList, TimeSpan.FromMinutes(30));
        //        return productList;

        //    }
        //}
    }
}
