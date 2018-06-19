using project2._4.BL.Repositories;
using project2._4.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace project2._4.API.Controllers
{
    public class FeedDiscussionController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetFeedDiscussion(Guid FeedId)
        {
            FeedDiscussionRepository db = new FeedDiscussionRepository();
            return Ok(db.GetFeedDiscussions(FeedId));
        }

        public IHttpActionResult CreateFeedDiscussion([FromBody] FeedDiscussion feedDis)
        {
            FeedDiscussionRepository db = new FeedDiscussionRepository();
            db.CreateFeedDiscussion(feedDis);
            return Ok();
        }
    }
}
