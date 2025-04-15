using ContactController.Models;
using ContactController.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using ISession = ContactController.Helper.ISession;


namespace ContactController.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly ISession _ISession;
        public LoginController(IUserRepository userRepository, ISession session)
        {
            _userRepository = userRepository;
            _ISession = session;
        }
        public IActionResult Index()
        {
            //se o usuario estiver logado, redirecionar para a home
            if (_ISession.GetUserSession() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Exit()
        {
            _ISession.RemoveUserSession();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Submit(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.SearchForLogin(loginModel.Login);

                    if (user != null)
                    {
                        if (user.PasswordIsValid(loginModel.Password))
                        {
                            _ISession.CreateUserSession(user);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["ErrorMessage"] = $"Password is invalid. Try again";
                        }
                    }
                    else
                    {
                       TempData["ErrorMessage"] = $"User is invalid. Try again";
                    }
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"We were unable to log you in. Error details: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
