using Chandrakanth_CRUD.Data;
using Chandrakanth_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chandrakanth_CRUD.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Point 1 in Assesment
        public IActionResult Index()
        {
            string sql = "EXEC GetAllBookDataDefaultSort";
            IEnumerable<Book> objCatlist = _context.Book.FromSqlRaw<Book>(sql).ToList();
            GetAllBookPrice();
            return View(objCatlist);
        }
        //Point 2 in Assesment
        public IActionResult Index2()
        {
            string sql = "EXEC GetAllBookDataDefaultSort2";
            IEnumerable<Book> objCatlist = _context.Book.FromSqlRaw<Book>(sql).ToList();
            return View("index", objCatlist);
        }
        public IActionResult GetAllBookPrice()
        {
            IEnumerable<Book> objCatlist = _context.Book;
            var price = objCatlist.Sum(item => item.Price);
            TempData["Totalprice"] = Convert.ToString(price);
            return View(objCatlist);
        }


        public IActionResult IndexSortDifferent()
        {
            IEnumerable<Book> objCatlist = _context.Book;
            objCatlist = objCatlist.OrderBy(x => x.AuthorLastName).ThenBy(x => x.AuthorFirstName).ThenBy(x => x.Title);
            return View(objCatlist);
        }

        
        public IActionResult Create()
        {
            return View();
        }


        public IActionResult GetBooksFromDBContext()
        {
            IEnumerable<Book> objCatlist = _context.Book;
            objCatlist = objCatlist.OrderBy(x => x.Publisher).ThenBy(x => x.AuthorLastName).ThenBy(x => x.AuthorFirstName).ThenBy(x => x.Title);
            return View(objCatlist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Book.Add(book);
                _context.SaveChanges();
                TempData["ResultOk"] = "Book Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookdb = _context.Book.Find(id);

            if (bookdb == null)
            {
                return NotFound();
            }
            return View(bookdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Book.Update(book);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookdb = _context.Book.Find(id);

            if (bookdb == null)
            {
                return NotFound();
            }
            return View(bookdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? id)
        {
            var deleterecord = _context.Book.Find(id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.Book.Remove(deleterecord);
            _context.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }

    }
}
