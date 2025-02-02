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
            cbCampo.Items.AddRange(new string[] { "Numero", "Nombre", "Documento" });
            cbCampo.SelectedIndex = 0;
        }

        private void dgvSocios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow != null)
            {
                socio seleccionado = (socio)dgvSocios.CurrentRow.DataBoundItem;
            }
        }

        private void cargar()
        {
            socioDatos datos = new socioDatos();
            try
            {
                listaSocio = datos.listar();
                dgvSocios.DataSource = listaSocio;
                ocultarColumnas();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            //dgvSocios.Columns["Id"].Visible = false;
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

            if (dgvSocios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una fila antes de modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            seleccionado = (socio)dgvSocios.CurrentRow.DataBoundItem;

                frmAltaSocio modificar = new frmAltaSocio(seleccionado);
                modificar.ShowDialog();
                cargar();   
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            socioDatos datos = new socioDatos();
            socio seleccionado;

            if (dgvSocios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una fila antes de eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult respuesta = MessageBox.Show(" ¿Seguro desea eliminar al socio? \n Este usuario no se podra recuperar",
                    "Eliminar",MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
                if (respuesta == DialogResult.Yes) 
                {
                    seleccionado = (socio)dgvSocios.CurrentRow.DataBoundItem;
                    datos.eliminar(seleccionado.id);
                    cargar();
                }
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            socioDatos datos = new socioDatos();
            socio seleccionado;

            if (dgvSocios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una fila antes de modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult respuesta = MessageBox.Show(" Cambiar estado del socio", "btnEstado", MessageBoxButtons.YesNo);
                if(respuesta == DialogResult.Yes)
                {
                    seleccionado = (socio)dgvSocios.CurrentRow.DataBoundItem;
                    datos.modificarEstado(seleccionado.id, seleccionado.estado);
                    cargar();
                }
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        /*Funcion validar filtro de busqueda por caracteres inngresados para cada opcion
        private bool validarFiltro()
        {
            if(cbCampo.SelectedItem.ToString() == "Numero" || cbCampo.SelectedItem.ToString() == "Documento")
            {
                if (!(soloNumeros(txtBuscar.Text)))
                {
                    MessageBox.Show("Solo numero para filtrar por campo numerico");
                    return true;
                }    
            }
            else
            {
                return false;
            }
        }

        private bool soloNumeros(string cadena)
        {
            foreach(char caracter in cadena)
            {
                if(!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }*/

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<socio> listaFiltrada;
            string filtro = txtBuscar.Text.Trim().ToUpper();

            if (cbCampo.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un campo para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            string opcion = cbCampo.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(filtro) && !string.IsNullOrEmpty(opcion))
            {
                switch (opcion)
                {
                    case "Numero":
                        listaFiltrada = listaSocio.FindAll(x => x.id.ToString().StartsWith(filtro));
                        break;

                    case "Nombre":
                        listaFiltrada = listaSocio.FindAll(x => x.nombre.ToUpper().StartsWith(filtro));
                        break;

                    case "Documento":
                        listaFiltrada = listaSocio.FindAll(x => x.documento.Trim().StartsWith(filtro));
                        break;

                    default:
                        listaFiltrada = listaSocio; // Si no hay un criterio válido, mostramos todos
                        break;
                }
            }
            else
            {
                listaFiltrada = listaSocio;
            }


            dgvSocios.DataSource = null;
            dgvSocios.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void cbCampo_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }
    }
}
