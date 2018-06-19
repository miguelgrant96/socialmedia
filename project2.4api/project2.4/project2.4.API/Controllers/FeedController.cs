using project2._4.BL.Repositories;
using project2._4.Entities.Models;
using project2._4.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace project2._4.API.Controllers
{
    public class FeedController : ApiController
    {
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Authorize]
        public IHttpActionResult GetFeed()
        {
            List<Feed> Feed = new List<Feed>();
            FeedRepository db = new FeedRepository();
            Feed.AddRange(db.GetTextFeed());
            Feed.AddRange(db.GetImageFeed());
            Feed.AddRange(db.GetVideoFeed());
            Feed.OrderBy(x => x.CreatedAt);
            List<FeedViewModel> viewmodels = new List<FeedViewModel>();
            UserRepository userRep = new UserRepository();
            foreach (Feed feed in Feed)
            {
                viewmodels.Add(new FeedViewModel()
                {
                    Feed = feed,
                    Creator = userRep.GetUser(feed.CreatorId)

                });
            }

            return Ok(viewmodels);
        }
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Authorize]
        public IHttpActionResult CreateFeed(string Text,string imageurl, string videourl)
        {
            FeedRepository db = new FeedRepository();
            UserRepository userRep = new UserRepository();
            User user = userRep.GetUserByEmail(User.Identity.Name);

            if (Text == null || Text == "")
            {
                throw new Exception("Text was empty");
            }

            if (imageurl == null && videourl == null)
            {
                TextFeed textfeed = new TextFeed();
                textfeed.Id = Guid.NewGuid();
                textfeed.Text = Text;
                textfeed.CreatedAt = DateTime.Now;
                textfeed.CreatorId = user.Id;
                db.CreateTextFeed(textfeed);
                return Ok();
            }

            if (imageurl != null)
            {
                ImageFeed imageFeed = new ImageFeed();
                imageFeed.Id = Guid.NewGuid();
                imageFeed.Text = Text;
                imageFeed.CreatedAt = DateTime.Now;
                imageFeed.CreatorId = user.Id;
                imageFeed.ImageUrl = imageurl;
                db.CreateImageFeed(imageFeed);
                return Ok();
            }

            if (videourl != null)
            {
                VideoFeed videoFeed = new VideoFeed();
                videoFeed.Id = Guid.NewGuid();
                videoFeed.DescriptionText = Text;
                videoFeed.CreatedAt = DateTime.Now;
                videoFeed.CreatorId = user.Id;
                videoFeed.VideoUrl = videourl;
                db.CreateVideoFeed(videoFeed);
                return Ok();
            }

            throw new Exception("No feed was created.");
        }
    }
}
