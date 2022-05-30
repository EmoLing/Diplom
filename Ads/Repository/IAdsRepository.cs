
using Helper.Ads.ViewModels;
using Model.Ads;

namespace Ads.Repository
{
    public interface IAdsRepository
    {
        public void CreateAd(Ad ad, AdViewModel adViewModel);
        public void Publication();
        public void Close(Guid adGuid);
        public void SendToArchive(Guid adGuid);
        public Ad GetAd(Guid adGuid);
        public IEnumerable<Ad> GetAds();
    }
}
