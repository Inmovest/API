using AutoMapper;
using Imnovest.API.Domain;
using Inmovest.API.Domain;
using Inmovest.API.Domain.Models;
using Inmovest.API.Resources;

namespace Inmovest.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Developer, DeveloperResource>();
            CreateMap<User, UserResource>();
            CreateMap<BankAccount, BankAccountResource>();
            CreateMap<Wallet, WalletResource>();
            CreateMap<Contract, ContractResource>();
        }
    }
}