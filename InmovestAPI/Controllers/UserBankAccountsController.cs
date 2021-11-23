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
    [Route("/api/v1/Users/{userId}/BankAccounts")]
    public class UserBankAccountsController
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly IMapper _mapper;
        
        public UserBankAccountsController(IBankAccountService bankAccountService, IMapper mapper)
        {
            _bankAccountService = bankAccountService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<BankAccountResource>> GetAllByBankAccountIdAsync(int bankAccountId)
        {
            var bankAccounts = await _bankAccountService.ListByUserIdAsync(bankAccountId);
            var resources = _mapper.Map<IEnumerable<BankAccount>, IEnumerable<BankAccountResource>>(bankAccounts);

            return resources;
        }
    }
}