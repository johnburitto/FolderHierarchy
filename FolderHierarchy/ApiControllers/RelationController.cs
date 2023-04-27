using FolderHierarchy.Dtos;
using FolderHierarchy.Models;
using FolderHierarchy.Services;
using Microsoft.AspNetCore.Mvc;

namespace FolderHierarchy.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationController : ControllerBase
    {
        private readonly RelationService _service;

        public RelationController(RelationService service)
        {
            _service = service ?? throw new ArgumentNullException(typeof(RelationService).ToString());
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HierarchyRelation>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<HierarchyRelation>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        [ProducesResponseType(typeof(HierarchyRelation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HierarchyRelation>> GetAllAsync([FromBody] RelationCreateDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }

        [HttpGet("parent/{parent?}")]
        [ProducesResponseType(typeof(IEnumerable<HierarchyRelation>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<HierarchyRelation>>> GetAllByParentAsync(string? parent)
        {
            return Ok(await _service.GetAllByParentAsync(parent ?? ""));
        }
    }
}
