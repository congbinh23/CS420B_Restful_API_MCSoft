using CS420B_RestfulApi.Models.Table;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CS420B_RestfulApi.Models.InputModule
{
    public class RoomModule
    {
        [Required]
        public int HotelID { get; set; }
        public int TypeID { get; set; }
        [MaxLength(20)]
        public string status { get; set; }
    }
}
