using System;
using System.Linq;
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
                if (UserExists(dbContext, userEmail, hashedPassword, out string userType))
                {
                    FormsAuthentication.RedirectFromLoginPage(userEmail, false);
                    Response.Redirect("main.aspx");
                }
                else
                {
                    Label1.Text = "Login failed. Invalid email or password.";
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }
        private bool UserExists(librarydbEntities dbContext, string email, string hashedPassword, out string userType)
        {
            Customer customer = dbContext.Customers.FirstOrDefault(c => c.email == email && c.password_hash == hashedPassword);
            if (customer != null)
            {
                userType = "customer";
                return true;
            }

            Staff staff = dbContext.Staffs.FirstOrDefault(s => s.email == email && s.password_hash == hashedPassword);
            if (staff != null)
            {
                userType = "staff";
                return true;
            }

            userType = null;
            return false;
        }

    }
}