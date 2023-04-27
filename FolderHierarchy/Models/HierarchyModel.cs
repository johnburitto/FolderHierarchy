using FolderHierarchy.Entities;

namespace FolderHierarchy.Models
{
    public class HierarchyModel
    {
        public string? Parent { get; set; }
        public IEnumerable<HierarchyRelation>? Relations { get; set; }
    }
}
