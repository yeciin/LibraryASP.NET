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
                if (authManager.IsStaff(userEmail, hashedPassword))
                {
                    FormsAuthentication.RedirectFromLoginPage(userEmail, false);
                    string userType = "Staff";
                    if (!Roles.RoleExists(userType))
                    {
                        Roles.CreateRole(userType);
                    }
                    if (!Roles.IsUserInRole(userEmail, userType))
                    {
                        Roles.AddUserToRole(userEmail, userType);
                    }

                    Response.Redirect("directory.aspx");
                }
                else
                {
                    Label1.Text = "Login failed. Invalid email or password.";

                    return;
                }
            }
        }
    }
}