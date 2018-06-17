using project2._4.BL.Repositories;
using project2._4.Entities.Models;
using project2._4.Entities.ViewModels;
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
        [HttpGet]
        public IHttpActionResult GetFeed()
        {
            List<Feed> Feed = new List<Feed>();
            FeedRepository db = new FeedRepository();
            UserRepository userRep = new UserRepository();
            Feed.AddRange(db.GetTextFeed());
            Feed.AddRange(db.GetImageFeed());
            Feed.AddRange(db.GetVideoFeed());
            Feed.OrderBy(x => x.CreatedAt);

            List<FeedViewModel> viewmodels = new List<FeedViewModel>();
            foreach (Feed feed in Feed)
            {
                viewmodels.Add(new FeedViewModel() {
                    Feed = feed,
                    Creator = userRep.GetUser(feed.CreatorId)

                });
            }

            return Ok(viewmodels);
        }

        [HttpPost]
        public IHttpActionResult CreateFeed(string text, string imageurl, string videourl)
        {
            FeedRepository db = new FeedRepository();
            UserRepository rep = new UserRepository();
            User user = rep.GetAllUsers().First();
            if (imageurl == null && videourl == null)
            {
                TextFeed textFeed = new TextFeed();
                textFeed.Id = Guid.NewGuid();
                textFeed.Text = text;
                textFeed.CreatorId = user.Id;
                textFeed.CreatedAt = DateTime.Now;
                db.CreateTextFeed(textFeed);
                return Ok();
            }
            if (imageurl != null)
            {
                ImageFeed imageFeed = new ImageFeed();
                imageFeed.Id = Guid.NewGuid();
                imageFeed.Text = text;
                imageFeed.CreatorId = user.Id;
                imageFeed.CreatedAt = DateTime.Now;
                imageFeed.ImageUrl = imageurl;
                db.CreateImageFeed(imageFeed);
                return Ok();
            }

            if (videourl != null)
            {
                VideoFeed videoFeed = new VideoFeed();
                videoFeed.Id = Guid.NewGuid();
                videoFeed.DescriptionText = text;
                videoFeed.CreatorId = user.Id;
                videoFeed.CreatedAt = DateTime.Now;
                videoFeed.VideoUrl = videourl;
                db.CreateVideoFeed(videoFeed);
                return Ok();
            }
                

            return Ok();
        }
    }
}
