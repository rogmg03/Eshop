using System.Collections.Generic;
using Newtonsoft.Json;
using RestServices.Models;
using System.Web.Http;

namespace RestServices.Controllers
{
    
    public class FarmerController : ApiController
    {

        /*
         * Esta clase provee  metodos  que se encarguen  de  creación, actualización y eliminación de productores.
         */


        [Route("api/farmers/Post")]
        [HttpPost]
        
        public IHttpActionResult SetFarmer(Farmers model)
        {


            //string json = JsonConvert.SerializeObject(farmer);

            //write string to file


            // System.IO.File.WriteAllText(@"E:\Eshop\RestServices\RestServices\DataBase\farmers.json", json);

            //  return Ok("Se insertó el agricultor");

            /////////////////////////////////////////
            

            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\farmers.json");
            //var list = JsonConvert.DeserializeObject<LinkedList<Farmers>>(json);
           // List<Farmers> list = JsonConvert.DeserializeObject<List<Farmers>>(json);
          //  list.AddLast(new Farmers(model.id, model.name, model.lastName, model.address, model.sinpe, model.phone,model.places,model.userName, model.password));



            var convertedJson = JsonConvert.SerializeObject(new Farmers(model.id, model.name, model.lastName, model.address, model.sinpe, model.phone, model.places, model.userName, model.password)
, Formatting.Indented);
          
            System.IO.File.WriteAllText(@"E:\Eshop\RestServices\RestServices\DataBase\farmers.json", convertedJson.ToString());

            return Ok("SE INSERTÓ agricultor");
        }


        [Route("api/farmers")]
        [HttpGet]
        // este metodo se encarga de enviar todos  los agritucores registrados
        public IEnumerable<Farmers> FarmerInfo()
        {
            int size = getSize();
            Farmers[] farmers = new Farmers[size];
            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\farmers.json");
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
        /*
         * este metodo toma la cantidad de usuarios que se han registrado y lo retorna.
         */
        public int getSize()
        {
            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\farmers.json");
            dynamic array = JsonConvert.DeserializeObject(json);
            return array.Count;
        }

        [Route("api/names")]
        [HttpGet]
        // devulve el número de  agricultores almacenados.
        public IEnumerable<string> FarmerNames()
        {
            int size = getSize();
            string[] farmers = new string[size];
            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\farmers.json");
            dynamic array = JsonConvert.DeserializeObject(json);
           
            for (int index = 0; index < size; index++)
            {
                Farmers farmer = JsonConvert.DeserializeObject<Farmers>(array[index].ToString());
                farmers[index] = farmer.name;
            }
            return farmers;
        }

        [Route("api/actualizar")]
     
        /*
         * Este metodo se enca se encarga de poder realizar  una actualización de datos de los agricultores en caso de  que este
         * necesitara poder realizar algun cambio, este primero debe poder consultar si en  este  se encuentra  registrado en la base de  de datos.
         *  en caso contrario este  devuelve in mensaje de error
         */
        public IHttpActionResult Update(Farmers farmers)
        {
            int size = getSize();
          
            string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\farmers.json");

            dynamic array = JsonConvert.DeserializeObject(json);
            
            for (int index = 0; index < size; index++)
            {
                Farmers farmer = JsonConvert.DeserializeObject<Farmers>(array[index].ToString());
                if (farmer.id == farmers.id)
                {
                    array[index]["id"] = farmers.id;
                    array[index]["name"] = farmers.name;
                    array[index]["lastName"] = farmers.lastName;
                    array[index]["address"] = farmers.address;
                    array[index]["sinpe"] = farmers.sinpe;
                    array[index]["places"] = farmers.places;
                    array[index]["serName"] = farmers.userName;
                    array[index]["password"] = farmers.password;







                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(array, Newtonsoft.Json.Formatting.Indented);
                    System.IO.File.WriteAllText(@"E:\Eshop\RestServices\RestServices\DataBase\farmers.json", output);
                    return Ok("  se ha actualizadoel cliente: " + farmers.name);





                }
                else { return Ok("el dato no hace match con la base de datos"); }
              
             




                }
            return Ok("Se insertó el agricultor");


        }


       
    }
}


