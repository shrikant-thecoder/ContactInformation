using Contacts.Models;
using Contacts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactsAPI.Controllers
{
    public class ContactsController : ApiController
    {
        public ContactsController() 
        {
            this.repository = new ContactRepository();
        }
        IContactRepository repository;
        public ContactsController(IContactRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Contact> Get()
        {
            return this.repository.Get();
        }
        public Contact Get(int id)
        {
            return this.repository.Get(id);
        }

        // POST: api/Default
        [HttpPost]
        public IEnumerable<Contact> Post(Contact contact)
        {
            this.repository.Add(contact);
            return this.repository.Get();
        }

        // PUT: api/Default/5
        [HttpPut]
        public IEnumerable<Contact> Put(Contact contact)
        {
            this.repository.Update(contact);
            return this.repository.Get();
        }

        [HttpDelete]
        // DELETE: api/Default/5
        public IEnumerable<Contact> Delete(int id)
        {
            Contact contact = this.repository.Get(id);
            contact.Status = false;
            this.repository.Update(contact);
            return this.repository.Get();
        }
    }
}
