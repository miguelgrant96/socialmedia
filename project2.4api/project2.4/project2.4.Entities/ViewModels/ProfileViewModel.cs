using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.Entities.ViewModels
{
    public class ProfileViewModel
    { 
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string Work { get; set; }

        public string School { get; set; }

        public string Hometown { get; set; }

        public string Relation { get; set; }

        public string Hobby { get; set;}

        public string ProfilePictureUrl { get; set; }

        public string Motto { get; set; }

        public string AboutMe { get; set; }

        public DateTime MemberSince { get; set; }
    }
}
