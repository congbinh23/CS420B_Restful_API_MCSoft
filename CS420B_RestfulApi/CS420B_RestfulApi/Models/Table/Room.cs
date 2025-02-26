using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS420B_RestfulApi.Models.Table
{
    public enum Status
    {
        Empty = 0, Confirmed = 1, Operational = 2, Completed = 3, Cancelled = -1
    }

    [Table("Room")]
    public class Room
    {
        [Required]
        [Key]
        public int RoomNumber { get; set; }
        public int? HotelID { get; set; }
        [ForeignKey("HotelID")]
        public Hotel Hotel { get; set; }
        public int? TypeID { get; set; }
        [ForeignKey("TypeID")]
        public RoomType RoomType { get; set; }
        [MaxLength(20)]
        public Status status { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
