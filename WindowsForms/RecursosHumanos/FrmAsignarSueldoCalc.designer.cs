namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmAsignarSueldoCalc
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
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.grpCalcular = new System.Windows.Forms.GroupBox();
            this.LblFechaHora = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.pnlCalculo = new System.Windows.Forms.Panel();
            this.grpBonificaciones = new System.Windows.Forms.GroupBox();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.tbcCalculo = new System.Windows.Forms.TabControl();
            this.tbpAsistenciasDetalle = new System.Windows.Forms.TabPage();
            this.btnExportarAsistenciasCsv = new System.Windows.Forms.Button();
            this.lblLeyendaAsistenciaResumen = new System.Windows.Forms.Label();
            this.txtInasistencia = new System.Windows.Forms.TextBox();
            this.txtAsistenciaFeriado = new System.Windows.Forms.TextBox();
            this.txtAsistenciaNormal = new System.Windows.Forms.TextBox();
            this.cboAsistenciaPor = new System.Windows.Forms.ComboBox();
            this.lblCalculoPor = new System.Windows.Forms.Label();
            this.txtRegistrosAsistencias = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAsistenciasDetalle = new System.Windows.Forms.DataGridView();
            this.tbpAsistenciasResumen = new System.Windows.Forms.TabPage();
            this.btnExportarAsistenciasResumenCsv = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInasistenciaResumen = new System.Windows.Forms.TextBox();
            this.txtAsistenciaResumenFeriado = new System.Windows.Forms.TextBox();
            this.txtAsistenciaResumenNormal = new System.Windows.Forms.TextBox();
            this.cboAsistenciaResumenPor = new System.Windows.Forms.ComboBox();
            this.lblCalculoResumenPor = new System.Windows.Forms.Label();
            this.txtRegistrosAsistenciasResumen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvAsistenciasResumen = new System.Windows.Forms.DataGridView();
            this.tbpCostos = new System.Windows.Forms.TabPage();
            this.btnExportarCostoCsv = new System.Windows.Forms.Button();
            this.lblLeyendaDescuentos = new System.Windows.Forms.Label();
            this.txtLeyendaTardanzaFeriado = new System.Windows.Forms.TextBox();
            this.txtLeyendaInasistencia = new System.Windows.Forms.TextBox();
            this.lblLeyendaCostos = new System.Windows.Forms.Label();
            this.txtLeyendaTardanzaNormal = new System.Windows.Forms.TextBox();
            this.txtLeyendaAsistenciaFeriado = new System.Windows.Forms.TextBox();
            this.txtLeyendaAsistenciaNormal = new System.Windows.Forms.TextBox();
            this.cboCostoPor = new System.Windows.Forms.ComboBox();
            this.lblCostoPor = new System.Windows.Forms.Label();
            this.txtRegistrosCostos = new System.Windows.Forms.TextBox();
            this.lblRegistrosCostos = new System.Windows.Forms.Label();
            this.dgvCostos = new System.Windows.Forms.DataGridView();
            this.tbpSueldos = new System.Windows.Forms.TabPage();
            this.dgvSueldos = new System.Windows.Forms.DataGridView();
            this.txtTotalSueldos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroSueldos = new System.Windows.Forms.TextBox();
            this.lblRegistrosAsistencias = new System.Windows.Forms.Label();
            this.txtAnho = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.grpCalcular.SuspendLayout();
            this.pnlCalculo.SuspendLayout();
            this.grpBonificaciones.SuspendLayout();
            this.tbcCalculo.SuspendLayout();
            this.tbpAsistenciasDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciasDetalle)).BeginInit();
            this.tbpAsistenciasResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciasResumen)).BeginInit();
            this.tbpCostos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).BeginInit();
            this.tbpSueldos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSueldos)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlFiltro, 0, 0);
            this.tlpPrincipal.Controls.Add(this.pnlCalculo, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Size = new System.Drawing.Size(946, 489);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Controls.Add(this.grpCalcular);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiltro.Location = new System.Drawing.Point(3, 3);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(940, 84);
            this.pnlFiltro.TabIndex = 16;
            // 
            // grpCalcular
            // 
            this.grpCalcular.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCalcular.Controls.Add(this.LblFechaHora);
            this.grpCalcular.Controls.Add(this.btnCalcular);
            this.grpCalcular.Controls.Add(this.cboMes);
            this.grpCalcular.Controls.Add(this.cboAnho);
            this.grpCalcular.Location = new System.Drawing.Point(9, 9);
            this.grpCalcular.Name = "grpCalcular";
            this.grpCalcular.Size = new System.Drawing.Size(922, 63);
            this.grpCalcular.TabIndex = 102;
            this.grpCalcular.TabStop = false;
            this.grpCalcular.Text = "Filtro de Calculo";
            // 
            // LblFechaHora
            // 
            this.LblFechaHora.AutoSize = true;
            this.LblFechaHora.Location = new System.Drawing.Point(6, 22);
            this.LblFechaHora.Name = "LblFechaHora";
            this.LblFechaHora.Size = new System.Drawing.Size(63, 13);
            this.LblFechaHora.TabIndex = 95;
            this.LblFechaHora.Text = "Año y Mes :";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcular.Location = new System.Drawing.Point(816, 19);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(100, 31);
            this.btnCalcular.TabIndex = 101;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(170, 19);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(211, 21);
            this.cboMes.TabIndex = 97;
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(78, 19);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(86, 21);
            this.cboAnho.TabIndex = 96;
            // 
            // pnlCalculo
            // 
            this.pnlCalculo.Controls.Add(this.grpBonificaciones);
            this.pnlCalculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCalculo.Location = new System.Drawing.Point(3, 93);
            this.pnlCalculo.Name = "pnlCalculo";
            this.pnlCalculo.Size = new System.Drawing.Size(940, 393);
            this.pnlCalculo.TabIndex = 17;
            // 
            // grpBonificaciones
            // 
            this.grpBonificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBonificaciones.Controls.Add(this.txtMes);
            this.grpBonificaciones.Controls.Add(this.tbcCalculo);
            this.grpBonificaciones.Controls.Add(this.txtAnho);
            this.grpBonificaciones.Controls.Add(this.label2);
            this.grpBonificaciones.Controls.Add(this.btnGuardar);
            this.grpBonificaciones.Location = new System.Drawing.Point(9, 3);
            this.grpBonificaciones.Name = "grpBonificaciones";
            this.grpBonificaciones.Size = new System.Drawing.Size(922, 381);
            this.grpBonificaciones.TabIndex = 100;
            this.grpBonificaciones.TabStop = false;
            this.grpBonificaciones.Text = "Resultado de Sueldos Calculados";
            // 
            // txtMes
            // 
            this.txtMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMes.Location = new System.Drawing.Point(170, 344);
            this.txtMes.Name = "txtMes";
            this.txtMes.ReadOnly = true;
            this.txtMes.Size = new System.Drawing.Size(211, 20);
            this.txtMes.TabIndex = 111;
            this.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbcCalculo
            // 
            this.tbcCalculo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcCalculo.Controls.Add(this.tbpAsistenciasDetalle);
            this.tbcCalculo.Controls.Add(this.tbpAsistenciasResumen);
            this.tbcCalculo.Controls.Add(this.tbpCostos);
            this.tbcCalculo.Controls.Add(this.tbpSueldos);
            this.tbcCalculo.Location = new System.Drawing.Point(6, 19);
            this.tbcCalculo.Name = "tbcCalculo";
            this.tbcCalculo.SelectedIndex = 0;
            this.tbcCalculo.Size = new System.Drawing.Size(910, 319);
            this.tbcCalculo.TabIndex = 110;
            // 
            // tbpAsistenciasDetalle
            // 
            this.tbpAsistenciasDetalle.Controls.Add(this.btnExportarAsistenciasCsv);
            this.tbpAsistenciasDetalle.Controls.Add(this.lblLeyendaAsistenciaResumen);
            this.tbpAsistenciasDetalle.Controls.Add(this.txtInasistencia);
            this.tbpAsistenciasDetalle.Controls.Add(this.txtAsistenciaFeriado);
            this.tbpAsistenciasDetalle.Controls.Add(this.txtAsistenciaNormal);
            this.tbpAsistenciasDetalle.Controls.Add(this.cboAsistenciaPor);
            this.tbpAsistenciasDetalle.Controls.Add(this.lblCalculoPor);
            this.tbpAsistenciasDetalle.Controls.Add(this.txtRegistrosAsistencias);
            this.tbpAsistenciasDetalle.Controls.Add(this.label1);
            this.tbpAsistenciasDetalle.Controls.Add(this.dgvAsistenciasDetalle);
            this.tbpAsistenciasDetalle.Location = new System.Drawing.Point(4, 22);
            this.tbpAsistenciasDetalle.Name = "tbpAsistenciasDetalle";
            this.tbpAsistenciasDetalle.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAsistenciasDetalle.Size = new System.Drawing.Size(902, 293);
            this.tbpAsistenciasDetalle.TabIndex = 1;
            this.tbpAsistenciasDetalle.Text = "Detalle de Asistencias";
            this.tbpAsistenciasDetalle.UseVisualStyleBackColor = true;
            // 
            // btnExportarAsistenciasCsv
            // 
            this.btnExportarAsistenciasCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarAsistenciasCsv.Location = new System.Drawing.Point(785, 187);
            this.btnExportarAsistenciasCsv.Name = "btnExportarAsistenciasCsv";
            this.btnExportarAsistenciasCsv.Size = new System.Drawing.Size(111, 21);
            this.btnExportarAsistenciasCsv.TabIndex = 114;
            this.btnExportarAsistenciasCsv.Text = "Exportar CSV";
            this.btnExportarAsistenciasCsv.UseVisualStyleBackColor = true;
            this.btnExportarAsistenciasCsv.Click += new System.EventHandler(this.btnExportarAsistenciasCsv_Click);
            // 
            // lblLeyendaAsistenciaResumen
            // 
            this.lblLeyendaAsistenciaResumen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeyendaAsistenciaResumen.AutoSize = true;
            this.lblLeyendaAsistenciaResumen.Location = new System.Drawing.Point(785, 6);
            this.lblLeyendaAsistenciaResumen.Name = "lblLeyendaAsistenciaResumen";
            this.lblLeyendaAsistenciaResumen.Size = new System.Drawing.Size(54, 13);
            this.lblLeyendaAsistenciaResumen.TabIndex = 113;
            this.lblLeyendaAsistenciaResumen.Text = "Leyenda :";
            // 
            // txtInasistencia
            // 
            this.txtInasistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInasistencia.BackColor = System.Drawing.Color.Red;
            this.txtInasistencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInasistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInasistencia.Location = new System.Drawing.Point(785, 74);
            this.txtInasistencia.Name = "txtInasistencia";
            this.txtInasistencia.Size = new System.Drawing.Size(111, 20);
            this.txtInasistencia.TabIndex = 112;
            this.txtInasistencia.Text = "Inasistencia";
            this.txtInasistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAsistenciaFeriado
            // 
            this.txtAsistenciaFeriado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsistenciaFeriado.BackColor = System.Drawing.Color.LightYellow;
            this.txtAsistenciaFeriado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAsistenciaFeriado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsistenciaFeriado.Location = new System.Drawing.Point(785, 48);
            this.txtAsistenciaFeriado.Name = "txtAsistenciaFeriado";
            this.txtAsistenciaFeriado.Size = new System.Drawing.Size(111, 20);
            this.txtAsistenciaFeriado.TabIndex = 111;
            this.txtAsistenciaFeriado.Text = "Asistencia Feriado";
            this.txtAsistenciaFeriado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAsistenciaNormal
            // 
            this.txtAsistenciaNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsistenciaNormal.BackColor = System.Drawing.Color.LightGreen;
            this.txtAsistenciaNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAsistenciaNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsistenciaNormal.Location = new System.Drawing.Point(785, 22);
            this.txtAsistenciaNormal.Name = "txtAsistenciaNormal";
            this.txtAsistenciaNormal.Size = new System.Drawing.Size(111, 20);
            this.txtAsistenciaNormal.TabIndex = 110;
            this.txtAsistenciaNormal.Text = "Asistencia Normal";
            this.txtAsistenciaNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboAsistenciaPor
            // 
            this.cboAsistenciaPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAsistenciaPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsistenciaPor.FormattingEnabled = true;
            this.cboAsistenciaPor.Location = new System.Drawing.Point(785, 227);
            this.cboAsistenciaPor.Name = "cboAsistenciaPor";
            this.cboAsistenciaPor.Size = new System.Drawing.Size(111, 21);
            this.cboAsistenciaPor.TabIndex = 108;
            this.cboAsistenciaPor.SelectionChangeCommitted += new System.EventHandler(this.cboAsistenciaPor_SelectionChangeCommitted);
            // 
            // lblCalculoPor
            // 
            this.lblCalculoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCalculoPor.AutoSize = true;
            this.lblCalculoPor.Location = new System.Drawing.Point(785, 211);
            this.lblCalculoPor.Name = "lblCalculoPor";
            this.lblCalculoPor.Size = new System.Drawing.Size(79, 13);
            this.lblCalculoPor.TabIndex = 106;
            this.lblCalculoPor.Text = "Asistencia por :";
            // 
            // txtRegistrosAsistencias
            // 
            this.txtRegistrosAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistrosAsistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistrosAsistencias.Location = new System.Drawing.Point(785, 267);
            this.txtRegistrosAsistencias.Name = "txtRegistrosAsistencias";
            this.txtRegistrosAsistencias.Size = new System.Drawing.Size(111, 20);
            this.txtRegistrosAsistencias.TabIndex = 109;
            this.txtRegistrosAsistencias.Text = "0";
            this.txtRegistrosAsistencias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(785, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "Registros :";
            // 
            // dgvAsistenciasDetalle
            // 
            this.dgvAsistenciasDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsistenciasDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistenciasDetalle.Location = new System.Drawing.Point(6, 6);
            this.dgvAsistenciasDetalle.Name = "dgvAsistenciasDetalle";
            this.dgvAsistenciasDetalle.Size = new System.Drawing.Size(773, 281);
            this.dgvAsistenciasDetalle.TabIndex = 105;
            // 
            // tbpAsistenciasResumen
            // 
            this.tbpAsistenciasResumen.Controls.Add(this.btnExportarAsistenciasResumenCsv);
            this.tbpAsistenciasResumen.Controls.Add(this.label3);
            this.tbpAsistenciasResumen.Controls.Add(this.txtInasistenciaResumen);
            this.tbpAsistenciasResumen.Controls.Add(this.txtAsistenciaResumenFeriado);
            this.tbpAsistenciasResumen.Controls.Add(this.txtAsistenciaResumenNormal);
            this.tbpAsistenciasResumen.Controls.Add(this.cboAsistenciaResumenPor);
            this.tbpAsistenciasResumen.Controls.Add(this.lblCalculoResumenPor);
            this.tbpAsistenciasResumen.Controls.Add(this.txtRegistrosAsistenciasResumen);
            this.tbpAsistenciasResumen.Controls.Add(this.label6);
            this.tbpAsistenciasResumen.Controls.Add(this.dgvAsistenciasResumen);
            this.tbpAsistenciasResumen.Location = new System.Drawing.Point(4, 22);
            this.tbpAsistenciasResumen.Name = "tbpAsistenciasResumen";
            this.tbpAsistenciasResumen.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAsistenciasResumen.Size = new System.Drawing.Size(902, 293);
            this.tbpAsistenciasResumen.TabIndex = 3;
            this.tbpAsistenciasResumen.Text = "Resumen de Asistencias";
            this.tbpAsistenciasResumen.UseVisualStyleBackColor = true;
            // 
            // btnExportarAsistenciasResumenCsv
            // 
            this.btnExportarAsistenciasResumenCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarAsistenciasResumenCsv.Location = new System.Drawing.Point(785, 187);
            this.btnExportarAsistenciasResumenCsv.Name = "btnExportarAsistenciasResumenCsv";
            this.btnExportarAsistenciasResumenCsv.Size = new System.Drawing.Size(111, 21);
            this.btnExportarAsistenciasResumenCsv.TabIndex = 124;
            this.btnExportarAsistenciasResumenCsv.Text = "Exportar CSV";
            this.btnExportarAsistenciasResumenCsv.UseVisualStyleBackColor = true;
            this.btnExportarAsistenciasResumenCsv.Click += new System.EventHandler(this.btnExportarAsistenciasResumenCsv_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(785, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 123;
            this.label3.Text = "Leyenda :";
            // 
            // txtInasistenciaResumen
            // 
            this.txtInasistenciaResumen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInasistenciaResumen.BackColor = System.Drawing.Color.Red;
            this.txtInasistenciaResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInasistenciaResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInasistenciaResumen.Location = new System.Drawing.Point(785, 74);
            this.txtInasistenciaResumen.Name = "txtInasistenciaResumen";
            this.txtInasistenciaResumen.Size = new System.Drawing.Size(111, 20);
            this.txtInasistenciaResumen.TabIndex = 122;
            this.txtInasistenciaResumen.Text = "Inasistencia";
            this.txtInasistenciaResumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAsistenciaResumenFeriado
            // 
            this.txtAsistenciaResumenFeriado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsistenciaResumenFeriado.BackColor = System.Drawing.Color.LightYellow;
            this.txtAsistenciaResumenFeriado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAsistenciaResumenFeriado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsistenciaResumenFeriado.Location = new System.Drawing.Point(785, 48);
            this.txtAsistenciaResumenFeriado.Name = "txtAsistenciaResumenFeriado";
            this.txtAsistenciaResumenFeriado.Size = new System.Drawing.Size(111, 20);
            this.txtAsistenciaResumenFeriado.TabIndex = 121;
            this.txtAsistenciaResumenFeriado.Text = "Asistencia Feriado";
            this.txtAsistenciaResumenFeriado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAsistenciaResumenNormal
            // 
            this.txtAsistenciaResumenNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsistenciaResumenNormal.BackColor = System.Drawing.Color.LightGreen;
            this.txtAsistenciaResumenNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAsistenciaResumenNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsistenciaResumenNormal.Location = new System.Drawing.Point(785, 22);
            this.txtAsistenciaResumenNormal.Name = "txtAsistenciaResumenNormal";
            this.txtAsistenciaResumenNormal.Size = new System.Drawing.Size(111, 20);
            this.txtAsistenciaResumenNormal.TabIndex = 120;
            this.txtAsistenciaResumenNormal.Text = "Asistencia Normal";
            this.txtAsistenciaResumenNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboAsistenciaResumenPor
            // 
            this.cboAsistenciaResumenPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAsistenciaResumenPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsistenciaResumenPor.FormattingEnabled = true;
            this.cboAsistenciaResumenPor.Location = new System.Drawing.Point(785, 227);
            this.cboAsistenciaResumenPor.Name = "cboAsistenciaResumenPor";
            this.cboAsistenciaResumenPor.Size = new System.Drawing.Size(111, 21);
            this.cboAsistenciaResumenPor.TabIndex = 118;
            this.cboAsistenciaResumenPor.SelectionChangeCommitted += new System.EventHandler(this.cboAsistenciaResumenPor_SelectionChangeCommitted);
            // 
            // lblCalculoResumenPor
            // 
            this.lblCalculoResumenPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCalculoResumenPor.AutoSize = true;
            this.lblCalculoResumenPor.Location = new System.Drawing.Point(785, 211);
            this.lblCalculoResumenPor.Name = "lblCalculoResumenPor";
            this.lblCalculoResumenPor.Size = new System.Drawing.Size(79, 13);
            this.lblCalculoResumenPor.TabIndex = 116;
            this.lblCalculoResumenPor.Text = "Asistencia por :";
            // 
            // txtRegistrosAsistenciasResumen
            // 
            this.txtRegistrosAsistenciasResumen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistrosAsistenciasResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistrosAsistenciasResumen.Location = new System.Drawing.Point(785, 267);
            this.txtRegistrosAsistenciasResumen.Name = "txtRegistrosAsistenciasResumen";
            this.txtRegistrosAsistenciasResumen.Size = new System.Drawing.Size(111, 20);
            this.txtRegistrosAsistenciasResumen.TabIndex = 119;
            this.txtRegistrosAsistenciasResumen.Text = "0";
            this.txtRegistrosAsistenciasResumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(785, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 117;
            this.label6.Text = "Registros :";
            // 
            // dgvAsistenciasResumen
            // 
            this.dgvAsistenciasResumen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsistenciasResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistenciasResumen.Location = new System.Drawing.Point(6, 6);
            this.dgvAsistenciasResumen.Name = "dgvAsistenciasResumen";
            this.dgvAsistenciasResumen.Size = new System.Drawing.Size(773, 281);
            this.dgvAsistenciasResumen.TabIndex = 115;
            // 
            // tbpCostos
            // 
            this.tbpCostos.Controls.Add(this.btnExportarCostoCsv);
            this.tbpCostos.Controls.Add(this.lblLeyendaDescuentos);
            this.tbpCostos.Controls.Add(this.txtLeyendaTardanzaFeriado);
            this.tbpCostos.Controls.Add(this.txtLeyendaInasistencia);
            this.tbpCostos.Controls.Add(this.lblLeyendaCostos);
            this.tbpCostos.Controls.Add(this.txtLeyendaTardanzaNormal);
            this.tbpCostos.Controls.Add(this.txtLeyendaAsistenciaFeriado);
            this.tbpCostos.Controls.Add(this.txtLeyendaAsistenciaNormal);
            this.tbpCostos.Controls.Add(this.cboCostoPor);
            this.tbpCostos.Controls.Add(this.lblCostoPor);
            this.tbpCostos.Controls.Add(this.txtRegistrosCostos);
            this.tbpCostos.Controls.Add(this.lblRegistrosCostos);
            this.tbpCostos.Controls.Add(this.dgvCostos);
            this.tbpCostos.Location = new System.Drawing.Point(4, 22);
            this.tbpCostos.Name = "tbpCostos";
            this.tbpCostos.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCostos.Size = new System.Drawing.Size(902, 293);
            this.tbpCostos.TabIndex = 2;
            this.tbpCostos.Text = "Costos por Candidato";
            this.tbpCostos.UseVisualStyleBackColor = true;
            // 
            // btnExportarCostoCsv
            // 
            this.btnExportarCostoCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarCostoCsv.Location = new System.Drawing.Point(785, 187);
            this.btnExportarCostoCsv.Name = "btnExportarCostoCsv";
            this.btnExportarCostoCsv.Size = new System.Drawing.Size(111, 21);
            this.btnExportarCostoCsv.TabIndex = 129;
            this.btnExportarCostoCsv.Text = "Exportar CSV";
            this.btnExportarCostoCsv.UseVisualStyleBackColor = true;
            this.btnExportarCostoCsv.Click += new System.EventHandler(this.btnExportarCostoCsv_Click);
            // 
            // lblLeyendaDescuentos
            // 
            this.lblLeyendaDescuentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeyendaDescuentos.AutoSize = true;
            this.lblLeyendaDescuentos.Location = new System.Drawing.Point(785, 78);
            this.lblLeyendaDescuentos.Name = "lblLeyendaDescuentos";
            this.lblLeyendaDescuentos.Size = new System.Drawing.Size(114, 13);
            this.lblLeyendaDescuentos.TabIndex = 128;
            this.lblLeyendaDescuentos.Text = "Leyenda Descuentos :";
            // 
            // txtLeyendaTardanzaFeriado
            // 
            this.txtLeyendaTardanzaFeriado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeyendaTardanzaFeriado.BackColor = System.Drawing.Color.Yellow;
            this.txtLeyendaTardanzaFeriado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeyendaTardanzaFeriado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeyendaTardanzaFeriado.Location = new System.Drawing.Point(785, 120);
            this.txtLeyendaTardanzaFeriado.Name = "txtLeyendaTardanzaFeriado";
            this.txtLeyendaTardanzaFeriado.Size = new System.Drawing.Size(111, 20);
            this.txtLeyendaTardanzaFeriado.TabIndex = 127;
            this.txtLeyendaTardanzaFeriado.Text = "Tardanza Feriado";
            this.txtLeyendaTardanzaFeriado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeyendaInasistencia
            // 
            this.txtLeyendaInasistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeyendaInasistencia.BackColor = System.Drawing.Color.Red;
            this.txtLeyendaInasistencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeyendaInasistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeyendaInasistencia.Location = new System.Drawing.Point(785, 146);
            this.txtLeyendaInasistencia.Name = "txtLeyendaInasistencia";
            this.txtLeyendaInasistencia.Size = new System.Drawing.Size(111, 20);
            this.txtLeyendaInasistencia.TabIndex = 126;
            this.txtLeyendaInasistencia.Text = "Inasistencia";
            this.txtLeyendaInasistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLeyendaCostos
            // 
            this.lblLeyendaCostos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeyendaCostos.AutoSize = true;
            this.lblLeyendaCostos.Location = new System.Drawing.Point(785, 6);
            this.lblLeyendaCostos.Name = "lblLeyendaCostos";
            this.lblLeyendaCostos.Size = new System.Drawing.Size(89, 13);
            this.lblLeyendaCostos.TabIndex = 125;
            this.lblLeyendaCostos.Text = "Leyenda Costos :";
            // 
            // txtLeyendaTardanzaNormal
            // 
            this.txtLeyendaTardanzaNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeyendaTardanzaNormal.BackColor = System.Drawing.Color.Green;
            this.txtLeyendaTardanzaNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeyendaTardanzaNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeyendaTardanzaNormal.Location = new System.Drawing.Point(785, 94);
            this.txtLeyendaTardanzaNormal.Name = "txtLeyendaTardanzaNormal";
            this.txtLeyendaTardanzaNormal.Size = new System.Drawing.Size(111, 20);
            this.txtLeyendaTardanzaNormal.TabIndex = 124;
            this.txtLeyendaTardanzaNormal.Text = "Tardanza Normal";
            this.txtLeyendaTardanzaNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeyendaAsistenciaFeriado
            // 
            this.txtLeyendaAsistenciaFeriado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeyendaAsistenciaFeriado.BackColor = System.Drawing.Color.LightYellow;
            this.txtLeyendaAsistenciaFeriado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeyendaAsistenciaFeriado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeyendaAsistenciaFeriado.Location = new System.Drawing.Point(785, 48);
            this.txtLeyendaAsistenciaFeriado.Name = "txtLeyendaAsistenciaFeriado";
            this.txtLeyendaAsistenciaFeriado.Size = new System.Drawing.Size(111, 20);
            this.txtLeyendaAsistenciaFeriado.TabIndex = 123;
            this.txtLeyendaAsistenciaFeriado.Text = "Asistencia Feriado";
            this.txtLeyendaAsistenciaFeriado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeyendaAsistenciaNormal
            // 
            this.txtLeyendaAsistenciaNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeyendaAsistenciaNormal.BackColor = System.Drawing.Color.LightGreen;
            this.txtLeyendaAsistenciaNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeyendaAsistenciaNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeyendaAsistenciaNormal.Location = new System.Drawing.Point(785, 22);
            this.txtLeyendaAsistenciaNormal.Name = "txtLeyendaAsistenciaNormal";
            this.txtLeyendaAsistenciaNormal.Size = new System.Drawing.Size(111, 20);
            this.txtLeyendaAsistenciaNormal.TabIndex = 122;
            this.txtLeyendaAsistenciaNormal.Text = "Asistencia Normal";
            this.txtLeyendaAsistenciaNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboCostoPor
            // 
            this.cboCostoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCostoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCostoPor.FormattingEnabled = true;
            this.cboCostoPor.Location = new System.Drawing.Point(785, 227);
            this.cboCostoPor.Name = "cboCostoPor";
            this.cboCostoPor.Size = new System.Drawing.Size(111, 21);
            this.cboCostoPor.TabIndex = 120;
            this.cboCostoPor.SelectionChangeCommitted += new System.EventHandler(this.cboCostoPor_SelectionChangeCommitted);
            // 
            // lblCostoPor
            // 
            this.lblCostoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCostoPor.AutoSize = true;
            this.lblCostoPor.Location = new System.Drawing.Point(786, 211);
            this.lblCostoPor.Name = "lblCostoPor";
            this.lblCostoPor.Size = new System.Drawing.Size(58, 13);
            this.lblCostoPor.TabIndex = 118;
            this.lblCostoPor.Text = "Costo por :";
            // 
            // txtRegistrosCostos
            // 
            this.txtRegistrosCostos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistrosCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistrosCostos.Location = new System.Drawing.Point(785, 267);
            this.txtRegistrosCostos.Name = "txtRegistrosCostos";
            this.txtRegistrosCostos.Size = new System.Drawing.Size(111, 20);
            this.txtRegistrosCostos.TabIndex = 121;
            this.txtRegistrosCostos.Text = "0";
            this.txtRegistrosCostos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRegistrosCostos
            // 
            this.lblRegistrosCostos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistrosCostos.AutoSize = true;
            this.lblRegistrosCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosCostos.Location = new System.Drawing.Point(785, 251);
            this.lblRegistrosCostos.Name = "lblRegistrosCostos";
            this.lblRegistrosCostos.Size = new System.Drawing.Size(57, 13);
            this.lblRegistrosCostos.TabIndex = 119;
            this.lblRegistrosCostos.Text = "Registros :";
            // 
            // dgvCostos
            // 
            this.dgvCostos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostos.Location = new System.Drawing.Point(6, 6);
            this.dgvCostos.Name = "dgvCostos";
            this.dgvCostos.Size = new System.Drawing.Size(773, 281);
            this.dgvCostos.TabIndex = 105;
            // 
            // tbpSueldos
            // 
            this.tbpSueldos.Controls.Add(this.dgvSueldos);
            this.tbpSueldos.Controls.Add(this.txtTotalSueldos);
            this.tbpSueldos.Controls.Add(this.label4);
            this.tbpSueldos.Controls.Add(this.txtNroSueldos);
            this.tbpSueldos.Controls.Add(this.lblRegistrosAsistencias);
            this.tbpSueldos.Location = new System.Drawing.Point(4, 22);
            this.tbpSueldos.Name = "tbpSueldos";
            this.tbpSueldos.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSueldos.Size = new System.Drawing.Size(902, 293);
            this.tbpSueldos.TabIndex = 0;
            this.tbpSueldos.Text = "Calculos de Sueldos";
            this.tbpSueldos.UseVisualStyleBackColor = true;
            // 
            // dgvSueldos
            // 
            this.dgvSueldos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSueldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSueldos.Location = new System.Drawing.Point(6, 6);
            this.dgvSueldos.Name = "dgvSueldos";
            this.dgvSueldos.Size = new System.Drawing.Size(890, 254);
            this.dgvSueldos.TabIndex = 0;
            // 
            // txtTotalSueldos
            // 
            this.txtTotalSueldos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalSueldos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSueldos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSueldos.Location = new System.Drawing.Point(798, 266);
            this.txtTotalSueldos.Name = "txtTotalSueldos";
            this.txtTotalSueldos.ReadOnly = true;
            this.txtTotalSueldos.Size = new System.Drawing.Size(98, 20);
            this.txtTotalSueldos.TabIndex = 109;
            this.txtTotalSueldos.Text = "0.00";
            this.txtTotalSueldos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(755, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 108;
            this.label4.Text = "Total :";
            // 
            // txtNroSueldos
            // 
            this.txtNroSueldos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNroSueldos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroSueldos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroSueldos.Location = new System.Drawing.Point(95, 265);
            this.txtNroSueldos.Name = "txtNroSueldos";
            this.txtNroSueldos.ReadOnly = true;
            this.txtNroSueldos.Size = new System.Drawing.Size(41, 20);
            this.txtNroSueldos.TabIndex = 104;
            this.txtNroSueldos.Text = "0";
            this.txtNroSueldos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRegistrosAsistencias
            // 
            this.lblRegistrosAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegistrosAsistencias.AutoSize = true;
            this.lblRegistrosAsistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosAsistencias.Location = new System.Drawing.Point(3, 268);
            this.lblRegistrosAsistencias.Name = "lblRegistrosAsistencias";
            this.lblRegistrosAsistencias.Size = new System.Drawing.Size(80, 13);
            this.lblRegistrosAsistencias.TabIndex = 103;
            this.lblRegistrosAsistencias.Text = "Nro. Registros :";
            // 
            // txtAnho
            // 
            this.txtAnho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnho.Location = new System.Drawing.Point(78, 344);
            this.txtAnho.Name = "txtAnho";
            this.txtAnho.ReadOnly = true;
            this.txtAnho.Size = new System.Drawing.Size(86, 20);
            this.txtAnho.TabIndex = 105;
            this.txtAnho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Año y Mes :";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(816, 344);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 31);
            this.btnGuardar.TabIndex = 102;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmAsignarSueldoCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 489);
            this.Controls.Add(this.tlpPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmAsignarSueldoCalc";
            this.Text = "Calcular Sueldos de Candidatos";
            this.Load += new System.EventHandler(this.FrmAsignarSueldoCalc_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlFiltro.ResumeLayout(false);
            this.grpCalcular.ResumeLayout(false);
            this.grpCalcular.PerformLayout();
            this.pnlCalculo.ResumeLayout(false);
            this.grpBonificaciones.ResumeLayout(false);
            this.grpBonificaciones.PerformLayout();
            this.tbcCalculo.ResumeLayout(false);
            this.tbpAsistenciasDetalle.ResumeLayout(false);
            this.tbpAsistenciasDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciasDetalle)).EndInit();
            this.tbpAsistenciasResumen.ResumeLayout(false);
            this.tbpAsistenciasResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciasResumen)).EndInit();
            this.tbpCostos.ResumeLayout(false);
            this.tbpCostos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).EndInit();
            this.tbpSueldos.ResumeLayout(false);
            this.tbpSueldos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSueldos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAnho;
        internal System.Windows.Forms.Label LblFechaHora;
        private System.Windows.Forms.GroupBox grpBonificaciones;
        private System.Windows.Forms.DataGridView dgvSueldos;
        private System.Windows.Forms.GroupBox grpCalcular;
        public System.Windows.Forms.Button btnCalcular;
        public System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNroSueldos;
        internal System.Windows.Forms.Label lblRegistrosAsistencias;
        private System.Windows.Forms.TextBox txtAnho;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlCalculo;
        private System.Windows.Forms.TextBox txtTotalSueldos;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tbcCalculo;
        private System.Windows.Forms.TabPage tbpSueldos;
        private System.Windows.Forms.TabPage tbpAsistenciasDetalle;
        private System.Windows.Forms.DataGridView dgvAsistenciasDetalle;
        private System.Windows.Forms.TabPage tbpCostos;
        private System.Windows.Forms.DataGridView dgvCostos;
        private System.Windows.Forms.TextBox txtMes;
        public System.Windows.Forms.Button btnExportarCostoCsv;
        internal System.Windows.Forms.Label lblLeyendaDescuentos;
        private System.Windows.Forms.TextBox txtLeyendaTardanzaFeriado;
        private System.Windows.Forms.TextBox txtLeyendaInasistencia;
        internal System.Windows.Forms.Label lblLeyendaCostos;
        private System.Windows.Forms.TextBox txtLeyendaTardanzaNormal;
        private System.Windows.Forms.TextBox txtLeyendaAsistenciaFeriado;
        private System.Windows.Forms.TextBox txtLeyendaAsistenciaNormal;
        private System.Windows.Forms.ComboBox cboCostoPor;
        internal System.Windows.Forms.Label lblCostoPor;
        private System.Windows.Forms.TextBox txtRegistrosCostos;
        internal System.Windows.Forms.Label lblRegistrosCostos;
        public System.Windows.Forms.Button btnExportarAsistenciasCsv;
        internal System.Windows.Forms.Label lblLeyendaAsistenciaResumen;
        private System.Windows.Forms.TextBox txtInasistencia;
        private System.Windows.Forms.TextBox txtAsistenciaFeriado;
        private System.Windows.Forms.TextBox txtAsistenciaNormal;
        private System.Windows.Forms.ComboBox cboAsistenciaPor;
        internal System.Windows.Forms.Label lblCalculoPor;
        private System.Windows.Forms.TextBox txtRegistrosAsistencias;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbpAsistenciasResumen;
        public System.Windows.Forms.Button btnExportarAsistenciasResumenCsv;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInasistenciaResumen;
        private System.Windows.Forms.TextBox txtAsistenciaResumenFeriado;
        private System.Windows.Forms.TextBox txtAsistenciaResumenNormal;
        private System.Windows.Forms.ComboBox cboAsistenciaResumenPor;
        internal System.Windows.Forms.Label lblCalculoResumenPor;
        private System.Windows.Forms.TextBox txtRegistrosAsistenciasResumen;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvAsistenciasResumen;
    }
}