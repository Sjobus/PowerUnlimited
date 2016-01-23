using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using PowerUnlimited.Classen;

namespace PowerUnlimited.Paginas
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GebruikerMaken(object sender, EventArgs e)
        {
            string Deuser = UsernameBox.Text;
            string Hetww = Userww.Text;
            string wwControle = wwCheck.Text;
            MailAddress mail = new MailAddress(UserEmail.Text);
            if (Hetww == wwControle)
            {
                try
                {
                    Database.Instance.CreateAccount(Deuser, mail, Hetww);
                    Response.Redirect("MainPagina.aspx");
                }
                catch (OracleException)
                {
                    Debug.WriteLine("Oops, er is iets fout gegaan. probeer het later opnieuw");
                }
            }
        }
    }
}