using Microsoft.AspNetCore.Identity;

namespace UserProfile.Model
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
