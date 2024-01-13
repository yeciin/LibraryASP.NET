using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace WebFinalProject
{
    public partial class main : System.Web.UI.Page
    {
        private librarydbEntities dbContext = new librarydbEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            else if (!IsPostBack)
            {
                LoadBooks();
                // BindData(DropDownList1.SelectedValue);
            }

        }
        private void BindData(string sortBy)
        {
            using (librarydbEntities dbContext = new librarydbEntities())
            {
                var books = dbContext.Books.ToList();

                switch (sortBy)
                {
                    case "author":
                        books = books.OrderBy(b => b.author).ToList();
                        break;
                    case "genre":
                        books = books.OrderBy(b => b.genre).ToList();
                        break;
                    case "year":
                        books = books.OrderBy(b => b.publication_year).ToList();
                        break;
                    case "availablecopies":
                        books = books.OrderBy(b => b.copies_available).ToList();
                        break;
                }

                Repeater1.DataSource = books;
                Repeater1.DataBind();
            }
        }

        private void LoadBooks()
        {
            using (librarydbEntities dbContext = new librarydbEntities())
            {
                List<Book> books = dbContext.Books.ToList();

                Repeater1.DataSource = books;
                Repeater1.DataBind();
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
        private void DisplayBooks(List<Book> books)
        {
            Repeater1.DataSource = books;
            Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Response.Redirect("~/Login.aspx");
        }

        protected void SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSortOption = DropDownList1.SelectedValue;
            BindData(selectedSortOption);
        }
    }
}