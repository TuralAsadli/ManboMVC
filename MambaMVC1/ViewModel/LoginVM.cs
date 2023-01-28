using System.ComponentModel.DataAnnotations;

namespace MambaMVC1.ViewModel
{
    public class LoginVM
    {
        
        [Required(ErrorMessage = "Pleace write Your username")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Pleace write Your Email"), DataType(DataType.EmailAddress, ErrorMessage = "incorrect Email adress")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Pleace write Your Email"), DataType(DataType.Password, ErrorMessage = "Incorrect Password")]
        public string Password { get; set; }


        
    }
}
