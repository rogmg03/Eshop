using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestService.Models
{
    public class CategoryManagement
    {
       // Las operaciones que debe proveer esta vista son creación, actualización y 
        //eliminación de categorías.Los principales datos de las categorías son:
            //identificador único y nombre(verduras, lácteos, legumbres, entre otros).
        public int id { get; set; }     // Nombre
        public string nameCategory { get; set; } // Categoria
       
    }
}
