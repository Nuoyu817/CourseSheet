using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProShow : System.Web.UI.Page
{
    MyPetShopEntities db = new MyPetShopEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var categories = db.Category.ToList();
            ddlCategory.DataSource = categories;
            ddlCategory.DataBind();
            Bind();
        }
    }
    protected void DdlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind();
    }
    private void Bind()
    {
        int categoryId = int.Parse(ddlCategory.SelectedValue);
        var products = db.Product.Where(p => p.CategoryId == categoryId).ToList();
        gvProduct.DataSource = products;
        gvProduct.DataBind();
    }
    protected void GvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProduct.PageIndex = e.NewPageIndex;
        Bind();
    }
}