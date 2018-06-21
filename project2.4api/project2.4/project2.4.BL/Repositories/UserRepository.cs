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
    public class UserRepository
    {
        private DatabaseContext Db;

        public UserRepository()
        {
            this.Db = new DatabaseContext();
        }

        public User ValidateUser(string email, string password)
        {
            string hashedpassword = PasswordHasher.HashPassword(password);

            User user = Db.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();

            if (user == null)
                return null;

            if (user.Password != hashedpassword)
                return null;

            user.LastLogin = DateTime.Now;
            this.UpdateUser(user);

            return user;
        }

        public List<User> GetAllUsers()
        {
            return Db.Users.ToList();
        }

        public User GetUser(Guid id)
        {
            return Db.Users.Find(id);
        }

        public User GetUserByEmail(string email)
        {
            return Db.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
        }

        public void RegisterUser(User newUser)
        {
            newUser.LastLogin = DateTime.Now;
            Db.Users.Add(newUser);
            Db.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            Db.Users.Attach(user);
            Db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            Db.Users.Remove(user);
            Db.SaveChanges();
        }
    }
}
