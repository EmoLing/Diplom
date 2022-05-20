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
            Guid = Guid.NewGuid();
            UserGuid = Guid.NewGuid();
            TypeAd = 0;
            StatusAd = StatusAd.New;

            Photos = new List<Image>()
            { new Image(Guid) { ImageHash = new byte[5] } };

            Coordinates = new AdCoordinates()
            {
                AdGuid = Guid,
                Latitude = 44,
                Longitude = 55,
            };

            Name = "ttt";
            Description = "gggf";
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
