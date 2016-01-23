using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace PowerUnlimited.Classen
{
    public class Redacteur : Account
    {
        public Redacteur(int accountId, string naam, string wachtwoord, MailAddress email, bool moderator)
            : base(accountId, naam, wachtwoord, email, moderator)
        {
        }
    }
}