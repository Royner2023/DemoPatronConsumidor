using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoPatronConsumidor
{
    public class ClassCola<T>// Asignamos "t" para recibir cualquier tipo de objeto
    {
        private int capacidadMaxima;
        private Queue<T> cola = new Queue<T> ();
        private object LockObjeto = new object ();// objeto de bloqueo
        public ClassCola( int capacidamaxima)
        {
            capacidadMaxima = capacidamaxima;
        }
        public void Agregar(T item) //método para agregar a la cola 
        {
            lock (LockObjeto)//objeto de bloqueo
            {
                while (cola.Count >= capacidadMaxima)
                {
                    Monitor.Wait(LockObjeto);
                }
                cola.Enqueue(item);// aca añadimos elementos a la cola
                Monitor.Pulse(LockObjeto);
            }
        }
        public T Extraer()// método para extraer de la cola
        {
            lock (LockObjeto)
            {
                while (cola.Count == 0)
                { 
                    Monitor.Wait(LockObjeto);
                }
               T item = cola.Dequeue();//Para verificar y quitar de la cola
                Monitor.Pulse (LockObjeto);
                return item;
            }
           
        }    
    }
}
