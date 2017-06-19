using LoanMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LoanMVC.Models;

namespace LoanMVC.Controllers
{
    public class EmployeeController : Controller
    {
        /// <summary>
        /// this Action checks for the List of customers who have applied for Loan
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Check for List of applicants
        /// Process their Loan request
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> CheckLoanApplicants()
        {
           
            string apiUrl = "http://localhost:49601/api/EmployeeApi/";

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
                    //return View(obj);

                    List<LoanApplicantType> obj2 = new List<LoanApplicantType>();
                    foreach (var item in obj)
                    {
                        if (item.StatusOfLoan == "Pending"|| item.StatusOfLoan=="Rejected")
                        {
                            obj2.Add(item);
                        }
                    }

                    return View(obj2);
                   
                }

                else
                    return View("Error");
            }

        }


       /// <summary>
       /// Gets the updated status after Loan Process Request
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public async Task<ActionResult> ProcessApplicants(int id)
        {
            //int applicantID = 5;
            string apiUrl = "http://localhost:49601/api/EmployeeApi/" + id;

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
                    LoanApplicantType obj = new LoanApplicantType();
                    obj = oJS.Deserialize<LoanApplicantType>(data);
                    

                    return View(obj);
                }

                else
                    return View("Error");
            }
        }
        /// <summary>
        /// Action to get the list of Approved Applicants
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ApprovedApplicants()
        {

            string apiUrl = "http://localhost:49601/api/EmployeeApi/";

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
                   
                    //test
                    List<LoanApplicantType> obj2 = new List<LoanApplicantType>();
                    foreach(var item in obj)
                    {
                        if(item.StatusOfLoan=="Approved")
                        {
                            obj2.Add(item);
                        }
                    }

                    return View(obj2);
                }

                else
                    return View("Error");
            }

        }
       
    }
}
