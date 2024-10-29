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
    public partial class Form1 : Form
    {
        private List<socio> listaSocio;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dgvSocios_SelectionChanged(object sender, EventArgs e)
        {

            socio seleccionado = (socio)dgvSocios.CurrentRow.DataBoundItem;
        }

        private void cargar()
        {
            socioDatos datos = new socioDatos();
            try
            {
                listaSocio = datos.listar();
                dgvSocios.DataSource = listaSocio;
                dgvSocios.Columns["Id"].Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaSocio alta = new frmAltaSocio();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            socio seleccionado;
            seleccionado = (socio)dgvSocios.CurrentRow.DataBoundItem;

            frmAltaSocio modificar = new frmAltaSocio(seleccionado);
            modificar.ShowDialog();
            cargar();
        }
    }
}
