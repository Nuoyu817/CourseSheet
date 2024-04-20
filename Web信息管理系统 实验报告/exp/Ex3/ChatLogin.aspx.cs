using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Ex3
{
    public partial class ChatLogin : System.Web.UI.Page
    {
        string[,] user = { { "zny", "111111" }, { "test", "111111" } };
        protected void Page_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 1; i++)
            {
                if (txtName.Text == user[i, 0] && txtPassword.Text == user[i, 1])
                {
                    Session["user"] = user[i, 0];
                    Response.Redirect("Chat.aspx");
                }
            }
            Response.Write("<script type='text/javascript'>alert('用户名或密码错误！');</script>");
        }
    }
}