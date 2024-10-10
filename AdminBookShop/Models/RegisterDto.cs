using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AdminBookShop.Models
{
    public class RegisterDto
    {
       
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Required]
            [DisplayName("Confirm Password")]
            [Compare("Password", ErrorMessage = "پسورد و تایید پسورد باهم مطابقت ندارند")]
            public string ConfirmPassword { get; set; }


        
    }
}
