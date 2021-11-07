using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InmovestAPI.Domain.Services;
using Swashbuckle.AspNetCore.Annotations;
using InmovestAPI.Resources;
using InmovestAPI.Domain.Models;
using InmovestAPI.Extensions;

namespace InmovestAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get All Projects",
            Description = "Get All Projects already stored",
            Tags = new[] { "Projects" }
         )]
        [HttpGet]
        public async Task<IEnumerable<ProjectResource>> GetAllAsync()
        {
            var projects = await _projectService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);

            return resources;
        }

        [SwaggerOperation(
            Summary = "Post a Project",
            Description = "Post a Project to the database",
            Tags = new[] { "Projects" }
         )]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProjectResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var project = _mapper.Map<SaveProjectResource, Project>(resource);

            var result = await _projectService.SaveAsync(project);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);

            return Ok(projectResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Project",
            Description = "Delete a Project in the database",
            Tags = new[] { "Projects" }
         )]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _projectService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);

            return Ok(projectResource);
        }

        [SwaggerOperation(
            Summary = "Update a Project",
            Description = "Update a Project in the database",
            Tags = new[] { "Projects" }
         )]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProjectResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var project = _mapper.Map<SaveProjectResource, Project>(resource);

            var result = await _projectService.UpdateAsync(id, project);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);

            return Ok(projectResource);
        }
    }
}
