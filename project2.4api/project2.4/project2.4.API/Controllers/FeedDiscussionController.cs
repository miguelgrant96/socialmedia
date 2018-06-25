using project2._4.BL.Repositories;
using project2._4.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace project2._4.API.Controllers
{
    public class FeedDiscussionController : ApiController
    {
        [HttpGet]
        [Authorize]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetFeedDiscussion(Guid FeedId)
        {
            FeedDiscussionRepository db = new FeedDiscussionRepository();
            return Ok(db.GetFeedDiscussions(FeedId));
        }

        [HttpPost]
        [Authorize]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult CreateFeedDiscussion(Guid FeedId , string CommentText)
        {
            if (FeedId.Equals(Guid.Empty) || CommentText == "" || CommentText == null)
            {
                throw new Exception("Geen comment ingevuld");
            }

            UserRepository UserRep = new UserRepository();
            FeedRepository FeedRep = new FeedRepository();
            FeedDiscussionRepository FeedDisRep = new FeedDiscussionRepository();
            FeedDiscussion Comment = new FeedDiscussion()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Text = CommentText,
                User_Id = UserRep.GetUserByEmail(User.Identity.Name).Id,
                Feed_Id = FeedRep.GetFeed(FeedId).Id
            };

            FeedDisRep.CreateFeedDiscussion(Comment);
            return Ok();
        }
    }
}
