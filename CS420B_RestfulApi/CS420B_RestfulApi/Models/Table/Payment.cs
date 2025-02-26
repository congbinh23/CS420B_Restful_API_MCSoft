using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS420B_RestfulApi.Models.Table
{
    public enum PaymentMethod
    {
        CreditCard = 1, Electronic = 2, EWallet = 3, Cash = 4
    }

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
        public PaymentMethod PaymentMethod { get; set; }
    }
}
