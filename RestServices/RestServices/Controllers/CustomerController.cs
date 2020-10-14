﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using RestServices.Models;

namespace RestServices.Controllers
{
    public class CustomerController : ApiController
    {


        [Route("api/customers/getAll")]
        [HttpGet]
        // este metodo se encarga de enviar todos  los agritucores registrados
        public IEnumerable<Customer> getCustomers()
        {
            int size = getSize();
            Customer[] customerList = new Customer[size];
            string json = System.IO.File.ReadAllText(@"./JsonDataBase/customer.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            // List<Farmers> farmers = new List<Farmers>();
            // foreach(var element in array){    
            //     farmers.Add(farmer);
            // } 
            for (int index = 0; index < size; index++)
            {
                Customer customerJSON = JsonConvert.DeserializeObject<Customer>(array[index].ToString());

                customerList[index] = customerJSON;
            }
            return customerList;
        }


        [Route("api/customers/count")]
        [HttpGet]

        public int getSize()
        {
            string json = System.IO.File.ReadAllText(@"./JsonDataBase/customer.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            return array.Count;
        }

        [Route("api/customers/getAllNames")]
        [HttpGet]

        public IEnumerable<string> FarmerNames()
        {
            int size = getSize();
            string[] customers = new string[size];
            string json = System.IO.File.ReadAllText(@"./JsonDataBase/customer.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            // List<Farmers> farmers = new List<Farmers>();
            // foreach(var element in array){    
            //     farmers.Add(farmer);
            // } 
            for (int index = 0; index < size; index++)
            {
                Customer customerNames = JsonConvert.DeserializeObject<Customer>(array[index].ToString());

                customers[index] = customerNames.name + "" + customerNames.lastName;
            }
            return customers;
            ;
        }

    }
}