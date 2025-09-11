////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Web;
////using System.Web.UI;
////using System.Web.UI.WebControls;

////namespace Assignment2
////{
////    public partial class BillEntry : System.Web.UI.Page
////    {
////        private ElectricityBoard _board = new ElectricityBoard();

////        public int LeftToAdd
////        {
////            get { return (int)(Session["LeftToAdd"] ?? 0); }
////            set { Session["LeftToAdd"] = value; }
////        }

////        protected void Page_Load(object sender, EventArgs e)
////        {
////            if (Session["auth"] == null)   // not logged in
////            {
////                Response.Redirect("Login.aspx");
////            }
////            if (!IsPostBack) LeftToAdd = Math.Max(1, int.TryParse(txtCount.Text, out var c) ? c : 1);
////        }

////        //protected void btnAdd_Click(object sender, EventArgs e)
////        //{

////        //    lblMsg.Text = ""; lblOut.Text = "";

////        //    if (LeftToAdd <= 0) LeftToAdd = Math.Max(1, int.TryParse(txtCount.Text, out var c) ? c : 1);

////        //    // Validation 1: consumer number
////        //    try { 
////        //        BillValidator.ValidateConsumerNumberOrThrow(txtCN.Text.Trim()); 
////        //    }
////        //    catch (FormatException ex) { 
////        //        lblMsg.Text = ex.Message; return; 
////        //    }

////        //    // Validation 2: units
////        //    if (!int.TryParse(txtUnits.Text.Trim(), out int units))
////        //    { 
////        //        lblMsg.Text = "Given units is invalid"; 
////        //        return; 
////        //    }

////        //    string unitsErr = BillValidator.ValidateUnitsConsumed(units);
////        //    if (!string.IsNullOrEmpty(unitsErr)) { 
////        //        lblMsg.Text = unitsErr; return; 
////        //    }


////        //    var eb = new ElectricityBill
////        //    {
////        //        ConsumerNumber = txtCN.Text.Trim(),
////        //        ConsumerName = txtName.Text.Trim(),
////        //        UnitsConsumed = units
////        //    };

////        //    // calculate + save
////        //    _board.CalculateBill(eb);
////        //    _board.AddBill(eb);

////        //    lblOut.Text = $"{eb.ConsumerNumber} {eb.ConsumerName} {eb.UnitsConsumed} Bill Amount : {eb.BillAmount}";

////        //    LeftToAdd--;
////        //    if (LeftToAdd > 0)
////        //    {
////        //        lblMsg.Text = $"Saved. Enter next customer ({LeftToAdd} left).";
////        //        txtCN.Text = txtName.Text = txtUnits.Text = "";
////        //        txtCN.Focus();
////        //    }
////        //    else
////        //    {
////        //        lblMsg.Text = "All entries saved.";
////        //    }
////        //}
////        protected void btnSave_Click(object sender, EventArgs e)
////        {
////            try
////            {
////                string consumerNo = txtCN.Text.Trim();
////                string name = txtName.Text.Trim();
////                int units = int.Parse(txtUnits.Text);

////                double amount = CalculateBill(units);

////                btnSave.Enabled = false;
////                LeftToAdd--;   // <-- keep this as a static or session variable tracking how many are left

////                if (LeftToAdd > 0)
////                {
////                    lblMsg.Text = $"Saved. Enter next customer ({LeftToAdd} left).";
////                    txtCN.Text = txtName.Text = txtUnits.Text = "";
////                    btnSave.Enabled = true;   // allow next entry
////                    txtCN.Focus();
////                }
////                else
////                {
////                    lblMsg.Text = "All entries saved.";
////                }
////            }
////            catch (Exception ex)
////            {
////                lblMsg.Text = "Error: " + ex.Message;
////            }
////        }

////    }
////}

//using System;

//namespace Assignment2
//{
//    public partial class BillEntry : System.Web.UI.Page
//    {
//        // 1) Keep this field: we use the board for CalculateBill + AddBill
//        private readonly ElectricityBoard _board = new ElectricityBoard();

//        // 2) Keep LeftToAdd inside the class (not inside a method)
//        public int LeftToAdd
//        {
//            get { return (int)(Session["LeftToAdd"] ?? 0); }
//            set { Session["LeftToAdd"] = value; }
//        }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (Session["auth"] == null) { Response.Redirect("Login.aspx"); return; }

//            if (!IsPostBack)
//            {
//                // initialize how many bills to add (textbox on the page named txtCount)
//                LeftToAdd = Math.Max(1, int.TryParse(txtCount.Text, out var c) ? c : 1);
//            }
//        }

//        protected void btnSave_Click(object sender, EventArgs e)
//        {
//            lblMsg.Text = ""; lblOut.Text = "";

//            // If first click and LeftToAdd somehow zero, refresh from txtCount
//            if (LeftToAdd <= 0)
//                LeftToAdd = Math.Max(1, int.TryParse(txtCount.Text, out var cnt) ? cnt : 1);

//            try
//            {
//                // Validate consumer number per requirement (throws FormatException if invalid)
//                BillValidator.ValidateConsumerNumberOrThrow(txtCN.Text.Trim());

//                // Validate units
//                if (!int.TryParse(txtUnits.Text.Trim(), out int units))
//                { lblMsg.Text = "Given units is invalid"; return; }

//                string uErr = BillValidator.ValidateUnitsConsumed(units);
//                if (!string.IsNullOrEmpty(uErr))
//                { lblMsg.Text = uErr; return; }

//                // Build the model
//                var eb = new ElectricityBill
//                {
//                    ConsumerNumber = txtCN.Text.Trim(),
//                    ConsumerName = txtName.Text.Trim(),
//                    UnitsConsumed = units
//                };

