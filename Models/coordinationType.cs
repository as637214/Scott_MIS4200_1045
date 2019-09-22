using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scott_MIS4200_1045.Models
{
    public class coordinationType
    {
        public int coordinationTypeID { get; set; }
        public string description { get; set; }
        public string CoordinationName { get; set; }
        // add any other fields as appropriate
        //Product is on the "one" side of a one-to-many relationship with OrderDetail
        //we indicate that with an ICollection
        public int coachID  { get; set; }
        public int footballPlayerID { get; set; }
        public virtual footballPlayer footballPlayer { get; set; }
        public virtual coach coach { get; }
    }

}