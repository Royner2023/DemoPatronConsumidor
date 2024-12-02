using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoPatronConsumidor
{
    public partial class Form1 : Form
    {
        private int contadorId = 1;
        private ClassCola<ClassUsuario> colaUsuarios;
        private ClassProductor productor;
        private ClassConsumidor consumidor;
        public Form1()
        {
            InitializeComponent();
            colaUsuarios = new ClassCola<ClassUsuario>(10);
            productor=new ClassProductor(colaUsuarios);
            consumidor = new ClassConsumidor(colaUsuarios);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            ClassUsuario nuevoUsuario = new  ClassUsuario(contadorId++, TxtNombre.Text, TxtCorreo.Text);
            ThreadPool.QueueUserWorkItem(estate=> { colaUsuarios.Agregar(nuevoUsuario); }
            );
            TxtNombre.Clear();
            TxtCorreo.Clear();

        }

        private void BtnProcesar_Click(object sender, EventArgs e)
        {
            Thread hiloConsumidor = new Thread(ProcesarUsuario);// creamos hilo para llamr al metodo procesar usuario
            hiloConsumidor.Start();
        }
        public void ProcesarUsuario()// procesa el usuario extrae de la cola el valor
        {
            ClassUsuario usuario = colaUsuarios.Extraer();// asignamos memoria al usuario
            AgregarUsuarioDataGrid(usuario);
        }
        private void AgregarUsuarioDataGrid(ClassUsuario usuario)// agrega usuario al datagrid
        {
            if (DgvUsuarios.InvokeRequired)
            {
                DgvUsuarios.Invoke(new Action(() =>
                {
                    DgvUsuarios.Rows.Add(usuario.Id_Usuario, usuario.Nombre, usuario.Correo, usuario.Fecha);

                })
                );

            }
            else 
            { 
                DgvUsuarios.Rows.Add(usuario.Id_Usuario, usuario.Nombre, usuario.Correo, usuario.Fecha); 
            }

        }
    }
}
