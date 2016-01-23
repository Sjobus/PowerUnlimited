using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerUnlimited.Classen;

namespace PowerUnlimited
{
    public partial class PU : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            logedinlabel.Text = Database.Instance.WebGebruiker == null
                ? "Login"
                : "Hallo " + Database.Instance.WebGebruiker.GebruikerNaam;
        }
    }
}