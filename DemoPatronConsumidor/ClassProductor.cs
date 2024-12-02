using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoPatronConsumidor
{
    public class ClassProductor
    {
        private ClassCola<ClassUsuario> _cola;
        public ClassProductor(ClassCola<ClassUsuario> cola)// Hacemos inyección de dependencias
        {
            _cola = cola;
        }
        public void Produccion(ClassUsuario item)// agrego a los parametro para agregar a la cola
        {
            _cola.Agregar(item);// agrego a la cola
            Thread.Sleep(2000);
        }
        // implementación para gestion de pedidos
        private ClassCola<ClassPedidos> _cola1;
        public ClassProductor(ClassCola<ClassPedidos> cola1)//
        {
            _cola1 = cola1;
        }
        public void produccion(ClassPedidos item) {_cola1.Agregar(item); Thread.Sleep(2000); }
    }
}
