namespace ErpCasino.WindowsForms.Seguridad
{
    partial class FrmLogin
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
            this.btnIngresar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLogoDown = new System.Windows.Forms.Panel();
            this.pnlAcceso = new System.Windows.Forms.Panel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlLogoMain = new System.Windows.Forms.Panel();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.pnlLogoUp = new System.Windows.Forms.Panel();
            this.tlpPrincipal.SuspendLayout();
            this.pnlAcceso.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIngresar
            // 
            this.btnIngresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIngresar.Location = new System.Drawing.Point(140, 3);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(100, 30);
            this.btnIngresar.TabIndex = 0;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Location = new System.Drawing.Point(111, 14);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(129, 20);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Text = "hacchia0";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContrasena.Location = new System.Drawing.Point(111, 40);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(129, 20);
            this.txtContrasena.TabIndex = 4;
            this.txtContrasena.Text = "hacchia0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 2;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlLogoDown, 0, 2);
            this.tlpPrincipal.Controls.Add(this.pnlAcceso, 1, 1);
            this.tlpPrincipal.Controls.Add(this.pnlBotones, 1, 2);
            this.tlpPrincipal.Controls.Add(this.pnlLogoMain, 0, 1);
            this.tlpPrincipal.Controls.Add(this.pnlTitulo, 1, 0);
            this.tlpPrincipal.Controls.Add(this.pnlLogoUp, 0, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPrincipal.Size = new System.Drawing.Size(367, 191);
            this.tlpPrincipal.TabIndex = 5;
            // 
            // pnlLogoDown
            // 
            this.pnlLogoDown.BackColor = System.Drawing.Color.Navy;
            this.pnlLogoDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogoDown.Location = new System.Drawing.Point(0, 141);
            this.pnlLogoDown.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLogoDown.Name = "pnlLogoDown";
            this.pnlLogoDown.Size = new System.Drawing.Size(100, 50);
            this.pnlLogoDown.TabIndex = 3;
            // 
            // pnlAcceso
            // 
            this.pnlAcceso.Controls.Add(this.label1);
            this.pnlAcceso.Controls.Add(this.txtUsuario);
            this.pnlAcceso.Controls.Add(this.txtContrasena);
            this.pnlAcceso.Controls.Add(this.label2);
            this.pnlAcceso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAcceso.Location = new System.Drawing.Point(103, 33);
            this.pnlAcceso.Name = "pnlAcceso";
            this.pnlAcceso.Size = new System.Drawing.Size(261, 105);
            this.pnlAcceso.TabIndex = 0;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnIngresar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotones.Location = new System.Drawing.Point(103, 144);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(261, 44);
            this.pnlBotones.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(19, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlLogoMain
            // 
            this.pnlLogoMain.BackColor = System.Drawing.Color.Navy;
            this.pnlLogoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogoMain.Location = new System.Drawing.Point(0, 30);
            this.pnlLogoMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLogoMain.Name = "pnlLogoMain";
            this.pnlLogoMain.Size = new System.Drawing.Size(100, 111);
            this.pnlLogoMain.TabIndex = 2;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitulo.Location = new System.Drawing.Point(103, 3);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(261, 24);
            this.pnlTitulo.TabIndex = 4;
            // 
            // pnlLogoUp
            // 
            this.pnlLogoUp.BackColor = System.Drawing.Color.Navy;
            this.pnlLogoUp.Location = new System.Drawing.Point(0, 0);
            this.pnlLogoUp.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLogoUp.Name = "pnlLogoUp";
            this.pnlLogoUp.Size = new System.Drawing.Size(100, 30);
            this.pnlLogoUp.TabIndex = 5;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 191);
            this.Controls.Add(this.tlpPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Text = "Acceso";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlAcceso.ResumeLayout(false);
            this.pnlAcceso.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlAcceso;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Panel pnlLogoMain;
        private System.Windows.Forms.Panel pnlLogoDown;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Panel pnlLogoUp;
    }
}