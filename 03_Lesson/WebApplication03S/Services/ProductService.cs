﻿using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using WebApplication03S.Abstraction;
using WebApplication03S.Models;
using WebApplication03S.Models.DTO;

namespace WebApplication03S.Services
{
    public class ProductService : IProductService
    {

        private readonly DBContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ProductService(DBContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public int AddProduct(ProductDto product)
        {
            using (_context)
            {
                var entity = _mapper.Map<Product>(product);

                _context.Products.Add(entity);
                _context.SaveChanges();
                _cache.Remove("products");

                return entity.Id;
            }
        }

        //[DBContext()]
        public IEnumerable<ProductDto> GetProducts()
        {
            using (_context)
            {
                if (_cache.TryGetValue("products", out List<ProductDto> products))
                    return products;

                products = _context.Products.Select(x => _mapper.Map<ProductDto>(x)).ToList();
                _cache.Set("products", products, TimeSpan.FromMinutes(30));

                return products;
            }
        }
    }
}

