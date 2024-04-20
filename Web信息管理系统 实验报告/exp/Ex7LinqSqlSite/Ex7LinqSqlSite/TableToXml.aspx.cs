using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class TableToXml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string xmlFilePath = Server.MapPath("~/Category.xml");
        XDocument doc = new XDocument
        (
        new XDeclaration("1.0", "utf-8", "yes"),
        new XComment("分类"),
        new XElement("Categories")
        );
        doc.Save(xmlFilePath);
        XElement els = XElement.Load(xmlFilePath);
        MyPetShopEntities db = new MyPetShopEntities();
        var results = from c in db.Category
                      select c;
        foreach (Category category in results)
        {
            XElement el = new XElement("Category",
            new XElement("CategoryId", category.CategoryId),
            new XElement("Name", category.Name),
            new XElement("Descn", category.Descn));
            els.Add(el);
        }
        els.Save(xmlFilePath);
        Response.Redirect("~/Category.xml");
    }
}