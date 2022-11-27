using ApiDotNet6.Application.DTOs;
using ApiDotNet6.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableAController : ControllerBase
    {
        private readonly ITableAServices _tableAServices;

        public TableAController(ITableAServices tableAServices)
        {
            _tableAServices = tableAServices;
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody]TableADTO tableADTO)
        {
            var result = await _tableAServices.CreateAsync(tableADTO);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _tableAServices.GetAllAsync();
            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _tableAServices.GetByIdAsync(id);
            if (result.IsSuccess) return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] TableADTO tableADTO)
        {
            var result = await _tableAServices.UpdateAsync(tableADTO);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _tableAServices.DeleteAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }
    }
}
