using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerUnlimited.Classen;

namespace PowerUnlimited.Paginas
{
    public partial class MainPagina : System.Web.UI.Page
    {
        private List<Artikel> mainArtikels;
        private Button myButton = new Button();

        protected void Page_Load(object sender, EventArgs e)
        {
            Database.Instance.KrijgAlleAccounts();
            if (!Page.IsPostBack)
            {
                Upadte();
            }
            else
            {
                mainArtikels = Session["mainArtikel"] as List<Artikel>;
            }
        }

        private void Upadte()
        {
            Database.Instance.KrijgAlleAccounts();
            LBArtikelen.Items.Clear();
            mainArtikels = Database.Instance.GetAlArtikels();
            foreach (Artikel post in mainArtikels)
            {
                string btnText = post.ToString();
                LBArtikelen.Items.Add(post.ToString());
                myButton.Text = "een knop";
                myButton.PostBackUrl = "Paginas/Login.aspx";
                myButton.ID = Convert.ToString(post.PostId);
                myButton.Visible = true;
                myButton.Enabled = true;
            }
        }
    }
}