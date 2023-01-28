using MambaMVC1.Models;
using System.ComponentModel.DataAnnotations;

namespace MambaMVC1.Areas.ViewModel.Employee
{
    public class CreateEmployeeVM
    {
        [Required(ErrorMessage ="Pleace write your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Pleace write your first name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Pleace write your first name")]
        public string? FaceBook { get; set; }
        public string? Twitter { get; set; }
        public string? LinkedIn { get; set; }
        public string? Instagram { get; set; }
        public IFormFile? Img { get; set; }

        [Required]
        public int PositionId { get; set; }
       
    }
}
