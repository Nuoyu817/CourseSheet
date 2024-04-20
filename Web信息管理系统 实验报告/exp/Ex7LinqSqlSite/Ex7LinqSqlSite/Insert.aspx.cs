using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Insert : System.Web.UI.Page
{
    protected void BtnInsert_Click(object sender, EventArgs e)
    {
        MyPetShopEntities db = new MyPetShopEntities();
        Category category = new Category();
        category.Name = txtName.Text;
        category.Descn = txtDescn.Text;
        db.Category.Add(category);
        db.SaveChanges();
    }
    protected void BtnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("DataManage.aspx");
    }
}