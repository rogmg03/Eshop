﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                string json = System.IO.File.ReadAllText(@"./JsonDataBase/products.json");
                dynamic array = JsonConvert.DeserializeObject(json);
                for (int index = 0; index < size; index++)
                {
                    Products product = JsonConvert.DeserializeObject<Products>(array[index].ToString());
                    products[index] = product;
                }
                return products;
            }
            public int getSize()
            {
                string json = System.IO.File.ReadAllText(@"./JsonDataBase/products.json");
                dynamic array = JsonConvert.DeserializeObject(json);
                return array.Count;
            }
        }
    }

    // Products[] products = new Products[]{
    //     new Products {Code = "111111", Description = "BARILLA FARINA 1 KG", Um = "PZ", PcCart = 24, NetWeight = 1, Price = 1.09 },
    //     new Products {Code = "013500121", Description = "BARILLA PASTA GR.500 N.70 1/2 PENNE", Um = "PZ", PcCart = 30, NetWeight = 0.5, Price = 1.3 },
    //     new Products {Code = "007686402", Description = "FINDUS FIOR DI NASELLO 300 GR", Um = "PZ", PcCart = 8, NetWeight = 0.3, Price = 6.46 },
    //     new Products {Code = "057549001", Description = "FINDUS CROCCOLE 400 GR", Um = "PZ", PcCart = 12, NetWeight = 0.4, Price = 5.97 }
    // };

    // [HttpGet]
    // public IEnumerable<Products> ListAllProducts(){
    //     // string jsonString = File.ReadAllText("./test.json");
    //     // weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString);
    //     // return jsonString;
    //     return products;
    // }

    // [HttpGet("code/{codart}")]
    // public IEnumerable<Products> ListProductsByCode(string codart){
    //      IEnumerable<Products> retVal =
    //         from g in products 
    //         where g.Code.Equals(codart) 
    //         select g;

    //     return retVal;

    // }

    // [HttpGet("description/{desart}")]
    // public IEnumerable<Products> ListProductsByDescription(string desart){
    //     IEnumerable<Products> retVal = 
    //         from g in products
    //         where g.Description.ToUpper().Contains(desart.ToUpper())
    //         orderby g.Code
    //         select g;

    //     return retVal;
    // }




}
