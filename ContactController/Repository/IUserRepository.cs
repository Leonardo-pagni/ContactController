using ContactController.Models;

namespace ContactController.Repository
{
    public interface IUserRepository
    {
        UserModel SearchForLogin(String Login);
        UserModel Add(UserModel user);
        UserModel Update(UserModel user);
        List<UserModel> SearchAll();
        UserModel GetUser(int? id);
        Boolean Delete(int id);

    }
}
