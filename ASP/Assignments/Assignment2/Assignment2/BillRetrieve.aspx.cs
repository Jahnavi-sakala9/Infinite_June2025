using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2
{
    public partial class BillRetrieve : System.Web.UI.Page
    {
        ElectricityBoard _board = new ElectricityBoard();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth"] == null)   // not logged in
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void btnGet_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtN.Text.Trim(), out int n) || n <= 0) return;
            gv.DataSource = _board.Generate_N_BillDetails(n);
            gv.DataBind();
        }
    }
}



