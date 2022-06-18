using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyMaker.Infrastructure.Persistence
{
    public class Party
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public string Images { get; set; }

        public double Price { get; set; }

        public int TotalAtendence { get; set; }
    }
}
