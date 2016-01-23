using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerUnlimited.Classen
{
    public class Thread : Post
    {
        // een bool om te kijken of de Thread nog open is. staat standaart op true
        public bool open;
        public Account webAccount;

        public Thread(int postId, string titel, string omschrijving, DateTime date, bool open, Account account)
            : base(postId, titel, omschrijving, date)
        {
            this.open = open;
            webAccount = account;
        }

        public override string ToString()
        {
            return Titel + " Door: " + webAccount.Naam + " op:" + Datum;
        }
    }
}