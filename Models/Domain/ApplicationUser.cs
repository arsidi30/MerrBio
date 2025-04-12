using Microsoft.AspNetCore.Identity;

namespace FarmIt.Models.Domain
{
    public class ApplicationUser : IdentityUser

    {
        public string Name { get; set; }
       

    }
}
