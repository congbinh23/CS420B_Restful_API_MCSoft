using CS420B_RestfulApi.Models.Table;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CS420B_RestfulApi.Repository.VM
{
    public class PaymentVM
    {
        public int PaymentID { get; set; }
        public Guid BookingID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
