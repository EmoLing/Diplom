using Ads.DbContexts;
using Helper.Ads.ViewModels;
using Microsoft.EntityFrameworkCore;
using Model.Ads;
using Model.Ads.Animals;

namespace Ads.Repository
{
    public class AdsRepository : IAdsRepository
    {
        private readonly AdContext _dbContext;
        public AdsRepository(AdContext adContext)
        {
            _dbContext = adContext;
        }

        public void CreateAd(Ad ad, AdViewModel adViewModel)
        {
            if (String.IsNullOrEmpty(adViewModel.OtherKind))
            {
                var kind = _dbContext.KindsOfAnimals.FirstOrDefault();
                ad.Animal.KindOfAnimalGuid = kind.Guid;
            }
            else
            {
                var kindOfAnimal = new KindOfAnimal()
                {
                    IsOtherKindName = true,
                    OtherKindName = adViewModel.OtherKind
                };

                _dbContext.KindsOfAnimals.Add(kindOfAnimal);

                ad.Animal.KindOfAnimalGuid = kindOfAnimal.Guid;
            }

            if (String.IsNullOrEmpty(adViewModel.OtherColor))
            {
                var color = _dbContext.ColorsOfAnimals.FirstOrDefault();
                ad.Animal.ColorOfAnimalGuid = color.Guid;
            }
            else
            {
                var colorOfAnimal = new ColorOfAnimal()
                {
                    IsOtherColor = true,
                    OtherColorName = adViewModel.OtherKind
                };

                _dbContext.ColorsOfAnimals.Add(colorOfAnimal);

                ad.Animal.ColorOfAnimalGuid = colorOfAnimal.Guid;
            }

            _dbContext.Ads.Add(ad);
            _dbContext.Animals.Add(ad.Animal);
            _dbContext.Images.AddRange(ad.Photo);
            _dbContext.AdCoordinates.Add(ad.Coordinates);

            _dbContext.SaveChanges();
        }

        public void Close(Guid adGuid)
        {
            throw new NotImplementedException();
        }

        public Ad GetAd(Guid adGuid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ad> GetAds()
        {
            _dbContext.Ads.Load();
            _dbContext.Animals.Load();
            _dbContext.KindsOfAnimals.Load();
            _dbContext.ColorsOfAnimals.Load();
            return _dbContext.Ads
                .Include(a => a.Coordinates)
                .Include(a => a.Photo)
                .Include(a => a.Animal)
                .ToList();
        }


        public void Publication()
        {
            throw new NotImplementedException();
        }

        public void SendToArchive(Guid adGuid)
        {
            throw new NotImplementedException();
        }
    }
}
