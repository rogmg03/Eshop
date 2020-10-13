using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Newtonsoft.Json;

namespace RestServices.Controllers
{
    public class FamerController : ApiController
    {


        [Route("api/farmers")]
        [HttpGet]
        // este metodo se encarga de enviar todos  los agritucores registrados
        public IEnumerable<Farmers> FarmerInfo()
        {
            int size = getSize();
            Farmers[] farmers = new Farmers[size];
            string json = System.IO.File.ReadAllText(@"./JsonDataBase/farmers.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            // List<Farmers> farmers = new List<Farmers>();
            // foreach(var element in array){    
            //     farmers.Add(farmer);
            // } 
            for (int index = 0; index < size; index++)
            {
                Farmers farmer = JsonConvert.DeserializeObject<Farmers>(array[index].ToString());
                farmers[index] = farmer;
            }
            return farmers;
        }


        [Route("api/CountUsers")]
        [HttpGet]

        public int getSize()
        {
            string json = System.IO.File.ReadAllText(@"./JsonDataBase/farmers.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            return array.Count;
        }

        [Route("api/names")]
        [HttpGet]

        public IEnumerable<string> FarmerNames()
        {
            int size = getSize();
            string[] farmers = new string[size];
            string json = System.IO.File.ReadAllText(@"./JsonDataBase/farmers.json");
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


        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

