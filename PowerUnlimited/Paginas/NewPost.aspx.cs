using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerUnlimited.Classen;

namespace PowerUnlimited.Paginas
{
    public partial class NewPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void UploadArtikel(object o, EventArgs eventArgs)
        {
            string at = ASoort.SelectedItem.ToString();
            string titel = tbTitel.Text;
            string body = tbBody.Text;
            Database.Instance.Uploadartikel(at, titel, body);
            Response.Redirect("MainPagina.aspx");
        }
    }
}