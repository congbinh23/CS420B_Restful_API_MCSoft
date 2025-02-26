using System.ComponentModel.DataAnnotations;

namespace CS420B_RestfulApi.Models.InputModule
{
    public class HotelModule
    {

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
    }
}
