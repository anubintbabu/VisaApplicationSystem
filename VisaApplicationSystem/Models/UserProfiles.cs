using System.ComponentModel.DataAnnotations;

namespace VisaApplicationSystem.Models
{
    public class UserProfiles
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Name is Required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "PhoneNo is Required.")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Username is Required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; }
       
        public DateOnly CreatedDate { get; set; }
    }
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
