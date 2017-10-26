namespace ErpCasino.WindowsForms.Configuracion
{
    partial class FrmEmpresaMant
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
            this.cboDistrito = new System.Windows.Forms.ComboBox();
            this.lblDistrito = new System.Windows.Forms.Label();
            this.lblAsterick7 = new System.Windows.Forms.Label();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.lblAsterick6 = new System.Windows.Forms.Label();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.lblAsterick5 = new System.Windows.Forms.Label();
            this.lblDomicilioFiscal = new System.Windows.Forms.Label();
            this.txtDomicilioFiscal = new System.Windows.Forms.TextBox();
            this.lblNombreComercial = new System.Windows.Forms.Label();
            this.lblAsterick1 = new System.Windows.Forms.Label();
            this.txtNombreComercial = new System.Windows.Forms.TextBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblAsterick2 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblRuc = new System.Windows.Forms.Label();
            this.lblAsterick3 = new System.Windows.Forms.Label();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.lblAsterick4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(609, 273);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboDistrito);
            this.panel1.Controls.Add(this.lblDistrito);
            this.panel1.Controls.Add(this.lblAsterick7);
            this.panel1.Controls.Add(this.cboProvincia);
            this.panel1.Controls.Add(this.lblProvincia);
            this.panel1.Controls.Add(this.lblAsterick6);
            this.panel1.Controls.Add(this.cboDepartamento);
            this.panel1.Controls.Add(this.lblDepartamento);
            this.panel1.Controls.Add(this.lblAsterick5);
            this.panel1.Controls.Add(this.lblDomicilioFiscal);
            this.panel1.Controls.Add(this.txtDomicilioFiscal);
            this.panel1.Controls.Add(this.lblNombreComercial);
            this.panel1.Controls.Add(this.lblAsterick1);
            this.panel1.Controls.Add(this.txtNombreComercial);
            this.panel1.Controls.Add(this.lblRazonSocial);
            this.panel1.Controls.Add(this.lblAsterick2);
            this.panel1.Controls.Add(this.txtRazonSocial);
            this.panel1.Controls.Add(this.lblRuc);
            this.panel1.Controls.Add(this.lblAsterick3);
            this.panel1.Controls.Add(this.txtRuc);
            this.panel1.Controls.Add(this.lblAsterick4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 217);
            this.panel1.TabIndex = 16;
            // 
            // cboDistrito
            // 
            this.cboDistrito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.Location = new System.Drawing.Point(145, 180);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(421, 21);
            this.cboDistrito.TabIndex = 62;
            // 
            // lblDistrito
            // 
            this.lblDistrito.AutoSize = true;
            this.lblDistrito.Location = new System.Drawing.Point(32, 183);
            this.lblDistrito.Name = "lblDistrito";
            this.lblDistrito.Size = new System.Drawing.Size(42, 13);
            this.lblDistrito.TabIndex = 65;
            this.lblDistrito.Text = "Distrito:";
            // 
            // lblAsterick7
            // 
            this.lblAsterick7.AutoSize = true;
            this.lblAsterick7.ForeColor = System.Drawing.Color.Red;
            this.lblAsterick7.Location = new System.Drawing.Point(131, 183);
            this.lblAsterick7.Name = "lblAsterick7";
            this.lblAsterick7.Size = new System.Drawing.Size(11, 13);
            this.lblAsterick7.TabIndex = 66;
            this.lblAsterick7.Text = "*";
            // 
            // cboProvincia
            // 
            this.cboProvincia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.Location = new System.Drawing.Point(145, 152);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(421, 21);
            this.cboProvincia.TabIndex = 61;
            this.cboProvincia.SelectionChangeCommitted += new System.EventHandler(this.cboProvincia_SelectionChangeCommitted);
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(32, 155);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(54, 13);
            this.lblProvincia.TabIndex = 63;
            this.lblProvincia.Text = "Provincia:";
            // 
            // lblAsterick6
            // 
            this.lblAsterick6.AutoSize = true;
            this.lblAsterick6.ForeColor = System.Drawing.Color.Red;
            this.lblAsterick6.Location = new System.Drawing.Point(131, 155);
            this.lblAsterick6.Name = "lblAsterick6";
            this.lblAsterick6.Size = new System.Drawing.Size(11, 13);
            this.lblAsterick6.TabIndex = 64;
            this.lblAsterick6.Text = "*";
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.Location = new System.Drawing.Point(145, 124);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(421, 21);
            this.cboDepartamento.TabIndex = 60;
            this.cboDepartamento.SelectionChangeCommitted += new System.EventHandler(this.cboDepartamento_SelectionChangeCommitted);
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Location = new System.Drawing.Point(32, 126);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(77, 13);
            this.lblDepartamento.TabIndex = 58;
            this.lblDepartamento.Text = "Departamento:";
            // 
            // lblAsterick5
            // 
            this.lblAsterick5.AutoSize = true;
            this.lblAsterick5.ForeColor = System.Drawing.Color.Red;
            this.lblAsterick5.Location = new System.Drawing.Point(131, 127);
            this.lblAsterick5.Name = "lblAsterick5";
            this.lblAsterick5.Size = new System.Drawing.Size(11, 13);
            this.lblAsterick5.TabIndex = 59;
            this.lblAsterick5.Text = "*";
            // 
            // lblDomicilioFiscal
            // 
            this.lblDomicilioFiscal.AutoSize = true;
            this.lblDomicilioFiscal.Location = new System.Drawing.Point(32, 100);
            this.lblDomicilioFiscal.Name = "lblDomicilioFiscal";
            this.lblDomicilioFiscal.Size = new System.Drawing.Size(85, 13);
            this.lblDomicilioFiscal.TabIndex = 33;
            this.lblDomicilioFiscal.Text = "Domicilio Fiscal :";
            // 
            // txtDomicilioFiscal
            // 
            this.txtDomicilioFiscal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDomicilioFiscal.Location = new System.Drawing.Point(145, 98);
            this.txtDomicilioFiscal.Name = "txtDomicilioFiscal";
            this.txtDomicilioFiscal.Size = new System.Drawing.Size(421, 20);
            this.txtDomicilioFiscal.TabIndex = 35;
            // 
            // lblNombreComercial
            // 
            this.lblNombreComercial.AutoSize = true;
            this.lblNombreComercial.Location = new System.Drawing.Point(32, 22);
            this.lblNombreComercial.Name = "lblNombreComercial";
            this.lblNombreComercial.Size = new System.Drawing.Size(99, 13);
            this.lblNombreComercial.TabIndex = 15;
            this.lblNombreComercial.Text = "Nombre Comercial :";
            // 
            // lblAsterick1
            // 
            this.lblAsterick1.AutoSize = true;
            this.lblAsterick1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterick1.Location = new System.Drawing.Point(131, 23);
            this.lblAsterick1.Name = "lblAsterick1";
            this.lblAsterick1.Size = new System.Drawing.Size(11, 13);
            this.lblAsterick1.TabIndex = 16;
            this.lblAsterick1.Text = "*";
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreComercial.Location = new System.Drawing.Point(145, 20);
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(421, 20);
            this.txtNombreComercial.TabIndex = 17;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Location = new System.Drawing.Point(32, 48);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(76, 13);
            this.lblRazonSocial.TabIndex = 18;
            this.lblRazonSocial.Text = "Razon Social :";
            // 
            // lblAsterick2
            // 
            this.lblAsterick2.AutoSize = true;
            this.lblAsterick2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterick2.Location = new System.Drawing.Point(131, 49);
            this.lblAsterick2.Name = "lblAsterick2";
            this.lblAsterick2.Size = new System.Drawing.Size(11, 13);
            this.lblAsterick2.TabIndex = 19;
            this.lblAsterick2.Text = "*";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRazonSocial.Location = new System.Drawing.Point(145, 46);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(421, 20);
            this.txtRazonSocial.TabIndex = 20;
            // 
            // lblRuc
            // 
            this.lblRuc.AutoSize = true;
            this.lblRuc.Location = new System.Drawing.Point(32, 74);
            this.lblRuc.Name = "lblRuc";
            this.lblRuc.Size = new System.Drawing.Size(36, 13);
            this.lblRuc.TabIndex = 21;
            this.lblRuc.Text = "RUC :";
            // 
            // lblAsterick3
            // 
            this.lblAsterick3.AutoSize = true;
            this.lblAsterick3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterick3.Location = new System.Drawing.Point(131, 75);
            this.lblAsterick3.Name = "lblAsterick3";
            this.lblAsterick3.Size = new System.Drawing.Size(11, 13);
            this.lblAsterick3.TabIndex = 23;
            this.lblAsterick3.Text = "*";
            // 
            // txtRuc
            // 
            this.txtRuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRuc.Location = new System.Drawing.Point(145, 72);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(421, 20);
            this.txtRuc.TabIndex = 22;
            // 
            // lblAsterick4
            // 
            this.lblAsterick4.AutoSize = true;
            this.lblAsterick4.ForeColor = System.Drawing.Color.Red;
            this.lblAsterick4.Location = new System.Drawing.Point(131, 101);
            this.lblAsterick4.Name = "lblAsterick4";
            this.lblAsterick4.Size = new System.Drawing.Size(11, 13);
            this.lblAsterick4.TabIndex = 25;
            this.lblAsterick4.Text = "*";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 226);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(603, 44);
            this.panel2.TabIndex = 17;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(494, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmEmpresaMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 273);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "FrmEmpresaMant";
            this.Text = "Mantenimiento de Empresa";
            this.Load += new System.EventHandler(this.FrmEmpresaMant_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lblNombreComercial;
        internal System.Windows.Forms.Label lblAsterick1;
        internal System.Windows.Forms.TextBox txtNombreComercial;
        internal System.Windows.Forms.Label lblRazonSocial;
        internal System.Windows.Forms.Label lblAsterick2;
        internal System.Windows.Forms.TextBox txtRazonSocial;
        internal System.Windows.Forms.Label lblRuc;
        internal System.Windows.Forms.Label lblAsterick3;
        internal System.Windows.Forms.TextBox txtRuc;
        internal System.Windows.Forms.Label lblAsterick4;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnGuardar;
        internal System.Windows.Forms.Label lblDomicilioFiscal;
        internal System.Windows.Forms.TextBox txtDomicilioFiscal;
        internal System.Windows.Forms.ComboBox cboDistrito;
        internal System.Windows.Forms.Label lblDistrito;
        internal System.Windows.Forms.Label lblAsterick7;
        internal System.Windows.Forms.ComboBox cboProvincia;
        internal System.Windows.Forms.Label lblProvincia;
        internal System.Windows.Forms.Label lblAsterick6;
        internal System.Windows.Forms.ComboBox cboDepartamento;
        internal System.Windows.Forms.Label lblDepartamento;
        internal System.Windows.Forms.Label lblAsterick5;
    }
}