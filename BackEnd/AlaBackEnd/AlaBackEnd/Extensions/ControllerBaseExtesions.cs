using AlaBackEnd.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlaBackEnd.API.Extensions
{
    public static class ControllerBaseExtesions
    {
        public static IActionResult GetResult(this ControllerBase controller, ServiceResponse response)
        {
            return response.IsSuccess
                ? controller.Ok(response)
                : controller.BadRequest(response);
        }
    }
}
