using project2._4.DAL;
using project2._4.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.BL.Repositories
{
    public class FeedRepository
    {
        private DatabaseContext db;

        public FeedRepository()
        {
            this.db = new DatabaseContext();
        }

        public Feed GetFeed(Guid Id)
        {
            Feed feed = db.FeedTexts.Find(Id);
            if (feed == null)
            {
                feed = db.ImageFeeds.Find(Id);
            }
            if (feed == null)
            {
                feed = db.VideoFeeds.Find(Id);
            }

            return feed;

        }

        public List<TextFeed> GetTextFeed()
        {
            return db.FeedTexts.ToList();
        }

        public List<ImageFeed> GetImageFeed()
        {
            return db.ImageFeeds.ToList();
        }

        public List<VideoFeed> GetVideoFeed()
        {
            return db.VideoFeeds.ToList();
        }

        public void CreateTextFeed(TextFeed feed)
        {
            db.FeedTexts.Add(feed);
            db.SaveChanges();
        }

        public void CreateImageFeed(ImageFeed feed)
        {
            db.ImageFeeds.Add(feed);
            db.SaveChanges();
        }

        public void CreateVideoFeed(VideoFeed feed)
        {
            db.VideoFeeds.Add(feed);
            db.SaveChanges();
        }
    }
}
