﻿using Microsoft.AspNetCore.Identity;

namespace UserProfile.Model
{
    //public class User : IdentityUser
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
