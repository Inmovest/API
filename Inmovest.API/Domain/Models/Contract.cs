namespace Inmovest.API.Domain.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public bool Signed { get; set; }
        
        //RelationShip
        public int UserId { get; set; }
        public User User { get; set; }
    }
}