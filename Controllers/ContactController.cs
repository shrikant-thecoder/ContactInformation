using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactInformation.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using System.Configuration;

namespace ContactInformation.Controllers
{
    public class ContactController : Controller
    {
        ViewModel vm;
        string BaseUrl = ConfigurationManager.AppSettings.Get("BaseUrl");
        public async Task<ActionResult> Delete(int Id)
        {
            vm = new ViewModel { contact = new Contact(), contacts = new List<Contact>() };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.DeleteAsync("api/contacts/" + Id);
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    vm.contacts = JsonConvert.DeserializeObject<List<Contact>>(response);
                }
            }
            return View("Create", vm);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            vm = new ViewModel { contact = new Contact(), contacts = new List<Contact>() };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/contacts/" + Id);
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    vm.contact = JsonConvert.DeserializeObject<Contact>(response);
                }
                Res = await client.GetAsync("api/contacts");
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    vm.contacts = JsonConvert.DeserializeObject<List<Contact>>(response);
                }
            }
            return View("Create", vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int? Id,Contact contact)
        {
            ViewModel vm = new ViewModel { contact = new Contact(), contacts = new List<Contact>() };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                contact.Id = Id ?? 0;
                client.DefaultRequestHeaders.Clear();
                contact.Status = true;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(contact);
                ModelState.Clear();
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PutAsync("api/contacts",stringContent);
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    vm.contacts = JsonConvert.DeserializeObject<List<Contact>>(response);
                }
                vm.contact = new Contact();
            }
            return View("Create",vm);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewModel vm = new ViewModel { contact=new Contact(), contacts = new List<Contact>() };
                using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/contacts");
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    vm.contacts = JsonConvert.DeserializeObject<List<Contact>>(response);
                }
            }
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                ViewModel vm = new ViewModel { contacts = new List<Contact>() };
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    contact.Status = true;
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var json = JsonConvert.SerializeObject(contact);
                    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                    ModelState.Clear();
                    HttpResponseMessage Res = await client.PostAsync("api/contacts", stringContent);
                    if (Res.IsSuccessStatusCode)
                    {
                        var response = Res.Content.ReadAsStringAsync().Result;
                        vm.contacts = JsonConvert.DeserializeObject<List<Contact>>(response);
                    }
                }
                vm.contact = new Contact();

                return View(vm);
            }
            return View();
        }
    }
}