using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contact.app.business.entity;
using contact.app.business.repository;
using contact.app.mvc.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace contact.app.mvc.Controllers
{
    public class StartController : Controller
    {
        private readonly IAuthRepository _repository;
        public StartController(IAuthRepository repository) {
            _repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View(new ModelSignIn());
        }

        [HttpPost]
        public IActionResult SignIn([Bind("Username,Password")] ModelSignIn model)
        {
            if (ModelState.IsValid) {
                if (_repository.SignIn(model.Username, model.Password))
                {
                    if (StartNewSessionForUsername(model.Username))
                    {
                        return Redirect("/Contact");
                    }
                }
                else {
                    model.Message = "Sign in failed. Username or password is not correct.";
                }
            }
            return View(model);
        }

        public IActionResult Register() {
            return View(new ModelRegister());
        }

        [HttpPost]
        public IActionResult Register([Bind("Username,Password,Email,PasswordConfirm")] ModelRegister model) {
            if (ModelState.IsValid)
            {
                _repository.Register(model.Username, model.Password, model.Email);
                _repository.Save();

                if (StartNewSessionForUsername(model.Username)) {
                    return Redirect("/Contact");
                }
            }
            model.Message = "Registration error. Please try again.";
            return View(model);
        }

        public IActionResult Exit() {
            RemoveSession();
            return Redirect("SignIn");
        }

        private bool StartNewSessionForUsername(string username) {
            if (!string.IsNullOrEmpty(username))
            {
                var obj = _repository.GetByUsername(username);
                if (obj != null && obj.Count(o => o.Username == username) == 1)
                {
                    NewSession(obj.First().OnlineUserId);
                    return true;
                }
            }
            return false;
        }

        private void NewSession(int id) {
            HttpContext.Session.SetInt32("current.user", id);
        }

        private void RemoveSession()
        {
            HttpContext.Session.SetInt32("current.user", 0);
        }
    }
}

