using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using AutoMapper;
using LoanAPI.Models;

namespace LoanAPI.Controllers
{
    public class ApplyLoanApiController : ApiController
    {
        ICustomerDAL dalObj = new CustomerDAL();
       
        // GET: api/LoanApi/5
        [Route("api/applyloanapi/{username}")]
        public CustomerModel GetInfo(string username)
        {
            try
            {
                //string username = "avasthy";
                var custInfo = dalObj.GetCustomerInfo(username);
                //Mapper initialization and creation
                Mapper.Initialize(cfg => { cfg.CreateMap<Customer, CustomerModel>(); });
                CustomerModel infoModel = Mapper.Map<Customer, CustomerModel>(custInfo);

                return infoModel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        

        // POST: api/LoanApi
        [HttpPost]
        [Route("api/ApplyLoanApi/PostAppliedLoan/{name}")]
        public void PostAppliedLoan([FromUri] string name,[FromBody]LoanApplicantModel obj)
        {
            try
            {
                //LoanApplicantModel obj = new LoanApplicantModel();
                //obj.Name = value[0];
                //obj.Age = Convert.ToInt16(value[1]);
                //obj.Salary = Convert.ToDouble(value[2]);
                //obj.TypeOfLoan = value[3];
                //obj.Duration = Convert.ToInt16(value[4]);
                //obj.Amount = Convert.ToDouble(value[5]);
                //string username = value[6];
                //Mapper initialization and creation
                Mapper.Initialize(cfg => { cfg.CreateMap<LoanApplicantModel, LoanApplicant>(); });
                LoanApplicant loaninfo = Mapper.Map<LoanApplicantModel, LoanApplicant>(obj);
                dalObj.applyLoan(loaninfo, name);
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }

      
    }
}
