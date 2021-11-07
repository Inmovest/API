using InmovestAPI.Domain.Models;

namespace InmovestAPI.Domain.Services.Communication
{
    public class ManagerResponse : BaseResponse<Manager>
    {
        public ManagerResponse(string message) : base(message)
        {
        }

        public ManagerResponse(Manager manager) : base(manager)
        {
        }
    }
}