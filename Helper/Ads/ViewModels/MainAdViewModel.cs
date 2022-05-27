using Helper.Ads.Enums;

namespace Helper.Ads.ViewModels
{
    public abstract class MainAdViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string KindOfAnimal { get; set; }
        public string Color { get; set; }
        public TypeAd TypeAd { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
