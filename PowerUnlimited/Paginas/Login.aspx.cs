using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerUnlimited.Classen;

namespace PowerUnlimited.Paginas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginDiv.Visible = Database.Instance.WebGebruiker == null;
            LogoutDiv.Visible = Database.Instance.WebGebruiker != null;
        }

        protected void SubmitLoginForm(object o, EventArgs eventArgs)
        {
            string naam = loginNaam.Text;
            string ww = loginWW.Text;
            Database.Instance.Login(new MailAddress(naam), ww);

            Response.Redirect("MainPagina.aspx");
        }

        protected void btnLogout_OnClick(object sender, EventArgs e)
        {
            Database.Instance.Logout();
        }
    }
}