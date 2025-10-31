using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        public DateTime MembershipDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public ICollection<BorrowRecord>? BorrowRecords { get; set; }
    }
}