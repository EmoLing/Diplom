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
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
