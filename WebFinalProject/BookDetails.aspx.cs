using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace WebFinalProject
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            else if (!IsPostBack)
            {
                DisplayRandomQuote();
                LoadBookDetails();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Response.Redirect("~/Login.aspx");
        }

        private Book LoadBookDetails()
        {
            if (Request.QueryString["bookId"] != null)
            {
                int bookId = Convert.ToInt32(Request.QueryString["bookId"]);

                using (librarydbEntities dbContext = new librarydbEntities())
                {
                    Book book = dbContext.Books.Find(bookId);

                    if (book != null)
                    {
                        Cover.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(book.cover);
                        BTitle.Text = "Title: " + book.title;
                        Author.Text = "Author: " + book.author;
                        Publisher.Text = "Publisher: " + book.publisher;
                        Year.Text = "Year: " + book.publication_year.ToString();
                        Genre.Text = "Genre: " + book.genre;
                        Copies.Text = "Available Copies: " + book.copies_available.ToString();

                        return book;
                    }
                    else
                    {
                        Response.Redirect("~/ErrorPage.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/ErrorPage.aspx");
            }

            return null;
        }
        private void DisplayRandomQuote()
        {
            using (librarydbEntities dbContext = new librarydbEntities())
            {
                Random random = new Random();
                int randomQuoteId = random.Next(1, dbContext.quotes.Count() + 1);

                var randomQuote = dbContext.quotes.FirstOrDefault(q => q.ID == randomQuoteId);

                if (randomQuote != null)
                {
                    quoteoftheday.Text = randomQuote.qotd + " - " + randomQuote.author;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Book book = LoadBookDetails();

            if (book != null)
            {
                string bookName = book.title;
                // int userId = GetUserId();
                // int bookId = book.book_id;
                DateTime currentDate = DateTime.Now;
                DateTime returnDate = currentDate.AddMonths(1);

                // UpdateAvailableCopies(bookId);

                // InsertBorrowingRecord(userId, bookId, currentDate, returnDate);

                Label2.Text = $"Checkout of '{bookName}' successful. Please pick it up when you are free. Return by {returnDate.ToString("yyyy-MM-dd")}.";

                //// Response.AddHeader("REFRESH", "5;URL=main.aspx");
            }
        }

        private int GetUserId()
        {
            MembershipUser currentUser = Membership.GetUser();

            if (currentUser != null && currentUser.ProviderUserKey != null)
            {
                if (int.TryParse(currentUser.ProviderUserKey.ToString(), out int userId))
                {
                    return userId;
                }
                else
                {
                    // Log or handle the case where parsing fails
                    throw new InvalidOperationException("Unable to parse ProviderUserKey to integer.");
                }
            }
            else
            {
                // Log or handle the case where ProviderUserKey is null
                throw new InvalidOperationException("ProviderUserKey is null.");
            }
        }



        private void InsertBorrowingRecord(int userId, int bookId, DateTime borrowDate, DateTime returnDate)
        {
            using (librarydbEntities dbContext = new librarydbEntities())
            {

                Borrowing borrowing = new Borrowing
                {
                    user_id = userId,
                    book_id = bookId,
                    borrow_date = borrowDate,
                    return_date = returnDate
                };

                dbContext.Borrowings.Add(borrowing);
                dbContext.SaveChanges();
            }
        }

        private void UpdateAvailableCopies(int bookId)
        {
            using (librarydbEntities dbContext = new librarydbEntities())
            {

                var book = dbContext.Books.Find(bookId);


                if (book != null && book.copies_available > 0)
                {
                    book.copies_available--;
                    dbContext.SaveChanges();
                }
            }
        }
    }
}