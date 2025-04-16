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
        public UserController(IUserRepository userRepository)
        { 
            _userRepository = userRepository;
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
    }
}
