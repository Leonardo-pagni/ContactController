using ContactController.Models;

namespace ContactController.Helper
{
    public interface ISession
    {
        void CreateUserSession(UserModel user);
        void RemoveUserSession ();
        UserModel GetUserSession ();
    }
}
