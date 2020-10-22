
using System.Collections.Generic;

using System.Web.Http;
using RestServices.Models;
using Newtonsoft.Json;

namespace RestServices.Controllers
{
    public class ProductController : ApiController
    {


        [Route("api/products")]
        public class ProductsController
        {

            [HttpGet]
            public IEnumerable<Products> ListAllProducts()
            {
                int size = getSize();
                Products[] products = new Products[size];
                string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\products.json");
                dynamic array = JsonConvert.DeserializeObject(json);
                for (int index = 0; index < size; index++)
                {
                    Products product = JsonConvert.DeserializeObject<Products>(array[index].ToString());
                    products[index] = product;
                }
                return products;
            }



            /*
             * este metodo toma la cantidad de productos que se insertaron funcionalidad para saber si aun  
             * queda en la base de datos algun prodcuto almacenado.
             */
            [Route("api/products/count")]
            [HttpGet]
            public int getSize()
            {
                string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\products.json");
                dynamic array = JsonConvert.DeserializeObject(json);
                return array.Count;
            }

            //////////////////estoy aqui//////////////////////////////////////




            [Route("api /name/products")]
            [HttpGet]
            // devulve el número de  productos almacenados.
            public IEnumerable<string> Products()
            {
                int size = getSize();
                string[] listProducts = new string[size];
                string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\products.json");
                dynamic array = JsonConvert.DeserializeObject(json);

                for (int index = 0; index < size; index++)
                {
                    Products p = JsonConvert.DeserializeObject<Products>(array[index].ToString());
                    listProducts[index] = p.name;
                }
                return listProducts;
            }

            /*
            * Este metodo se enca se encarga de poder realizar  una actualización de datos de los prodcutos en caso de haber cometido un error en su inserción

            */
            [Route("api/products/update")]
            [HttpPut]
           
            public void Update(Products product)
            {
                int size = getSize();
                string json = System.IO.File.ReadAllText(@"E:\Eshop\RestServices\RestServices\DataBase\products.json");
                dynamic array = JsonConvert.DeserializeObject(json);
                for (int index = 0; index < size; index++)
                {
                    Products lisP = JsonConvert.DeserializeObject<Farmers>(array[index].ToString());
                    if (lisP.category == product.category)
                    {
                        array[index]["category"] = product.category;
                        array[index]["picture"] = product.picture;
                        array[index]["cost"] = product.cost;
                        array[index]["sellMode"] = product.sellMode;
                        array[index]["amount"] = product.amount;
                        string output = Newtonsoft.Json.JsonConvert.SerializeObject(array, Newtonsoft.Json.Formatting.Indented);
                        System.IO.File.WriteAllText(@"E:\Eshop\RestServices\RestServices\DataBase\products.json", output);
                      //  return Ok("  se ha actualizadoel cliente: " + product.name);

                    }
                    else {
                       // return Ok("el dato no hace match con la base de datos");
                    }

                }
              


            }
        }
    }
}



        ///////////////////////////////////////////////////////





    





