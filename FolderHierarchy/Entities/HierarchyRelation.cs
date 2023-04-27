namespace FolderHierarchy.Entities
{
    public class HierarchyRelation
    {
        public int Id { get; set; }
        public string? Parent { get; set; }
        public string? Children { get; set; }
    }
}
