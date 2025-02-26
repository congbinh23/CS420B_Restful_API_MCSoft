using System.ComponentModel.DataAnnotations;

namespace CS420B_RestfulApi.Repository.VM
{
    public class HotelVM
    {
        public int HotelID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public int Stars { get; set; }
        public TimeOnly CheckinTime { get; set; }
        public TimeOnly CheckoutTime { get; set; }
    }
}
