using WebApplication02S.Models.DTO;
using WebApplication02S.Models;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using WebApplication02S.Abstraction;

namespace WebApplication02S.Repo
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GroupRepository(IMapper mapper, IMemoryCache cache)
        {
            _mapper = mapper;
            _cache = cache;
        }

        //--------

        public int AddGroup(GroupDto groupDto)
        {
            using (var context = new ProductContext())
            {
                var cat = context.Products.ToList();
                var products = context.Groups.ToList();
                var res = products.FirstOrDefault(x => x.Name.ToLower() == groupDto.Name.ToLower());
                if (res is null)
                {
                    _cache.Remove("categories");
                    res = new Group() { Name = groupDto.Name, Description = groupDto.Description };
                    context.Groups.Add(res);
                    context.SaveChanges();
                }
                return res.Id;
            }
        }

        public bool DeleteGroup(int id)
        {
            using (var context = new ProductContext())
            {
                Group group = context.Groups.FirstOrDefault(x => x.Id == id)!;
                if (group is null)
                    return false;
                
                context.Groups.Remove(group);
                context.SaveChanges();
                _cache.Remove("groups");
                return true;
            }
        }

        public IEnumerable<GroupDto> GetGroups()
        {
            if (_cache.TryGetValue("groups", out List<GroupDto> groupsCache))
                return groupsCache;

            List<Group> products = new List<Group>();
            using (var context = new ProductContext())
            {
                var cat = context.Products.ToList();
                products = context.Groups.ToList();
            }
            var res = products.Select(x => _mapper.Map<GroupDto>(x)).ToList();

            _cache.Set("categories", res, TimeSpan.FromMinutes(30));

            return res;
        }


        public string GetGroupsCSV()
        {
            var sb = new StringBuilder();
            var groups = GetGroups();

            foreach (var group in groups)
            {
                sb.AppendLine($"{group.Id},{group.Name},{group.Description}");
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


        //--------
        //public int AddGroup(GroupDto groupDto)
        //{
        //    using (var context = new ProductContext())
        //    {
        //        var entityGroup = context.Groups.FirstOrDefault(x => x.Name.ToLower() == groupDto.Name.ToLower());
        //        if (entityGroup == null)
        //        {
        //            entityGroup = _mapper.Map<Models.Group>(groupDto);
        //            context.Groups.Add(entityGroup);
        //            context.SaveChanges();
        //            _cache.Remove("groups");
        //        }
        //        return entityGroup.Id;
        //    }
        //}

        //public IEnumerable<GroupDto> GetGroups()
        //{
        //    if (_cache.TryGetValue("groups", out List<GroupDto> groups))
        //    {
        //        return groups;
        //    }

        //    using (var context = new ProductContext())
        //    {
        //        var groupsList = context.Groups.Select(x => _mapper.Map<GroupDto>(x)).ToList();
        //        _cache.Set("groups", groupsList, TimeSpan.FromMinutes(30));
        //        return groupsList;
        //    }
        //}
    }
}
