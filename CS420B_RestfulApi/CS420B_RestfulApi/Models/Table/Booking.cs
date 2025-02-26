using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS420B_RestfulApi.Models.Table
{
    [Table("HotelBooking")]
    public class Booking 
    {
        [Key]
        public Guid BookingID { get; set; }
        [Required]
        public int? GuestID { get; set; }
        [ForeignKey("GuestID")]
        public Guest Guest { get; set; }
        public int? RoomNumber { get; set; }
        [ForeignKey("RoomNumber")]
        public Room Room { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }

}
