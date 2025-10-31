using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string Author { get; set; }

        [StringLength(20)]
        public string ISBN { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [Range(1, int.MaxValue)]
        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }

        public bool IsAvailable { get; set; }

        public ICollection<BorrowRecord>? BorrowRecords { get; set; }
    }
}