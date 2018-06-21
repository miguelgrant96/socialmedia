using project2._4.DAL;
using project2._4.Entities.Models;
using project2._4.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.BL.Repositories
{
    public class UserInfoRepository
    {
        private DatabaseContext Db;

        public UserInfoRepository()
        {
            this.Db = new DatabaseContext();
        }

        public ProfileInfo GetProfileInfo(Guid id)
        {
            return Db.ProfileInfo.Find(id);
        }

        public void UpdateProfileInfo(ProfileInfo profileinfo)
        {
            Db.ProfileInfo.Attach(profileinfo);
            Db.Entry(profileinfo).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
