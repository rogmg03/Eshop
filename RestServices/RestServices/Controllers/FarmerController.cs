using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using RestServices.Models;


namespace RestServices.Controllers
{
    public class FarmerController : ApiController
    {


        [Route("api/farmers/Post")]
        [HttpPost]

        public IHttpActionResult SetFarmer(Farmers model)
        {

            var farmer=new Models. Farmers();
            farmer.id = model.id;
             farmer.name = model.name;
            farmer.lastName = model.lastName;
            farmer.address = model.address;
            farmer.sinpe = model.sinpe;
             farmer.userName = model.userName;
            farmer.password = model.password;
            farmer.phone = model.phone;
            farmer.places = model.places;
            string json = JsonConvert.SerializeObject(farmer);

            //write string to file
            System.IO.File.WriteAllText(@".Eshop\RestServices\RestServices\JsonDataBase\farmers.json", json);

             return Ok("Se insertó el agricultor");

        }


        [Route("api/farmers")]
        [HttpGet]
        // este metodo se encarga de enviar todos  los agritucores registrados
        public IEnumerable<Farmers> FarmerInfo()
        {
            int size = getSize();
            Farmers[] farmers = new Farmers[size];
            string json = System.IO.File.ReadAllText(@".Eshop\RestServices\RestServices\JsonDataBase\farmers.json");
            dynamic array = JsonConvert.DeserializeObject(json);
           
            for (int index = 0; index < size; index++)
            {
                Farmers farmer = JsonConvert.DeserializeObject<Farmers>(array[index].ToString());
                farmers[index] = farmer;
            }
            return farmers;
        }


        [Route("api /CountUsers")]
        [HttpGet]

        public int getSize()
        {
            string json = System.IO.File.ReadAllText(@".Eshop\RestServices\RestServices\JsonDataBase\farmers.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            return array.Count;
        }

        [Route("api/names")]
        [HttpGet]

        public IEnumerable<string> FarmerNames()
        {
            int size = getSize();
            string[] farmers = new string[size];
            string json = System.IO.File.ReadAllText(@".Eshop\RestServices\RestServices\JsonDataBase\farmers.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            // List<Farmers> farmers = new List<Farmers>();
            // foreach(var element in array){    
            //     farmers.Add(farmer);
            // } 
            for (int index = 0; index < size; index++)
            {
                Farmers farmer = JsonConvert.DeserializeObject<Farmers>(array[index].ToString());
                farmers[index] = farmer.name;
            }
            return farmers;
        }

        [Route("api/actualizar")]
        [HttpPut]
        public IHttpActionResult Update(Farmers farmers)
        {
            int size = getSize();
          
            string json = System.IO.File.ReadAllText(@".Eshop\RestServices\RestServices\JsonDataBase\farmers.json");

            dynamic array = JsonConvert.DeserializeObject(json);
            
            for (int index = 0; index < size; index++)
            {
                Farmers farmer = JsonConvert.DeserializeObject<Farmers>(array[index].ToString());
                if (farmer.id == farmers.id)
                {
                    //errores de validaciones
                    //write string to file
                    System.IO.File.WriteAllText(@".Eshop\RestServices\RestServices\JsonDataBase\farmers.json", json);





                }
              
             




                }
            return Ok("Se insertó el agricultor");


        }

       
    }
}


