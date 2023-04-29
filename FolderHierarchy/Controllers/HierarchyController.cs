using FolderHierarchy.Models;
using FolderHierarchy.Services;
using Microsoft.AspNetCore.Mvc;

namespace FolderHierarchy.Controllers
{
    public class HierarchyController : Controller
    {
        private readonly RelationService _service;
        private readonly ILogger<HierarchyController> _logger;

        public HierarchyController(RelationService service, ILogger<HierarchyController> logger)
        {
            _service = service ?? throw new ArgumentNullException(typeof(RelationService).ToString());
            _logger = logger ?? throw new ArgumentNullException(typeof(ILogger).ToString());
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

        public IActionResult LoadFromDrive()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadFromDriveAction(OneFieldModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation(await _service.LoadFromDriveAsync(new() { Path = model.Data }));
            }

            return Redirect("/");
        }
    }
}
