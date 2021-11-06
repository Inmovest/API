namespace Inmovest.API.Domain
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Serial { get; set; }
        public string Bank { get; set; }
        
        //RelationShips
        public int UserId { get; set; }
        public User User { get; set; }
    }
}