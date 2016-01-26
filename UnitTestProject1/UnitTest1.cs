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
        // test het inloggen van een gebruiker.
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

    [TestMethod]
        // test het aanmaken van een account.
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

        [TestMethod]
        // Test het uploaden van artikelen door eerst te tellen hoeveel post er in de databse zitten.
        // dan er een toe te voegen en het totaal weer op vragen. die twee vergelijk ik met elkaar.
        public void TestUploadArtikel()
        {
            string query = "Select Count(POSTNR) as teller from  post";
            int countVoor = Convert.ToInt32(Database.Instance.GetCount(query));
            int countVerwacht = countVoor + 1;
            Database.Instance.Login(new MailAddress("Jan@jan.nl"), "QWERTY");
            Database.Instance.Uploadartikel("N8W8","UnitTest","Unitest");
            int countNa = Convert.ToInt32(Database.Instance.GetCount(query));
            Assert.AreEqual(countVerwacht,countNa,"het is niet gelukt om iet te uploaden");
        }

        [TestMethod]
        // test het uploaden van een thread naar de database.
        public void TestUploadThread()
        {
            string query = "Select Count(POSTNR) as teller from  post";
            int countVoor = Convert.ToInt32(Database.Instance.GetCount(query));
            Database.Instance.Login(new MailAddress("Jan@jan.nl"), "QWERTY");
            Database.Instance.UploadThread("UniThread","UniThread body");
            int countNa = Convert.ToInt32(Database.Instance.GetCount(query));
            Assert.AreNotEqual(countVoor,countNa,"Ze zijn wel gelijk :(");
        }

        [TestMethod]
        // test het uitloggen van de ingelogde gebruiker.
        public void TestLogout()
        {
            IAccount testVoor =Database.Instance.Login(new MailAddress("Jan@jan.nl"), "QWERTY");
            Database.Instance.Logout();
            Assert.AreNotEqual(testVoor,Database.Instance.WebGebruiker,"ze zijn niet het zelfde");
        }
    }
}
