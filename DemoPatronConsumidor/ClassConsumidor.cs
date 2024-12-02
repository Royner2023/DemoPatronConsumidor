using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoPatronConsumidor
{
    public class ClassConsumidor
    {
        private ClassCola<ClassUsuario> _cola;
        public ClassConsumidor(ClassCola<ClassUsuario> cola)
        {
            _cola = cola;
        }
        public ClassUsuario Consumir()
        {
            ClassUsuario usuario = _cola.Extraer();
            Thread.Sleep(5000);
            return usuario;
        }
        // impementacion....Pedidos
        private ClassCola<ClassPedidos> _cola1;
        public ClassConsumidor(ClassCola<ClassPedidos> cola1)
        {
            _cola1 = cola1;
        }
        public ClassPedidos ConsumirPedidos()
        { ClassPedidos pedidos = _cola1.Extraer();
            Thread.Sleep(2000);
            return pedidos;
        }
    }
}
