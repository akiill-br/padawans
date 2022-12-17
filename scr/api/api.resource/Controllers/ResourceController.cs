using ApiResource.Application.DTOs;
using ApiResource.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.resource.Controllers
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

        [Authorize(Roles = "user,admin")]
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


        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _resourceService.GetByIdAsync(id);

            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }

        [Authorize(Roles = "admin")]
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


        [Authorize(Roles = "admin")]
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
