using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace PowerUnlimited.Classen
{
    public class IAccount
    {
        public int ID { get; set; }
        public string GebruikerNaam { get; set; }
        public MailAddress Email { get; set; }

        public IAccount(int id, string gebruikernaam, MailAddress email)
        {
            ID = id;
            GebruikerNaam = gebruikernaam;
            Email = email;
        }
    }
}