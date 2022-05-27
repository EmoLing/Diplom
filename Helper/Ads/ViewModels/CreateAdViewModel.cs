using Helper.Ads.Enums;
using Helper.Images;
using Microsoft.AspNetCore.Http;

namespace Helper.Ads.ViewModels
{
    public class CreateAdViewModel : MainAdViewModel
    {
        public IFormFileCollection Photo { get; set; }

        public static implicit operator AdViewModel(CreateAdViewModel adViewModel)
        {
            return new AdViewModel()
            {
                Name = adViewModel.Name,
                Description = adViewModel.Description,
                Color = adViewModel.Color,
                KindOfAnimal = adViewModel.KindOfAnimal,
                Latitude = adViewModel.Latitude,
                Longitude = adViewModel.Longitude,
                TypeAd = adViewModel.TypeAd,
                Photo = ImageHelper.GetImageFromRequest(adViewModel.Photo)
            };
        }
    }
}
