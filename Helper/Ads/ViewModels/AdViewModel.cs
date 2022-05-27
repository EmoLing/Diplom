namespace Helper.Ads.ViewModels
{
    public class AdViewModel : MainAdViewModel
    {
        public Guid UserGuid { get; set; }
        public IList<byte[]> Photo { get; set; }
    }
}
