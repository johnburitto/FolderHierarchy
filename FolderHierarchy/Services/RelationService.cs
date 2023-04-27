using AutoMapper;
using FolderHierarchy.Data;
using FolderHierarchy.Dtos;
using FolderHierarchy.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderHierarchy.Services
{
    public class RelationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RelationService(AppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(typeof(AppDbContext).ToString());
            _mapper = mapper ?? throw new ArgumentNullException(typeof(IMapper).ToString());
        }

        public async Task<IEnumerable<HierarchyRelation>> GetAllAsync()
        {
            return await _context.Relations.ToListAsync();
        }

        public async Task<HierarchyRelation> CreateAsync(RelationCreateDto dto)
        {
            var relation = _mapper.Map<HierarchyRelation>(dto);

            await _context.Relations.AddAsync(relation);
            await _context.SaveChangesAsync();

            return relation;
        }

        public async Task<IEnumerable<HierarchyRelation>> GetAllByParentAsync(string parent)
        {
            return await _context.Relations.Where(relation => relation.Parent == parent).ToListAsync();
        }
    }
}
