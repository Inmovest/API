namespace Inmovest.API.Resources
{
    public class ContractResource
    {
        public int id { get; set; }
        public bool signed { get; set; }
        public UserResource User { get; set; }
    }
}