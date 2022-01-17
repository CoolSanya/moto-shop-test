using System.ComponentModel.DataAnnotations;

namespace moto_shop_test.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
