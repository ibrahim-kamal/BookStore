using BookStore2.Models;
using BookStore2.Models.Repositiories;
using BookStore2.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookStoreRepository<Books> bookRep;
        private readonly IBookStoreRepository<Authors> authRep;

        // GET: BooksController

        public BooksController(IBookStoreRepository<Books> BookRep , IBookStoreRepository<Authors> authRep)
        {
            this.bookRep = BookRep;
            this.authRep = authRep;
        }
        public ActionResult Index()
        {
            var books=  this.bookRep.list();
            return View(books);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {

            var book = this.bookRep.find(id);
            return View(book);
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            BooksAuthorViewModel bookAuthorViewModel = new BooksAuthorViewModel() {
                authors = authRep.list()
            };
            return View(bookAuthorViewModel);
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BooksAuthorViewModel bookAuthorViewModel)
        {


            try
            {
                Books book = new Books()
                {
                    title= bookAuthorViewModel.book.title,
                    description = bookAuthorViewModel.book.description,
                    author = authRep.find(bookAuthorViewModel.book.author.id)
                };
                this.bookRep.add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            Books book = bookRep.find(id);
            BooksAuthorViewModel bookAuthorViewModel = new BooksAuthorViewModel()
            {

                book = book,
                authors = authRep.list()
            };
            return View(bookAuthorViewModel);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BooksAuthorViewModel booksAuthorViewModel)
        {
            try
            {
                Books book = new Books()
                {
                    id = booksAuthorViewModel.book.id,
                    title = booksAuthorViewModel.book.title,
                    description = booksAuthorViewModel.book.description,
                    author = authRep.find(booksAuthorViewModel.book.author.id)
                };
            bookRep.edit(id, book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {

            Books book = bookRep.find(id);
            return View(book);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bookRep.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
