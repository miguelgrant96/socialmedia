using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.Entities.Models
{
    public class FeedDiscussion
    {
        public Guid Id { get; set; }

        public Feed Feed { get; set; }

        public User User { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Text { get; set; }


    }
}
