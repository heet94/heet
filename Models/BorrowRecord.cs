using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member? Member { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }

        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal FineAmount { get; set; } = 0;

        public void CalculateFine()
        {
            if (ReturnDate == null || ReturnDate <= DueDate)
                FineAmount = 0;
            else
                FineAmount = (decimal)(ReturnDate.Value - DueDate).Days * 1.00m;
        }
    }
}