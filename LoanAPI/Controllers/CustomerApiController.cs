using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoanAPI.Models;
using DataAccessLayer;
using AutoMapper;
using DataAccessLayer.Interfaces;

namespace LoanAPI.Controllers
{
    public class CustomerApiController : ApiController
    {
        ICustomerDAL custObj = new CustomerDAL();
       
        //Create New Customer
        // POST api/customerapi
        public void Post(CustomerModel obj)
        {
            try
            {
                //CustomerModel obj = new CustomerModel();
                //obj.Name = value[0];
                //obj.Address = value[1];
                //obj.Age = Convert.ToInt16(value[2]);
                //obj.UserName = value[3];
                //obj.Password = value[4];

                    //Mapper initialization and creation
                    Mapper.Initialize(cfg=>{cfg.CreateMap<CustomerModel,Customer>();});
                    Customer dalObj= Mapper.Map<CustomerModel,Customer>(obj);
               
                    custObj.AddCustomer(dalObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    

    }
}
