using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace PowerUnlimited.Classen
{
    public abstract class Account
    {
        public int AccountId { get; set; }
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
        public MailAddress Email { get; set; }
        public bool Moderator { get; set; }

        public Account(int accountId, string naam, string wachtwoord, MailAddress email, bool moderator)
        {
            AccountId = accountId;
            Naam = naam;
            Wachtwoord = wachtwoord;
            Email = email;
        }
    }
}