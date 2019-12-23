using SignupWithLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignupWithLogin.Controllers
{
    public class LoginController : Controller
    {
        SignupLoginEntities entities = new SignupLoginEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u)
        {
            var user = entities.Users.Where(model => model.username == u.username && model.password == u.password).FirstOrDefault();
            if(user != null)
            {
                Session["UserId"] = u.Id;
                Session["UserName"] = u.username;
                TempData["LoginSuccessMessage"] = "<script>alert('Login Succefully !')</script>";
                return RedirectToAction("Index","User");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Username and Password incorrect')</script>";
                return View();
            }

        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if(ModelState.IsValid)
            {                
                entities.Users.Add(user);
                int a =entities.SaveChanges();

                if(a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registerd Succefully !')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registerd Failed !')</script>";

                }

                return RedirectToAction("Index", "Login");
            }

            return View();
        }
        
    }
}