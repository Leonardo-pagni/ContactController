using ContactController.Data;
using ContactController.Models;

namespace ContactController.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly BancoContext _context;
        public UserRepository(BancoContext context) 
        {
            _context = context;
        }
        public UserModel SearchForLogin(string Login)
        {
            return _context.Users.FirstOrDefault(X => X.Login.ToUpper() == Login.ToUpper());
        }

        public UserModel GetUser(int? id)
        {
            return _context.Users.FirstOrDefault(X => X.Id == id);
        }

        public UserModel Add(UserModel user)
        {
            user.CreatedDate = DateTime.Now;
            user.SetPasswordHash();
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public UserModel Update(UserModel user)
        {
            UserModel model = GetUser(user.Id);


            if (model == null) throw new Exception("Error in updated User");

            model.Name = user.Name;
            model.Email = user.Email;
            model.Login = user.Login;
            model.UpdatedDate = DateTime.Now;
            model.Profile = user.Profile;
            model.Password = user.Password;

            _context.Users.Update(model);
            _context.SaveChanges();

            return model;
        }

        public List<UserModel> SearchAll()
        {
            return _context.Users.ToList();
        }

        public Boolean Delete(int id)
        {
            UserModel model = GetUser(id);

            if (model == null) throw new Exception("Error in delete user");

            _context.Users.Remove(model);
            _context.SaveChanges();

            return true;
        }

     
    }
}
