using System;

namespace project2._4.Entities.ViewModels
{
    public class FeedDiscussionViewModel
    {

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePicUrl { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}