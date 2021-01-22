﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Identity
{
    public class AppUser : IdentityUser
    {
        //need something more to the user, here be the place

        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AppUser()
        {

        }
    }
}
