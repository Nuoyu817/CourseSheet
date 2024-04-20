using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RepeaterForm : System.Web.UI.Page
{
    MyPetShopEntities db = new MyPetShopEntities();
    protected void Bind()
    {
        var products = db.Product.OrderByDescending(p => p.ProductId).ToList();
        rptProduct.DataSource = products;
        rptProduct.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        LinkButton btndel = (LinkButton)sender;
        var product = db.Product.Find(int.Parse(btndel.CommandArgument));
        db.Product.Remove(product);
        db.SaveChanges();
        Bind();
    }

   
}