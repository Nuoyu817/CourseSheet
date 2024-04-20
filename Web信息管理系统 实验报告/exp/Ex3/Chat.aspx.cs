using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ex3
{
    public partial class Chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lb1Name.Text = "发言人：" + Session["user"];
            if (!IsPostBack)
            {
                Application["message"] = Session["user"] + "进入聊天室<br />" + Application["message"];
            }
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            Application.Lock();
            Application["message"] = Session["user"] + "说：" + txtMessage.Text + "（" + DateTime.Now.ToString() + "）<br />" + Application["message"];
            Application.UnLock();
            txtMessage.Text = "";
        }
    }
}