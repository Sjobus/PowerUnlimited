using System;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerUnlimited.Classen;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogin()
        {
            // test login
            MailAddress mail = new MailAddress("Jan@jan.nl");
            string naam = "JAN";
            int verwachtAccountId = 22;
            string verwachtAccountType = "redacteur";
            Database.Instance.Login(mail, "QWERTY");
            Assert.AreEqual(verwachtAccountId,Database.Instance.WebGebruiker.ID, "Webgebruiker Id incorrect.");
            Assert.AreEqual(naam,Database.Instance.WebGebruiker.GebruikerNaam,"Gebruikernaam incorrect.");
            Assert.AreEqual(verwachtAccountType,Database.Instance.WebGebruiker.AccountType,"AccountType incorrect.");

        }
    [TestMethod]
        public void TestGetAccountCreate()
        {
            int verwachtID = 1;
            string verwachtNaam = "Cees";
            string verwachtWW = "qwerty";
            string verwachtEmail = "Cees@hotmail.com";
            MailAddress mail = new MailAddress("Cees@hotmail.com");
            Gebruiker testGebruiker = Database.Instance.CreateAccount("Cees",mail,"qwerty");
            Assert.AreEqual(verwachtID,testGebruiker.AccountId,"AccountID incorrect.");
            Assert.AreEqual(verwachtNaam,testGebruiker.Naam,"Gebruikernaam incorrect.");
            Assert.AreEqual(verwachtWW,testGebruiker.Wachtwoord,"Wachtwoord inccorect.");
            Assert.AreEqual(verwachtEmail,testGebruiker.Email.ToString(),"Email incorrect.");
        }
    }
}
