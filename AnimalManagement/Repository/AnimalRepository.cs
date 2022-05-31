using AnimalManagement.DbContexts;
using Helper.Ads.ViewModels;
using Model.Ads.Animals;

namespace AnimalManagement.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalContext _dbContext;
        public AnimalRepository(AnimalContext animalContext)
        {
            _dbContext = animalContext;
        }

        public void CreateAnimal(Animal animal)
        {

            //if (String.IsNullOrEmpty(animal.))
            //{
            //    var kind = _dbContext.KindsOfAnimals.FirstOrDefault();
            //    adsAnimal.Item1.KindOfAnimalGuid = kind.Guid;
            //}
            //else
            //{
            //    var kindOfAnimal = new KindOfAnimal()
            //    {
            //        IsOtherKindName = true,
            //        OtherKindName = adsAnimal.Item2.OtherKind
            //    };

            //    _dbContext.KindsOfAnimals.Add(kindOfAnimal);

            //    adsAnimal.Item1.KindOfAnimalGuid = kindOfAnimal.Guid;
            //    _dbContext.SaveChanges();
            //}

            //if (String.IsNullOrEmpty(adsAnimal.Item2.OtherColor))
            //{
            //    var color = _dbContext.ColorsOfAnimals.FirstOrDefault();
            //    adsAnimal.Item1.ColorOfAnimalGuid = color.Guid;
            //}
            //else
            //{
            //    var colorOfAnimal = new ColorOfAnimal()
            //    {
            //        IsOtherColor = true,
            //        OtherColorName = adsAnimal.Item2.OtherKind
            //    };

            //    _dbContext.ColorsOfAnimals.Add(colorOfAnimal);

            //    adsAnimal.Item1.ColorOfAnimalGuid = colorOfAnimal.Guid;
            //    _dbContext.SaveChanges();
            //}

            
            _dbContext.Ads.Attach(animal.Ad);
            _dbContext.Animals.Add(animal);
            _dbContext.SaveChanges();

            _dbContext.Ads.Remove(animal.Ad);
            _dbContext.SaveChanges();
        }

        public List<Animal> GetAllAnimals() => _dbContext.Animals.ToList();

        public List<ColorOfAnimal> GetColorOfAnimals() => _dbContext.ColorsOfAnimals.ToList();

        public List<KindOfAnimal> GetKindOfAnimals() => _dbContext.KindsOfAnimals.ToList();

        public void RemoveAnimal(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void RemoveAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public void UpdateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public void UpdateAnimal(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
