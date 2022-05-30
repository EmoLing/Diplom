using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model.Ads
{
    public class Image
    {
        public Guid Guid { get; }
        public Guid AdGuid { get; private set; }
        [JsonIgnore]
        public Ad Ad { get; private set; }
        public byte[] ImageHash { get; set; }

        public Image(Guid adGuid)
        {
            Guid = Guid.NewGuid();
            AdGuid = adGuid;
        }
    }
}
