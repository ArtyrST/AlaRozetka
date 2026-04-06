using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AlaBackEnd.BLL.Services
{
    public class ServiceResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public object? PayLoad { get; set; }
        public static ServiceResponse Success(string message, object? obj)
        {
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = message,
                PayLoad = obj
            };
        }
        public static ServiceResponse Error(string message)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = message,
            };
        }
    }
}
