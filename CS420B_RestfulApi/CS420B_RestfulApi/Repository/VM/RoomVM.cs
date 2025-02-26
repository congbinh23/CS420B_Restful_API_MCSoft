using CS420B_RestfulApi.Models.Table;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CS420B_RestfulApi.Repository.VM
{
    public class RoomVM
    {
        public int RoomNumber { get; set; }
        public int HotelID { get; set; }
        public int TypeID { get; set; }
        public Status status { get; set; }
    }
}
