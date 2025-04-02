using ContactController.Models;

namespace ContactController.Repository
{
    public interface IContactRepository
    {
        ContactModel Add(ContactModel contact);

    }
}
