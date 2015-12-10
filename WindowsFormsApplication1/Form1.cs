using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {
                TablaDos tablados = new TablaDos();
                tablados.condicion = 1;
                tablados.esActivo = true;
                tablados.fechaCreacion = System.DateTime.Now;
                tablados.nombre = "gg";

                TablaUno tablauno = new TablaUno();
                tablauno.condicion = 1;
                tablauno.fecha = Convert.ToDateTime("03/10/2015");
                tablauno.fechaCreacion = System.DateTime.Now;
                tablauno.hora = TimeSpan.Parse("8:00");
                tablauno.idTablaDos = 81;
                tablauno.nombre = "qp";
                tablauno.numero = 77;
                tablauno.unico = "P6541255";
                
                tablauno.TablaDos = new TablaDos();
                tablauno.TablaDos = tablados;

                NTablaUno.Instancia.insert(tablauno);

                MessageBox.Show("ok");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
