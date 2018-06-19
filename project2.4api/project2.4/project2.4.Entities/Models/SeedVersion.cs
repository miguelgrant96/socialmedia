using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.Entities.Models
{
    public class SeedVersion
    {
        public SeedVersion(string id)
        {
            this.Id = Guid.Parse(id);
        }

        public SeedVersion()
        {

        }

        public Guid Id { get; set; }
    }
}
