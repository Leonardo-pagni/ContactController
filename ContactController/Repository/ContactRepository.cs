using ContactController.Data;
using ContactController.Models;

namespace ContactController.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly BancoContext _bancoContext;
        public ContactRepository(BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }
        public ContactModel Add(ContactModel contact)
        {
            // insert into Contact
            _bancoContext.Contact.Add(contact);
            _bancoContext.SaveChanges();

             return contact;
        }
    }
}
