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
    public class EmployeeApiController : ApiController
    {
        IEmployeeDAL dalObj = new EmployeeDAL();

       
        public List<LoanApplicantModel> GetLoanApplicants()
        {
            try
            {
                var custInfo = dalObj.GetAllApplicants();
                var itemlist = new List<LoanApplicantModel>();
                //Mapper initialization and creation
                Mapper.Initialize(cfg => { cfg.CreateMap<LoanApplicant, LoanApplicantModel>(); });
                if (custInfo.Any())
                {
                    foreach (var item in custInfo)
                    {
                        LoanApplicantModel userModel =
                         Mapper.Map<LoanApplicant, LoanApplicantModel>(item);
                        itemlist.Add(userModel);

                    }
                }

                return itemlist;
            }
            catch(Exception ex)
            {
                throw ex;
            }
         

        }

        [Route("api/employeeapi/{id:int}")]
        public LoanApplicantModel GetCheckApplicants(int id)
        {
            try
            {
                var custInfo = dalObj.CheckApplicantsforLoan(id);

                //Mapper initialization and creation
                Mapper.Initialize(cfg => { cfg.CreateMap<LoanApplicant, LoanApplicantModel>(); });
                LoanApplicantModel infoModel = Mapper.Map<LoanApplicant, LoanApplicantModel>(custInfo);

                return infoModel;
            }
           
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
