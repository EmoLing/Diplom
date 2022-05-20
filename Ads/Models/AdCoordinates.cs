using System.ComponentModel.DataAnnotations;

namespace Ads.Models
{
    public class AdCoordinates
    {
        [Key]
        public Guid AdGuid { get; set; }
        public Guid Guid { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public AdCoordinates()
        {
            Guid = Guid.NewGuid();
        }
    }
}
