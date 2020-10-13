using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RestService.Models;


namespace RestServices.Controllers
{
    public class CategoryManagementController : ApiController
    {



        [Route("api/CategoryManagement")]
        [HttpGet]
        // este metodo se encarga de enviar todos  los agritucores registrados
        public IEnumerable<CategoryManagement> getCategory()
        {
            int size = getSize();
            CategoryManagement[] arrCategory = new CategoryManagement[size];
            string json = System.IO.File.ReadAllText(@"./RestServices/JsonDataBase/categoryManagement.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            // List<Farmers> farmers = new List<Farmers>();
            // foreach(var element in array){    
            //     farmers.Add(farmer);
            // } 
            for (int index = 0; index < size; index++)
            {
                CategoryManagement cm = JsonConvert.DeserializeObject<CategoryManagement>(array[index].ToString());
                arrCategory[index] = cm;
            }
            return arrCategory;
        }




        public int getSize()
        {
            string json = System.IO.File.ReadAllText(@"./RestServices/JsonDataBase/categoryManagement.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            return array.Count;
        }
        // GET: api/CategoryManagements
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CategoryManagements/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CategoryManagements
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CategoryManagements/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CategoryManagements/5
        public void Delete(int id)
        {
        }
    }
}
