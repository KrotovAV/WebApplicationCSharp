using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using WebApplication03HW.Abstraction;
using WebApplication03HW.Models;
using WebApplication03HW.Models.DTO;

namespace WebApplication03HW.Services
{
    public class GroupService : IGroupService
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GroupService(DBContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }
        public int AddCategory(GroupDto category)
        {
            using (_context)
            {
                var entity = _mapper.Map<Group>(category);

                _context.Groups.Add(entity);
                _context.SaveChanges();
                _cache.Remove("categories");

                return entity.Id;
            }
        }

        public IEnumerable<GroupDto> GetCategories()
        {
            using (_context)
            {
                if (_cache.TryGetValue("categories", out List<GroupDto> categories))
                    return categories;

                categories = _context.Groups.Select(x => _mapper.Map<GroupDto>(x)).ToList();
                _cache.Set("categories", categories, TimeSpan.FromMinutes(30));

                return categories;
            }
        }
    }
}
