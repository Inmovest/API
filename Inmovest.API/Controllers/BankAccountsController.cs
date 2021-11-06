using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Inmovest.API.Domain;
using Inmovest.API.Domain.Services;
using Inmovest.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Inmovest.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly IMapper _mapper;

        public BankAccountsController(IBankAccountService bankAccountService, IMapper mapper)
        {
            _bankAccountService = bankAccountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BankAccountResource>> GetAllAsync()
        {
            var bankAccounts = await _bankAccountService.ListAsync();

            var resources = _mapper.Map<IEnumerable<BankAccount>, IEnumerable<BankAccountResource>>(bankAccounts);

            return resources;
        }
    }
}