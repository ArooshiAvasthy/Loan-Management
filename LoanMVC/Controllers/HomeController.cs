using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoanMVC.Models;
using System.Net;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace LoanMVC.Controllers
{
    public class HomeController : Controller
    {
       

        public ActionResult Index()
        {
            return View();
        }

        //Customer Sign In Page
        public ActionResult CustomerSignUp()
        {
            ViewBag.Message = "Your application description page.";
            //return RedirectToAction("Create");
            return View();
        }
        [HttpPost]
        
        public ActionResult CustomerSignUp(string username,string password)
        {
            if(ModelState.IsValid)
            {
                Session["Username"] = username;
                Session["Password"] = password;
                Session["Role"] = "Customer";
            }
            return RedirectToAction("UserDashBoard");
           
        }

        //Function for setting Session Variables
        public ActionResult UserDashBoard()
        {
            if(Session["UserName"] !=null && Session["Password"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("CustomerSignUp");
            }
        }

        // GET: /Home/Register
        //for Creating a new Cutomer register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(CustomerType customer)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "http://localhost:49601/api/customerapi";
                var response = await client.PostAsJsonAsync(apiUrl, customer);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("CustomerSignUp");
                }
                else
                {
                    return View("Error");
                }
            }
            
        }
        //New Customer gets created when user enter details and clicks on Register button
        // POST: /Home/Details/5
        public ActionResult Details(string name)
        {

            return View();
        }



        /// <summary>
        /// Employee Entry
        /// </summary>
        /// <returns></returns>

        public ActionResult EmployeeSignUp()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult EmployeeSignUp(string username, string password)
        {
            if (ModelState.IsValid)
            {
                Session["Username"] = username;
                Session["Password"] = password;
                Session["Role"] = "Employee";
            }
            return RedirectToAction("UserDashBoard");
           
        }


        
      
        
    }
}