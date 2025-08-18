using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2
{
    public partial class BillEntry : System.Web.UI.Page
    {
        private ElectricityBoard _board = new ElectricityBoard();

        private int LeftToAdd
        {
            get => (int)(ViewState["LeftToAdd"] ?? 0);
            set => ViewState["LeftToAdd"] = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LeftToAdd = Math.Max(1, int.TryParse(txtCount.Text, out var c) ? c : 1);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblMsg.Text = ""; lblOut.Text = "";

            if (LeftToAdd <= 0) LeftToAdd = Math.Max(1, int.TryParse(txtCount.Text, out var c) ? c : 1);

            // Validation 1: consumer number
            try { 
                BillValidator.ValidateConsumerNumberOrThrow(txtCN.Text.Trim()); 
            }
            catch (FormatException ex) { 
                lblMsg.Text = ex.Message; return; 
            }

            // Validation 2: units
            if (!int.TryParse(txtUnits.Text.Trim(), out int units))
            { 
                lblMsg.Text = "Given units is invalid"; 
                return; 
            }

            string unitsErr = BillValidator.ValidateUnitsConsumed(units);
            if (!string.IsNullOrEmpty(unitsErr)) { 
                lblMsg.Text = unitsErr; return; 
            }


            var eb = new ElectricityBill
            {
                ConsumerNumber = txtCN.Text.Trim(),
                ConsumerName = txtName.Text.Trim(),
                UnitsConsumed = units
            };

            // calculate + save
            _board.CalculateBill(eb);
            _board.AddBill(eb);

            lblOut.Text = $"{eb.ConsumerNumber} {eb.ConsumerName} {eb.UnitsConsumed} Bill Amount : {eb.BillAmount}";

            LeftToAdd--;
            if (LeftToAdd > 0)
            {
                lblMsg.Text = $"Saved. Enter next customer ({LeftToAdd} left).";
                txtCN.Text = txtName.Text = txtUnits.Text = "";
                txtCN.Focus();
            }
            else
            {
                lblMsg.Text = "All entries saved.";
            }
        }
    }
}


