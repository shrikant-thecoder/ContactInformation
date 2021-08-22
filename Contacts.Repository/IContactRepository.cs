using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Repository
{
    public interface IContactRepository 
    {
        List<Contact> Get();
        Contact Get(int id);
        // Marks an entity as new
        void Add(Contact entity);
        // Marks an entity as modified
        void Update(Contact entity);
        // Marks an entity to be removed
        void Delete(Contact entity);
    }
}
