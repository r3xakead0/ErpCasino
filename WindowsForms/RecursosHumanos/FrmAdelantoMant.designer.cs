namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmAdelantoMant
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
            this.GrpDetalleBono = new System.Windows.Forms.GroupBox();
            this.txtEmpleadoCodigo = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.cboBancos = new System.Windows.Forms.ComboBox();
            this.lblTipoAdelanto = new System.Windows.Forms.Label();
            this.cboTipos = new System.Windows.Forms.ComboBox();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.GrpDetalleBono.SuspendLayout();
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
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPrincipal.Size = new System.Drawing.Size(498, 205);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.GrpDetalleBono);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(492, 149);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // GrpDetalleBono
            // 
            this.GrpDetalleBono.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpDetalleBono.Controls.Add(this.txtEmpleadoCodigo);
            this.GrpDetalleBono.Controls.Add(this.txtNumero);
            this.GrpDetalleBono.Controls.Add(this.lblNumero);
            this.GrpDetalleBono.Controls.Add(this.lblBanco);
            this.GrpDetalleBono.Controls.Add(this.cboBancos);
            this.GrpDetalleBono.Controls.Add(this.lblTipoAdelanto);
            this.GrpDetalleBono.Controls.Add(this.cboTipos);
            this.GrpDetalleBono.Controls.Add(this.cboEmpleado);
            this.GrpDetalleBono.Controls.Add(this.dtpFecha);
            this.GrpDetalleBono.Controls.Add(this.txtMonto);
            this.GrpDetalleBono.Controls.Add(this.lblMonto);
            this.GrpDetalleBono.Controls.Add(this.lblEmpleado);
            this.GrpDetalleBono.Controls.Add(this.lblFecha);
            this.GrpDetalleBono.Location = new System.Drawing.Point(3, 3);
            this.GrpDetalleBono.Name = "GrpDetalleBono";
            this.GrpDetalleBono.Size = new System.Drawing.Size(486, 138);
            this.GrpDetalleBono.TabIndex = 39;
            this.GrpDetalleBono.TabStop = false;
            this.GrpDetalleBono.Text = "Detalle de Adelanto";
            // 
            // txtEmpleadoCodigo
            // 
            this.txtEmpleadoCodigo.Location = new System.Drawing.Point(78, 49);
            this.txtEmpleadoCodigo.Name = "txtEmpleadoCodigo";
            this.txtEmpleadoCodigo.Size = new System.Drawing.Size(86, 20);
            this.txtEmpleadoCodigo.TabIndex = 90;
            this.txtEmpleadoCodigo.Leave += new System.EventHandler(this.txtEmpleadoCodigo_Leave);
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero.Location = new System.Drawing.Point(357, 103);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(118, 20);
            this.txtNumero.TabIndex = 71;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNumero
            // 
            this.lblNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(288, 106);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(50, 13);
            this.lblNumero.TabIndex = 70;
            this.lblNumero.Text = "Número :";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(9, 79);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(44, 13);
            this.lblBanco.TabIndex = 69;
            this.lblBanco.Text = "Banco :";
            // 
            // cboBancos
            // 
            this.cboBancos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBancos.Enabled = false;
            this.cboBancos.Location = new System.Drawing.Point(78, 76);
            this.cboBancos.Name = "cboBancos";
            this.cboBancos.Size = new System.Drawing.Size(397, 21);
            this.cboBancos.TabIndex = 68;
            // 
            // lblTipoAdelanto
            // 
            this.lblTipoAdelanto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipoAdelanto.AutoSize = true;
            this.lblTipoAdelanto.Location = new System.Drawing.Point(288, 25);
            this.lblTipoAdelanto.Name = "lblTipoAdelanto";
            this.lblTipoAdelanto.Size = new System.Drawing.Size(34, 13);
            this.lblTipoAdelanto.TabIndex = 67;
            this.lblTipoAdelanto.Text = "Tipo :";
            // 
            // cboTipos
            // 
            this.cboTipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipos.Location = new System.Drawing.Point(357, 22);
            this.cboTipos.Name = "cboTipos";
            this.cboTipos.Size = new System.Drawing.Size(118, 21);
            this.cboTipos.TabIndex = 66;
            this.cboTipos.SelectionChangeCommitted += new System.EventHandler(this.cboTipos_SelectionChangeCommitted);
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(170, 49);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(305, 21);
            this.cboEmpleado.TabIndex = 49;
            this.cboEmpleado.SelectionChangeCommitted += new System.EventHandler(this.cboEmpleado_SelectionChangeCommitted);
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(78, 20);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(86, 20);
            this.dtpFecha.TabIndex = 38;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(78, 103);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(86, 20);
            this.txtMonto.TabIndex = 23;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.Enter += new System.EventHandler(this.txtMonto_Enter);
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(9, 106);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(43, 13);
            this.lblMonto.TabIndex = 22;
            this.lblMonto.Text = "Monto :";
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(9, 52);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(60, 13);
            this.lblEmpleado.TabIndex = 20;
            this.lblEmpleado.Text = "Empleado :";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(9, 26);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(43, 13);
            this.lblFecha.TabIndex = 18;
            this.lblFecha.Text = "Fecha :";
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.BtnSave);
            this.pnlInferior.Controls.Add(this.BtnCancel);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 158);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(492, 44);
            this.pnlInferior.TabIndex = 17;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(383, 5);
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
            this.BtnCancel.Location = new System.Drawing.Point(277, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAdelantoMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 205);
            this.Controls.Add(this.tlpPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmAdelantoMant";
            this.Text = "Mantenimiento de Adelanto";
            this.Load += new System.EventHandler(this.FrmAfpComisionMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.GrpDetalleBono.ResumeLayout(false);
            this.GrpDetalleBono.PerformLayout();
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
        private System.Windows.Forms.GroupBox GrpDetalleBono;
        private System.Windows.Forms.TextBox txtMonto;
        internal System.Windows.Forms.Label lblMonto;
        internal System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboEmpleado;
        internal System.Windows.Forms.Label lblTipoAdelanto;
        internal System.Windows.Forms.ComboBox cboTipos;
        internal System.Windows.Forms.Label lblBanco;
        internal System.Windows.Forms.ComboBox cboBancos;
        private System.Windows.Forms.TextBox txtNumero;
        internal System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtEmpleadoCodigo;
    }
}