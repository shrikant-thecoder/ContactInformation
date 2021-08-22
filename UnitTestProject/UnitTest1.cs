using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using ContactInformation.Controllers;
using Contacts.Models;
using ContactsAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllContacts_ShouldReturnAllContacts()
        {
            var testContacts = GetTestContacts();
            var controller = new ContactsController();

            List<Contact> result = (List<Contact>)controller.Get();
            Assert.AreEqual(testContacts.Count, result.Count);
        }

        [TestMethod]
        public void GetContact_ShouldReturnCorrectContact()
        {
            var testContacts = GetTestContacts();
            var controller = new ContactsController();

            var result = controller.Get(4);
            Assert.IsNotNull(result);
            Assert.AreEqual(testContacts[3].FirstName, result.FirstName);
        }
        private List<Contact> GetTestContacts()
        {
            var testContacts = new List<Contact>();
            testContacts.Add(new Contact { Id = 1, FirstName = "Shrikant", LastName = "Mule", Email = "abc@12.com", PhoneNo = "123", Status = true });
            testContacts.Add(new Contact { Id = 2, FirstName = "Dipali", LastName = "Mule", Email = "asd", PhoneNo = "123", Status = false });
            testContacts.Add(new Contact { Id = 3, FirstName = "abc-changed", LastName = "xyz", Email = "sanc@gda.com", PhoneNo = "123", Status = true });
            testContacts.Add(new Contact { Id = 4, FirstName = "cdc", LastName = "weradfasd", Email = "sdl@sdf.com", PhoneNo = "123456", Status = true });

            return testContacts;
        }
    }
}
