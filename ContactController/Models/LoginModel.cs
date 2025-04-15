using System.ComponentModel.DataAnnotations;

namespace ContactController.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login is empty")]
        public string Login {  get; set; }

        [Required(ErrorMessage = "Password is empty")]
        public string Password {  get; set; }        
    }
}
