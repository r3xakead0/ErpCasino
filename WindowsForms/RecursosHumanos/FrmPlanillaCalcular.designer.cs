namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmPlanillaCalcular
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
            this.tbcPlanilla = new System.Windows.Forms.TabControl();
            this.tbpAsistencias = new System.Windows.Forms.TabPage();
            this.btnExportarAsistenciasCsv = new System.Windows.Forms.Button();
            this.lblLeyendaAsistencia = new System.Windows.Forms.Label();
            this.txtInasistencia = new System.Windows.Forms.TextBox();
            this.txtAsistenciaFeriado = new System.Windows.Forms.TextBox();
            this.txtAsistenciaNormal = new System.Windows.Forms.TextBox();
            this.cboCalculoPor = new System.Windows.Forms.ComboBox();
            this.lblCalculoPor = new System.Windows.Forms.Label();
            this.txtRegistrosAsistencias = new System.Windows.Forms.TextBox();
            this.lblRegistrosAsistencias = new System.Windows.Forms.Label();
            this.dgvAsistencias = new System.Windows.Forms.DataGridView();
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
            this.grpPeriodo = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.tbcPlanilla.SuspendLayout();
            this.tbpAsistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).BeginInit();
            this.tbpCostos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).BeginInit();
            this.grpPeriodo.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlPrincipal, 0, 0);
            this.tlpPrincipal.Controls.Add(this.pnlBotones, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPrincipal.Size = new System.Drawing.Size(986, 462);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.tbcPlanilla);
            this.pnlPrincipal.Controls.Add(this.grpPeriodo);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(980, 406);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // tbcPlanilla
            // 
            this.tbcPlanilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcPlanilla.Controls.Add(this.tbpAsistencias);
            this.tbcPlanilla.Controls.Add(this.tbpCostos);
            this.tbcPlanilla.Location = new System.Drawing.Point(9, 56);
            this.tbcPlanilla.Name = "tbcPlanilla";
            this.tbcPlanilla.SelectedIndex = 0;
            this.tbcPlanilla.Size = new System.Drawing.Size(964, 347);
            this.tbcPlanilla.TabIndex = 41;
            // 
            // tbpAsistencias
            // 
            this.tbpAsistencias.Controls.Add(this.btnExportarAsistenciasCsv);
            this.tbpAsistencias.Controls.Add(this.lblLeyendaAsistencia);
            this.tbpAsistencias.Controls.Add(this.txtInasistencia);
            this.tbpAsistencias.Controls.Add(this.txtAsistenciaFeriado);
            this.tbpAsistencias.Controls.Add(this.txtAsistenciaNormal);
            this.tbpAsistencias.Controls.Add(this.cboCalculoPor);
            this.tbpAsistencias.Controls.Add(this.lblCalculoPor);
            this.tbpAsistencias.Controls.Add(this.txtRegistrosAsistencias);
            this.tbpAsistencias.Controls.Add(this.lblRegistrosAsistencias);
            this.tbpAsistencias.Controls.Add(this.dgvAsistencias);
            this.tbpAsistencias.Location = new System.Drawing.Point(4, 22);
            this.tbpAsistencias.Name = "tbpAsistencias";
            this.tbpAsistencias.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAsistencias.Size = new System.Drawing.Size(956, 321);
            this.tbpAsistencias.TabIndex = 0;
            this.tbpAsistencias.Text = "Asistencias";
            this.tbpAsistencias.UseVisualStyleBackColor = true;
            // 
            // btnExportarAsistenciasCsv
            // 
            this.btnExportarAsistenciasCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarAsistenciasCsv.Location = new System.Drawing.Point(839, 215);
            this.btnExportarAsistenciasCsv.Name = "btnExportarAsistenciasCsv";
            this.btnExportarAsistenciasCsv.Size = new System.Drawing.Size(111, 21);
            this.btnExportarAsistenciasCsv.TabIndex = 91;
            this.btnExportarAsistenciasCsv.Text = "Exportar CSV";
            this.btnExportarAsistenciasCsv.UseVisualStyleBackColor = true;
            this.btnExportarAsistenciasCsv.Click += new System.EventHandler(this.btnExportarAsistenciasCsv_Click);
            // 
            // lblLeyendaAsistencia
            // 
            this.lblLeyendaAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeyendaAsistencia.AutoSize = true;
            this.lblLeyendaAsistencia.Location = new System.Drawing.Point(839, 6);
            this.lblLeyendaAsistencia.Name = "lblLeyendaAsistencia";
            this.lblLeyendaAsistencia.Size = new System.Drawing.Size(54, 13);
            this.lblLeyendaAsistencia.TabIndex = 60;
            this.lblLeyendaAsistencia.Text = "Leyenda :";
            // 
            // txtInasistencia
            // 
            this.txtInasistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInasistencia.BackColor = System.Drawing.Color.Red;
            this.txtInasistencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInasistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInasistencia.Location = new System.Drawing.Point(839, 74);
            this.txtInasistencia.Name = "txtInasistencia";
            this.txtInasistencia.Size = new System.Drawing.Size(111, 20);
            this.txtInasistencia.TabIndex = 59;
            this.txtInasistencia.Text = "Inasistencia";
            this.txtInasistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAsistenciaFeriado
            // 
            this.txtAsistenciaFeriado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsistenciaFeriado.BackColor = System.Drawing.Color.LightYellow;
            this.txtAsistenciaFeriado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAsistenciaFeriado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsistenciaFeriado.Location = new System.Drawing.Point(839, 48);
            this.txtAsistenciaFeriado.Name = "txtAsistenciaFeriado";
            this.txtAsistenciaFeriado.Size = new System.Drawing.Size(111, 20);
            this.txtAsistenciaFeriado.TabIndex = 58;
            this.txtAsistenciaFeriado.Text = "Asistencia Feriado";
            this.txtAsistenciaFeriado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAsistenciaNormal
            // 
            this.txtAsistenciaNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsistenciaNormal.BackColor = System.Drawing.Color.LightGreen;
            this.txtAsistenciaNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAsistenciaNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsistenciaNormal.Location = new System.Drawing.Point(839, 22);
            this.txtAsistenciaNormal.Name = "txtAsistenciaNormal";
            this.txtAsistenciaNormal.Size = new System.Drawing.Size(111, 20);
            this.txtAsistenciaNormal.TabIndex = 57;
            this.txtAsistenciaNormal.Text = "Asistencia Normal";
            this.txtAsistenciaNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboCalculoPor
            // 
            this.cboCalculoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCalculoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalculoPor.FormattingEnabled = true;
            this.cboCalculoPor.Location = new System.Drawing.Point(839, 255);
            this.cboCalculoPor.Name = "cboCalculoPor";
            this.cboCalculoPor.Size = new System.Drawing.Size(111, 21);
            this.cboCalculoPor.TabIndex = 55;
            this.cboCalculoPor.SelectionChangeCommitted += new System.EventHandler(this.cboCalculoPor_SelectionChangeCommitted);
            // 
            // lblCalculoPor
            // 
            this.lblCalculoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCalculoPor.AutoSize = true;
            this.lblCalculoPor.Location = new System.Drawing.Point(839, 239);
            this.lblCalculoPor.Name = "lblCalculoPor";
            this.lblCalculoPor.Size = new System.Drawing.Size(66, 13);
            this.lblCalculoPor.TabIndex = 53;
            this.lblCalculoPor.Text = "Calculo por :";
            // 
            // txtRegistrosAsistencias
            // 
            this.txtRegistrosAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistrosAsistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistrosAsistencias.Location = new System.Drawing.Point(839, 295);
            this.txtRegistrosAsistencias.Name = "txtRegistrosAsistencias";
            this.txtRegistrosAsistencias.Size = new System.Drawing.Size(111, 20);
            this.txtRegistrosAsistencias.TabIndex = 56;
            this.txtRegistrosAsistencias.Text = "0";
            this.txtRegistrosAsistencias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRegistrosAsistencias
            // 
            this.lblRegistrosAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistrosAsistencias.AutoSize = true;
            this.lblRegistrosAsistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosAsistencias.Location = new System.Drawing.Point(839, 279);
            this.lblRegistrosAsistencias.Name = "lblRegistrosAsistencias";
            this.lblRegistrosAsistencias.Size = new System.Drawing.Size(57, 13);
            this.lblRegistrosAsistencias.TabIndex = 54;
            this.lblRegistrosAsistencias.Text = "Registros :";
            // 
            // dgvAsistencias
            // 
            this.dgvAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencias.Location = new System.Drawing.Point(6, 6);
            this.dgvAsistencias.Name = "dgvAsistencias";
            this.dgvAsistencias.Size = new System.Drawing.Size(827, 309);
            this.dgvAsistencias.TabIndex = 40;
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
            this.tbpCostos.Size = new System.Drawing.Size(956, 321);
            this.tbpCostos.TabIndex = 1;
            this.tbpCostos.Text = "Costos";
            this.tbpCostos.UseVisualStyleBackColor = true;
            // 
            // btnExportarCostoCsv
            // 
            this.btnExportarCostoCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarCostoCsv.Location = new System.Drawing.Point(838, 205);
            this.btnExportarCostoCsv.Name = "btnExportarCostoCsv";
            this.btnExportarCostoCsv.Size = new System.Drawing.Size(111, 21);
            this.btnExportarCostoCsv.TabIndex = 90;
            this.btnExportarCostoCsv.Text = "Exportar CSV";
            this.btnExportarCostoCsv.UseVisualStyleBackColor = true;
            this.btnExportarCostoCsv.Click += new System.EventHandler(this.btnExportarCostoCsv_Click);
            // 
            // lblLeyendaDescuentos
            // 
            this.lblLeyendaDescuentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeyendaDescuentos.AutoSize = true;
            this.lblLeyendaDescuentos.Location = new System.Drawing.Point(838, 78);
            this.lblLeyendaDescuentos.Name = "lblLeyendaDescuentos";
            this.lblLeyendaDescuentos.Size = new System.Drawing.Size(114, 13);
            this.lblLeyendaDescuentos.TabIndex = 67;
            this.lblLeyendaDescuentos.Text = "Leyenda Descuentos :";
            // 
            // txtLeyendaTardanzaFeriado
            // 
            this.txtLeyendaTardanzaFeriado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeyendaTardanzaFeriado.BackColor = System.Drawing.Color.Yellow;
            this.txtLeyendaTardanzaFeriado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeyendaTardanzaFeriado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeyendaTardanzaFeriado.Location = new System.Drawing.Point(838, 120);
            this.txtLeyendaTardanzaFeriado.Name = "txtLeyendaTardanzaFeriado";
            this.txtLeyendaTardanzaFeriado.Size = new System.Drawing.Size(111, 20);
            this.txtLeyendaTardanzaFeriado.TabIndex = 66;
            this.txtLeyendaTardanzaFeriado.Text = "Tardanza Feriado";
            this.txtLeyendaTardanzaFeriado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeyendaInasistencia
            // 
            this.txtLeyendaInasistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeyendaInasistencia.BackColor = System.Drawing.Color.Red;
            this.txtLeyendaInasistencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeyendaInasistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeyendaInasistencia.Location = new System.Drawing.Point(838, 146);
            this.txtLeyendaInasistencia.Name = "txtLeyendaInasistencia";
            this.txtLeyendaInasistencia.Size = new System.Drawing.Size(111, 20);
            this.txtLeyendaInasistencia.TabIndex = 65;
            this.txtLeyendaInasistencia.Text = "Inasistencia";
            this.txtLeyendaInasistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLeyendaCostos
            // 
            this.lblLeyendaCostos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeyendaCostos.AutoSize = true;
            this.lblLeyendaCostos.Location = new System.Drawing.Point(838, 6);
            this.lblLeyendaCostos.Name = "lblLeyendaCostos";
            this.lblLeyendaCostos.Size = new System.Drawing.Size(89, 13);
            this.lblLeyendaCostos.TabIndex = 64;
            this.lblLeyendaCostos.Text = "Leyenda Costos :";
            // 
            // txtLeyendaTardanzaNormal
            // 
            this.txtLeyendaTardanzaNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeyendaTardanzaNormal.BackColor = System.Drawing.Color.Green;
            this.txtLeyendaTardanzaNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeyendaTardanzaNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeyendaTardanzaNormal.Location = new System.Drawing.Point(838, 94);
            this.txtLeyendaTardanzaNormal.Name = "txtLeyendaTardanzaNormal";
            this.txtLeyendaTardanzaNormal.Size = new System.Drawing.Size(111, 20);
            this.txtLeyendaTardanzaNormal.TabIndex = 63;
            this.txtLeyendaTardanzaNormal.Text = "Tardanza Normal";
            this.txtLeyendaTardanzaNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeyendaAsistenciaFeriado
            // 
            this.txtLeyendaAsistenciaFeriado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeyendaAsistenciaFeriado.BackColor = System.Drawing.Color.LightYellow;
            this.txtLeyendaAsistenciaFeriado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeyendaAsistenciaFeriado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeyendaAsistenciaFeriado.Location = new System.Drawing.Point(838, 48);
            this.txtLeyendaAsistenciaFeriado.Name = "txtLeyendaAsistenciaFeriado";
            this.txtLeyendaAsistenciaFeriado.Size = new System.Drawing.Size(111, 20);
            this.txtLeyendaAsistenciaFeriado.TabIndex = 62;
            this.txtLeyendaAsistenciaFeriado.Text = "Asistencia Feriado";
            this.txtLeyendaAsistenciaFeriado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeyendaAsistenciaNormal
            // 
            this.txtLeyendaAsistenciaNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeyendaAsistenciaNormal.BackColor = System.Drawing.Color.LightGreen;
            this.txtLeyendaAsistenciaNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeyendaAsistenciaNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeyendaAsistenciaNormal.Location = new System.Drawing.Point(838, 22);
            this.txtLeyendaAsistenciaNormal.Name = "txtLeyendaAsistenciaNormal";
            this.txtLeyendaAsistenciaNormal.Size = new System.Drawing.Size(111, 20);
            this.txtLeyendaAsistenciaNormal.TabIndex = 61;
            this.txtLeyendaAsistenciaNormal.Text = "Asistencia Normal";
            this.txtLeyendaAsistenciaNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboCostoPor
            // 
            this.cboCostoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCostoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCostoPor.FormattingEnabled = true;
            this.cboCostoPor.Location = new System.Drawing.Point(838, 245);
            this.cboCostoPor.Name = "cboCostoPor";
            this.cboCostoPor.Size = new System.Drawing.Size(111, 21);
            this.cboCostoPor.TabIndex = 52;
            this.cboCostoPor.SelectionChangeCommitted += new System.EventHandler(this.cboCostoPor_SelectionChangeCommitted);
            // 
            // lblCostoPor
            // 
            this.lblCostoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCostoPor.AutoSize = true;
            this.lblCostoPor.Location = new System.Drawing.Point(839, 229);
            this.lblCostoPor.Name = "lblCostoPor";
            this.lblCostoPor.Size = new System.Drawing.Size(58, 13);
            this.lblCostoPor.TabIndex = 51;
            this.lblCostoPor.Text = "Costo por :";
            // 
            // txtRegistrosCostos
            // 
            this.txtRegistrosCostos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistrosCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistrosCostos.Location = new System.Drawing.Point(838, 285);
            this.txtRegistrosCostos.Name = "txtRegistrosCostos";
            this.txtRegistrosCostos.Size = new System.Drawing.Size(111, 20);
            this.txtRegistrosCostos.TabIndex = 52;
            this.txtRegistrosCostos.Text = "0";
            this.txtRegistrosCostos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRegistrosCostos
            // 
            this.lblRegistrosCostos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistrosCostos.AutoSize = true;
            this.lblRegistrosCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosCostos.Location = new System.Drawing.Point(838, 269);
            this.lblRegistrosCostos.Name = "lblRegistrosCostos";
            this.lblRegistrosCostos.Size = new System.Drawing.Size(57, 13);
            this.lblRegistrosCostos.TabIndex = 51;
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
            this.dgvCostos.Size = new System.Drawing.Size(826, 299);
            this.dgvCostos.TabIndex = 41;
            // 
            // grpPeriodo
            // 
            this.grpPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPeriodo.Controls.Add(this.btnBuscar);
            this.grpPeriodo.Controls.Add(this.cboMes);
            this.grpPeriodo.Controls.Add(this.cboAnho);
            this.grpPeriodo.Controls.Add(this.lblFechaHora);
            this.grpPeriodo.Location = new System.Drawing.Point(9, 3);
            this.grpPeriodo.Name = "grpPeriodo";
            this.grpPeriodo.Size = new System.Drawing.Size(960, 47);
            this.grpPeriodo.TabIndex = 39;
            this.grpPeriodo.TabStop = false;
            this.grpPeriodo.Text = "Periodo";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(854, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 19;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(154, 17);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(241, 21);
            this.cboMes.TabIndex = 50;
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(76, 17);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(72, 21);
            this.cboAnho.TabIndex = 49;
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.Location = new System.Drawing.Point(6, 20);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(63, 13);
            this.lblFechaHora.TabIndex = 18;
            this.lblFechaHora.Text = "Año y Mes :";
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnGenerar);
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotones.Location = new System.Drawing.Point(3, 415);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(980, 44);
            this.pnlBotones.TabIndex = 17;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerar.Location = new System.Drawing.Point(871, 5);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(100, 30);
            this.btnGenerar.TabIndex = 17;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(765, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmPlanillaCalcular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 462);
            this.Controls.Add(this.tlpPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmPlanillaCalcular";
            this.Text = "Calcular Planilla";
            this.Load += new System.EventHandler(this.FrmPlanillaCalcular_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.tbcPlanilla.ResumeLayout(false);
            this.tbpAsistencias.ResumeLayout(false);
            this.tbpAsistencias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).EndInit();
            this.tbpCostos.ResumeLayout(false);
            this.tbpCostos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).EndInit();
            this.grpPeriodo.ResumeLayout(false);
            this.grpPeriodo.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        internal System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Panel pnlBotones;
        public System.Windows.Forms.Button btnGenerar;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpPeriodo;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAnho;
        private System.Windows.Forms.DataGridView dgvAsistencias;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TabControl tbcPlanilla;
        private System.Windows.Forms.TabPage tbpAsistencias;
        private System.Windows.Forms.TabPage tbpCostos;
        private System.Windows.Forms.DataGridView dgvCostos;
        internal System.Windows.Forms.Label lblRegistrosCostos;
        private System.Windows.Forms.TextBox txtRegistrosCostos;
        private System.Windows.Forms.ComboBox cboCostoPor;
        internal System.Windows.Forms.Label lblCostoPor;
        private System.Windows.Forms.ComboBox cboCalculoPor;
        internal System.Windows.Forms.Label lblCalculoPor;
        private System.Windows.Forms.TextBox txtRegistrosAsistencias;
        internal System.Windows.Forms.Label lblRegistrosAsistencias;
        internal System.Windows.Forms.Label lblLeyendaAsistencia;
        private System.Windows.Forms.TextBox txtInasistencia;
        private System.Windows.Forms.TextBox txtAsistenciaFeriado;
        private System.Windows.Forms.TextBox txtAsistenciaNormal;
        internal System.Windows.Forms.Label lblLeyendaCostos;
        private System.Windows.Forms.TextBox txtLeyendaTardanzaNormal;
        private System.Windows.Forms.TextBox txtLeyendaAsistenciaFeriado;
        private System.Windows.Forms.TextBox txtLeyendaAsistenciaNormal;
        private System.Windows.Forms.TextBox txtLeyendaTardanzaFeriado;
        private System.Windows.Forms.TextBox txtLeyendaInasistencia;
        internal System.Windows.Forms.Label lblLeyendaDescuentos;
        public System.Windows.Forms.Button btnExportarAsistenciasCsv;
        public System.Windows.Forms.Button btnExportarCostoCsv;
    }
}