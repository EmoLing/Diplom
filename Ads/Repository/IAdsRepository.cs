using Ads.Models;

namespace Ads.Repository
{
    public interface IAdsRepository
    {
        public void Publication();
        public void Close(Guid adGuid);
        public void SendToArchive(Guid adGuid);
        public Ad GetAd(Guid adGuid);
        public IEnumerable<Ad> GetAds();
    }
}
