using Microsoft.AspNetCore.Identity;

namespace Chatty.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name {get; set; }
        public bool SignedIn {get; set;}
    }
}