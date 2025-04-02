using ContactController.Models;

namespace ContactController.Repository
{
    public interface IContactRepository
    {
        ContactModel GetContact(int? id);
        List<ContactModel> SearchAll();
        ContactModel Add(ContactModel contact);

        ContactModel Update(ContactModel contact);

    }
}
