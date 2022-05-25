using Microsoft.AspNetCore.Mvc;

namespace Ads.ViewModel
{
    public class AdViewModel
    {
        [FromForm(Name = "caption")]
        public string Caption { get; set; }

        [FromForm(Name = "description")]
        public string Description { get; set; }

        [FromForm(Name = "images")]
        public IList<IFormFile> Images { get; set; }
    }
}
