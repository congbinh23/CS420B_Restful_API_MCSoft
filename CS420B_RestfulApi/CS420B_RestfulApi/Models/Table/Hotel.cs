using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CS420B_RestfulApi.Models.Table
{
    [Table("Hotel")]
    public class Hotel
    {
        
        [Key]
        public int HotelID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [MaxLength(10)]
        public string Number { get; set; }
        [Range(1, 5)]
        public int Stars { get; set; }
        public TimeOnly CheckinTime { get; set; }
        public TimeOnly CheckoutTime { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }


}
