using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace PowerUnlimited.Classen
{
    public class Gebruiker : Account
    {
        public string adres { get; set; }
        public int huisNr { get; set; }
        public string woonplaats { get; set; }

        public Gebruiker(int accountId, string naam, string wachtwoord, MailAddress email, bool moderator)
            : base(accountId, naam, wachtwoord, email, moderator)
        {
        }
    }
}