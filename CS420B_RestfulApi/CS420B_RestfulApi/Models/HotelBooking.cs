using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS420B_RestfulApi.Models
{
    [Table("HotelBooking")]
    public class HotelBooking : HotelBooking_Info
    {
        [Key]
        public Guid Id { get; set; }
    }

    public class HotelBooking_Info 
    {
        [Required]
        [Range(1, 100)]
        public int RoomNumber { get; set; }
        [MaxLength(100)]
        public string ClientName { get; set; }
    }
}
