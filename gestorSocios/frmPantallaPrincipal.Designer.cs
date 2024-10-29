namespace gestorSocios
{
    partial class frmPantallaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelFijo = new System.Windows.Forms.Panel();
            this.btnMembresias = new System.Windows.Forms.Button();
            this.btnSocios = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelMenuLateral = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelMenuLateral.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFijo
            // 
            this.panelFijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFijo.Location = new System.Drawing.Point(156, 0);
            this.panelFijo.Name = "panelFijo";
            this.panelFijo.Size = new System.Drawing.Size(971, 622);
            this.panelFijo.TabIndex = 8;
            // 
            // btnMembresias
            // 
            this.btnMembresias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMembresias.FlatAppearance.BorderSize = 0;
            this.btnMembresias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnMembresias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnMembresias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembresias.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembresias.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMembresias.Location = new System.Drawing.Point(0, 145);
            this.btnMembresias.Name = "btnMembresias";
            this.btnMembresias.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMembresias.Size = new System.Drawing.Size(156, 45);
            this.btnMembresias.TabIndex = 2;
            this.btnMembresias.Text = "Membresias";
            this.btnMembresias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembresias.UseVisualStyleBackColor = true;
            // 
            // btnSocios
            // 
            this.btnSocios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSocios.FlatAppearance.BorderSize = 0;
            this.btnSocios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnSocios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnSocios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSocios.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSocios.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSocios.Location = new System.Drawing.Point(0, 100);
            this.btnSocios.Name = "btnSocios";
            this.btnSocios.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSocios.Size = new System.Drawing.Size(156, 45);
            this.btnSocios.TabIndex = 1;
            this.btnSocios.Text = "Socios";
            this.btnSocios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSocios.UseVisualStyleBackColor = true;
            this.btnSocios.Click += new System.EventHandler(this.btnSocios_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(156, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // panelMenuLateral
            // 
            this.panelMenuLateral.AutoScroll = true;
            this.panelMenuLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panelMenuLateral.Controls.Add(this.btnExit);
            this.panelMenuLateral.Controls.Add(this.btnMembresias);
            this.panelMenuLateral.Controls.Add(this.btnSocios);
            this.panelMenuLateral.Controls.Add(this.panelLogo);
            this.panelMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.panelMenuLateral.Name = "panelMenuLateral";
            this.panelMenuLateral.Size = new System.Drawing.Size(156, 622);
            this.panelMenuLateral.TabIndex = 6;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExit.Location = new System.Drawing.Point(0, 577);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(156, 45);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // frmPantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 622);
            this.Controls.Add(this.panelFijo);
            this.Controls.Add(this.panelMenuLateral);
            this.MinimumSize = new System.Drawing.Size(1143, 661);
            this.Name = "frmPantallaPrincipal";
            this.Text = "frmPantallaPrincipal";
            this.panelMenuLateral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFijo;
        private System.Windows.Forms.Button btnMembresias;
        private System.Windows.Forms.Button btnSocios;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelMenuLateral;
        private System.Windows.Forms.Button btnExit;
    }
}