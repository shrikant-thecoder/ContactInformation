using Contacts.Models;
using Contacts.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Repository
{
    public class ContactRepository : IContactRepository
    {
        ContactsDB db;
        public void Add(Contact entity)
        {
            db = new ContactsDB();
            db.Contacts.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Contact entity)
        {
            db = new ContactsDB();
            db.Contacts.Attach(entity);
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Contact> Get()
        {
            db = new ContactsDB();
            return db.Contacts.ToList();
        }

        public Contact Get(int id)
        {
            db = new ContactsDB();
            return db.Contacts.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(Contact entity)
        {
            db = new ContactsDB();
            db.Contacts.Attach(entity);
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
