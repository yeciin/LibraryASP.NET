using System;
using System.Linq;

    namespace WebFinalProject
    {
        public class DatabaseInitializer
        {
            public static void AddStaffMember()
            {
                try
                {
                    using (librarydbEntities dbContext = new librarydbEntities())
                    {
                        // Check if staff with the same email already exists
                        if (!dbContext.Staffs.Any(s => s.email == "staff@example.com"))
                        {
                            // Create a new Staff object
                            Staff newStaff = new Staff
                            {
                                email = "yassin@staff.com",
                                password_hash = PasswordHelper.HashPassword("password"), // Hash the password
                                first_name = "Yassin",
                                last_name = "Hafez",
                                phone_number = "76036154",
                                position = "Owner"
                            };

                            // Add the new staff member to the Staffs table
                            dbContext.Staffs.Add(newStaff);

                            // Save changes to the database
                            dbContext.SaveChanges();

                            Console.WriteLine("Staff member added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Staff member with the same email already exists.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding staff member: " + ex.Message);
                }
            }

            public static void Main(string[] args)
            {
                // Call the method to add a staff member
                AddStaffMember();
            }
        }
    }