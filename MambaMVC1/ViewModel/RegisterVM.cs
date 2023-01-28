using System.ComponentModel.DataAnnotations;

namespace MambaMVC1.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Pleace write Your Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Pleace write Your Second Name")]
        public string SecondName { get; set; }


        [Required(ErrorMessage = "Pleace write Your username")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Pleace write Your Email"),DataType(DataType.EmailAddress, ErrorMessage ="incorrect Email adress")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Pleace write Your Email"), DataType(DataType.Password,ErrorMessage ="Incorrect Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Pleace write Your Email"), DataType(DataType.Password, ErrorMessage = "Incorrect Password"), Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
