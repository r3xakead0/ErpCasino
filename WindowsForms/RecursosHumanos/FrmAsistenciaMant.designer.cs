namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmAsistenciaMant
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
            this.GrpCarga = new System.Windows.Forms.GroupBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.TxtArchivo = new System.Windows.Forms.TextBox();
            this.LblArchivo = new System.Windows.Forms.Label();
            this.GrpManual = new System.Windows.Forms.GroupBox();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.txtEmpleadoCodigo = new System.Windows.Forms.TextBox();
            this.cboTurno = new System.Windows.Forms.ComboBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.DtpFechaHoraSalida = new System.Windows.Forms.DateTimePicker();
            this.LblFechaHora = new System.Windows.Forms.Label();
            this.DtpFechaHoraEntrada = new System.Windows.Forms.DateTimePicker();
            this.LblCodigo = new System.Windows.Forms.Label();
            this.GrpDatos = new System.Windows.Forms.GroupBox();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.LblFechaRegistroAsistencia = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.dtpFechaRegistroAsistencia = new System.Windows.Forms.DateTimePicker();
            this.dgvRegistroAsistencias = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GrpCarga.SuspendLayout();
            this.GrpManual.SuspendLayout();
            this.GrpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroAsistencias)).BeginInit();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(630, 502);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GrpCarga);
            this.panel1.Controls.Add(this.GrpManual);
            this.panel1.Controls.Add(this.GrpDatos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 446);
            this.panel1.TabIndex = 16;
            // 
            // GrpCarga
            // 
            this.GrpCarga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpCarga.Controls.Add(this.btnCargar);
            this.GrpCarga.Controls.Add(this.TxtArchivo);
            this.GrpCarga.Controls.Add(this.LblArchivo);
            this.GrpCarga.Location = new System.Drawing.Point(9, 102);
            this.GrpCarga.Name = "GrpCarga";
            this.GrpCarga.Size = new System.Drawing.Size(606, 52);
            this.GrpCarga.TabIndex = 40;
            this.GrpCarga.TabStop = false;
            this.GrpCarga.Text = "Cargar Registros";
            // 
            // btnCargar
            // 
            this.btnCargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargar.Location = new System.Drawing.Point(495, 16);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(100, 25);
            this.btnCargar.TabIndex = 20;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.BtnFile_Click);
            // 
            // TxtArchivo
            // 
            this.TxtArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtArchivo.Location = new System.Drawing.Point(104, 19);
            this.TxtArchivo.Name = "TxtArchivo";
            this.TxtArchivo.ReadOnly = true;
            this.TxtArchivo.Size = new System.Drawing.Size(373, 20);
            this.TxtArchivo.TabIndex = 17;
            // 
            // LblArchivo
            // 
            this.LblArchivo.AutoSize = true;
            this.LblArchivo.Location = new System.Drawing.Point(10, 22);
            this.LblArchivo.Name = "LblArchivo";
            this.LblArchivo.Size = new System.Drawing.Size(46, 13);
            this.LblArchivo.TabIndex = 15;
            this.LblArchivo.Text = "Archivo:";
            // 
            // GrpManual
            // 
            this.GrpManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpManual.Controls.Add(this.txtTiempo);
            this.GrpManual.Controls.Add(this.txtEmpleadoCodigo);
            this.GrpManual.Controls.Add(this.cboTurno);
            this.GrpManual.Controls.Add(this.lblTurno);
            this.GrpManual.Controls.Add(this.cboEmpleado);
            this.GrpManual.Controls.Add(this.BtnAgregar);
            this.GrpManual.Controls.Add(this.DtpFechaHoraSalida);
            this.GrpManual.Controls.Add(this.LblFechaHora);
            this.GrpManual.Controls.Add(this.DtpFechaHoraEntrada);
            this.GrpManual.Controls.Add(this.LblCodigo);
            this.GrpManual.Location = new System.Drawing.Point(9, 9);
            this.GrpManual.Name = "GrpManual";
            this.GrpManual.Size = new System.Drawing.Size(606, 87);
            this.GrpManual.TabIndex = 39;
            this.GrpManual.TabStop = false;
            this.GrpManual.Text = "Registro Manual";
            // 
            // txtTiempo
            // 
            this.txtTiempo.Location = new System.Drawing.Point(416, 51);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.ReadOnly = true;
            this.txtTiempo.Size = new System.Drawing.Size(61, 20);
            this.txtTiempo.TabIndex = 89;
            this.txtTiempo.Text = "00:00:00";
            this.txtTiempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEmpleadoCodigo
            // 
            this.txtEmpleadoCodigo.Location = new System.Drawing.Point(104, 19);
            this.txtEmpleadoCodigo.Name = "txtEmpleadoCodigo";
            this.txtEmpleadoCodigo.Size = new System.Drawing.Size(86, 20);
            this.txtEmpleadoCodigo.TabIndex = 88;
            this.txtEmpleadoCodigo.Leave += new System.EventHandler(this.txtEmpleadoCodigo_Leave);
            // 
            // cboTurno
            // 
            this.cboTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTurno.FormattingEnabled = true;
            this.cboTurno.Location = new System.Drawing.Point(553, 19);
            this.cboTurno.Name = "cboTurno";
            this.cboTurno.Size = new System.Drawing.Size(42, 21);
            this.cboTurno.TabIndex = 50;
            // 
            // lblTurno
            // 
            this.lblTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(492, 22);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(41, 13);
            this.lblTurno.TabIndex = 49;
            this.lblTurno.Text = "Turno :";
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(196, 19);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(281, 21);
            this.cboEmpleado.TabIndex = 48;
            this.cboEmpleado.SelectionChangeCommitted += new System.EventHandler(this.cboEmpleado_SelectionChangeCommitted);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAgregar.Location = new System.Drawing.Point(495, 48);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(100, 25);
            this.BtnAgregar.TabIndex = 19;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // DtpFechaHoraSalida
            // 
            this.DtpFechaHoraSalida.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.DtpFechaHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaHoraSalida.Location = new System.Drawing.Point(261, 51);
            this.DtpFechaHoraSalida.Name = "DtpFechaHoraSalida";
            this.DtpFechaHoraSalida.Size = new System.Drawing.Size(149, 20);
            this.DtpFechaHoraSalida.TabIndex = 37;
            // 
            // LblFechaHora
            // 
            this.LblFechaHora.AutoSize = true;
            this.LblFechaHora.Location = new System.Drawing.Point(9, 54);
            this.LblFechaHora.Name = "LblFechaHora";
            this.LblFechaHora.Size = new System.Drawing.Size(86, 13);
            this.LblFechaHora.TabIndex = 18;
            this.LblFechaHora.Text = "Ingreso - Salida :";
            // 
            // DtpFechaHoraEntrada
            // 
            this.DtpFechaHoraEntrada.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.DtpFechaHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFechaHoraEntrada.Location = new System.Drawing.Point(104, 51);
            this.DtpFechaHoraEntrada.Name = "DtpFechaHoraEntrada";
            this.DtpFechaHoraEntrada.Size = new System.Drawing.Size(151, 20);
            this.DtpFechaHoraEntrada.TabIndex = 36;
            // 
            // LblCodigo
            // 
            this.LblCodigo.AutoSize = true;
            this.LblCodigo.Location = new System.Drawing.Point(10, 22);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(60, 13);
            this.LblCodigo.TabIndex = 15;
            this.LblCodigo.Text = "Empleado :";
            // 
            // GrpDatos
            // 
            this.GrpDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpDatos.Controls.Add(this.btnExportarCsv);
            this.GrpDatos.Controls.Add(this.LblFechaRegistroAsistencia);
            this.GrpDatos.Controls.Add(this.BtnEliminar);
            this.GrpDatos.Controls.Add(this.dtpFechaRegistroAsistencia);
            this.GrpDatos.Controls.Add(this.dgvRegistroAsistencias);
            this.GrpDatos.Location = new System.Drawing.Point(9, 160);
            this.GrpDatos.Name = "GrpDatos";
            this.GrpDatos.Size = new System.Drawing.Size(606, 272);
            this.GrpDatos.TabIndex = 38;
            this.GrpDatos.TabStop = false;
            this.GrpDatos.Text = "Registro de Asistencias";
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarCsv.Location = new System.Drawing.Point(389, 241);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(100, 25);
            this.btnExportarCsv.TabIndex = 90;
            this.btnExportarCsv.Text = "Exportar CSV";
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            // 
            // LblFechaRegistroAsistencia
            // 
            this.LblFechaRegistroAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblFechaRegistroAsistencia.AutoSize = true;
            this.LblFechaRegistroAsistencia.Location = new System.Drawing.Point(10, 247);
            this.LblFechaRegistroAsistencia.Name = "LblFechaRegistroAsistencia";
            this.LblFechaRegistroAsistencia.Size = new System.Drawing.Size(79, 13);
            this.LblFechaRegistroAsistencia.TabIndex = 38;
            this.LblFechaRegistroAsistencia.Text = "Fecha Registro";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEliminar.Location = new System.Drawing.Point(495, 241);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(100, 25);
            this.BtnEliminar.TabIndex = 20;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // dtpFechaRegistroAsistencia
            // 
            this.dtpFechaRegistroAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpFechaRegistroAsistencia.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaRegistroAsistencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaRegistroAsistencia.Location = new System.Drawing.Point(105, 244);
            this.dtpFechaRegistroAsistencia.Name = "dtpFechaRegistroAsistencia";
            this.dtpFechaRegistroAsistencia.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaRegistroAsistencia.TabIndex = 39;
            this.dtpFechaRegistroAsistencia.ValueChanged += new System.EventHandler(this.dtpFechaRegistroAsistencia_ValueChanged);
            // 
            // dgvRegistroAsistencias
            // 
            this.dgvRegistroAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegistroAsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistroAsistencias.Location = new System.Drawing.Point(12, 19);
            this.dgvRegistroAsistencias.Name = "dgvRegistroAsistencias";
            this.dgvRegistroAsistencias.Size = new System.Drawing.Size(583, 216);
            this.dgvRegistroAsistencias.TabIndex = 0;
            this.dgvRegistroAsistencias.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRegistroAsistencias_ColumnHeaderMouseClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnSave);
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 455);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 44);
            this.panel2.TabIndex = 17;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(515, 5);
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
            this.BtnCancel.Location = new System.Drawing.Point(409, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAsistenciaMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 502);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "FrmAsistenciaMant";
            this.Text = "Mantenimiento de Asistencias";
            this.Load += new System.EventHandler(this.FrmAsistenciaMant_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmAsistenciaMant_ResizeEnd);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.GrpCarga.ResumeLayout(false);
            this.GrpCarga.PerformLayout();
            this.GrpManual.ResumeLayout(false);
            this.GrpManual.PerformLayout();
            this.GrpDatos.ResumeLayout(false);
            this.GrpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroAsistencias)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label LblCodigo;
        internal System.Windows.Forms.Label LblFechaHora;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.DateTimePicker DtpFechaHoraSalida;
        private System.Windows.Forms.DateTimePicker DtpFechaHoraEntrada;
        public System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.GroupBox GrpDatos;
        private System.Windows.Forms.DataGridView dgvRegistroAsistencias;
        private System.Windows.Forms.GroupBox GrpManual;
        private System.Windows.Forms.GroupBox GrpCarga;
        internal System.Windows.Forms.TextBox TxtArchivo;
        internal System.Windows.Forms.Label LblArchivo;
        public System.Windows.Forms.Button BtnEliminar;
        internal System.Windows.Forms.Label LblFechaRegistroAsistencia;
        private System.Windows.Forms.DateTimePicker dtpFechaRegistroAsistencia;
        private System.Windows.Forms.ComboBox cboEmpleado;
        public System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.ComboBox cboTurno;
        internal System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.TextBox txtEmpleadoCodigo;
        private System.Windows.Forms.TextBox txtTiempo;
        public System.Windows.Forms.Button btnExportarCsv;
    }
}