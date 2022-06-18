using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyMaker.Domain.Entities
{
    public class Party
	{
        //        #party
        //{
        //	Id: Guid
        //	Description: String
        //	Images: ["imgURL"...]
        //		Price: Double
        //		TotalAtendence: int
        //		Author: UserId
        //		Type: String
        //		LocationX: Double
        //		LocationY:	Double
        //		StartTime: DateTime
        //		EndTime: DateTime
        //		Preferences: [String]
        //		Reviews: [review1...]


        public Guid Id { get; set; }
        public string Description { get; set; }

        public string Images { get; set; }

        public double Price { get; set; }

        public int TotalAtendence { get; set; }

        Prop
    }
}
}
