using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Text.RegularExpressions;
using WebApplication03S.Abstraction;
using WebApplication03S.Models;
using WebApplication03S.Models.DTO;

namespace WebApplication03S.Services
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
        public int AddGroup(GroupDto group)
        {
            using (_context)
            {
                var entity = _mapper.Map<Models.Group>(group);

                _context.Groups.Add(entity);
                _context.SaveChanges();
                _cache.Remove("groups");

                return entity.Id;
            }
        }
        public IEnumerable<GroupDto> GetGroups()
        {
            using (_context)
            {
                if (_cache.TryGetValue("groups", out List<GroupDto> groups))
                    return groups;

                groups = _context.Groups.Select(x => _mapper.Map<GroupDto>(x)).ToList();
                _cache.Set("categories", groups, TimeSpan.FromMinutes(30));

                return groups;
            }
        }
    }
}
