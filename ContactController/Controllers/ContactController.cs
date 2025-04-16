using ContactController.Filters;
using ContactController.Models;
using ContactController.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactController.Controllers
{
    [UserLogin]
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
        public IActionResult Create(int? id, ContactModel model)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                ContactModel contact = _contactRepository.GetContact(id);
                return View(contact);
            }
        }

        public IActionResult ConfirmDelete(int id)
        {
            ContactModel contact = _contactRepository.GetContact(id);
            return View(contact);
        }


        [HttpPost]
        public IActionResult AddOrUpdate(ContactModel contact)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                if (contact.Id == 0 || contact.Id == int.MinValue)
                {
                    _contactRepository.Add(contact);
                }
                else
                {
                    _contactRepository.Update(contact);
                }
                return RedirectToAction("Index");
            }

            return View("Create", contact);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _contactRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
