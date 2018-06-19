using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.Entities.Models
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string RefreshToken_ID { get; set; }
        public string Subject { get; set; }
        public string Client_Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ExpiresDateTime { get; set; }
        public string ProtectedTicket { get; set; }
    }
}
