using Ads.Models;
using Ads.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdsController : Controller
    {
        private readonly IAdsRepository _adsRepository;

        public AdsController(IAdsRepository AdsRepository) { _adsRepository = AdsRepository; }

        [HttpGet]
        public IEnumerable<Ad> GetFindAds()
        {
            return new List<Ad>();
        }
    }
}
