using System;

namespace RestServices.Models
{
    public class Farmers{
        
        public int id {get; set;}           // Número Cédula
        
        public string name {get; set;}      // Nombre
        
        public string lastName {get; set;}  // Apellidos
        

        public string address {get; set;}   // Dirección (Provincia, Cantón, Distrito deben estar por defecto)
        // public DateTime birth;  // Fecha de nacimiento
        
        public int phone {get; set;}        // Teléfono
        
        public int sinpe {get; set;}        // Número de SINPE móvil
        
        public string places {get; set;}    // Lugares de entrega de los pedidos
        public string userName {get; set;}  // Usuario
        public int password {get; set;}     // Contraseña
    }
}