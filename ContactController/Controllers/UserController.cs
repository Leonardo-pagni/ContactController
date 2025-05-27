using ContactController.Filters;
using ContactController.Models;
using ContactController.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactController.Controllers
{
    [RestrictPageForAdm]
    public class UserController : Controller
    {
        public readonly IUserRepository _userRepository;
        private readonly IContactRepository _contactRepository;
        public UserController(IUserRepository userRepository, IContactRepository contactRepository)
        { 
            _userRepository = userRepository;
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.SearchAll();

            return View(users);
        }
        public IActionResult ConfirmDelete(int id)
        {
            UserModel user = _userRepository.GetUser(id);

            return View(user);
        }

        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                UserModel user = _userRepository.GetUser(id);
                return View(user);
            }
        }
        public IActionResult ListContactsPerUserId(int userId)
        {
            List<ContactModel> contacts = _contactRepository.SearchAll(userId);
            return PartialView("_ContactsUser", contacts);
        }

        [HttpPost]
        public IActionResult AddOrUpdate(UserModel model)
        {

            if (model.Id == 0 || model.Id == int.MinValue)
            {
                _userRepository.Add(model);
            }
            else
            {
                _userRepository.Update(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult NewPassword(int id)
        {
            UserModel model = _userRepository.GetUser(id);

            try
            {
                string newPassword = model.GenerateNewPassword();

                _userRepository.Update(model);
                TempData["SuccessMessage"] = $"Password Reseted. New Password: {newPassword}";
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Error. error details: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
