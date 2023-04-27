using System.ComponentModel.DataAnnotations;

namespace FolderHierarchy.Dtos
{
    public class RelationCreateDto
    {
        [Required]
        public string? Parent { get; set; }
        [Required]
        public string? Children { get; set; }
    }
}
