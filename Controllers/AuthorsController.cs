using BookStore2.Models;
using BookStore2.Models.Repositiories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IBookStoreRepository<Authors> autorRep;

        public AuthorsController(IBookStoreRepository<Authors> autorRep)
        {
            this.autorRep = autorRep;
        }
        // GET: AuthorsController
        public ActionResult Index()
        {
            var autor = autorRep.list();
            return View(autor);
        }

        // GET: AuthorsController/Details/5
        public ActionResult Details(int id)
        {
            var author = autorRep.find(id);
            return View(author);
        }

        // GET: AuthorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Authors author)
        {
            Console.WriteLine(author.ToString());
            try
            {
                autorRep.add(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Edit/5
        public ActionResult Edit(int id)
        {
            var author = autorRep.find(id);
            return View(author);
        }

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult update(int id, Authors author)
        {
            try
            {
                autorRep.edit(id , author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = autorRep.find(id);
            return View(author);
        }

        // POST: AuthorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Authors author)
        {
            try
            {
                autorRep.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
