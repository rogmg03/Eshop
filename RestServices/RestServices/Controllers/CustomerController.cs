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
    /*
     *Esta blase se encarga de  gestionar los objetos de la clase Cliente ubicada en la sección  de Models, donde mediante el protocolo http
     *se comunica mediante el API con la seecion del Model y del view del frontEnd.
     * 
     * 

      */
    public class CustomerController : ApiController
    {


        [Route("api/customers/get")]
        [HttpGet]
        /*
         * Este método se encarga de obtener todos los valores de los clientes almacenados en un JSON  
         * 
         */
        public IEnumerable<Customer> getCustomers()
        {
            int size = getSize();
            Customer[] customerList = new Customer[size];
            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\customer.json");
            dynamic array = JsonConvert.DeserializeObject(json);
         
            for (int index = 0; index < size; index++)
            {
                Customer customerJSON = JsonConvert.DeserializeObject<Customer>(array[index].ToString());

                customerList[index] = customerJSON;
            }
            return customerList;
        }


        [Route("api/customers/post")]
        [HttpPost]
        /*
         * Este metodo medainte el protocolo HTTP recibe una serialización de un objeto  tipo Customer,
         *en este casos  toman los valores  y se insertan en los valores JSON mediante un Constructor
         */

        public IHttpActionResult SetCustomer(Customer model)
        {

            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\customer.json");// se llama al JSON, 
            var convertedJson = JsonConvert.SerializeObject(new Customer((int)model.id, (string)model.name, (string)model.lastName, (string)model.address, (int)model.phone, (string)model.userName, (int)model.password), Formatting.Indented);
            System.IO.File.WriteAllText(@"E:\Eshop\RestServices\RestServices\DataBase\customer.json", convertedJson.ToString());

            return Ok("SE INSERTÓ CLIENTE");

        }


        [Route("api/customers/count")]
        [HttpGet]
        // se obtiene  la cantidad de  clientes  que se han registrado.
        public int getSize()
        {
            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\customer.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            return array.Count;
        }

        /*
         * devuelve el nombre de los clientes insertados 
         * 
         */
        [Route("api/customers/getAllNames")]
        [HttpGet]

        public IEnumerable<string> CustomerNames()
        {
            int size = getSize();
            string[] customers = new string[size];
            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\customer.json");
            dynamic array = JsonConvert.DeserializeObject(json);
          
            for (int index = 0; index < size; index++)
            {
                Customer customerNames = JsonConvert.DeserializeObject<Customer>(array[index].ToString());
                customers[index] = customerNames.name + "" + customerNames.lastName;
            }
            return customers;
    }
        /*
         * Este metodo se  encarga de actualizar los valores JSON de algun agricultor en específico
         */
        [Route("api/customer/actualizar")]
        [HttpPut]

        public IHttpActionResult Update(Customer ncustomer)
        {
            int size = getSize();
            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\farmers.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            for (int index = 0; index < size; index++)
            {
                Customer farmer = JsonConvert.DeserializeObject<Customer>(array[index].ToString());
                if (farmer.id == ncustomer.id)
                {
                    array[index]["id"] = ncustomer.id;
                    array[index]["name"] = ncustomer.name;
                    array[index]["lastName"] = ncustomer.lastName;
                    array[index]["address"] = ncustomer.address;
                    array[index]["serName"] = ncustomer.userName;
                    array[index]["password"] = ncustomer.password;
                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(array, Newtonsoft.Json.Formatting.Indented);
                    System.IO.File.WriteAllText(@"E:\Eshop\RestServices\RestServices\DataBase\farmers.json", output);
                    return Ok("  se ha actualizadoel cliente: " + ncustomer.name);
                }
                else { return Ok("el dato no hace match con la base de datos"); }
 }
            return Ok("Se insertó el clienter");


        }
    }
}