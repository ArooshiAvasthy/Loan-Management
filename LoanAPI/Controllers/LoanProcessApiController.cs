using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanAPI.Models;
using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Interfaces;

namespace LoanAPI.Controllers
{
    public class LoanProcessApiController : ApiController
    {

        ICustomerDAL dalObj = new CustomerDAL();
        [Route("api/loanprocessapi/{username}")]
        public List<LoanApplicantModel> GetLoanStatus(string username)
        {
            try
            {
                var custInfo = dalObj.GetLoanStatus(username);
                List<LoanApplicantModel> applicantList = new List<LoanApplicantModel>();

                if (custInfo.Any())
                {
                    //Mapper initialization and creation
                    Mapper.Initialize(cfg => { cfg.CreateMap<LoanApplicant, LoanApplicantModel>(); });
                    foreach (var item in custInfo)
                    {
                        LoanApplicantModel infoModel = Mapper.Map<LoanApplicant, LoanApplicantModel>(item);
                        applicantList.Add(infoModel);
                    }
                }
                return applicantList;
            }
           
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
