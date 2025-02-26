using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS420B_RestfulApi.Models.Table
{
    [Table("Guest")]
    public class Guest
    {
        [Required]
        [Key]
        public int GuestID { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
