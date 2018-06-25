using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.Entities.Models
{
    public class UserSettings
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string SeeMyMessages { get; set; }

        public string SentFriendRequests { get; set; }

        public string SeeFriendList { get; set; }

        public string TagMe { get; set; }
    }
}
