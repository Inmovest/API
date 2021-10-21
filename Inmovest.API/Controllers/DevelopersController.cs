using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Inmovest.API.Domain;
using Inmovest.API.Domain.Services;
using Inmovest.API.Resources;
using Inmovest.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inmovest.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class DevelopersController : ControllerBase
    {
        private readonly IDeveloperService _developerService;
        private readonly IMapper _mapper;

        public DevelopersController(IDeveloperService developerService, IMapper mapper)
        {
            _developerService = developerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DeveloperResource>> GetAllAsync()
        {
            var developers = await _developerService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Developer>, IEnumerable<DeveloperResource>>(developers);
            
            return resources;
        }
    }
}