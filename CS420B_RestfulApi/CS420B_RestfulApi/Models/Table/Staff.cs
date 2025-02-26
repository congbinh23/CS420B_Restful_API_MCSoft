using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS420B_RestfulApi.Models.Table
{
    [Table("Staff")]
    public class Staff
    {
        [Required]
        [Key]
        public int StaffID { get; set; }
        public int? HotelID { get; set; }
        [ForeignKey("HotelID")]
        public Hotel Hotel { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        public DateTime HireDate { get; set; }

    }
}
