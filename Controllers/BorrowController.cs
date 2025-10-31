using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    public class BorrowController : Controller
    {
        private readonly LibraryContext _context;
        public BorrowController(LibraryContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var records = await _context.BorrowRecords
                .Include(b => b.Book)
                .Include(m => m.Member)
                .ToListAsync();
            return View(records);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Books = _context.Books.Where(b => b.AvailableCopies > 0).ToList();
            ViewBag.Members = _context.Members.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BorrowRecord record)
        {
            var book = await _context.Books.FindAsync(record.BookId);
            if (book == null || book.AvailableCopies <= 0)
                return BadRequest("Book not available.");

            record.DueDate = DateTime.Now.AddDays(7);
            book.AvailableCopies--;

            _context.BorrowRecords.Add(record);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var record = await _context.BorrowRecords
                .Include(b => b.Book)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (record == null) return NotFound();

            record.ReturnDate = DateTime.Now;
            record.CalculateFine();
            record.Book.AvailableCopies++;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}