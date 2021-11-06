namespace Inmovest.API.Resources
{
    public class WalletResource
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public bool Frozen { get; set; }
        public UserResource User { get; set; }
    }
}