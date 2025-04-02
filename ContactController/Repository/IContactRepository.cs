using ContactController.Models;

namespace ContactController.Repository
{
    public interface IContactRepository
    {
        List<ContactModel> SearchAll();
        ContactModel Add(ContactModel contact);

    }
}
