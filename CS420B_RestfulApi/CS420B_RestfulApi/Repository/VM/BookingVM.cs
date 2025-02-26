using CS420B_RestfulApi.Models.Table;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CS420B_RestfulApi.Repository.VM
{
    public class BookingVM
    {
        public Guid BookingID { get; set; }
        public int GuestID { get; set; }
        public int RoomNumber { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
