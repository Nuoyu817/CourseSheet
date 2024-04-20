using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ex2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void CsvIdentity_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string cid = args.Value;
            args.IsValid = true;
            try
            {
                DateTime.Parse(cid.Substring(6, 4) + "-" + cid.Substring(10, 2) + "-" + cid.Substring(12, 2));
            }
            catch
            {
                args.IsValid = false;
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (Page.IsValid)
            {
                lblMsg.Text = "验证通过！";
            }
        }
        
    }
}