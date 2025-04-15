using ContactController.Models;
using ContactController.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactController.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
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
