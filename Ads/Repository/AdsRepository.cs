using Ads.DbContexts;
using Ads.Models;

namespace Ads.Repository
{
    public class AdsRepository : IAdsRepository
    {
        private readonly AdContext _dbContext;
        public AdsRepository(AdContext adContext)
        {
            _dbContext = adContext;
        }

        public void CreateAd(Ad ad)
        {
            _dbContext.Ads.Add(ad);
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

        public IEnumerable<Ad> GetAds() => _dbContext.Ads.ToList();

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
