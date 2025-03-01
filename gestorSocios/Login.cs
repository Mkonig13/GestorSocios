﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using datos;
using System.Diagnostics.Eventing.Reader;

namespace gestorSocios
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtbUsuario_Enter(object sender, EventArgs e)
        {
            if(txtbUsuario.Text == "USUARIO")
            {
                txtbUsuario.Text = "";
                txtbUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtbUsuario_Leave(object sender, EventArgs e)
        {
            if(txtbUsuario.Text == "")
            {
                txtbUsuario.Text = "USUARIO";
                txtbUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtbContrasena_Enter(object sender, EventArgs e)
        {
            if (txtbContrasena.Text == "CONTRASEÑA")
            {
                txtbContrasena.Text = "";
                txtbContrasena.ForeColor = Color.LightGray;
                txtbContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtbContrasena_Leave(object sender, EventArgs e)
        {
            if (txtbContrasena.Text == "")
            {
                txtbContrasena.Text = "CONTRASEÑA";
                txtbContrasena.ForeColor = Color.DimGray;
                txtbContrasena.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btmLogin_Click(object sender, EventArgs e)
        {
            if(txtbUsuario.Text != "USUARIO")
            {
                if (txtbContrasena.Text != "CONTRASEÑA")
                {
                    loginDatos user = new loginDatos();
                    var validLogin = user.login(txtbUsuario.Text, txtbContrasena.Text);
                    if(validLogin == true)
                    {
                        frmPantallaPrincipal mainMenu = new frmPantallaPrincipal();
                        mainMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        msgError("Usuario o contraseña incorrecto. \n Intentelo denuevo");
                        txtbContrasena.Clear();
                        txtbUsuario.Focus();
                    }
                }
                else msgError("Por favor ingrese su contraseña");
            }
            else
            {
                msgError("Por favor ingrese su nombre de usuario");
            }
        }
        private void msgError(string msg) 
        {
            lblErrorMessage.Text = msg;
            lblErrorMessage.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recoverPassword = new frmRecuperarContraseña();
            recoverPassword.ShowDialog();

        }
    }
}
