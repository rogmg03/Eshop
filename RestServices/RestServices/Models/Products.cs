using System;
namespace RestServices.Models
{
    public class Products{
        public string name {get; set;}     // Nombre
        public string category {get; set;} // Categoria
        public string picture {get; set;}  // Foto del producto
        public int cost {get; set;}        // Precio
        public string sellMode {get; set;} // Modo de venta (por kilo, paquete, caja, entre otros)
        public int amount {get; set;}      // Disponibilidad de producto


    }
}

        // public string Code {get; set;}
        // public string Description {get; set;}
        // public string Um {get; set;}
        // public string CodStat {get; set;}
        // public int PcCart {get; set;}
        // public double NetWeight {get; set;}
        // public string State {get; set;}
        // public DateTime CreationDate {get; set;}
        // public double Price {get; set;}