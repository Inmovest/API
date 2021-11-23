using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Imnovest.API.Domain;
using Inmovest.API.Domain.Models;
using Inmovest.API.Domain.Services;
using Inmovest.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Inmovest.API.Controllers
{
    [ApiController]
    [Route("/api/v1/Users/{userId}/Contracts")]
    public class UserContractsController: ControllerBase
    {
        private readonly IContractService _contractService;
        private readonly IMapper _mapper;

        public UserContractsController(IContractService contractService, IMapper mapper)
        {
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContractResource>> GetAllByContractIdAsync(int contractId)
        {
            var contracts = await _contractService.ListByUserIdAsync(contractId);
            var resources = _mapper.Map<IEnumerable<Contract>, IEnumerable<ContractResource>>(contracts);

            return resources;
        }
        
    }
}