using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerUnlimited.Classen;

namespace PowerUnlimited.Paginas
{
    public partial class AllArtikels : System.Web.UI.Page
    {
        private List<Artikel> mainArtikels;

        protected void Page_Load(object sender, EventArgs e)
        {
            Database.Instance.GetAlAccounts();
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
                LBArtikelen.Items.Add(post.ToString());
            }
        }
    }
}