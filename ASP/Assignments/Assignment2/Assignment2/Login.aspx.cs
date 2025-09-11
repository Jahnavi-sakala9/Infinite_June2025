using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //  hardcoded validation
            if (txtUser.Text == "admin" && txtPass.Text == "admin")
            {
                Session["auth"] = "ok"; // store login flag
                Response.Redirect("BillEntry.aspx"); // go to bill entry page
            }
            else
            {
                lblMsg.Text = "Invalid username or password.";
            }
        }
    }
}




