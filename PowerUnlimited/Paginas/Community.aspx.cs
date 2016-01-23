using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerUnlimited.Classen;

namespace PowerUnlimited.Paginas
{
    public partial class Community : System.Web.UI.Page
    {
        private List<Thread> threadList;
        private Button myButton = new Button();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginDiv.Visible = Database.Instance.WebGebruiker != null;
            Database.Instance.GetAlAccounts();
            if (!Page.IsPostBack)
            {
                Upadte();
            }
            else
            {
                threadList = Session["threadList"] as List<Thread>;
            }
        }

        private void Upadte()
        {
            Database.Instance.KrijgAlleAccounts();
            LBThread.Items.Clear();
            threadList = Database.Instance.GeAllThreads();
            foreach (Thread post in threadList)
            {
                string btnText = post.ToString();
                LBThread.Items.Add(post.ToString());
                myButton.Text = "fucking bitch nigger";
                myButton.PostBackUrl = "Paginas/Login.aspx";
                myButton.ID = Convert.ToString(post.PostId);
                myButton.Visible = true;
                myButton.Enabled = true;
            }
        }
    }
}