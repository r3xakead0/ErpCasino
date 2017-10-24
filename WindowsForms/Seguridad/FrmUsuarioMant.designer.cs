namespace ErpCasino.WindowsForms.Seguridad
{
    partial class FrmUsuarioMant
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblContrasenha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtContrasenha = new System.Windows.Forms.TextBox();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.LblUsuarioAsterisk = new System.Windows.Forms.Label();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.LblNombre = new System.Windows.Forms.Label();
            this.LblNombreAsterisk = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblEmail = new System.Windows.Forms.Label();
            this.LblEmailAsterisk = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.LblContrasenha2 = new System.Windows.Forms.Label();
            this.LblContrasenhaAsterisk = new System.Windows.Forms.Label();
            this.TxtContrasenha2 = new System.Windows.Forms.TextBox();
            this.LblBloqueado = new System.Windows.Forms.Label();
            this.LblBloqueadoAsterisk = new System.Windows.Forms.Label();
            this.CbxBloqueado = new System.Windows.Forms.CheckBox();
            this.LblActivo = new System.Windows.Forms.Label();
            this.LblActivoAsterisk = new System.Windows.Forms.Label();
            this.CbxActivo = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 290);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblContrasenha);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TxtContrasenha);
            this.panel1.Controls.Add(this.LblUsuario);
            this.panel1.Controls.Add(this.LblUsuarioAsterisk);
            this.panel1.Controls.Add(this.TxtUsuario);
            this.panel1.Controls.Add(this.LblNombre);
            this.panel1.Controls.Add(this.LblNombreAsterisk);
            this.panel1.Controls.Add(this.TxtNombre);
            this.panel1.Controls.Add(this.LblEmail);
            this.panel1.Controls.Add(this.LblEmailAsterisk);
            this.panel1.Controls.Add(this.TxtEmail);
            this.panel1.Controls.Add(this.LblContrasenha2);
            this.panel1.Controls.Add(this.LblContrasenhaAsterisk);
            this.panel1.Controls.Add(this.TxtContrasenha2);
            this.panel1.Controls.Add(this.LblBloqueado);
            this.panel1.Controls.Add(this.LblBloqueadoAsterisk);
            this.panel1.Controls.Add(this.CbxBloqueado);
            this.panel1.Controls.Add(this.LblActivo);
            this.panel1.Controls.Add(this.LblActivoAsterisk);
            this.panel1.Controls.Add(this.CbxActivo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 234);
            this.panel1.TabIndex = 16;
            // 
            // LblContrasenha
            // 
            this.LblContrasenha.AutoSize = true;
            this.LblContrasenha.Location = new System.Drawing.Point(27, 111);
            this.LblContrasenha.Name = "LblContrasenha";
            this.LblContrasenha.Size = new System.Drawing.Size(64, 13);
            this.LblContrasenha.TabIndex = 33;
            this.LblContrasenha.Text = "Contraseña:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(131, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "*";
            // 
            // TxtContrasenha
            // 
            this.TxtContrasenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtContrasenha.Location = new System.Drawing.Point(145, 108);
            this.TxtContrasenha.Name = "TxtContrasenha";
            this.TxtContrasenha.PasswordChar = '*';
            this.TxtContrasenha.Size = new System.Drawing.Size(162, 20);
            this.TxtContrasenha.TabIndex = 35;
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Location = new System.Drawing.Point(27, 23);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(46, 13);
            this.LblUsuario.TabIndex = 15;
            this.LblUsuario.Text = "Usuario:";
            // 
            // LblUsuarioAsterisk
            // 
            this.LblUsuarioAsterisk.AutoSize = true;
            this.LblUsuarioAsterisk.ForeColor = System.Drawing.Color.Red;
            this.LblUsuarioAsterisk.Location = new System.Drawing.Point(131, 23);
            this.LblUsuarioAsterisk.Name = "LblUsuarioAsterisk";
            this.LblUsuarioAsterisk.Size = new System.Drawing.Size(11, 13);
            this.LblUsuarioAsterisk.TabIndex = 16;
            this.LblUsuarioAsterisk.Text = "*";
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtUsuario.Location = new System.Drawing.Point(145, 20);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(162, 20);
            this.TxtUsuario.TabIndex = 17;
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(27, 55);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(47, 13);
            this.LblNombre.TabIndex = 18;
            this.LblNombre.Text = "Nombre:";
            // 
            // LblNombreAsterisk
            // 
            this.LblNombreAsterisk.AutoSize = true;
            this.LblNombreAsterisk.ForeColor = System.Drawing.Color.Red;
            this.LblNombreAsterisk.Location = new System.Drawing.Point(131, 55);
            this.LblNombreAsterisk.Name = "LblNombreAsterisk";
            this.LblNombreAsterisk.Size = new System.Drawing.Size(11, 13);
            this.LblNombreAsterisk.TabIndex = 19;
            this.LblNombreAsterisk.Text = "*";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNombre.Location = new System.Drawing.Point(145, 52);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(162, 20);
            this.TxtNombre.TabIndex = 20;
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Location = new System.Drawing.Point(27, 83);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(35, 13);
            this.LblEmail.TabIndex = 21;
            this.LblEmail.Text = "Email:";
            // 
            // LblEmailAsterisk
            // 
            this.LblEmailAsterisk.AutoSize = true;
            this.LblEmailAsterisk.ForeColor = System.Drawing.Color.Red;
            this.LblEmailAsterisk.Location = new System.Drawing.Point(131, 83);
            this.LblEmailAsterisk.Name = "LblEmailAsterisk";
            this.LblEmailAsterisk.Size = new System.Drawing.Size(11, 13);
            this.LblEmailAsterisk.TabIndex = 23;
            this.LblEmailAsterisk.Text = "*";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtEmail.Location = new System.Drawing.Point(145, 80);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(162, 20);
            this.TxtEmail.TabIndex = 22;
            // 
            // LblContrasenha2
            // 
            this.LblContrasenha2.AutoSize = true;
            this.LblContrasenha2.Location = new System.Drawing.Point(27, 139);
            this.LblContrasenha2.Name = "LblContrasenha2";
            this.LblContrasenha2.Size = new System.Drawing.Size(101, 13);
            this.LblContrasenha2.TabIndex = 24;
            this.LblContrasenha2.Text = "Repetir Contraseña:";
            // 
            // LblContrasenhaAsterisk
            // 
            this.LblContrasenhaAsterisk.AutoSize = true;
            this.LblContrasenhaAsterisk.ForeColor = System.Drawing.Color.Red;
            this.LblContrasenhaAsterisk.Location = new System.Drawing.Point(131, 111);
            this.LblContrasenhaAsterisk.Name = "LblContrasenhaAsterisk";
            this.LblContrasenhaAsterisk.Size = new System.Drawing.Size(11, 13);
            this.LblContrasenhaAsterisk.TabIndex = 25;
            this.LblContrasenhaAsterisk.Text = "*";
            // 
            // TxtContrasenha2
            // 
            this.TxtContrasenha2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtContrasenha2.Location = new System.Drawing.Point(145, 136);
            this.TxtContrasenha2.Name = "TxtContrasenha2";
            this.TxtContrasenha2.PasswordChar = '*';
            this.TxtContrasenha2.Size = new System.Drawing.Size(162, 20);
            this.TxtContrasenha2.TabIndex = 26;
            // 
            // LblBloqueado
            // 
            this.LblBloqueado.AutoSize = true;
            this.LblBloqueado.Location = new System.Drawing.Point(27, 167);
            this.LblBloqueado.Name = "LblBloqueado";
            this.LblBloqueado.Size = new System.Drawing.Size(61, 13);
            this.LblBloqueado.TabIndex = 27;
            this.LblBloqueado.Text = "Bloqueado:";
            // 
            // LblBloqueadoAsterisk
            // 
            this.LblBloqueadoAsterisk.AutoSize = true;
            this.LblBloqueadoAsterisk.ForeColor = System.Drawing.Color.Red;
            this.LblBloqueadoAsterisk.Location = new System.Drawing.Point(131, 139);
            this.LblBloqueadoAsterisk.Name = "LblBloqueadoAsterisk";
            this.LblBloqueadoAsterisk.Size = new System.Drawing.Size(11, 13);
            this.LblBloqueadoAsterisk.TabIndex = 28;
            this.LblBloqueadoAsterisk.Text = "*";
            // 
            // CbxBloqueado
            // 
            this.CbxBloqueado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxBloqueado.Location = new System.Drawing.Point(145, 164);
            this.CbxBloqueado.Name = "CbxBloqueado";
            this.CbxBloqueado.Size = new System.Drawing.Size(162, 20);
            this.CbxBloqueado.TabIndex = 29;
            // 
            // LblActivo
            // 
            this.LblActivo.AutoSize = true;
            this.LblActivo.Location = new System.Drawing.Point(27, 195);
            this.LblActivo.Name = "LblActivo";
            this.LblActivo.Size = new System.Drawing.Size(40, 13);
            this.LblActivo.TabIndex = 30;
            this.LblActivo.Text = "Activo:";
            // 
            // LblActivoAsterisk
            // 
            this.LblActivoAsterisk.AutoSize = true;
            this.LblActivoAsterisk.ForeColor = System.Drawing.Color.Red;
            this.LblActivoAsterisk.Location = new System.Drawing.Point(131, 167);
            this.LblActivoAsterisk.Name = "LblActivoAsterisk";
            this.LblActivoAsterisk.Size = new System.Drawing.Size(11, 13);
            this.LblActivoAsterisk.TabIndex = 31;
            this.LblActivoAsterisk.Text = "*";
            // 
            // CbxActivo
            // 
            this.CbxActivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxActivo.Location = new System.Drawing.Point(145, 192);
            this.CbxActivo.Name = "CbxActivo";
            this.CbxActivo.Size = new System.Drawing.Size(162, 20);
            this.CbxActivo.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnSave);
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 243);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 44);
            this.panel2.TabIndex = 17;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(235, 5);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(100, 30);
            this.BtnSave.TabIndex = 17;
            this.BtnSave.Text = "Guardar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(129, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmUsuarioMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 290);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "FrmUsuarioMant";
            this.Text = "Mantenimiento de Usuario";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label LblUsuario;
        internal System.Windows.Forms.Label LblUsuarioAsterisk;
        internal System.Windows.Forms.TextBox TxtUsuario;
        internal System.Windows.Forms.Label LblNombre;
        internal System.Windows.Forms.Label LblNombreAsterisk;
        internal System.Windows.Forms.TextBox TxtNombre;
        internal System.Windows.Forms.Label LblEmail;
        internal System.Windows.Forms.Label LblEmailAsterisk;
        internal System.Windows.Forms.TextBox TxtEmail;
        internal System.Windows.Forms.Label LblContrasenha2;
        internal System.Windows.Forms.Label LblContrasenhaAsterisk;
        internal System.Windows.Forms.TextBox TxtContrasenha2;
        internal System.Windows.Forms.Label LblBloqueado;
        internal System.Windows.Forms.Label LblBloqueadoAsterisk;
        internal System.Windows.Forms.CheckBox CbxBloqueado;
        internal System.Windows.Forms.Label LblActivo;
        internal System.Windows.Forms.Label LblActivoAsterisk;
        internal System.Windows.Forms.CheckBox CbxActivo;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Label LblContrasenha;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox TxtContrasenha;
    }
}