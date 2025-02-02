using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestorSocios
{
    public partial class frmPantallaPrincipal : Form
    {
        public frmPantallaPrincipal()
        {
            InitializeComponent();
        }


        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFijo.Controls.Add(childForm);
            panelFijo.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            openChildForm(new Form1());
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Estás seguro de que deseas cerrar la aplicación?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
