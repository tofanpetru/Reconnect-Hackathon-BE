using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyMaker.Infrastructure.Persistence
{
    public class Review
    {
        public Guid Id { get; set; }
        public ApplicationUser MyProperty { get; set; }
        public string Content { get; set; }
        public int Reviewers { get; set; }
    }
}
