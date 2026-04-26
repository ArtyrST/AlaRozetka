using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.BLL.Services.Interfaces
{
    public interface IProductCartInterface
    {
        Task<ServiceResponse> GetUserCartAsync();
    }
}
