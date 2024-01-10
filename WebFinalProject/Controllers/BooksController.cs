using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebFinalProject;

namespace WebFinalProject.Controllers
{
    [Authorize(Roles = "Staff")]
    public class BooksController : Controller
    {
        private librarydbEntities db = new librarydbEntities();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "book_id,title,author,publisher,publication_year,ISBN,genre,total_copies,copies_available")] Book book, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null && imageFile.ContentLength > 0)
                    {
                        if (!imageFile.ContentType.StartsWith("image"))
                        {
                            ModelState.AddModelError(string.Empty, "Please upload a valid image file.");
                            return View(book);
                        }

                        using (var binaryReader = new BinaryReader(imageFile.InputStream))
                        {
                            book.cover = binaryReader.ReadBytes(imageFile.ContentLength);
                        }
                    }

                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can replace this with your logging mechanism)
                    Console.WriteLine($"Error saving image: {ex.Message}");
                    ModelState.AddModelError(string.Empty, "Error saving image. Please try again.");
                }
            }

            return View(book);
        }


        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "book_id,title,author,publisher,publication_year,ISBN,genre,total_copies,copies_available")] Book book, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null && imageFile.ContentLength > 0)
                    {
                        if (!imageFile.ContentType.StartsWith("image"))
                        {
                            ModelState.AddModelError(string.Empty, "Please upload a valid image file.");
                            return View(book);
                        }

                        using (var binaryReader = new BinaryReader(imageFile.InputStream))
                        {
                            book.cover = binaryReader.ReadBytes(imageFile.ContentLength);
                        }
                    }

                    db.Entry(book).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the exception (you can replace this with your logging mechanism)
                    Console.WriteLine($"Error saving image during edit: {ex.Message}");
                    ModelState.AddModelError(string.Empty, "Error saving image during edit. Please try again.");
                }
            }

            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
