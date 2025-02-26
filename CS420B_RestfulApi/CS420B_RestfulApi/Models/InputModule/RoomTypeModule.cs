using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CS420B_RestfulApi.Models.InputModule
{
    public class RoomTypeModule
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
    }
}
