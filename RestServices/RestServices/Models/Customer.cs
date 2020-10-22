using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServices.Models
{
 //   Las operaciones que debe proveer esta vista son creación, actualización y eliminación
   //     de clientes.Los principales datos de los clientes son: Número Cédula, Nombre, Apellidos,
     //   dirección (Provincia, cantón, distrito), Fecha de nacimiento, teléfono, usuario y password.
    public class Customer
    { // constructor para inicializar los  valores del objeto JSON
        public Customer(int id, string name, string lastName, string address, int phone, string userName, int password)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.address = address;
            this.phone = phone;
            this.userName = userName;
            this.password = password;
        }

        public int id { get; set; }           // Número Cédula

        public string name { get; set; }      // Nombre

        public string lastName { get; set; }  // Apellidos


        public string address { get; set; }   // Dirección (Provincia, Cantón, Distrito deben estar por defecto)
                                              // public DateTime birth;  // Fecha de nacimiento

        public int phone { get; set; }        // Teléfono

        public string userName { get; set; }  // Usuario
        public int password { get; set; }     // Contraseña
    }
}