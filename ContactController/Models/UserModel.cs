using ContactController.Enums;
using ContactController.Helper;

namespace ContactController.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public ProfileEnum Profile { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public bool PasswordIsValid(string Password)
        {
            Password = Password.GenerateHash();

            return this.Password == Password;
        }

        public void SetPasswordHash()
        {
            Password = Password.GenerateHash(); 
        }
        
        public string GenerateNewPassword()
        {
            string NewPassword = Guid.NewGuid().ToString().Substring(0,8);
            Password = NewPassword.GenerateHash();

            return NewPassword;
        }
    }
}
