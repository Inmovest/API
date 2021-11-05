using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmovestAPI.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {
        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }
        public BaseResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }
    }
}
