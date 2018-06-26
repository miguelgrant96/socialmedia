using project2._4.DAL;
using project2._4.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.BL.Repositories
{
    public class FeedDiscussionRepository
    {
        private DatabaseContext db;

        public FeedDiscussionRepository()
        {
            this.db = new DatabaseContext();
        }

        public List<FeedDiscussion> GetFeedDiscussions(Guid FeedId)
        {
            return db.FeedDiscussions.Where(x => x.Feed_Id.Equals(FeedId)).ToList();
        }

        public FeedDiscussion GetFeedDiscussion(Guid id)
        {
            return db.FeedDiscussions.Find(id);
        }

        public void CreateFeedDiscussion(FeedDiscussion feedDis)
        {
            db.FeedDiscussions.Add(feedDis);
            db.SaveChanges();
        }
    }
}
