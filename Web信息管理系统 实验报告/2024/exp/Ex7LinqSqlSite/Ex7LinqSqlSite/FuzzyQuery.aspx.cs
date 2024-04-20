using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FuzzyQuery : System.Web.UI.Page
{
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        MyPetShopEntities db = new MyPetShopEntities();
        var results = from c in db.Category.Where(c => c.Name.Contains(txtSearch.Text)).ToList()select c;
        if (results.Count() != 0)
        {
            gvCategory.DataSource = results;
            gvCategory.DataBind();
        }
        else
        {
            lblMsg.Text = "没有满足条件的数据！";
        }
    }
    protected void BtnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("DataManage.aspx");
    }
}