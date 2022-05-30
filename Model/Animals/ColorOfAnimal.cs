using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Ads.Animals
{
    public class ColorOfAnimal
    {
        public Guid Guid { get; set; }
        public string ColorName { get; set; }
        public bool IsOtherColor { get; set; } = false;
        public string OtherColorName { get; set; } = String.Empty;
        public ColorOfAnimal()
        {
            Guid = Guid.NewGuid();
        }
    }
}
