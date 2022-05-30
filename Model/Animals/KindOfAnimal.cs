using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Ads.Animals
{
    public class KindOfAnimal
    {
        public Guid Guid { get; }
        public string KindName { get; set; }
        public bool IsOtherKindName { get; set; } = false;
        public string OtherKindName { get; set; } = String.Empty;
        public KindOfAnimal()
        {
            Guid = Guid.NewGuid();
        }
    }
}
