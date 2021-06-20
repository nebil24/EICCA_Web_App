using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NPO.Models;
using Microsoft.AspNetCore.Http;

namespace NPO.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public int? InSession { 
            get { return HttpContext.Session.GetInt32("userid"); }
            set { HttpContext.Session.SetInt32("userid", (int)value); }
        }
        
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult OurSchool()
        {
            return View();
        }
        [HttpPost("contact_us")]
        public IActionResult contact_us(Message fromform)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(fromform);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Submitted");
        }

        public IActionResult Submitted()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost("NewLogin")]
        public IActionResult NewLogin(LoginUser user)
        {
            if(ModelState.IsValid)
            {
                var userInDb = dbContext.users.FirstOrDefault(u => u.Email == user.Email);
                //if user not in database check isnt showing error
                if(userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("LogIn");
                }
                if(user.Password != userInDb.Password)
                {
                    ModelState.AddModelError("Password", "Incorrect Password");
                    return View("LogIn");
                }
                User currentUser = dbContext.users.FirstOrDefault(u => u.Email == user.Email);
                InSession = currentUser.UserId;
                return RedirectToAction("Submitted");
            }
            else{
                return View("LogIn");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
