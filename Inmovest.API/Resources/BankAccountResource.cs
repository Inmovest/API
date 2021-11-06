
namespace Inmovest.API.Resources
{
    public class BankAccountResource
    {
        public int Id { get; set; }
        public string Serial { get; set; }
        public string Bank { get; set; }
        public UserResource User { get; set; }
    }
}