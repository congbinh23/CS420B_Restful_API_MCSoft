using CS420B_RestfulApi.Models.Table;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CS420B_RestfulApi.Models.InputModule
{
    public class BookingModule
    {
        [Required]
        public int GuestID { get; set; }
        public int RoomNumber { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }
    }
}
