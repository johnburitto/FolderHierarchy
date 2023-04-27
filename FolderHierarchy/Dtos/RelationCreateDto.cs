using System.ComponentModel.DataAnnotations;

namespace FolderHierarchy.Dtos
{
    public class RelationCreateDto
    {
        public string? Parent { get; set; }
        public string? Children { get; set; }
    }
}
