using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataManage : System.Web.UI.Page
{
    MyPetShopEntities db = new MyPetShopEntities();
    protected void Bind()
    {
        var results = db.Category.ToList();
        gvCategory.DataSource = results;
        gvCategory.DataBind();
    }
    protected void BtnQueryAll_Click(object sender, EventArgs e)
    {
        Bind();
    }
    protected void BtnFuzzy_Click(object sender, EventArgs e)
    {
        Response.Redirect("FuzzyQuery.aspx");
    }
    protected void BtnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect("Insert.aspx");
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("Update.aspx?CategoryId=" + txtCategoryId.Text);
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        var category = db.Category.Find(int.Parse(txtCategoryId.Text));
                     
        db.Category.Remove(category);
        db.SaveChanges();
        Bind();
    }
}