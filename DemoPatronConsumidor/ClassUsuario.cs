using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPatronConsumidor
{
    public class ClassUsuario
    {
       public int Id_Usuario {  get; set; }
       public string Nombre { get; set; }
       public string Correo{ get; set; }
       public DateTime Fecha { get; set; }

        public ClassUsuario(int id_usuario, string nombre, string correo)// constructor de la clase
        {
            Id_Usuario = id_usuario;
            Nombre = nombre;
            Correo = correo;
            Fecha = DateTime.Now;
        }
        public override string ToString()//método de conversión a cadena de caracteres
        {
            return $"Id Usuario: {Id_Usuario}, Nombre: {Nombre}, Correo: {Correo}, Fecha:{Fecha}";
        }
    }
}
