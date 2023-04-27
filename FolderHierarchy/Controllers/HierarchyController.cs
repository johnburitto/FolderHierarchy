using FolderHierarchy.Entities;
using FolderHierarchy.Models;
using FolderHierarchy.Services;
using Microsoft.AspNetCore.Mvc;

namespace FolderHierarchy.Controllers
{
    public class HierarchyController : Controller
    {
        private readonly RelationService _service;

        public HierarchyController(RelationService service)
        {
            _service = service ?? throw new ArgumentNullException(typeof(RelationService).ToString());
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
            return View(new HierarchyModel
                {
                    Parent = "",
                    Relations = await _service.GetAllAsync()
                }
            );
        }

        public async Task<IActionResult> AllByParent(string? parent)
        {
            return View(new HierarchyModel
                {
                    Parent = parent ?? "",
                    Relations = await _service.GetAllByParentAsync(parent ?? "")
                }
            );
        }
    }
}
