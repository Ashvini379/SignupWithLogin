using SignupWithLogin.Resository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SignupWithLogin.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                try
                {
                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.GetResponse("api/employees");
                    response.EnsureSuccessStatusCode();
                    List<Models.Employee> employees = response.Content.ReadAsAsync<List<Models.Employee>>().Result;
                    ViewBag.Title = "All Employees";
                    return View(employees);
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
        public ActionResult Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Employees/GetEmployee?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.Employee employees = response.Content.ReadAsAsync<Models.Employee>().Result;
            ViewBag.Title = "All Employees";
            return View(employees);
        }
        //[HttpPost]  
        public ActionResult Update(Models.Employee employee)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Employees/PutEmployee", employee);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Employees/GetEmployee?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.Employee products = response.Content.ReadAsAsync<Models.Employee>().Result;
            ViewBag.Title = "All Employees";
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Employee employee)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Employees/PostEmployee", employee);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Employees/DeleteEmployee?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");


        }
    }
}