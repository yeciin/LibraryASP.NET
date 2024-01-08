using System;
using System.Linq;

namespace WebFinalProject
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string firstName = TextBox1.Text;
            string lastName = TextBox2.Text;
            string email = TextBox3.Text;
            string phoneNumber = TextBox4.Text;
            string address = TextBox5.Text;
            string password = TextBox6.Text;
            string confirmPassword = TextBox7.Text;

            if (password != confirmPassword)
            {
                Label1.Text = $"Passwords do not match";
                

                return;
            }
            if( string.IsNullOrEmpty(firstName)|| string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(password))
            {
                Label1.Text = $"There is some missing data";
                return;
            }

            string hashedPassword = PasswordHelper.HashPassword(password);

            using (librarydbEntities dbContext = new librarydbEntities())
            {
                if (dbContext.Customers.Any(c => c.email == email) || dbContext.Staffs.Any(s => s.email == email))
                {
                    Label1.Text = $"User with the same email already exists";
                    return;
                }


                Customer newCustomer = new Customer
                {
                    first_name = firstName,
                    last_name = lastName,
                    email = email,
                    phone_number = phoneNumber,
                    home_address = address,
                    password_hash = hashedPassword
                };

                dbContext.Customers.Add(newCustomer);
                dbContext.SaveChanges();

                Response.Redirect("Login.aspx");
            }
        }
    }
}