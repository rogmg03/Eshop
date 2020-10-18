using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
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
         
            for (int index = 0; index < size; index++)
            {
                Customer customerJSON = JsonConvert.DeserializeObject<Customer>(array[index].ToString());

                customerList[index] = customerJSON;
            }
            return customerList;
        }


        [Route("api/customers/Post")]
        [HttpPost]

        public IHttpActionResult SetCustomer(Customer model)
        {

           
            

            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\customer.json");
            var list = JsonConvert.DeserializeObject<List<Customer>>(json);
            list.Add(new Customer(model.id, model.name, model.lastName, model.address, model.phone, model.userName, model.password));


           
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            System.IO.File.WriteAllText(@"E:\Eshop\RestServices\RestServices\DataBase\customer.json", convertedJson.ToString());



            return Ok("SE INSERTÓ CLIENTE");

        }


        [Route("api/customers/count")]
        [HttpGet]

        public int getSize()
        {
            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\customer.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            return array.Count;
        }

        [Route("api/customers/getAllNames")]
        [HttpGet]

        public IEnumerable<string> FarmerNames()
        {
            int size = getSize();
            string[] customers = new string[size];
            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\customer.json");
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