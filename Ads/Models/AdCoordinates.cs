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

        public static decimal GetDecimalFromString(string @string)
        {
            if (string.IsNullOrWhiteSpace(@string))
                return 0;

            if (Decimal.TryParse(@string, out decimal result)
                || Decimal.TryParse(@string.Replace(',', '.'), out result)
                || Decimal.TryParse(@string.Replace('.', ','), out result))
            {
                return result;
            }


            throw new Exception("Не удалось распарсить строку");
        }
    }
}
