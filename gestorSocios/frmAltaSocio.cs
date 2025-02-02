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
    public partial class frmAltaSocio : Form
    {
        private socio socio = null;
        public frmAltaSocio()
        {
            InitializeComponent();
        }

        public frmAltaSocio(socio socio)
        {
            InitializeComponent();
            this.socio = socio;
            Text = "Modificar socio";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            socioDatos datos = new socioDatos();

            try
            {
                if (socio == null)
                    socio = new socio();

                socio.nombre = txtNombre.Text;
                socio.apellido = txtApellido.Text;
                socio.documento = txtBDocumento.Text;
                socio.fechaNacimiento = dtpFechaNacimiento.Value;
                socio.domicilio = txtBDomicilio.Text;
                socio.telefonoContacto = txtBTelefono.Text;
                socio.email = txtBEmail.Text;
                socio.Tipo = (membresia)cboMembresia.SelectedItem;
                


                if(socio.id != 0)
                {
                    datos.modificar(socio);
                    MessageBox.Show("Modificado exitosamente");

                }
                else
                {
                    datos.agregar(socio);
                    MessageBox.Show("Agregado exitosamente");
                }

                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void frmAltaSocio_Load(object sender, EventArgs e)
        {
            membresiaDatos membresiaDatos = new membresiaDatos();
            try
            {
                cboMembresia.DataSource = membresiaDatos.listar();
                cboMembresia.ValueMember = "Id";
                cboMembresia.DisplayMember = "Tipo";

                if(socio != null)
                {
                    txtNombre.Text = socio.nombre;
                    txtApellido.Text = socio.apellido;
                    txtBDocumento.Text = socio.documento;
                    dtpFechaNacimiento.Value = socio.fechaNacimiento;
                    txtBDomicilio.Text = socio.domicilio;
                    txtBTelefono.Text = socio.telefonoContacto;
                    txtBEmail.Text = socio.email;
                    cboMembresia.SelectedValue = socio.Tipo.Id;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        
    }
}
