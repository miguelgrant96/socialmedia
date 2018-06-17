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
    public class FeedController : ApiController
    {
        public IHttpActionResult GetFeed()
        {
            List<Feed> Feed = new List<Feed>();
            FeedRepository db = new FeedRepository();
            Feed.AddRange(db.GetTextFeed());
            Feed.AddRange(db.GetImageFeed());
            Feed.AddRange(db.GetVideoFeed());
            Feed.OrderBy(x => x.CreatedAt);

            return Ok(Feed);
        }

        public IHttpActionResult CreateFeed(TextFeed textfeed, ImageFeed imageFeed, VideoFeed videoFeed)
        {
            FeedRepository db = new FeedRepository();

            if (textfeed != null)
                db.CreateTextFeed(textfeed);
            if (imageFeed != null)
                db.CreateImageFeed(imageFeed);
            if (videoFeed != null)
                db.CreateVideoFeed(videoFeed);

            return Ok();
        }
    }
}
