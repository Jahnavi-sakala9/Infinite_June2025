using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Assignment1
{
        public partial class ProductsDemo : System.Web.UI.Page
        {
            Dictionary<string, (string ImageUrl, decimal Price)> products = new Dictionary<string, (string, decimal)>
        {
            {"Sonata watch",("images/Product1.jpg", 2000m) },
            {"Daniel klein",("images/Product2.jpg", 7500m) },
            {"Michael kors",("images/Product3.jpg", 10000m) }
        };

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    foreach (var product in products.Keys)
                    {
                        ddlProducts.Items.Add(product);
                    }
                }
            }

            protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
            {
                string selectedProduct = ddlProducts.SelectedItem.Text;
                if (products.ContainsKey(selectedProduct))
                {
                    imgProduct.ImageUrl = products[selectedProduct].ImageUrl;
                }
            }

            protected void btnGetPrice_Click(object sender, EventArgs e)
            {
                string selectedProduct = ddlProducts.SelectedItem.Text;
                if (products.ContainsKey(selectedProduct))
                {
                    lblPrice.Text = "Price:" + products[selectedProduct].Price.ToString();
                }
            }
        }
    } 






