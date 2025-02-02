using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using datos;

namespace gestorSocios
{
    public partial class Form2 : Form
    {
        private List<membresia> listaMembresia;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            membresiaDatos datos = new membresiaDatos();
            try
            {
                listaMembresia = datos.listar();
                dgvMembresia.DataSource = listaMembresia;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
