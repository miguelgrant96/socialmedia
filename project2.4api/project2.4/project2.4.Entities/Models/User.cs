﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.Entities.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string ProfilePictureUrl { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public string NickName { get; set; } 

        public string Password { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        //public string Motto { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastLogin { get; set; }
    }
}
