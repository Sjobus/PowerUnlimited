using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerUnlimited.Classen
{
    public class Verkoop
    {
        public int verkoopId { get; set; }
        public double totaal { get; set; }

        public Verkoop(int verkoopId, double totaal)
        {
        }
    }
}