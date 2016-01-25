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
            MailAddress mail = new MailAddress("Jan@jan.nl");
            string naam = "JAN";
            int verwachtAccountId = 22;
            string verwachtAccountType = "redacteur";
            Database.Instance.Login(mail, "QWERTY");
            Assert.AreEqual(verwachtAccountId,Database.Instance.WebGebruiker.ID, "Webgebruiker Id incorrect.");
            Assert.AreEqual(naam,Database.Instance.WebGebruiker.GebruikerNaam,"Gebruikernaam incorrect.");
            Assert.AreEqual(verwachtAccountType,Database.Instance.WebGebruiker.AccountType,"AccountType incorrect.");

        }
    }
}
