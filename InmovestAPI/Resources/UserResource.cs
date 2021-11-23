using System.Collections.Generic;
using Imnovest.API.Domain;
using Inmovest.API.Domain;

namespace Inmovest.API.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Ruc { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public IList<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public IList<Wallet> Wallets { get; set; } = new List<Wallet>();
    }
}