using CS420B_RestfulApi.Models.Table;
using System.ComponentModel.DataAnnotations;

namespace CS420B_RestfulApi.Models.InputModule
{
    public class PaymentModule
    {
        [Required]
        public Guid BookingID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        [MaxLength(50)]
        public int PaymentMethod { get; set; }
    }
}
