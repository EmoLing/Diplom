using Diplom.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdesController : ControllerBase
    {
        [HttpGet("GetPosters")]
        public IEnumerable<Poster> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Poster("kek", "sprek", Poster.PosterType.Loss, null));
        }
    }
}
