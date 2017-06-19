using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using AutoMapper;
using LoanAPI.Models;
using DataAccessLayer.BusinessEntities;
using DataAccessLayer.Interfaces;

namespace LoanAPI.Controllers
{
    public class LoanDetailsApiController : ApiController
    {

        ILoanDetailsDAL dalObj = new LoanDetailsDAL();

        // GET api/loandetailsapi/5
        [Route("api/loandetailsapi/{id:int}")]
        public List<runTimeTableModel> GetAccountStatement(int id)
        {
            try
            {
                var custInfo = dalObj.getAccountStatement(id);
                var itemlist = new List<runTimeTableModel>();
                //Mapper initialization and creation
                Mapper.Initialize(cfg => { cfg.CreateMap<runtimeTable, runTimeTableModel>(); });
                if (custInfo.Any())
                {
                    foreach (var item in custInfo)
                    {
                        runTimeTableModel userModel =
                        Mapper.Map<runtimeTable, runTimeTableModel>(item);
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

        //Pay EMI
        [Route("api/loandetailsapi/GetEMIpayment/{id:int}")]
        public void GetEMIpayment(int id)
        {
            try
            {
                dalObj.PayEmi(id);    
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }


    }
}
