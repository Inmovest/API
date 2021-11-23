using Inmovest.API.Domain;

namespace Imnovest.API.Domain
{
    public class Wallet
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public bool Frozen { get; set; }
        
        //RelationShip
        public int UserId { get; set; }
        public User User { get; set; }
    }
}