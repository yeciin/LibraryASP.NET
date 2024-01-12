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

        private void LoadBookDetails()
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
    }
}