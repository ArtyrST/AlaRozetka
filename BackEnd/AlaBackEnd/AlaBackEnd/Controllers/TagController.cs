using AlaBackEnd.API.Extensions;
using AlaBackEnd.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlaBackEnd.API.Controllers
{
    [ApiController]
    [Route("api/tags")]
    public class TagController : ControllerBase
    {
        private readonly TagServise _tag;
        public TagController(TagServise tag)
        {
            _tag = tag;
        }
        [HttpGet("alltags")]
        public async Task<IActionResult> GetAllTags()
        {
            var response = await _tag.GelAllAsync();
            return this.GetResult(response);
        }

    }
}
