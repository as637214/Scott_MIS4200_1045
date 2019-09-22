using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scott_MIS4200_1045.Models
{
    public class footballPlayer
    {
        public int footballPlayerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string playerFullName {
            get { return firstName + ", " + lastName; }
                }
        public string position { get; set; }
        public DateTime footballPlayerSince { get; set; }
        // add any other fields as appropriate
        // a customer can have any number of orders, a 1:M relationship,
        // We represent this in the model with an ICollection
        // The syntax says we are creating an ICollection of Order objects,
        // (the name inside the <> is the object name),
        // and the local name of the collection will be Order
        // (the object name and the local name do not have to be the same)
        public ICollection<coordinationType> coordinationType { get; set; }
    }
}