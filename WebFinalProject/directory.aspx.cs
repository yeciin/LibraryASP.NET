using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinalProject
{
    public partial class directory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("Staff"))
            {
                Response.Redirect("~/stafflogin.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/books");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/staffs");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/customers");
        }
    }
}