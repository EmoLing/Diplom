using System.ComponentModel.DataAnnotations;

namespace Ads.Models
{
    public class AdCoordinates
    {
        [Key]
        public Guid Guid { get; }
        public Guid AdGuid { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public AdCoordinates(Guid adGuid)
        {
            AdGuid = adGuid;
            Guid = Guid.NewGuid();
        }
    }
}
