using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerUnlimited.Classen
{
    public class Artikel : Post
    {
        public string Tags { get; set; }
        public Account Door { get; set; }

        public Artikel(int postId, string titel, string omschrijving, DateTime date, Account door, string tags)
            : base(postId, titel, omschrijving, date)
        {
            Door = door;
            Tags = tags;
        }

        public override string ToString()
        {
            return Titel.ToString() + " Door: " + Door.Naam;
        }
    }
}