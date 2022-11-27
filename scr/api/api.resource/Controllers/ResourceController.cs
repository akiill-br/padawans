using ApiResource.Application.DTOs;
using ApiResource.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiResource.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ResourceDTO resourceDTO)
        {
            var result = await _resourceService.CreateAsync(resourceDTO);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _resourceService.GetAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _resourceService.GetByIdAsync(id);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ResourceDTO resourceDTO)
        {
            var result = await _resourceService.UpdateAsync(resourceDTO);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _resourceService.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
