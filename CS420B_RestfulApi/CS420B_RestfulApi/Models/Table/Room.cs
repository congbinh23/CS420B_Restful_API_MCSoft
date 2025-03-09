using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS420B_RestfulApi.Models.Table
{

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
        public string status { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
