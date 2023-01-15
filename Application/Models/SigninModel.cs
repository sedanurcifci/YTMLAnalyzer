using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class SigninModel
    {
        [Required(ErrorMessage = "Plase enter valid username!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Plase enter valid password!")]
        public string Password { get; set; }
    }
}
