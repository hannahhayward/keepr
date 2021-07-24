using System;
using System.Collections.Generic;

namespace keepr.Models
{
    public class Account: Profile
    {
        public string Email { get; set; }
        public Profile Profile {get; set;}
    }
}