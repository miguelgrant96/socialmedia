using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using project2._4.Entities.Models;
using project2._4.Shared.Helpers;
using project2._4.BL.Repositories;
using project2._4.Entities.ViewModels;
using System.Web.Http.Cors;

namespace project2._4.API.Controllers
{
    public class AccountController : ApiController
    {

        [HttpGet]
        [Authorize]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetAccount(Guid? id)
        {
            UserRepository db = new UserRepository();
            if (!id.HasValue)
            {
                return Ok(db.GetUserByEmail(User.Identity.Name));
            }

            return Ok(db.GetUser(id.Value));
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PostAccount([FromBody] UserViewModel userViewModel)
        {

            UserRepository db = new UserRepository();
            UserInfoRepository infoRep = new UserInfoRepository();
            if (db.GetUserByEmail(userViewModel.Email) != null)
            {
                throw new Exception("Email already in use");
            }

            User user = new Entities.Models.User() {
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Gender = userViewModel.Gender,
                BirthDate = userViewModel.BirthDate,
                Email = userViewModel.Email,
                ProfilePictureUrl = "Images/defaultProfilePic.jpg"
            };
            user.Password = PasswordHasher.HashPassword(userViewModel.Password);
            user.Id = Guid.NewGuid();
            user.CreatedDate = DateTime.Now;

            
            db.RegisterUser(user);
            infoRep.AddProfileInfo(new ProfileInfo()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Hobbies = "",
                RelatieStatus = "",
                School = "",
                Werk = "",
                Woonplaats = ""
            });

            return Ok();
        }

        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult UpdatePassword(Guid Id, string oldpassword, string newpassword)
        {
            UserRepository db = new UserRepository();
            User user = db.GetUser(Id);
            if (!user.Password.Equals(PasswordHasher.HashPassword(oldpassword)))
            {
                throw new Exception("Old Password does not match");
            }

            user.Password = PasswordHasher.HashPassword(newpassword);

            db.UpdateUser(user);

            return Ok();
        }
    }
}
