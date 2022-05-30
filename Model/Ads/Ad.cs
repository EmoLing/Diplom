using Microsoft.EntityFrameworkCore;
using Model.Ads.Animals;
using Model.Ads.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Ads
{
    public class Ad : IAd
    {
        public Guid Guid { get; }
        public string Name { get; set; }
        public Animal Animal { get; set; }
        public string Description { get; set; }
        public IEnumerable<Image> Photo { get; set; }
        public TypeAd TypeAd { get; private set; }
        public Guid UserGuid { get; }
        public AdCoordinates Coordinates { get; set; }
        public StatusAd StatusAd { get; private set; }
        public DateTime DateCreate { get; private set; }

        public Ad() { }

        public Ad(Guid userGuid, TypeAd typeAd)
        {
            Guid = Guid.NewGuid();
            UserGuid = userGuid;
            DateCreate = DateTime.Now;
            TypeAd = typeAd;
            StatusAd = StatusAd.New;
        }

        public void Post() => StatusAd = StatusAd.Open;

        public void Close() => StatusAd = StatusAd.Closed;

        public void Archiving() => StatusAd = StatusAd.Archived;
    }
}
