using System.ComponentModel.DataAnnotations;

namespace CS420B_RestfulApi.Models.InputModule
{
    public class GuestModule
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
    }
}
