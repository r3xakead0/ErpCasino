namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmPrestamoMant
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
            this.grpDetalleCuota = new System.Windows.Forms.GroupBox();
            this.chkPagadoCuota = new System.Windows.Forms.CheckBox();
            this.btnCuotaAgregar = new System.Windows.Forms.Button();
            this.dtpFechaCuota = new System.Windows.Forms.DateTimePicker();
            this.txtMontoCuota = new System.Windows.Forms.TextBox();
            this.lblMontoCuota = new System.Windows.Forms.Label();
            this.lblFechaCuota = new System.Windows.Forms.Label();
            this.grpListaCuotas = new System.Windows.Forms.GroupBox();
            this.btnCuotaEliminar = new System.Windows.Forms.Button();
            this.txtCantidadCuotas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCuotas = new System.Windows.Forms.DataGridView();
            this.grpDatosPrestamo = new System.Windows.Forms.GroupBox();
            this.chkPagado = new System.Windows.Forms.CheckBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
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
            this.grpDetalleCuota.SuspendLayout();
            this.grpListaCuotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).BeginInit();
            this.grpDatosPrestamo.SuspendLayout();
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
            this.tlpPrincipal.Size = new System.Drawing.Size(445, 501);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.grpDetalleCuota);
            this.pnlPrincipal.Controls.Add(this.grpListaCuotas);
            this.pnlPrincipal.Controls.Add(this.grpDatosPrestamo);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(439, 445);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // grpDetalleCuota
            // 
            this.grpDetalleCuota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetalleCuota.Controls.Add(this.chkPagadoCuota);
            this.grpDetalleCuota.Controls.Add(this.btnCuotaAgregar);
            this.grpDetalleCuota.Controls.Add(this.dtpFechaCuota);
            this.grpDetalleCuota.Controls.Add(this.txtMontoCuota);
            this.grpDetalleCuota.Controls.Add(this.lblMontoCuota);
            this.grpDetalleCuota.Controls.Add(this.lblFechaCuota);
            this.grpDetalleCuota.Location = new System.Drawing.Point(3, 354);
            this.grpDetalleCuota.Name = "grpDetalleCuota";
            this.grpDetalleCuota.Size = new System.Drawing.Size(433, 82);
            this.grpDetalleCuota.TabIndex = 41;
            this.grpDetalleCuota.TabStop = false;
            this.grpDetalleCuota.Text = "Detalle de Cuota";
            // 
            // chkPagadoCuota
            // 
            this.chkPagadoCuota.AutoSize = true;
            this.chkPagadoCuota.Location = new System.Drawing.Point(12, 50);
            this.chkPagadoCuota.Name = "chkPagadoCuota";
            this.chkPagadoCuota.Size = new System.Drawing.Size(63, 17);
            this.chkPagadoCuota.TabIndex = 74;
            this.chkPagadoCuota.Text = "Pagado";
            this.chkPagadoCuota.UseVisualStyleBackColor = true;
            // 
            // btnCuotaAgregar
            // 
            this.btnCuotaAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCuotaAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuotaAgregar.Location = new System.Drawing.Point(327, 46);
            this.btnCuotaAgregar.Name = "btnCuotaAgregar";
            this.btnCuotaAgregar.Size = new System.Drawing.Size(95, 23);
            this.btnCuotaAgregar.TabIndex = 26;
            this.btnCuotaAgregar.Text = "Agregar +";
            this.btnCuotaAgregar.UseVisualStyleBackColor = true;
            this.btnCuotaAgregar.Click += new System.EventHandler(this.btnCuotaAgregar_Click);
            // 
            // dtpFechaCuota
            // 
            this.dtpFechaCuota.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaCuota.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaCuota.Location = new System.Drawing.Point(80, 20);
            this.dtpFechaCuota.Name = "dtpFechaCuota";
            this.dtpFechaCuota.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaCuota.TabIndex = 42;
            // 
            // txtMontoCuota
            // 
            this.txtMontoCuota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMontoCuota.Location = new System.Drawing.Point(327, 20);
            this.txtMontoCuota.Name = "txtMontoCuota";
            this.txtMontoCuota.Size = new System.Drawing.Size(95, 20);
            this.txtMontoCuota.TabIndex = 41;
            this.txtMontoCuota.Text = "0.00";
            this.txtMontoCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoCuota.Enter += new System.EventHandler(this.txtMontoCuota_Enter);
            this.txtMontoCuota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoCuota_KeyPress);
            this.txtMontoCuota.Leave += new System.EventHandler(this.txtMontoCuota_Leave);
            // 
            // lblMontoCuota
            // 
            this.lblMontoCuota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMontoCuota.AutoSize = true;
            this.lblMontoCuota.Location = new System.Drawing.Point(258, 23);
            this.lblMontoCuota.Name = "lblMontoCuota";
            this.lblMontoCuota.Size = new System.Drawing.Size(43, 13);
            this.lblMontoCuota.TabIndex = 40;
            this.lblMontoCuota.Text = "Monto :";
            // 
            // lblFechaCuota
            // 
            this.lblFechaCuota.AutoSize = true;
            this.lblFechaCuota.Location = new System.Drawing.Point(9, 23);
            this.lblFechaCuota.Name = "lblFechaCuota";
            this.lblFechaCuota.Size = new System.Drawing.Size(43, 13);
            this.lblFechaCuota.TabIndex = 39;
            this.lblFechaCuota.Text = "Fecha :";
            // 
            // grpListaCuotas
            // 
            this.grpListaCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpListaCuotas.Controls.Add(this.btnCuotaEliminar);
            this.grpListaCuotas.Controls.Add(this.txtCantidadCuotas);
            this.grpListaCuotas.Controls.Add(this.label1);
            this.grpListaCuotas.Controls.Add(this.dgvCuotas);
            this.grpListaCuotas.Location = new System.Drawing.Point(3, 163);
            this.grpListaCuotas.Name = "grpListaCuotas";
            this.grpListaCuotas.Size = new System.Drawing.Size(433, 185);
            this.grpListaCuotas.TabIndex = 40;
            this.grpListaCuotas.TabStop = false;
            this.grpListaCuotas.Text = "Lista de Cuotas";
            // 
            // btnCuotaEliminar
            // 
            this.btnCuotaEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCuotaEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuotaEliminar.Location = new System.Drawing.Point(12, 156);
            this.btnCuotaEliminar.Name = "btnCuotaEliminar";
            this.btnCuotaEliminar.Size = new System.Drawing.Size(95, 23);
            this.btnCuotaEliminar.TabIndex = 27;
            this.btnCuotaEliminar.Text = "Eliminar -";
            this.btnCuotaEliminar.UseVisualStyleBackColor = true;
            this.btnCuotaEliminar.Click += new System.EventHandler(this.btnCuotaEliminar_Click);
            // 
            // txtCantidadCuotas
            // 
            this.txtCantidadCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidadCuotas.Location = new System.Drawing.Point(359, 159);
            this.txtCantidadCuotas.Name = "txtCantidadCuotas";
            this.txtCantidadCuotas.ReadOnly = true;
            this.txtCantidadCuotas.Size = new System.Drawing.Size(63, 20);
            this.txtCantidadCuotas.TabIndex = 25;
            this.txtCantidadCuotas.Text = "0";
            this.txtCantidadCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nro. Cuotas :";
            // 
            // dgvCuotas
            // 
            this.dgvCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuotas.Location = new System.Drawing.Point(12, 19);
            this.dgvCuotas.Name = "dgvCuotas";
            this.dgvCuotas.Size = new System.Drawing.Size(410, 134);
            this.dgvCuotas.TabIndex = 0;
            // 
            // grpDatosPrestamo
            // 
            this.grpDatosPrestamo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDatosPrestamo.Controls.Add(this.chkPagado);
            this.grpDatosPrestamo.Controls.Add(this.txtMotivo);
            this.grpDatosPrestamo.Controls.Add(this.lblMotivo);
            this.grpDatosPrestamo.Controls.Add(this.cboEmpleado);
            this.grpDatosPrestamo.Controls.Add(this.dtpFecha);
            this.grpDatosPrestamo.Controls.Add(this.txtMonto);
            this.grpDatosPrestamo.Controls.Add(this.lblMonto);
            this.grpDatosPrestamo.Controls.Add(this.lblEmpleado);
            this.grpDatosPrestamo.Controls.Add(this.lblFecha);
            this.grpDatosPrestamo.Location = new System.Drawing.Point(3, 3);
            this.grpDatosPrestamo.Name = "grpDatosPrestamo";
            this.grpDatosPrestamo.Size = new System.Drawing.Size(433, 154);
            this.grpDatosPrestamo.TabIndex = 39;
            this.grpDatosPrestamo.TabStop = false;
            this.grpDatosPrestamo.Text = "Datos del Prestamo";
            // 
            // chkPagado
            // 
            this.chkPagado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPagado.AutoSize = true;
            this.chkPagado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPagado.Location = new System.Drawing.Point(359, 128);
            this.chkPagado.Name = "chkPagado";
            this.chkPagado.Size = new System.Drawing.Size(63, 17);
            this.chkPagado.TabIndex = 73;
            this.chkPagado.Text = "Pagado";
            this.chkPagado.UseVisualStyleBackColor = true;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMotivo.Location = new System.Drawing.Point(78, 76);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.Size = new System.Drawing.Size(344, 46);
            this.txtMotivo.TabIndex = 72;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(9, 79);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(45, 13);
            this.lblMotivo.TabIndex = 69;
            this.lblMotivo.Text = "Motivo :";
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(78, 49);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(344, 21);
            this.cboEmpleado.TabIndex = 49;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(78, 23);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(95, 20);
            this.dtpFecha.TabIndex = 38;
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonto.Location = new System.Drawing.Point(327, 23);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(95, 20);
            this.txtMonto.TabIndex = 23;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMonto
            // 
            this.lblMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(258, 26);
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
            this.pnlInferior.Location = new System.Drawing.Point(3, 454);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(439, 44);
            this.pnlInferior.TabIndex = 17;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(330, 5);
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
            this.BtnCancel.Location = new System.Drawing.Point(224, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmPrestamoMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 501);
            this.Controls.Add(this.tlpPrincipal);
            this.Name = "FrmPrestamoMant";
            this.Text = "Mantenimiento de Prestamo";
            this.Load += new System.EventHandler(this.FrmPrestamoMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.grpDetalleCuota.ResumeLayout(false);
            this.grpDetalleCuota.PerformLayout();
            this.grpListaCuotas.ResumeLayout(false);
            this.grpListaCuotas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuotas)).EndInit();
            this.grpDatosPrestamo.ResumeLayout(false);
            this.grpDatosPrestamo.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpDatosPrestamo;
        private System.Windows.Forms.TextBox txtMonto;
        internal System.Windows.Forms.Label lblMonto;
        internal System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboEmpleado;
        internal System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.CheckBox chkPagado;
        private System.Windows.Forms.GroupBox grpListaCuotas;
        private System.Windows.Forms.DataGridView dgvCuotas;
        private System.Windows.Forms.TextBox txtCantidadCuotas;
        internal System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnCuotaEliminar;
        public System.Windows.Forms.Button btnCuotaAgregar;
        private System.Windows.Forms.GroupBox grpDetalleCuota;
        private System.Windows.Forms.CheckBox chkPagadoCuota;
        private System.Windows.Forms.DateTimePicker dtpFechaCuota;
        private System.Windows.Forms.TextBox txtMontoCuota;
        internal System.Windows.Forms.Label lblMontoCuota;
        internal System.Windows.Forms.Label lblFechaCuota;
    }
}