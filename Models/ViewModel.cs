using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contacts.Models;

namespace ContactInformation.Models
{
    public class ViewModel
    {
        public List<Contact> contacts { get; set; }
        public Contact contact { get; set; }
    }
}