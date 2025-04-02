using ContactController.Models;
using ContactController.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactController.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.SearchAll();


            return View(contacts);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult ConfirmDelete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ContactModel contact)
        {
            _contactRepository.Add(contact);

            return RedirectToAction("Index");
        }
    }
}
