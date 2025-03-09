using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS420B_RestfulApi.Models.Table
{


    [Table("Payment")]
    public class Payment
    {
        [Required]
        [Key]
        public int PaymentID { get; set; }
        public Guid? BookingID { get; set; }
        [ForeignKey("BookingID")]
        public Booking Booking { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        [MaxLength(50)]
        public string PaymentMethod { get; set; }
    }
}
