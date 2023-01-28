using System.ComponentModel.DataAnnotations;

namespace MambaMVC1.Areas.ViewModel.Position
{
    public class CreatePositionVM
    {
        [Required, MinLength(3, ErrorMessage = "your position have short name"), MaxLength(25, ErrorMessage ="Your position is long")]
        public string PositionName { get; set; }
    }
}
