using Ads.Repository;
using Helper.Ads.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Model.Ads;
using Model.Ads.Animals;
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
        [Route("CreateAd")]
        public async Task<IActionResult> CreateAd(AdViewModel adViewModel)
        {
            if (adViewModel is null)
                return BadRequest();

            var ad = new Ad(adViewModel.UserGuid, adViewModel.TypeAd)
            {
                Name = adViewModel.Name,
                Description = adViewModel.Description,
            };

            var animal = new Animal()
            {
                Ad = ad,
                AdGuid = ad.Guid,
                AnimalName = adViewModel.Name,
                SexAnimal = adViewModel.SexAnimal,
                KindOfAnimalGuid = adViewModel.KindOfAnimal,
                ColorOfAnimalGuid = adViewModel.Color
            };

            ad.Animal = animal;

            ad.Coordinates = new AdCoordinates(ad.Guid)
            {
                Latitude = AdCoordinates.GetDecimalFromString(adViewModel.Latitude),
                Longitude = AdCoordinates.GetDecimalFromString(adViewModel.Longitude),
            };

            var images = new List<Image>(adViewModel.Photo.Count);
            foreach (var image in adViewModel.Photo)
                images.Add(new Image(ad.Guid) { ImageHash = image });

            ad.Photo = images;

            try
            {
                _adsRepository.CreateAd(ad);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return Ok();
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
