using System.ComponentModel.DataAnnotations;

namespace FitnessTrackerApi.Model.Dto.ApplicationUserDtoFolder
{
    public class UserLoginRequestDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
