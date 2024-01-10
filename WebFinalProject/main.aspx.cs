using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebFinalProject
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
           else if (!IsPostBack)
            {
                LoadBooks();
            }

        }
        private void LoadBooks()
        {
            using (librarydbEntities dbContext = new librarydbEntities())
            {
                List<Book> books = dbContext.Books.ToList();

                foreach (Book book in books)
                {
                    HtmlGenericControl bookDiv = new HtmlGenericControl("div");
                    bookDiv.InnerHtml = $"<h3>{book.title}</h3><p>Author: {book.author}</p><p>Genre: {book.genre}</p> <p>Available Copies: {book.copies_available}</p>";

                    PlaceHolder1.Controls.Add(bookDiv);
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string searchTerm = txtSearch.Text;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                SearchBooks(searchTerm);
            }
            else
            {
                LoadBooks();
            }
        }
        private void SearchBooks(string searchTerm)
        {

            using (librarydbEntities dbContext = new librarydbEntities())
            {
                var books = dbContext.Books
                    .Where(b => b.title.Contains(searchTerm) || b.author.Contains(searchTerm))
                    .ToList();

                DisplayBooks(books);
            }
        }
        private void DisplayBooks(System.Collections.Generic.List<Book> books)
        {
            PlaceHolder1.Controls.Clear();

            foreach (Book book in books)
            {
                var bookDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                bookDiv.Attributes["class"] = "flex-item";
                bookDiv.InnerHtml = $"<h3>{book.title}</h3><p>Author: {book.author}</p><p>Genre: {book.genre}</p> <p>Available Copies : {book.copies_available}</p>";
                PlaceHolder1.Controls.Add(bookDiv);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Response.Redirect("~/Login.aspx");
        }
    }
}