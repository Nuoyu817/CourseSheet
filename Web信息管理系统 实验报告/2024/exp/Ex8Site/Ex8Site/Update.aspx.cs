using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Update : System.Web.UI.Page
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
            string productId = Request.QueryString["ProductId"];
            var product = db.Product.Find(int.Parse(productId));
            txtProductId.Text = productId;
            ddlCategory.SelectedValue = product.CategoryId.ToString();
            txtProductId.ReadOnly = true;
            txtName.Text = product.Name;
            txtListPrice.Text = product.ListPrice.ToString();
            txtQty.Text = product.Qty.ToString();
            ddlSupplier.SelectedValue = product.SuppId.ToString();
            txtDescn.Text = product.Descn;

        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        var product = db.Product.Find(int.Parse(txtProductId.Text));
        product.Name = txtName.Text;
        product.CategoryId = int.Parse(ddlCategory.SelectedValue);
        product.ListPrice = decimal.Parse(txtListPrice.Text);
        product.Qty = int.Parse(txtQty.Text); 
        product.SuppId = int.Parse(ddlSupplier.SelectedValue);
        product.Descn = txtDescn.Text;
        db.SaveChanges();

    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("RepeaterForm.aspx");
    }
}