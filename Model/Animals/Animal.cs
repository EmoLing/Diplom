using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.Ads.Animals
{
    public class Animal
    {
        public Guid Guid { get; }
        public string AnimalName { get; set; }
        [JsonIgnore]
        public Ad Ad { get; set; }
        public Guid AdGuid { get; set; }
        public Guid KindOfAnimalGuid { get; set; }
        public SexAnimal SexAnimal { get; set; } = SexAnimal.Undefined;
        public Guid ColorOfAnimalGuid { get; set; }

        public Animal()
        {
            Guid = Guid.NewGuid();
        }
    }
}
