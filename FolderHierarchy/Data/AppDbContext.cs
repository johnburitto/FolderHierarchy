using FolderHierarchy.Configurations;
using FolderHierarchy.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderHierarchy.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<HierarchyRelation> Relations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new HierarchyRelationConfiguration());
        }
    }
}
