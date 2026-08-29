using Microsoft.AspNetCore.Identity;

namespace FitnessTrackerApi.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
