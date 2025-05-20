using ContactController.Data;
using ContactController.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContactController.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly BancoContext _bancoContext;
        public ContactRepository(BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }
        public ContactModel GetContact(int? id)
        {
            return _bancoContext.Contact.FirstOrDefault(X => X.Id == id);
        }

        public List<ContactModel> SearchAll(int UserId)
        {
               return _bancoContext.Contact.Where(x => x.UserId == UserId).ToList();
        }
        public ContactModel Add(ContactModel contact)
        {
            // insert into Contact
            _bancoContext.Contact.Add(contact);
            _bancoContext.SaveChanges();

             return contact;
        }

        public ContactModel Update(ContactModel contact)
        {
            // update row in table contact
            ContactModel contactModel = GetContact(contact.Id);

            if (contactModel == null) throw new Exception("Error in updated Contact");

            contactModel.Name = contact.Name;
            contactModel.Email = contact.Email;
            contactModel.Phone = contact.Phone;

            _bancoContext.Contact.Update(contactModel);
            _bancoContext.SaveChanges();

            return contactModel;
        }

        public bool Delete(int id)
        {
            ContactModel contact = _bancoContext.Contact.FirstOrDefault(x => x.Id == id);

            if (contact == null) throw new Exception("Error in deleted Contact");

            _bancoContext.Contact.Remove(contact);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
