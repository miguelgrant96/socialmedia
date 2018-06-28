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

        public TextFeed GetTextFeed(Guid Id)
        {
            return db.FeedTexts.Find(Id);
        }
        public ImageFeed GetImageFeed(Guid Id)
        {
            return db.ImageFeeds.Find(Id);
        }
        public VideoFeed GetVideoFeed(Guid Id)
        {
            return db.VideoFeeds.Find(Id);
        }

        public List<Feed> GetUserFeed(Guid userId)
        {
            List<Feed> userFeed = new List<Feed>();
            userFeed.AddRange(db.FeedTexts.Where(x => x.CreatorId.Equals(userId)));
            userFeed.AddRange(db.VideoFeeds.Where(x => x.CreatorId.Equals(userId)));
            userFeed.AddRange(db.ImageFeeds.Where(x => x.CreatorId.Equals(userId)));
            return userFeed;
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

        public void UpdateTextFeed(TextFeed feed)
        {
            db.FeedTexts.Attach(feed);
            db.Entry(feed).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateImageFeed(ImageFeed feed)
        {
            db.ImageFeeds.Attach(feed);
            db.Entry(feed).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateVideoFeed(VideoFeed feed)
        {
            db.VideoFeeds.Attach(feed);
            db.Entry(feed).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
