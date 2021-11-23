using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Imnovest.API.Domain;
using Inmovest.API.Domain.Services;
using Inmovest.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Inmovest.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class WalletsController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly IMapper _mapper;

        public WalletsController(IWalletService walletService, IMapper mapper)
        {
            _walletService = walletService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<WalletResource>> GetALlAsync()
        {
            var wallets = await _walletService.ListAsync();
            
            var resources = _mapper.Map<IEnumerable<Wallet>, IEnumerable<WalletResource>>(wallets);
            
            return resources;
        }
    }
}