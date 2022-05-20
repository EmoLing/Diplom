using Ads.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly IAdsRepository _adsRepository;
        public AdsController(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
        }

        // GET: api/<AdsController>
        [HttpGet]
        public IActionResult Get() => new OkObjectResult(_adsRepository.GetAds());

        // GET api/<AdsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
