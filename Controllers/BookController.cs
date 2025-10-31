using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;
        public BooksController(LibraryContext context) => _context = context;

        public async Task<IActionResult> Index(string search)
        {
            var books = from b in _context.Books select b;
            if (!string.IsNullOrEmpty(search))
                books = books.Where(b => b.Title.Contains(search) || b.Author.Contains(search));

            return View(await books.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.AvailableCopies = book.TotalCopies;
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
    }
}