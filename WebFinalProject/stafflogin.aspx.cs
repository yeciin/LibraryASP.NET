using System;
using System.Web.Security;

namespace WebFinalProject
{
    public partial class stafflogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userEmail = TextBox1.Text;
            string userPassword = TextBox2.Text;
            string hashedPassword = PasswordHelper.HashPassword(userPassword);

            using (librarydbEntities dbContext = new librarydbEntities())
            {
                AuthenticationManager authManager = new AuthenticationManager(dbContext);
                if (authManager.UserExists(userEmail, hashedPassword, out string userType))
                {
                    FormsAuthentication.RedirectFromLoginPage(userEmail, false);
                    Response.Redirect("directory.aspx");
                }
                else
                {
                    return;
                }
            }
        }
    }
}