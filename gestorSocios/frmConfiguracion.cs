using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using datos;
using dominio;

namespace gestorSocios
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            loadUserData();
            initializePassEditControl();
        }

        private void loadUserData()
        {
            //Mi perfil
            lblUsuario.Text = UserCache.LoginName;
            lblEmail.Text = UserCache.Email;
            lblNombre.Text = UserCache.FirstName;
            lblApellido.Text = UserCache.LastName;

            //Editar perfil
            txtbUsuario.Text = UserCache.LoginName;
            txtbNombre.Text = UserCache.FirstName;
            txtbApellido.Text = UserCache.LastName;
            txtbEmail.Text = UserCache.Email;
            txtbContraseña.Text = "";
            txtbConfirmContraseña.Text = UserCache.Password;
            txtbContraseñaNueva.Text = UserCache.Password;
        }

        private void initializePassEditControl()
        {
            linklblEditarPass.Text = "Editar";
            txtbContraseña.UseSystemPasswordChar = true;
            txtbContraseñaNueva.Enabled = false;
            txtbContraseñaNueva.UseSystemPasswordChar = true;
            txtbConfirmContraseña.Enabled = false;
            txtbConfirmContraseña.UseSystemPasswordChar = true;

        }

        private void reset()
        {
            loadUserData();
            initializePassEditControl();
        }

        private void linkEditarPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
            loadUserData();
        }

        private void linklblEditarPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(linklblEditarPass.Text == "Editar")
            {
                linklblEditarPass.Text = "Cancelar";
                txtbContraseñaNueva.Enabled = true;
                txtbContraseñaNueva.Text = "";
                txtbConfirmContraseña.Enabled = true;
                txtbConfirmContraseña.Text = "";
            }
            else if(linklblEditarPass.Text == "Cancelar")
            {
                reset();
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtbContraseñaNueva.Text.Length >= 4)
            {

            
                if (txtbContraseñaNueva.Text == txtbConfirmContraseña.Text)
                {
                    if (txtbContraseña.Text == UserCache.Password)
                    {

                        loginDatos datos = new loginDatos();
                        
                        var result = datos.editProfile(id:UserCache.Id, txtbUsuario.Text, txtbContraseñaNueva.Text, txtbNombre.Text, txtbApellido.Text, txtbEmail.Text);

                        MessageBox.Show(result);
                        reset();
                        panel1.Visible = false;

                    }
                    else
                    {
                        MessageBox.Show("La contraseña actual no coincide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La contraseña debe tener minimo 4 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            reset();
        }
    }
}
