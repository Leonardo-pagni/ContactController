using ContactController.Models;

namespace ContactController.Repository
{
    public interface IContactRepository
    {
        ContactModel GetContact(int? id);
        List<ContactModel> SearchAll(int UserId);
        ContactModel Add(ContactModel contact);

        ContactModel Update(ContactModel contact);
        bool Delete(int id);

    }
}
