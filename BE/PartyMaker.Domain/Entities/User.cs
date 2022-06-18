using System;
using System.Collections.Generic;

namespace PartyMaker.Domain.Entities
{
    public class User
    {
        public string IdentityCard { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public int Age { get; set; }
        public bool Verified { get; set; }
        public bool EmailVerified { get; set; }
        public string Phone { get; set; }
        public bool PhoneVerified { get; set; }
    }
}
