using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.Entities.Models
{
    public class ProfileInfo
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Werk { get; set; }

        public string School { get; set; }

        public string Woonplaats { get; set; }

        public string RelatieStatus { get; set; }

        public string Hobbies { get; set; }
    }
}