//                // *** This is the important part: call ElectricityBoard.CalculateBill ***
//                _board.CalculateBill(eb);   // <-- instead of CalculateBill(units)
//                _board.AddBill(eb);

//                // Show sample-style line
//                lblOut.Text = $"{eb.ConsumerNumber} {eb.ConsumerName} {eb.UnitsConsumed} Bill Amount : {eb.BillAmount}";

//                // Prevent double submit for this record
//                btnSave.Enabled = false;

//                // Prepare for next record if N > 1
//                LeftToAdd--;
//                if (LeftToAdd > 0)
//                {
//                    lblMsg.Text = $"Saved. Enter next customer ({LeftToAdd} left).";
//                    txtCN.Text = txtName.Text = txtUnits.Text = "";
//                    btnSave.Enabled = true;   // re-enable for the next entry
//                    txtCN.Focus();
//                }
//                else
//                {
//                    lblMsg.Text = "All entries saved.";
//                }
//            }
//            catch (FormatException ex)
//            {
//                // from ValidateConsumerNumberOrThrow
//                lblMsg.Text = ex.Message;
//            }
//            catch (Exception ex)
//            {
//                lblMsg.Text = "Error: " + ex.Message;
//            }
//        }
//    }
//}

//using System;

//namespace Assignment2
//{
//    public partial class BillEntry : System.Web.UI.Page
//    {
//        private readonly ElectricityBoard _board = new ElectricityBoard();

//        // remembers how many entries remain in this session
//        public int LeftToAdd
//        {
//            get { return (int)(Session["LeftToAdd"] ?? 0); }
//            set { Session["LeftToAdd"] = value; }
//        }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (Session["auth"] == null) { Response.Redirect("Login.aspx"); return; }

//            if (!IsPostBack)
//            {
//                LeftToAdd = Math.Max(1, int.TryParse(txtCount.Text, out var c) ? c : 1);
//            }
//        }

//        protected void btnSave_Click(object sender, EventArgs e)
//        {
//            lblMsg.Text = ""; lblOut.Text = "";

//            // if somehow 0, sync from txtCount
//            if (LeftToAdd <= 0)
//                LeftToAdd = Math.Max(1, int.TryParse(txtCount.Text, out var cnt) ? cnt : 1);

//            try
//            {
//                // validate consumer number
//                BillValidator.ValidateConsumerNumberOrThrow(txtCN.Text.Trim());

//                // validate units
//                if (!int.TryParse(txtUnits.Text.Trim(), out int units))
//                { lblMsg.Text = "Given units is invalid"; return; }

//                string uErr = BillValidator.ValidateUnitsConsumed(units);
//                if (!string.IsNullOrEmpty(uErr)) { lblMsg.Text = uErr; return; }

//                // build model
//                var eb = new ElectricityBill
//                {
//                    ConsumerNumber = txtCN.Text.Trim(),
//                    ConsumerName = txtName.Text.Trim(),
//                    UnitsConsumed = units
//                };

//                // calculate & save
//                _board.CalculateBill(eb);     // <-- THIS is why CalculateBill must exist in ElectricityBoard
//                _board.AddBill(eb);

//                // show output in sample format
//                lblOut.Text = $"{eb.ConsumerNumber} {eb.ConsumerName} {eb.UnitsConsumed} Bill Amount : {eb.BillAmount}";

//                // prevent double submit for this record
//                btnSave.Enabled = false;

//                // prepare next if N>1
//                LeftToAdd--;
//                if (LeftToAdd > 0)
//                {
//                    lblMsg.Text = $"Saved. Enter next customer ({LeftToAdd} left).";
//                    txtCN.Text = txtName.Text = txtUnits.Text = "";
//                    btnSave.Enabled = true;      // re-enable for the next entry
//                    txtCN.Focus();
//                }
//                else
//                {
//                    lblMsg.Text = "All entries saved.";
//                }
//            }
//            catch (FormatException ex)
//            {
//                lblMsg.Text = ex.Message; // "Invalid Consumer Number"
//            }
//            catch (Exception ex)
//            {
//                lblMsg.Text = "Error: " + ex.Message;
//            }
//        }

//        protected void btnLogout_Click(object sender, EventArgs e)
//        {
//            Session.Clear();
//            Response.Redirect("Login.aspx");
//        }
//    }
//}





using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
 
public partial class BillEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadBills();
        }
    }

    // 🔹 Save button click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string consumerNo = txtCN.Text.Trim();
            string name = txtName.Text.Trim();
            int units = int.Parse(txtUnits.Text.Trim());

            // Calculate bill amount
            double amount = 0;
            if (units <= 100)
                amount = units * 1.5;
            else if (units <= 200)
                amount = (100 * 1.5) + ((units - 100) * 2.5);
            else
                amount = (100 * 1.5) + (100 * 2.5) + ((units - 200) * 3.5);

            // Insert into DB
            using (SqlConnection con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["EBillCon"].ConnectionString))
            {
                string query = "INSERT INTO ElectricityBill ([consumer number], [consumer name], [units consumed], bill_amount) " +
                               "VALUES (@no, @name, @units, @amount)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@no", consumerNo);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@units", units);
                cmd.Parameters.AddWithValue("@amount", amount);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            // Show success + refresh grid
            lblMsg.Text = "Saved successfully!";
            LoadBills();

            // Clear input boxes
            txtCN.Text = txtName.Text = txtUnits.Text = "";
            txtCN.Focus();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error: " + ex.Message;
        }
    }

    // 🔹 Load all bills to GridView
    private void LoadBills()
    {
        using (SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["EBillCon"].ConnectionString))
        {
            string query = "SELECT * FROM ElectricityBill ORDER BY id DESC";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gv.DataSource = dt;
            gv.DataBind();
        }
    }
}
