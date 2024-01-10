using System;
using System.Web.Security;

namespace WebFinalProject
{
    public partial class Login : System.Web.UI.Page
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

                    string userRole = (userType == "customer") ? "Customer" : "Staff";

                    if (!Roles.RoleExists(userType))
                    {
                        Roles.CreateRole(userType);
                    }
                    if (!Roles.IsUserInRole(userEmail, userType))
                    {
                        Roles.AddUserToRole(userEmail, userType);
                    }

                    Response.Redirect("main.aspx");
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("stafflogin.aspx");
        }
    }
}