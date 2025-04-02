﻿using ContactController.Data;
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
        public ContactModel GetContact(int? id)
        {
            return _bancoContext.Contact.FirstOrDefault(X => X.Id == id);
        }

        public List<ContactModel> SearchAll()
        {
               return _bancoContext.Contact.ToList();
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
    }
}
