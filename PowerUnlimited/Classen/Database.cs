using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

namespace PowerUnlimited.Classen
{
    public class Database
    {
        private static Database instance;
        public List<Artikel> Artikelen;
        private List<Post> postList;
        private List<Comment> commentlComments;
        private List<Thread> threadList;
        private List<Game> gameList;
        private List<Account> accounts;
        // de connectie string voor de database
        private const string databseString =
            "User Id=dbi325455;Password=PYvRaqVTfP;Data Source=fhictora01.fhict.local:1521/fhictora;";
        // de ingelogde gebruiker
        public IAccount WebGebruiker { get; set; }
        //database instance
        public static Database Instance
        {
            get { return instance ?? (instance = new Database()); }
        }
        // kijken of ik verbinding kan maken met de database
        private Database()
        {
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                }
                catch (OracleException e)
                {
                    Debug.WriteLine("Kan geen verbinding maken met Oracle databse, Error: " + e.Message);
                }
            }
        }

        /// <summary>
        /// returnt de connectie string
        /// </summary>
        /// <returns></returns>
        private static OracleConnection GetConnection()
        {
            return new OracleConnection(databseString);
        }
        /// <summary>
        /// Log een gebruiker in.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="wachtwoord"></param>
        /// <returns></returns>
        public IAccount Login(MailAddress email, string wachtwoord)
        {
            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "Select * from Account where Email = '" + email.Address
                                   + "' and Wachtwoord = '" + wachtwoord + "'";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string userwachtwoord = reader["Wachtwoord"].ToString();
                                string naam = reader["NAAM"].ToString();
                                string userEmail = reader["EMAIL"].ToString();
                                int userID = Convert.ToInt32(reader["ACCOUNTNR"]);
                                if (wachtwoord == userwachtwoord && email.Address == userEmail)
                                {
                                    WebGebruiker = new IAccount(userID, naam, new MailAddress(userEmail));
                                }
                            }
                        }
                    }
                }
            }
            catch (OracleException e)
            {
                Debug.WriteLine("Oops!! Er is iets misgegaan, Error: " + e.Message);
            }
            return WebGebruiker;
        }
        /// <summary>
        /// log de ingelogde gebruiker uit
        /// </summary>
        public void Logout()
        {
            WebGebruiker = null;
        }
        /// <summary>
        /// maakt een nieuwe account aan en schrijft hem naar de database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="wachwoord"></param>
        /// <returns></returns>
        public Gebruiker CreateAccount(string username, MailAddress email, string wachwoord)
        {
            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    string accounType = "lid";
                    string query = "INSERT INTO ACCOUNT (ACCOUNTNR,NAAM,EMAIL,WACHTWOORD,ACCOUNTTYPE)" +
                                   " VALUES(seq_Account.nextval,'" + username + "','" + email.Address + "','" +
                                   wachwoord +
                                   "','" + accounType + "')";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OracleException e)
            {
                Debug.WriteLine("Oops er is iets mis met de baklap van een server, error: " + e.Message);
            }
            return null;
        }

        public object IAccount { get; set; }
        /// <summary>
        /// haal alle cach accounts op
        /// </summary>
        /// <returns></returns>
        public List<Account> KrijgAlleAccounts()
        {
            if (accounts == null)
            {
                accounts = GetAlAccounts();
            }
            return accounts;
        }
        /// <summary>
        /// haal alle account op
        /// </summary>
        /// <returns></returns>
        public List<Account> GetAlAccounts()
        {
            List<Account> accountlijst = new List<Account>();

            using (OracleConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from account";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            switch (reader["ACCOUNTTYPE"].ToString())
                            {
                                case "redacteur":
                                    int accountId = Convert.ToInt32(reader["AccountNR"]);
                                    string accountnaam = reader["NAAM"].ToString();
                                    MailAddress email = new MailAddress(reader["email"].ToString());
                                    string ww = reader["Wachtwoord"].ToString();
                                    bool mod = Convert.ToBoolean(reader["MODERATOR"]);

                                    Redacteur re = new Redacteur(accountId, accountnaam, ww, email, mod);
                                    accountlijst.Add(re);

                                    break;
                                case "lid":
                                    accountId = Convert.ToInt32(reader["AccountNR"]);
                                    accountnaam = reader["NAAM"].ToString();
                                    email = new MailAddress(reader["email"].ToString());
                                    ww = reader["Wachtwoord"].ToString();
                                    mod = Convert.ToBoolean(reader["MODERATOR"]);
                                    Gebruiker ge = new Gebruiker(accountId, accountnaam, ww, email, mod);
                                    accountlijst.Add(ge);

                                    break;
                            }
                        }
                    }
                }
                return accountlijst;
            }
        }
        /// <summary>
        /// hall alle artikelen op
        /// </summary>
        /// <returns></returns>
        public List<Artikel> GetAlArtikels()
        {
            List<Artikel> artikelList = new List<Artikel>();

            using (OracleConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select p.*,a.* from POST p, ARTIKEL a";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            switch (reader["postType"].ToString())
                            {
                                case "artikel":
                                    int id = Convert.ToInt32(reader["POSTNR"]);
                                    int prId = Convert.ToInt32(reader["POSTERNR"]);
                                    string titel = reader["Titel"].ToString();
                                    string body = reader["TEXT"].ToString();
                                    DateTime date = Convert.ToDateTime(reader["Datum"]);
                                    string at = reader["ARTIKELTYPE"].ToString();
                                    int arID = Convert.ToInt32(reader["PostID"]);

                                    foreach (Account a  in accounts)
                                    {
                                        if (a.AccountId == prId)
                                        {
                                            Artikel ar = new Artikel(id, titel, body, date, a, "Actie");
                                            artikelList.Add(ar);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
                return artikelList;
            }
        }
        /// <summary>
        /// haal alle threads op
        /// </summary>
        /// <returns></returns>
        public List<Thread> GeAllThreads()
        {
            List<Thread> threadList = new List<Thread>();
            using (OracleConnection conn = GetConnection())
            {
                conn.Open();
                string query = "Select p.*, t.* from post p, thread_table t";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            switch (reader["Posttype"].ToString())
                            {
                                case "thread":
                                    int id = Convert.ToInt32(reader["POSTNR"]);
                                    int prId = Convert.ToInt32(reader["POSTERNR"]);
                                    string titel = reader["Titel"].ToString();
                                    string body = reader["TEXT"].ToString();
                                    DateTime date = Convert.ToDateTime(reader["Datum"]);
                                    int arID = Convert.ToInt32(reader["PostID"]);
                                    bool open = Convert.ToBoolean(reader["THREADOPEN"]);
                                    foreach (Account a  in accounts)
                                    {
                                        if (a.AccountId == prId)
                                        {
                                            Thread thread = new Thread(id, titel, body, date, open, a);
                                            threadList.Add(thread);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
                return threadList;
            }
        }
    }
}