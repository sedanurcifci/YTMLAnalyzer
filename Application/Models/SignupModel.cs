using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class SignupModel
    {
        [Required(ErrorMessage ="Plase enter valid username!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Plase enter valid password!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Plase enter valid E-Mail Address!")]
        public string EMail { get; set; }
    }
}
