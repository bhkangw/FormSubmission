using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string fname, string lname, int age, string email, string password)
        {
            User NewUser = new User
            {
                FirstName = fname,
                LastName = lname,
                Age = age,
                Email = email,
                Password = password
            };

            if(TryValidateModel(NewUser) == false)
            {
                ViewBag.errors = ModelState.Values;
                return View();
            }
            else
            {
                return RedirectToAction("Success");
            }
        }

        [HttpGet]
        [Route("/success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}
