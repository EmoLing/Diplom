using Model.Ads.Animals;
using Model.Ads.Enums;

namespace Helper.Ads.ViewModels
{
    public abstract class MainAdViewModel
    {
        public string Name { get; set; }
        public Guid Color { get; set; }
        public Guid KindOfAnimal { get; set; }
        public string OtherKind { get; set; }
        public SexAnimal SexAnimal { get; set; }
        public string OtherColor { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public TypeAd TypeAd { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
