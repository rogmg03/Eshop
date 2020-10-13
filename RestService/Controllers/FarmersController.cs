using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Models;
using Newtonsoft.Json;
using System.IO;

namespace Controllers{
    public class FarmerController : ControllerBase{
        
        [Route ("api/farmers")]
        [HttpGet]
        // este metodo se encarga de enviar todos  los agritucores registrados
        public IEnumerable<Farmers> FarmerInfo(){
            int size = getSize();
            Farmers[] farmers = new Farmers[size];
            string json = System.IO.File.ReadAllText(@"./JsonDataBase/farmers.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            // List<Farmers> farmers = new List<Farmers>();
            // foreach(var element in array){    
            //     farmers.Add(farmer);
            // } 
            for(int index = 0; index < size; index++){
                Farmers farmer = JsonConvert.DeserializeObject<Farmers>(array[index].ToString());
                farmers[index] = farmer;
            }
            return farmers;
        }


        [Route("api/CountUsers")]
        [HttpGet]
        
        public int getSize(){
            string json = System.IO.File.ReadAllText(@"./JsonDataBase/farmers.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            return array.Count;
        }

        [Route("api/names")]
       [HttpGet]

        public IEnumerable<string> FarmerNames()
        {
            int size = getSize();
            string [] farmers = new string[size];
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

    }
    

}