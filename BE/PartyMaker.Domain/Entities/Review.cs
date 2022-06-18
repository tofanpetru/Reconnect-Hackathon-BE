using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyMaker.Domain.Entities
{
    public class Review
    {
        //    Id: Guid
        //UserId: Guid
        //Content: String
        //Review: Int


        public Guid Id { get; set; }
        public User MyProperty { get; set; }
        public string Content { get; set; }
        public int Reviewers { get; set; }

    }
}
