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
    public class LoanDetailsController : Controller
    {
        //
        // GET: /LoanDetails/
        /// <summary>
        /// Screen gives option to PayEMi and Get ACCt Statement
        /// </summary>
        /// <returns></returns>
        /// 
       
        public ActionResult paymentOptions(int id)
        {
            //Session["ApplicantId"] = id;
            applicantModel.applicantId = id;
            return View();
        }


        /// <summary>
        /// GET Account statement
        /// </summary>
        /// <returns></returns>
        //public async Task<ActionResult> getAccountStatement()
        //{
        //    //int id = Convert.ToInt32(@Session["UserName"]);
        //    string apiUrl = "http://localhost:49601/api/LoanDetailsApi/" + applicantModel.applicantId;

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(apiUrl);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = await client.GetAsync(apiUrl);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var data = await response.Content.ReadAsStringAsync();

        //            JavaScriptSerializer oJS = new JavaScriptSerializer();
        //            List<runtimeTableType> obj = new List<runtimeTableType>();
        //            obj = oJS.Deserialize<List<runtimeTableType>>(data);
        //            return View(obj);
        //        }

        //        else
        //            return View("Error");
        //    }
          
        //}

        public ActionResult getAccountStatement3()
        {
            return View();

        }

        public async Task<ActionResult> getAccountStatement2()
        {
            //int id = Convert.ToInt32(@Session["UserName"]);
            string apiUrl = "http://localhost:49601/api/LoanDetailsApi/" + applicantModel.applicantId;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data2 = await response.Content.ReadAsStringAsync();
                    
                    //return Json(new { data = data2 }, JsonRequestBehavior.AllowGet);
                    JavaScriptSerializer oJS = new JavaScriptSerializer();

                    List<runtimeTableType> obj = new List<runtimeTableType>();
                    
                    
                    obj = oJS.Deserialize<List<runtimeTableType>>(data2);
                   
                    return Json(new { data = obj }, JsonRequestBehavior.AllowGet);
                   // return View(data);
                }

                else
                    return View("Error");
            }

        }

        /// <summary>
        /// Pay EMI
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> payEMI()
        {
            string apiUrl = "http://localhost:49601/api/LoanDetailsApi/GetEMIpayment/" + applicantModel.applicantId;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                    //client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("getAccountStatement3");
                }

                else
                    return View("Error");
            }
          
        }

        
    }
}
