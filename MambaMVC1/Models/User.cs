using Microsoft.AspNetCore.Identity;

namespace MambaMVC1.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
