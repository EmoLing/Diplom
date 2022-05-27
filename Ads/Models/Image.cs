using Helper.Images;
using System.ComponentModel.DataAnnotations;

namespace Ads.Models
{
    public class Image
    {
        [Key]
        public Guid Guid { get; }
        public Guid AdGuid { get; private set; }
        public byte[] ImageHash { get; set; }

        public Image(Guid adGuid)
        {
            Guid = Guid.NewGuid();
            AdGuid = adGuid;
        }
    }
}
