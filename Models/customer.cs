﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scott_MIS4200_1045.Models
{
    public class customer
    {
        public int customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public ICollection<order> orders { get; set; }
    }
}