using FolderHierarchy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FolderHierarchy.Configurations
{
    public class HierarchyRelationConfiguration : IEntityTypeConfiguration<HierarchyRelation>
    {
        public void Configure(EntityTypeBuilder<HierarchyRelation> builder)
        {
            builder.Property(relation => relation.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(relation => relation.Parent)
                   .HasMaxLength(100)
                   .IsRequired();
            
            builder.Property(relation => relation.Children)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
}
