using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPatronConsumidor
{
    public class ClassPedidos
    {
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
         public int Cantidad { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha { get; set; }
           
   
       

        public ClassPedidos(int id_usuario, string nombre, int cantidad, string direccion)// constructor de la clase
        {
            Id_Usuario = id_usuario;
            Nombre = nombre;
            Cantidad=cantidad;
            Direccion = direccion;
            Fecha = DateTime.Now;
        }
        public override string ToString()//método de conversión a cadena de caracteres
        {
            return $"Id Usuario: {Id_Usuario}, Nombre: {Nombre}, Cantidad: {Cantidad},Direccion {Direccion}, Fecha:{Fecha}";
        }
    }
}
