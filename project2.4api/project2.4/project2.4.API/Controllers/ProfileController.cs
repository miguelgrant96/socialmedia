using project2._4.BL.Repositories;
using project2._4.Entities.ViewModels;
using project2._4.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace project2._4.API.Controllers
{
    public class ProfileController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetProfile(Guid Id)
        {
            UserRepository db = new UserRepository();
            User user = db.GetUser(Id);
            ProfileViewModel viewmodel = new ProfileViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Gender,
                BirthDate = user.BirthDate
            };

            return Ok(viewmodel);
               
        }

        [HttpPut]
        public IHttpActionResult UpdateProfile([FromBody] ProfileViewModel viewModel)
        {
            UserRepository db = new UserRepository();
            User user = db.GetUser(viewModel.Id);
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.Email = viewModel.Email;
            user.BirthDate = viewModel.BirthDate;
            user.Gender = viewModel.Gender;

            db.UpdateUser(user);
            return Ok();
        }
    }
}
