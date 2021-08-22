using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Contacts.Repository.Infrastructure
{
    class ContactsDB:DbContext
    {
        public ContactsDB() : base("ContactsDB") { }

        public DbSet<Contact> Contacts { get; set; }

    }
}
