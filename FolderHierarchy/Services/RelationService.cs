using AutoMapper;
using FolderHierarchy.Data;
using FolderHierarchy.Dtos;
using FolderHierarchy.Entities;
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
            var presented = await _context.Relations.FirstOrDefaultAsync(relation => relation.Parent == dto.Parent && relation.Children == dto.Children);

            if (presented != null)
            {
                return presented;
            }

            var withoutParent = await _context.Relations.FirstOrDefaultAsync(relation => relation.Parent == "" && relation.Children == dto.Children);

            if (withoutParent != null)
            {
                withoutParent.Parent = dto.Parent;

                _context.Entry(withoutParent).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return withoutParent;
            }

            var relation = _mapper.Map<HierarchyRelation>(dto);

            await _context.Relations.AddAsync(relation);
            await _context.SaveChangesAsync();

            return relation;
        }

        public async Task<IEnumerable<HierarchyRelation>> GetAllByParentAsync(string parent)
        {
            return await _context.Relations.Where(relation => relation.Parent == parent).ToListAsync();
        }

        public async Task<string> LoadFromDriveAsync(AddFromDriveDto dto)
        {
            string[] allDirectories = Directory.GetDirectories($"{dto.Path}");

            foreach (var el in allDirectories)
            {
                var relations = el.Replace(":", "").Split("\\");

                for (int i = 0; i < relations.Length - 1; i++)
                {
                    var res = await CreateAsync(new RelationCreateDto
                        {
                            Parent = relations[i],
                            Children = relations[i + 1],
                        });

                    if (i == 0)
                    {
                        res = await CreateAsync(new RelationCreateDto
                        {
                            Parent = "",
                            Children = relations[i],
                        });
                    }
                }
            }

            return "Finished";
        }
    }
}
