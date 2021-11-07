using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Services;
using InmovestAPI.Extensions;
using InmovestAPI.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InmovestAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly IMapper _mapper;

        public ManagersController(IManagerService managerService, IMapper mapper)
        {
            _managerService = managerService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Managers",
            Description = "Get All Managers already stored",
            Tags = new[] {"Managers"}
            )]
        [HttpGet]
        public async Task<IEnumerable<ManagerResource>> GetAllAsync()
        {
            var managers = await _managerService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Manager>,IEnumerable<ManagerResource>>(managers);
            return resources;
        }
        [SwaggerOperation(
            Summary = "Post a Manager",
            Description = "Post a Manager to the database",
            Tags = new[] {"Managers"}
        )]

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveManagerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var manager = _mapper.Map<SaveManagerResource, Manager>(resource);

            var result = await _managerService.SaveAsync(manager);

            if (!result.Success)
                return BadRequest(result.Message);

            var managerResource = _mapper.Map<Manager, ManagerResource>(result.Resource);

            return Ok(managerResource);

        }
        [SwaggerOperation(
            Summary = "Update a Manager",
            Description = "Update a Manager in the database",
            Tags = new[] {"Managers"}
        )]

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveManagerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var manager = _mapper.Map<SaveManagerResource, Manager>(resource);

            var result = await _managerService.UpdateAsync(id, manager);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var managerResource = _mapper.Map<Manager, ManagerResource>(result.Resource);

            return Ok(managerResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete a Manager",
            Description = "Delete a Manager in the database",
            Tags = new[] {"Managers"}
        )]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _managerService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var managerResource = _mapper.Map<Manager, ManagerResource>(result.Resource);

            return Ok(managerResource);
        }
    }
}