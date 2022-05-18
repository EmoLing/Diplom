namespace Ads.Models
{
    internal class Ad : IAd
    {
        public Guid Guid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<byte[]> Photos { get; set; }
        public TypeAd TypeAd { get; private set; }
        public Guid UserGuid { get; }
        public AdCoordinates Coordinates { get; set; }
        public StatusAd StatusAd { get; private set; }


        public Ad(Guid userGuid, TypeAd typeAd)
        {
            Guid = new Guid();
            UserGuid = userGuid;
            TypeAd = typeAd;
        }


        public void Post() => StatusAd = StatusAd.New;

        public void Close() => StatusAd = StatusAd.Closed;

        public void Archiving() => StatusAd = StatusAd.Archived;


        public class AdCoordinates
        {
            public decimal Latitude { get; set; }
            public decimal Longitude { get; set; }
        }
    }
}
