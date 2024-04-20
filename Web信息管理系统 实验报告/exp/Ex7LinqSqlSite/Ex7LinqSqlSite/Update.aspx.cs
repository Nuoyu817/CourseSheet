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
            string categoryId = Request.QueryString["CategoryId"];
            var category = db.Category.Find(int.Parse(txtCategoryId.Text));
            txtCategoryId.Text = categoryId;
            txtCategoryId.ReadOnly = true;
            txtName.Text = category.Name;
            txtDescn.Text = category.Descn;
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        var category = db.Category.Find(int.Parse(txtCategoryId.Text));
        category.Name = txtName.Text;
        category.Descn = txtDescn.Text;
        db.SaveChanges();
    }
    protected void BtnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("DataManage.aspx");
    }
}