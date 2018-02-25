namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmPlanillaRevisar
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanillaRevisar));
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.tbcPlanilla = new System.Windows.Forms.TabControl();
            this.tbpResumen = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAnho = new System.Windows.Forms.TextBox();
            this.lblAnho = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.lblDias = new System.Windows.Forms.Label();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.grpGrafica = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpIndicador = new System.Windows.Forms.GroupBox();
            this.grpParametros = new System.Windows.Forms.GroupBox();
            this.txtSueldoMinimo = new System.Windows.Forms.TextBox();
            this.lblEsSalud = new System.Windows.Forms.Label();
            this.txtEsSalud = new System.Windows.Forms.TextBox();
            this.lblAsignacionFamiliar = new System.Windows.Forms.Label();
            this.txtAsignacionFamiliar = new System.Windows.Forms.TextBox();
            this.lblSueldoMinimo = new System.Windows.Forms.Label();
            this.txtPrimerasHorasExtras = new System.Windows.Forms.TextBox();
            this.lblPrimerasHorasExtras = new System.Windows.Forms.Label();
            this.lblPosterioresHorasExtras = new System.Windows.Forms.Label();
            this.txtPosterioresHorasExtras = new System.Windows.Forms.TextBox();
            this.lblHorarioNocturno = new System.Windows.Forms.Label();
            this.txtHorarioNocturno = new System.Windows.Forms.TextBox();
            this.grpTotales = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCantidadEmpleados = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalAfp = new System.Windows.Forms.TextBox();
            this.txtTotalSueldos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalOnp = new System.Windows.Forms.TextBox();
            this.txtTotalPagos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalEssalud = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbpDetalle = new System.Windows.Forms.TabPage();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.btnBoleta = new System.Windows.Forms.Button();
            this.txtEmpleadoCodigo = new System.Windows.Forms.TextBox();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCalculoPor = new System.Windows.Forms.ComboBox();
            this.lblCalculoPor = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.dgvPlanilla = new System.Windows.Forms.DataGridView();
            this.grpFiltro = new System.Windows.Forms.GroupBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.CbxMes = new System.Windows.Forms.ComboBox();
            this.CboAnho = new System.Windows.Forms.ComboBox();
            this.LblFechaHora = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.tbcPlanilla.SuspendLayout();
            this.tbpResumen.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpGrafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.grpParametros.SuspendLayout();
            this.grpTotales.SuspendLayout();
            this.tbpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanilla)).BeginInit();
            this.grpFiltro.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlPrincipal, 0, 0);
            this.tlpPrincipal.Controls.Add(this.panel2, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPrincipal.Size = new System.Drawing.Size(970, 511);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.tbcPlanilla);
            this.pnlPrincipal.Controls.Add(this.grpFiltro);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(964, 455);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // tbcPlanilla
            // 
            this.tbcPlanilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcPlanilla.Controls.Add(this.tbpResumen);
            this.tbcPlanilla.Controls.Add(this.tbpDetalle);
            this.tbcPlanilla.Location = new System.Drawing.Point(9, 56);
            this.tbcPlanilla.Name = "tbcPlanilla";
            this.tbcPlanilla.SelectedIndex = 0;
            this.tbcPlanilla.Size = new System.Drawing.Size(948, 393);
            this.tbcPlanilla.TabIndex = 41;
            // 
            // tbpResumen
            // 
            this.tbpResumen.Controls.Add(this.groupBox1);
            this.tbpResumen.Controls.Add(this.grpGrafica);
            this.tbpResumen.Controls.Add(this.grpIndicador);
            this.tbpResumen.Controls.Add(this.grpParametros);
            this.tbpResumen.Controls.Add(this.grpTotales);
            this.tbpResumen.Location = new System.Drawing.Point(4, 22);
            this.tbpResumen.Name = "tbpResumen";
            this.tbpResumen.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResumen.Size = new System.Drawing.Size(940, 367);
            this.tbpResumen.TabIndex = 0;
            this.tbpResumen.Text = "Resumen";
            this.tbpResumen.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAnho);
            this.groupBox1.Controls.Add(this.lblAnho);
            this.groupBox1.Controls.Add(this.lblMes);
            this.groupBox1.Controls.Add(this.txtMes);
            this.groupBox1.Controls.Add(this.lblDias);
            this.groupBox1.Controls.Add(this.txtDias);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 105);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Periodo";
            // 
            // txtAnho
            // 
            this.txtAnho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnho.Location = new System.Drawing.Point(86, 19);
            this.txtAnho.Name = "txtAnho";
            this.txtAnho.Size = new System.Drawing.Size(72, 20);
            this.txtAnho.TabIndex = 52;
            this.txtAnho.Text = "2017";
            this.txtAnho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAnho
            // 
            this.lblAnho.AutoSize = true;
            this.lblAnho.Location = new System.Drawing.Point(21, 22);
            this.lblAnho.Name = "lblAnho";
            this.lblAnho.Size = new System.Drawing.Size(32, 13);
            this.lblAnho.TabIndex = 51;
            this.lblAnho.Text = "Año :";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(21, 48);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(33, 13);
            this.lblMes.TabIndex = 53;
            this.lblMes.Text = "Mes :";
            // 
            // txtMes
            // 
            this.txtMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMes.Location = new System.Drawing.Point(86, 45);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(72, 20);
            this.txtMes.TabIndex = 54;
            this.txtMes.Text = "Mayo";
            this.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Location = new System.Drawing.Point(21, 74);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(36, 13);
            this.lblDias.TabIndex = 55;
            this.lblDias.Text = "Días :";
            // 
            // txtDias
            // 
            this.txtDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDias.Location = new System.Drawing.Point(86, 71);
            this.txtDias.Name = "txtDias";
            this.txtDias.Size = new System.Drawing.Size(72, 20);
            this.txtDias.TabIndex = 56;
            this.txtDias.Text = "31";
            this.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpGrafica
            // 
            this.grpGrafica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGrafica.Controls.Add(this.chart1);
            this.grpGrafica.Location = new System.Drawing.Point(518, 6);
            this.grpGrafica.Name = "grpGrafica";
            this.grpGrafica.Size = new System.Drawing.Size(416, 355);
            this.grpGrafica.TabIndex = 84;
            this.grpGrafica.TabStop = false;
            this.grpGrafica.Text = "Grafica";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 13);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(404, 336);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // grpIndicador
            // 
            this.grpIndicador.Location = new System.Drawing.Point(195, 6);
            this.grpIndicador.Name = "grpIndicador";
            this.grpIndicador.Size = new System.Drawing.Size(317, 105);
            this.grpIndicador.TabIndex = 83;
            this.grpIndicador.TabStop = false;
            // 
            // grpParametros
            // 
            this.grpParametros.Controls.Add(this.txtSueldoMinimo);
            this.grpParametros.Controls.Add(this.lblEsSalud);
            this.grpParametros.Controls.Add(this.txtEsSalud);
            this.grpParametros.Controls.Add(this.lblAsignacionFamiliar);
            this.grpParametros.Controls.Add(this.txtAsignacionFamiliar);
            this.grpParametros.Controls.Add(this.lblSueldoMinimo);
            this.grpParametros.Controls.Add(this.txtPrimerasHorasExtras);
            this.grpParametros.Controls.Add(this.lblPrimerasHorasExtras);
            this.grpParametros.Controls.Add(this.lblPosterioresHorasExtras);
            this.grpParametros.Controls.Add(this.txtPosterioresHorasExtras);
            this.grpParametros.Controls.Add(this.lblHorarioNocturno);
            this.grpParametros.Controls.Add(this.txtHorarioNocturno);
            this.grpParametros.Location = new System.Drawing.Point(6, 117);
            this.grpParametros.Name = "grpParametros";
            this.grpParametros.Size = new System.Drawing.Size(506, 105);
            this.grpParametros.TabIndex = 84;
            this.grpParametros.TabStop = false;
            this.grpParametros.Text = "Parametros";
            // 
            // txtSueldoMinimo
            // 
            this.txtSueldoMinimo.Location = new System.Drawing.Point(161, 19);
            this.txtSueldoMinimo.Name = "txtSueldoMinimo";
            this.txtSueldoMinimo.Size = new System.Drawing.Size(72, 20);
            this.txtSueldoMinimo.TabIndex = 68;
            this.txtSueldoMinimo.Text = "850.00";
            this.txtSueldoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEsSalud
            // 
            this.lblEsSalud.AutoSize = true;
            this.lblEsSalud.Location = new System.Drawing.Point(21, 74);
            this.lblEsSalud.Name = "lblEsSalud";
            this.lblEsSalud.Size = new System.Drawing.Size(52, 13);
            this.lblEsSalud.TabIndex = 57;
            this.lblEsSalud.Text = "EsSalud :";
            // 
            // txtEsSalud
            // 
            this.txtEsSalud.Location = new System.Drawing.Point(161, 71);
            this.txtEsSalud.Name = "txtEsSalud";
            this.txtEsSalud.Size = new System.Drawing.Size(72, 20);
            this.txtEsSalud.TabIndex = 58;
            this.txtEsSalud.Text = "9%";
            this.txtEsSalud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAsignacionFamiliar
            // 
            this.lblAsignacionFamiliar.AutoSize = true;
            this.lblAsignacionFamiliar.Location = new System.Drawing.Point(21, 48);
            this.lblAsignacionFamiliar.Name = "lblAsignacionFamiliar";
            this.lblAsignacionFamiliar.Size = new System.Drawing.Size(103, 13);
            this.lblAsignacionFamiliar.TabIndex = 59;
            this.lblAsignacionFamiliar.Text = "Asignación Familiar :";
            // 
            // txtAsignacionFamiliar
            // 
            this.txtAsignacionFamiliar.Location = new System.Drawing.Point(161, 45);
            this.txtAsignacionFamiliar.Name = "txtAsignacionFamiliar";
            this.txtAsignacionFamiliar.Size = new System.Drawing.Size(72, 20);
            this.txtAsignacionFamiliar.TabIndex = 60;
            this.txtAsignacionFamiliar.Text = "10%";
            this.txtAsignacionFamiliar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSueldoMinimo
            // 
            this.lblSueldoMinimo.AutoSize = true;
            this.lblSueldoMinimo.Location = new System.Drawing.Point(21, 22);
            this.lblSueldoMinimo.Name = "lblSueldoMinimo";
            this.lblSueldoMinimo.Size = new System.Drawing.Size(82, 13);
            this.lblSueldoMinimo.TabIndex = 67;
            this.lblSueldoMinimo.Text = "Sueldo Minimo :";
            // 
            // txtPrimerasHorasExtras
            // 
            this.txtPrimerasHorasExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrimerasHorasExtras.Location = new System.Drawing.Point(409, 22);
            this.txtPrimerasHorasExtras.Name = "txtPrimerasHorasExtras";
            this.txtPrimerasHorasExtras.Size = new System.Drawing.Size(72, 20);
            this.txtPrimerasHorasExtras.TabIndex = 62;
            this.txtPrimerasHorasExtras.Text = "25%";
            this.txtPrimerasHorasExtras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrimerasHorasExtras
            // 
            this.lblPrimerasHorasExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrimerasHorasExtras.AutoSize = true;
            this.lblPrimerasHorasExtras.Location = new System.Drawing.Point(269, 25);
            this.lblPrimerasHorasExtras.Name = "lblPrimerasHorasExtras";
            this.lblPrimerasHorasExtras.Size = new System.Drawing.Size(122, 13);
            this.lblPrimerasHorasExtras.TabIndex = 61;
            this.lblPrimerasHorasExtras.Text = "Primeras 2 Horas Extras:";
            // 
            // lblPosterioresHorasExtras
            // 
            this.lblPosterioresHorasExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosterioresHorasExtras.AutoSize = true;
            this.lblPosterioresHorasExtras.Location = new System.Drawing.Point(269, 51);
            this.lblPosterioresHorasExtras.Name = "lblPosterioresHorasExtras";
            this.lblPosterioresHorasExtras.Size = new System.Drawing.Size(134, 13);
            this.lblPosterioresHorasExtras.TabIndex = 63;
            this.lblPosterioresHorasExtras.Text = "Posteriores 2 Horas Extras:";
            // 
            // txtPosterioresHorasExtras
            // 
            this.txtPosterioresHorasExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPosterioresHorasExtras.Location = new System.Drawing.Point(409, 48);
            this.txtPosterioresHorasExtras.Name = "txtPosterioresHorasExtras";
            this.txtPosterioresHorasExtras.Size = new System.Drawing.Size(72, 20);
            this.txtPosterioresHorasExtras.TabIndex = 64;
            this.txtPosterioresHorasExtras.Text = "35%";
            this.txtPosterioresHorasExtras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHorarioNocturno
            // 
            this.lblHorarioNocturno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorarioNocturno.AutoSize = true;
            this.lblHorarioNocturno.Location = new System.Drawing.Point(269, 77);
            this.lblHorarioNocturno.Name = "lblHorarioNocturno";
            this.lblHorarioNocturno.Size = new System.Drawing.Size(88, 13);
            this.lblHorarioNocturno.TabIndex = 65;
            this.lblHorarioNocturno.Text = "Horario Nocturna";
            // 
            // txtHorarioNocturno
            // 
            this.txtHorarioNocturno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHorarioNocturno.Location = new System.Drawing.Point(409, 74);
            this.txtHorarioNocturno.Name = "txtHorarioNocturno";
            this.txtHorarioNocturno.Size = new System.Drawing.Size(72, 20);
            this.txtHorarioNocturno.TabIndex = 66;
            this.txtHorarioNocturno.Text = "35%";
            this.txtHorarioNocturno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpTotales
            // 
            this.grpTotales.Controls.Add(this.txtTotal);
            this.grpTotales.Controls.Add(this.label7);
            this.grpTotales.Controls.Add(this.txtCantidadEmpleados);
            this.grpTotales.Controls.Add(this.label10);
            this.grpTotales.Controls.Add(this.label1);
            this.grpTotales.Controls.Add(this.txtTotalAfp);
            this.grpTotales.Controls.Add(this.txtTotalSueldos);
            this.grpTotales.Controls.Add(this.label5);
            this.grpTotales.Controls.Add(this.label2);
            this.grpTotales.Controls.Add(this.txtTotalOnp);
            this.grpTotales.Controls.Add(this.txtTotalPagos);
            this.grpTotales.Controls.Add(this.label3);
            this.grpTotales.Controls.Add(this.txtTotalEssalud);
            this.grpTotales.Controls.Add(this.label4);
            this.grpTotales.Location = new System.Drawing.Point(6, 228);
            this.grpTotales.Name = "grpTotales";
            this.grpTotales.Size = new System.Drawing.Size(506, 133);
            this.grpTotales.TabIndex = 83;
            this.grpTotales.TabStop = false;
            this.grpTotales.Text = "Totales";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(409, 97);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(72, 20);
            this.txtTotal.TabIndex = 84;
            this.txtTotal.Text = "100,000.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(269, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 83;
            this.label7.Text = "Total :";
            // 
            // txtCantidadEmpleados
            // 
            this.txtCantidadEmpleados.Location = new System.Drawing.Point(161, 19);
            this.txtCantidadEmpleados.Name = "txtCantidadEmpleados";
            this.txtCantidadEmpleados.Size = new System.Drawing.Size(72, 20);
            this.txtCantidadEmpleados.TabIndex = 70;
            this.txtCantidadEmpleados.Text = "100";
            this.txtCantidadEmpleados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "Cantidad de Empleados :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Total Sueldos :";
            // 
            // txtTotalAfp
            // 
            this.txtTotalAfp.Location = new System.Drawing.Point(409, 71);
            this.txtTotalAfp.Name = "txtTotalAfp";
            this.txtTotalAfp.Size = new System.Drawing.Size(72, 20);
            this.txtTotalAfp.TabIndex = 80;
            this.txtTotalAfp.Text = "100,000.00";
            this.txtTotalAfp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalSueldos
            // 
            this.txtTotalSueldos.Location = new System.Drawing.Point(161, 45);
            this.txtTotalSueldos.Name = "txtTotalSueldos";
            this.txtTotalSueldos.Size = new System.Drawing.Size(72, 20);
            this.txtTotalSueldos.TabIndex = 72;
            this.txtTotalSueldos.Text = "100,012.85";
            this.txtTotalSueldos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 79;
            this.label5.Text = "Total AFP :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Total Pagos :";
            // 
            // txtTotalOnp
            // 
            this.txtTotalOnp.Location = new System.Drawing.Point(409, 45);
            this.txtTotalOnp.Name = "txtTotalOnp";
            this.txtTotalOnp.Size = new System.Drawing.Size(72, 20);
            this.txtTotalOnp.TabIndex = 78;
            this.txtTotalOnp.Text = "100,000.00";
            this.txtTotalOnp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalPagos
            // 
            this.txtTotalPagos.Location = new System.Drawing.Point(161, 71);
            this.txtTotalPagos.Name = "txtTotalPagos";
            this.txtTotalPagos.Size = new System.Drawing.Size(72, 20);
            this.txtTotalPagos.TabIndex = 74;
            this.txtTotalPagos.Text = "92,000.00";
            this.txtTotalPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "Total ONP :";
            // 
            // txtTotalEssalud
            // 
            this.txtTotalEssalud.Location = new System.Drawing.Point(409, 19);
            this.txtTotalEssalud.Name = "txtTotalEssalud";
            this.txtTotalEssalud.Size = new System.Drawing.Size(72, 20);
            this.txtTotalEssalud.TabIndex = 76;
            this.txtTotalEssalud.Text = "100,000.00";
            this.txtTotalEssalud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 75;
            this.label4.Text = "Total ESSALUD :";
            // 
            // tbpDetalle
            // 
            this.tbpDetalle.Controls.Add(this.btnExportarCsv);
            this.tbpDetalle.Controls.Add(this.btnBoleta);
            this.tbpDetalle.Controls.Add(this.txtEmpleadoCodigo);
            this.tbpDetalle.Controls.Add(this.cboEmpleado);
            this.tbpDetalle.Controls.Add(this.label6);
            this.tbpDetalle.Controls.Add(this.cboCalculoPor);
            this.tbpDetalle.Controls.Add(this.lblCalculoPor);
            this.tbpDetalle.Controls.Add(this.btnVer);
            this.tbpDetalle.Controls.Add(this.dgvPlanilla);
            this.tbpDetalle.Location = new System.Drawing.Point(4, 22);
            this.tbpDetalle.Name = "tbpDetalle";
            this.tbpDetalle.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDetalle.Size = new System.Drawing.Size(940, 367);
            this.tbpDetalle.TabIndex = 1;
            this.tbpDetalle.Text = "Detalle";
            this.tbpDetalle.UseVisualStyleBackColor = true;
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarCsv.Location = new System.Drawing.Point(834, 6);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(100, 21);
            this.btnExportarCsv.TabIndex = 89;
            this.btnExportarCsv.Text = "Exportar CSV";
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            // 
            // btnBoleta
            // 
            this.btnBoleta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBoleta.Location = new System.Drawing.Point(728, 340);
            this.btnBoleta.Name = "btnBoleta";
            this.btnBoleta.Size = new System.Drawing.Size(100, 21);
            this.btnBoleta.TabIndex = 88;
            this.btnBoleta.Text = "Ver Boleta";
            this.btnBoleta.UseVisualStyleBackColor = true;
            this.btnBoleta.Click += new System.EventHandler(this.btnBoleta_Click);
            // 
            // txtEmpleadoCodigo
            // 
            this.txtEmpleadoCodigo.Location = new System.Drawing.Point(75, 6);
            this.txtEmpleadoCodigo.Name = "txtEmpleadoCodigo";
            this.txtEmpleadoCodigo.Size = new System.Drawing.Size(111, 20);
            this.txtEmpleadoCodigo.TabIndex = 87;
            this.txtEmpleadoCodigo.Leave += new System.EventHandler(this.txtEmpleadoCodigo_Leave);
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(192, 6);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(278, 21);
            this.cboEmpleado.TabIndex = 86;
            this.cboEmpleado.SelectionChangeCommitted += new System.EventHandler(this.cboEmpleado_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "Empleado:";
            // 
            // cboCalculoPor
            // 
            this.cboCalculoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboCalculoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalculoPor.FormattingEnabled = true;
            this.cboCalculoPor.Location = new System.Drawing.Point(75, 340);
            this.cboCalculoPor.Name = "cboCalculoPor";
            this.cboCalculoPor.Size = new System.Drawing.Size(111, 21);
            this.cboCalculoPor.TabIndex = 57;
            this.cboCalculoPor.SelectionChangeCommitted += new System.EventHandler(this.cboCalculoPor_SelectionChangeCommitted);
            // 
            // lblCalculoPor
            // 
            this.lblCalculoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCalculoPor.AutoSize = true;
            this.lblCalculoPor.Location = new System.Drawing.Point(5, 343);
            this.lblCalculoPor.Name = "lblCalculoPor";
            this.lblCalculoPor.Size = new System.Drawing.Size(66, 13);
            this.lblCalculoPor.TabIndex = 56;
            this.lblCalculoPor.Text = "Calculo por :";
            // 
            // btnVer
            // 
            this.btnVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVer.Location = new System.Drawing.Point(834, 340);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(100, 21);
            this.btnVer.TabIndex = 51;
            this.btnVer.Text = "Ver Detalle";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // dgvPlanilla
            // 
            this.dgvPlanilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanilla.Location = new System.Drawing.Point(6, 31);
            this.dgvPlanilla.Name = "dgvPlanilla";
            this.dgvPlanilla.Size = new System.Drawing.Size(928, 303);
            this.dgvPlanilla.TabIndex = 41;
            // 
            // grpFiltro
            // 
            this.grpFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiltro.Controls.Add(this.BtnBuscar);
            this.grpFiltro.Controls.Add(this.CbxMes);
            this.grpFiltro.Controls.Add(this.CboAnho);
            this.grpFiltro.Controls.Add(this.LblFechaHora);
            this.grpFiltro.Location = new System.Drawing.Point(9, 3);
            this.grpFiltro.Name = "grpFiltro";
            this.grpFiltro.Size = new System.Drawing.Size(944, 47);
            this.grpFiltro.TabIndex = 39;
            this.grpFiltro.TabStop = false;
            this.grpFiltro.Text = "Filtro";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscar.Location = new System.Drawing.Point(838, 11);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(100, 30);
            this.BtnBuscar.TabIndex = 19;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // CbxMes
            // 
            this.CbxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxMes.FormattingEnabled = true;
            this.CbxMes.Location = new System.Drawing.Point(153, 17);
            this.CbxMes.Name = "CbxMes";
            this.CbxMes.Size = new System.Drawing.Size(241, 21);
            this.CbxMes.TabIndex = 50;
            // 
            // CboAnho
            // 
            this.CboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboAnho.FormattingEnabled = true;
            this.CboAnho.Location = new System.Drawing.Point(75, 17);
            this.CboAnho.Name = "CboAnho";
            this.CboAnho.Size = new System.Drawing.Size(72, 21);
            this.CboAnho.TabIndex = 49;
            // 
            // LblFechaHora
            // 
            this.LblFechaHora.AutoSize = true;
            this.LblFechaHora.Location = new System.Drawing.Point(6, 20);
            this.LblFechaHora.Name = "LblFechaHora";
            this.LblFechaHora.Size = new System.Drawing.Size(63, 13);
            this.LblFechaHora.TabIndex = 18;
            this.LblFechaHora.Text = "Año y Mes :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 464);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(964, 44);
            this.panel2.TabIndex = 17;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(855, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(749, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmPlanillaRevisar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 511);
            this.Controls.Add(this.tlpPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPlanillaRevisar";
            this.Text = "Revisar Planilla";
            this.Load += new System.EventHandler(this.FrmAfpComisionMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.tbcPlanilla.ResumeLayout(false);
            this.tbpResumen.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpGrafica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.grpParametros.ResumeLayout(false);
            this.grpParametros.PerformLayout();
            this.grpTotales.ResumeLayout(false);
            this.grpTotales.PerformLayout();
            this.tbpDetalle.ResumeLayout(false);
            this.tbpDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanilla)).EndInit();
            this.grpFiltro.ResumeLayout(false);
            this.grpFiltro.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        internal System.Windows.Forms.Label LblFechaHora;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox grpFiltro;
        private System.Windows.Forms.ComboBox CbxMes;
        private System.Windows.Forms.ComboBox CboAnho;
        public System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TabControl tbcPlanilla;
        private System.Windows.Forms.TabPage tbpResumen;
        private System.Windows.Forms.TabPage tbpDetalle;
        private System.Windows.Forms.DataGridView dgvPlanilla;
        private System.Windows.Forms.TextBox txtHorarioNocturno;
        internal System.Windows.Forms.Label lblHorarioNocturno;
        private System.Windows.Forms.TextBox txtPosterioresHorasExtras;
        internal System.Windows.Forms.Label lblPosterioresHorasExtras;
        private System.Windows.Forms.TextBox txtPrimerasHorasExtras;
        internal System.Windows.Forms.Label lblPrimerasHorasExtras;
        private System.Windows.Forms.TextBox txtAsignacionFamiliar;
        internal System.Windows.Forms.Label lblAsignacionFamiliar;
        private System.Windows.Forms.TextBox txtEsSalud;
        internal System.Windows.Forms.Label lblEsSalud;
        private System.Windows.Forms.TextBox txtDias;
        internal System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.TextBox txtMes;
        internal System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.TextBox txtAnho;
        internal System.Windows.Forms.Label lblAnho;
        private System.Windows.Forms.TextBox txtSueldoMinimo;
        internal System.Windows.Forms.Label lblSueldoMinimo;
        private System.Windows.Forms.TextBox txtCantidadEmpleados;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalAfp;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalOnp;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalEssalud;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalPagos;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalSueldos;
        internal System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.ComboBox cboCalculoPor;
        internal System.Windows.Forms.Label lblCalculoPor;
        private System.Windows.Forms.TextBox txtEmpleadoCodigo;
        private System.Windows.Forms.ComboBox cboEmpleado;
        internal System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnBoleta;
        public System.Windows.Forms.Button btnExportarCsv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpParametros;
        private System.Windows.Forms.GroupBox grpTotales;
        private System.Windows.Forms.GroupBox grpGrafica;
        private System.Windows.Forms.GroupBox grpIndicador;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox txtTotal;
        internal System.Windows.Forms.Label label7;
    }
}