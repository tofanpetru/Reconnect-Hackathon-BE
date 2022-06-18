using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PartyMaker.Infrastructure.Persistence
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityCard { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
