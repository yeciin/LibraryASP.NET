using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFinalProject
{
    public class AuthenticationManager
    {
        private librarydbEntities dbContext;

        public AuthenticationManager(librarydbEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool UserExists(string email, string hashedPassword, out string userType)
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

        public bool IsStaff(string email, string hashedPassword)
        {
            Staff staff = dbContext.Staffs.FirstOrDefault(s => s.email == email && s.password_hash == hashedPassword);
            return staff != null;
        }
    }

}