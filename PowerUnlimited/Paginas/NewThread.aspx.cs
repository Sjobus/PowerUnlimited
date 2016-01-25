using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerUnlimited.Classen;

namespace PowerUnlimited.Paginas
{
    public partial class NewThread : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void UploadThread(object o, EventArgs eventArgs)
        {
            string titel = tbTitel.Text;
            string body = tbBody.Text;
            Database.Instance.UploadThread(titel, body);
            Response.Redirect("MainPagina.aspx");
        }
    }
}