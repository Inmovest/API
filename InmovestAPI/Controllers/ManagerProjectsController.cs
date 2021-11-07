using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Services;
using InmovestAPI.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InmovestAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/managers/{managerId}/projects")]
    public class ManagerProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;  

        public ManagerProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Projects By Manager",
            Description = "Get All Projects for a given ManagerId",
            Tags = new[] {"Manager"}
        )]
        [HttpGet]
        public async Task<IEnumerable<ProjectResource>> GetAllByManagerIdAsync(int managerId)
        {
            var projects = await _projectService.ListByManagerIdAsync(managerId);
            var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);

            return resources;
        }
    }
}