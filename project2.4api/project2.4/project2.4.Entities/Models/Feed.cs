﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.Entities.Models
{
    public class Feed
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid CreatorId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Respect { get; set; }

        public virtual List<FeedDiscussion> Comments { get; set; }
    }
}
