using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ads.Models
{
    public class Ad : IAd
    {
        [Key]
        public Guid Guid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Image> Photos { get; set; }
        public TypeAd TypeAd { get; private set; }
        public Guid UserGuid { get; }
        public AdCoordinates Coordinates { get; set; }
        public StatusAd StatusAd { get; private set; }

        public Ad()
        { 
        }

        public Ad(Guid userGuid, TypeAd typeAd)
        {
            Guid = new Guid();
            UserGuid = userGuid;
            TypeAd = typeAd;
        }


        public void Post() => StatusAd = StatusAd.New;

        public void Close() => StatusAd = StatusAd.Closed;

        public void Archiving() => StatusAd = StatusAd.Archived;
    }
}
