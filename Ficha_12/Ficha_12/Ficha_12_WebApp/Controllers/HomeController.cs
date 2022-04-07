using Ficha_12.Models;
using Ficha_12.Services;
using Ficha_12_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ficha_12_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService service;

        public HomeController(IBookService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var books = service.GetAll();
            return View(new BooksViewModel { Books = books });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                var newBook = service.Create(book);
                if (newBook is not null)
                    return RedirectToAction(nameof(Index));
                else
                    return RedirectToAction(nameof(Error));
            }
            else
            {
                return RedirectToAction(nameof(Error));
            }
        }

        public IActionResult Update(string isbn)
        {
            var book = service.GetByISBN(isbn);
            return View(book);
        }

        [HttpPost]

        public async Task<IActionResult> Update(string isbn, Book book)
        {
            var updateBook = service.Update(isbn, book);

            if (updateBook is not null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Error));
            }
        }

        public IActionResult Delete(string isbn)
        {
            var book = service.GetByISBN(isbn);
            if (book is not null)
            {
                service.DeleteByISBN(isbn);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Error));
            }

        }
    }
}