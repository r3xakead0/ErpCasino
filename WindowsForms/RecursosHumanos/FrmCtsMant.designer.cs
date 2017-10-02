namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmCtsMant
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
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.lblPeriodoAl = new System.Windows.Forms.Label();
            this.dtpPeriodoFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodoInicial = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlPrincipal, 0, 0);
            this.tlpPrincipal.Controls.Add(this.pnlInferior, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpPrincipal.Size = new System.Drawing.Size(588, 174);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.txtEmpleado);
            this.pnlPrincipal.Controls.Add(this.lblPeriodoAl);
            this.pnlPrincipal.Controls.Add(this.dtpPeriodoFinal);
            this.pnlPrincipal.Controls.Add(this.dtpPeriodoInicial);
            this.pnlPrincipal.Controls.Add(this.lblPeriodo);
            this.pnlPrincipal.Controls.Add(this.cboEmpleado);
            this.pnlPrincipal.Controls.Add(this.dtpFecha);
            this.pnlPrincipal.Controls.Add(this.lblEmpleado);
            this.pnlPrincipal.Controls.Add(this.txtMonto);
            this.pnlPrincipal.Controls.Add(this.lblFecha);
            this.pnlPrincipal.Controls.Add(this.lblMonto);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(582, 108);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(99, 42);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(100, 20);
            this.txtEmpleado.TabIndex = 54;
            this.txtEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPeriodoAl
            // 
            this.lblPeriodoAl.AutoSize = true;
            this.lblPeriodoAl.Location = new System.Drawing.Point(205, 72);
            this.lblPeriodoAl.Name = "lblPeriodoAl";
            this.lblPeriodoAl.Size = new System.Drawing.Size(16, 13);
            this.lblPeriodoAl.TabIndex = 53;
            this.lblPeriodoAl.Text = "Al";
            // 
            // dtpPeriodoFinal
            // 
            this.dtpPeriodoFinal.CustomFormat = "dd/MM/yyyy";
            this.dtpPeriodoFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodoFinal.Location = new System.Drawing.Point(225, 69);
            this.dtpPeriodoFinal.Name = "dtpPeriodoFinal";
            this.dtpPeriodoFinal.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodoFinal.TabIndex = 52;
            // 
            // dtpPeriodoInicial
            // 
            this.dtpPeriodoInicial.CustomFormat = "dd/MM/yyyy";
            this.dtpPeriodoInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodoInicial.Location = new System.Drawing.Point(99, 69);
            this.dtpPeriodoInicial.Name = "dtpPeriodoInicial";
            this.dtpPeriodoInicial.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodoInicial.TabIndex = 51;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(12, 72);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(49, 13);
            this.lblPeriodo.TabIndex = 50;
            this.lblPeriodo.Text = "Periodo :";
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(208, 42);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(360, 21);
            this.cboEmpleado.TabIndex = 49;
            this.cboEmpleado.SelectionChangeCommitted += new System.EventHandler(this.cboEmpleado_SelectionChangeCommitted);
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(99, 16);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 20);
            this.dtpFecha.TabIndex = 38;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(12, 45);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(60, 13);
            this.lblEmpleado.TabIndex = 20;
            this.lblEmpleado.Text = "Empleado :";
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonto.Location = new System.Drawing.Point(468, 69);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 23;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.Enter += new System.EventHandler(this.txtMonto_Enter);
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 19);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(55, 13);
            this.lblFecha.TabIndex = 18;
            this.lblFecha.Text = "Deposito :";
            // 
            // lblMonto
            // 
            this.lblMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(381, 72);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(43, 13);
            this.lblMonto.TabIndex = 22;
            this.lblMonto.Text = "Monto :";
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.BtnSave);
            this.pnlInferior.Controls.Add(this.BtnCancel);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 117);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(582, 54);
            this.pnlInferior.TabIndex = 17;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(468, 5);
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
            this.BtnCancel.Location = new System.Drawing.Point(347, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmCtsMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 174);
            this.Controls.Add(this.tlpPrincipal);
            this.Name = "FrmCtsMant";
            this.Text = "Mantenimiento de CTS";
            this.Load += new System.EventHandler(this.FrmCtsMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        internal System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel pnlInferior;
        public System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox txtMonto;
        internal System.Windows.Forms.Label lblMonto;
        internal System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboEmpleado;
        internal System.Windows.Forms.Label lblPeriodoAl;
        private System.Windows.Forms.DateTimePicker dtpPeriodoFinal;
        private System.Windows.Forms.DateTimePicker dtpPeriodoInicial;
        internal System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.TextBox txtEmpleado;
    }
}