using System.Collections.Generic;
using System.Threading.Tasks;
using Inmovest.API.Domain;
using Inmovest.API.Domain.Repositories;
using Inmovest.API.Domain.Services;

namespace Inmovest.API.Services
{
    public class BankAccountService: IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        
        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }
        
        public async Task<IEnumerable<BankAccount>> ListAsync()
        {
            return await _bankAccountRepository.ListAsync();
        }
    }
}