using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserforLoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify password betwieen 4 and 8 characateres")]
        public string Password { get; set; }
    }
}