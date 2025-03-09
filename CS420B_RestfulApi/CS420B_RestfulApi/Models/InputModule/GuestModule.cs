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
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
