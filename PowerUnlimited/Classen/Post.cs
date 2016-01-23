using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerUnlimited.Classen
{
    public abstract class Post
    {
        public int PostId { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Datum { get; set; }


        public Post(int postId, string titel, string omschrijving, DateTime date)
        {
            PostId = postId;
            Titel = titel;
            Omschrijving = omschrijving;
            Datum = date;
        }

        public override string ToString()
        {
            return Titel;
        }
    }
}