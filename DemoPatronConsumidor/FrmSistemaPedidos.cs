using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoPatronConsumidor
{
    public partial class FrmSistemaPedidos : Form
    {
        public int id_usuario = 0;
        private ClassCola<ClassPedidos> ColaPedidos;
        private ClassProductor Productor;
        private ClassConsumidor Consumidor;
        public FrmSistemaPedidos()
        {
            
            InitializeComponent();
            ColaPedidos = new ClassCola<ClassPedidos>(10);
            Productor = new ClassProductor(ColaPedidos);
            Consumidor = new ClassConsumidor(ColaPedidos);
        }

        private void BtnPedir_Click(object sender, EventArgs e)
        {
            int numero = int.Parse(TxtCantidad.Text);
            ClassPedidos Nuevopedidos = new ClassPedidos(id_usuario++, TxtNombre.Text, numero, TxtDireccion.Text);
            ThreadPool.QueueUserWorkItem(estate => {ColaPedidos.Agregar(Nuevopedidos); }
            );
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnProcesar_Click(object sender, EventArgs e)
        {
            Thread HiloConsumidor = new Thread(ProcesarPedido);
            HiloConsumidor.Start();
        }
        public void ProcesarPedido()
        {
            ClassPedidos Pedidos= ColaPedidos.Extraer();
            AgregarPedidosDataGrid(Pedidos);
        }
        public void AgregarPedidosDataGrid(ClassPedidos pedidos)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.Rows.Add(pedidos.Id_Usuario, pedidos.Nombre, pedidos.Cantidad, pedidos.Fecha);

                })
              );

            }
            else
            {
                dataGridView1.Rows.Add(pedidos.Id_Usuario, pedidos.Nombre, pedidos.Cantidad, pedidos.Fecha);
            }
        }
    }
}
