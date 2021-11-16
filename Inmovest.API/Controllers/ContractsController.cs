using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Inmovest.API.Domain.Models;
using Inmovest.API.Domain.Services;
using Inmovest.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Inmovest.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;
        private readonly IMapper _mapper;
        
        public ContractsController(IContractService contractService, IMapper mapper)
        {
            _contractService = contractService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ContractResource>> GetALlAsync()
        {
            var contracts = await _contractService.ListAsync();
            
            var resources = _mapper.Map<IEnumerable<Contract>, IEnumerable<ContractResource>>(contracts);
            
            return resources;
        }
    }
}