using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Insert : System.Web.UI.Page
{
    MyPetShopEntities db = new MyPetShopEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            
            var categories = db.Category.ToList();
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataSource = categories;
            ddlCategory.DataBind();
            var suppliers = db.Supplier.ToList();
            ddlSupplier.DataTextField = "Name";
            ddlSupplier.DataValueField = "SuppId";
            ddlSupplier.DataSource = suppliers;
            ddlSupplier.DataBind();
        } 
    }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Product product = new Product();               
            product.CategoryId = int.Parse(ddlCategory.SelectedValue);
            product.Name = txtName.Text;
            product.ListPrice = decimal.Parse(txtListPrice.Text);
            product.Qty = int.Parse(txtQty.Text);
            product.Descn = txtDescn.Text;
            product.Image = "~／Prod＿Images／default.jpg";
            product.UnitCost = product.ListPrice;
            product.SuppId = int.Parse(ddlSupplier.SelectedValue);
            db.Product.Add(product);
            db.SaveChanges();
        }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("RepeaterForm.aspx");
    }
  }