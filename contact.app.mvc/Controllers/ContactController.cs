using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contact.app.business.entity;
using contact.app.business.repository;
using contact.app.mvc.Filter;
using contact.app.mvc.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace contact.app.mvc.Controllers
{
    [FilterAuth]
    public class ContactController : Controller
    {
        private readonly IGenericRepository<Contact> _repository;
        public ContactController(IGenericRepository<Contact> repository)
        {
            _repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var contacts = _repository.All().ToList();
            return View(contacts);
        }

        public IActionResult Add(int? Id) {
            if(Id == null) return View(new Contact());
            var model = _repository.GetById((int)Id);

            return View(model);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null) return NotFound();
            _repository.Delete((int)Id);
            _repository.Save();
            return Redirect("/Contact");
        }

        [HttpPost]
        public IActionResult Add([Bind("ContactId,Firstname,Surname,ContactEmail,ContactPhone,AddressSuburb,AddressStreet,AddressProvinceId,AddressCountryId")]Contact obj)
        {
            if (ModelState.IsValid) {
                if (obj.ContactId <= 0)
                {
                    _repository.Create(obj, 1);
                }
                else {
                    _repository.Update(obj);
                }

                _repository.Save();
                return Redirect("/Contact");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Search(string query) {
            if (!string.IsNullOrEmpty(query)) {

                var contacts = _repository.Filter(o =>
                    o.Firstname.ToLower().Contains(query.ToLower())
                    || o.Surname.ToLower().Contains(query.ToLower())
                    || o.ContactEmail.ToLower().Contains(query.ToLower())
                    || o.ContactPhone.ToLower().Contains(query.ToLower())).ToList();
                return View(contacts);
            }
            return NotFound();
        }
    }
}

