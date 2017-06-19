using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LoanMVC.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace LoanMVC.Controllers
{
    public class ApplyLoanController : Controller
    {
        // GET: ApplyLoan
        /// <summary>
        /// It displays the user welcome page
        /// with user info
        /// Apply for Loan option
        /// Check status of existing Loans
        /// </summary>
        /// <returns></returns>
       public async Task<ActionResult> Index()
        {
            string name = @Session["UserName"].ToString();
            string apiUrl = "http://localhost:49601/api/ApplyLoanApi/" + name;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    JavaScriptSerializer oJS = new JavaScriptSerializer();
                    CustomerType obj = new CustomerType();
                    obj = oJS.Deserialize<CustomerType>(data);
                    return View(obj);
                }

                else
                    return View("Error");
            }

           
        
        }


        // GET: ApplyLoan/Create
        /// <summary>
        /// Loan Application Form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CreateLoanApplication()
        {
            string name = @Session["UserName"].ToString();
            string apiUrl = "http://localhost:49601/api/ApplyLoanApi/" + name;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    JavaScriptSerializer oJS = new JavaScriptSerializer();
                    CustomerType obj = new CustomerType();
                    obj = oJS.Deserialize<CustomerType>(data);
                    return View(obj);
                }

                else
                    return View("Error");
            }

           // return View();
            
        }

        [HttpPost]
        public async Task<ActionResult> CreateLoanApplication(LoanApplicantType loanApplicant)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "http://localhost:49601/api/ApplyLoanApi/PostAppliedLoan/" + Session["UserName"].ToString();
                var response = await client.PostAsJsonAsync(apiUrl,loanApplicant);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
        }

        public async Task<ActionResult> ProvideLoanStatus()
        {
            string name = @Session["UserName"].ToString();
            string apiUrl = "http://localhost:49601/api/LoanProcessApi/" + name;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    JavaScriptSerializer oJS = new JavaScriptSerializer();
                    List<LoanApplicantType> obj = new List<LoanApplicantType>();
                    obj = oJS.Deserialize<List<LoanApplicantType>>(data);
                    return View(obj);
                }

                else
                    return View("Error");
            }
        }

        

        }
    }
