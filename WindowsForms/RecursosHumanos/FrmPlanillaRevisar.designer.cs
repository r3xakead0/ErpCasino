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
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.tbcPlanilla = new System.Windows.Forms.TabControl();
            this.tbpResumen = new System.Windows.Forms.TabPage();
            this.lblLinea = new System.Windows.Forms.Label();
            this.txtTotalAfp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalOnp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalEssalud = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalPagos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalSueldos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidadEmpleados = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSueldoMinimo = new System.Windows.Forms.TextBox();
            this.lblSueldoMinimo = new System.Windows.Forms.Label();
            this.txtHorarioNocturno = new System.Windows.Forms.TextBox();
            this.lblHorarioNocturno = new System.Windows.Forms.Label();
            this.txtPosterioresHorasExtras = new System.Windows.Forms.TextBox();
            this.lblPosterioresHorasExtras = new System.Windows.Forms.Label();
            this.txtPrimerasHorasExtras = new System.Windows.Forms.TextBox();
            this.lblPrimerasHorasExtras = new System.Windows.Forms.Label();
            this.txtAsignacionFamiliar = new System.Windows.Forms.TextBox();
            this.lblAsignacionFamiliar = new System.Windows.Forms.Label();
            this.txtEsSalud = new System.Windows.Forms.TextBox();
            this.lblEsSalud = new System.Windows.Forms.Label();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.lblDias = new System.Windows.Forms.Label();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.txtAnho = new System.Windows.Forms.TextBox();
            this.lblAnho = new System.Windows.Forms.Label();
            this.tbpDetalle = new System.Windows.Forms.TabPage();
            this.txtEmpleadoCodigo = new System.Windows.Forms.TextBox();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCalculoPor = new System.Windows.Forms.ComboBox();
            this.lblCalculoPor = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.dgvPlanilla = new System.Windows.Forms.DataGridView();
            this.GrpPeriodo = new System.Windows.Forms.GroupBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.CbxMes = new System.Windows.Forms.ComboBox();
            this.CboAnho = new System.Windows.Forms.ComboBox();
            this.LblFechaHora = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.btnBoleta = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.tbcPlanilla.SuspendLayout();
            this.tbpResumen.SuspendLayout();
            this.tbpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanilla)).BeginInit();
            this.GrpPeriodo.SuspendLayout();
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
            this.tlpPrincipal.Size = new System.Drawing.Size(940, 424);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.tbcPlanilla);
            this.pnlPrincipal.Controls.Add(this.GrpPeriodo);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(934, 368);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // tbcPlanilla
            // 
            this.tbcPlanilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcPlanilla.Controls.Add(this.tbpResumen);
            this.tbcPlanilla.Controls.Add(this.tbpDetalle);
            this.tbcPlanilla.Location = new System.Drawing.Point(9, 69);
            this.tbcPlanilla.Name = "tbcPlanilla";
            this.tbcPlanilla.SelectedIndex = 0;
            this.tbcPlanilla.Size = new System.Drawing.Size(918, 293);
            this.tbcPlanilla.TabIndex = 41;
            // 
            // tbpResumen
            // 
            this.tbpResumen.Controls.Add(this.lblLinea);
            this.tbpResumen.Controls.Add(this.txtTotalAfp);
            this.tbpResumen.Controls.Add(this.label5);
            this.tbpResumen.Controls.Add(this.txtTotalOnp);
            this.tbpResumen.Controls.Add(this.label3);
            this.tbpResumen.Controls.Add(this.txtTotalEssalud);
            this.tbpResumen.Controls.Add(this.label4);
            this.tbpResumen.Controls.Add(this.txtTotalPagos);
            this.tbpResumen.Controls.Add(this.label2);
            this.tbpResumen.Controls.Add(this.txtTotalSueldos);
            this.tbpResumen.Controls.Add(this.label1);
            this.tbpResumen.Controls.Add(this.txtCantidadEmpleados);
            this.tbpResumen.Controls.Add(this.label10);
            this.tbpResumen.Controls.Add(this.txtSueldoMinimo);
            this.tbpResumen.Controls.Add(this.lblSueldoMinimo);
            this.tbpResumen.Controls.Add(this.txtHorarioNocturno);
            this.tbpResumen.Controls.Add(this.lblHorarioNocturno);
            this.tbpResumen.Controls.Add(this.txtPosterioresHorasExtras);
            this.tbpResumen.Controls.Add(this.lblPosterioresHorasExtras);
            this.tbpResumen.Controls.Add(this.txtPrimerasHorasExtras);
            this.tbpResumen.Controls.Add(this.lblPrimerasHorasExtras);
            this.tbpResumen.Controls.Add(this.txtAsignacionFamiliar);
            this.tbpResumen.Controls.Add(this.lblAsignacionFamiliar);
            this.tbpResumen.Controls.Add(this.txtEsSalud);
            this.tbpResumen.Controls.Add(this.lblEsSalud);
            this.tbpResumen.Controls.Add(this.txtDias);
            this.tbpResumen.Controls.Add(this.lblDias);
            this.tbpResumen.Controls.Add(this.txtMes);
            this.tbpResumen.Controls.Add(this.lblMes);
            this.tbpResumen.Controls.Add(this.txtAnho);
            this.tbpResumen.Controls.Add(this.lblAnho);
            this.tbpResumen.Location = new System.Drawing.Point(4, 22);
            this.tbpResumen.Name = "tbpResumen";
            this.tbpResumen.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResumen.Size = new System.Drawing.Size(910, 267);
            this.tbpResumen.TabIndex = 0;
            this.tbpResumen.Text = "Resumen";
            this.tbpResumen.UseVisualStyleBackColor = true;
            // 
            // lblLinea
            // 
            this.lblLinea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLinea.BackColor = System.Drawing.Color.Black;
            this.lblLinea.Location = new System.Drawing.Point(3, 121);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(904, 10);
            this.lblLinea.TabIndex = 81;
            this.lblLinea.Text = "label6";
            // 
            // txtTotalAfp
            // 
            this.txtTotalAfp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalAfp.Location = new System.Drawing.Point(799, 222);
            this.txtTotalAfp.Name = "txtTotalAfp";
            this.txtTotalAfp.Size = new System.Drawing.Size(72, 20);
            this.txtTotalAfp.TabIndex = 80;
            this.txtTotalAfp.Text = "100,000.00";
            this.txtTotalAfp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(659, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 79;
            this.label5.Text = "Total AFP :";
            // 
            // txtTotalOnp
            // 
            this.txtTotalOnp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalOnp.Location = new System.Drawing.Point(799, 196);
            this.txtTotalOnp.Name = "txtTotalOnp";
            this.txtTotalOnp.Size = new System.Drawing.Size(72, 20);
            this.txtTotalOnp.TabIndex = 78;
            this.txtTotalOnp.Text = "100,000.00";
            this.txtTotalOnp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(659, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "Total ONP :";
            // 
            // txtTotalEssalud
            // 
            this.txtTotalEssalud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalEssalud.Location = new System.Drawing.Point(799, 170);
            this.txtTotalEssalud.Name = "txtTotalEssalud";
            this.txtTotalEssalud.Size = new System.Drawing.Size(72, 20);
            this.txtTotalEssalud.TabIndex = 76;
            this.txtTotalEssalud.Text = "100,000.00";
            this.txtTotalEssalud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(659, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 75;
            this.label4.Text = "Total ESSALUD :";
            // 
            // txtTotalPagos
            // 
            this.txtTotalPagos.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalPagos.Location = new System.Drawing.Point(466, 222);
            this.txtTotalPagos.Name = "txtTotalPagos";
            this.txtTotalPagos.Size = new System.Drawing.Size(72, 20);
            this.txtTotalPagos.TabIndex = 74;
            this.txtTotalPagos.Text = "92,000.00";
            this.txtTotalPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Total Pagos :";
            // 
            // txtTotalSueldos
            // 
            this.txtTotalSueldos.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalSueldos.Location = new System.Drawing.Point(466, 196);
            this.txtTotalSueldos.Name = "txtTotalSueldos";
            this.txtTotalSueldos.Size = new System.Drawing.Size(72, 20);
            this.txtTotalSueldos.TabIndex = 72;
            this.txtTotalSueldos.Text = "100,012.85";
            this.txtTotalSueldos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Total Sueldos :";
            // 
            // txtCantidadEmpleados
            // 
            this.txtCantidadEmpleados.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCantidadEmpleados.Location = new System.Drawing.Point(466, 170);
            this.txtCantidadEmpleados.Name = "txtCantidadEmpleados";
            this.txtCantidadEmpleados.Size = new System.Drawing.Size(72, 20);
            this.txtCantidadEmpleados.TabIndex = 70;
            this.txtCantidadEmpleados.Text = "100";
            this.txtCantidadEmpleados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(326, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "Cantidad de Empleados :";
            // 
            // txtSueldoMinimo
            // 
            this.txtSueldoMinimo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSueldoMinimo.Location = new System.Drawing.Point(466, 23);
            this.txtSueldoMinimo.Name = "txtSueldoMinimo";
            this.txtSueldoMinimo.Size = new System.Drawing.Size(72, 20);
            this.txtSueldoMinimo.TabIndex = 68;
            this.txtSueldoMinimo.Text = "850.00";
            this.txtSueldoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSueldoMinimo
            // 
            this.lblSueldoMinimo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSueldoMinimo.AutoSize = true;
            this.lblSueldoMinimo.Location = new System.Drawing.Point(326, 26);
            this.lblSueldoMinimo.Name = "lblSueldoMinimo";
            this.lblSueldoMinimo.Size = new System.Drawing.Size(82, 13);
            this.lblSueldoMinimo.TabIndex = 67;
            this.lblSueldoMinimo.Text = "Sueldo Minimo :";
            // 
            // txtHorarioNocturno
            // 
            this.txtHorarioNocturno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHorarioNocturno.Location = new System.Drawing.Point(799, 75);
            this.txtHorarioNocturno.Name = "txtHorarioNocturno";
            this.txtHorarioNocturno.Size = new System.Drawing.Size(72, 20);
            this.txtHorarioNocturno.TabIndex = 66;
            this.txtHorarioNocturno.Text = "35%";
            this.txtHorarioNocturno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHorarioNocturno
            // 
            this.lblHorarioNocturno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorarioNocturno.AutoSize = true;
            this.lblHorarioNocturno.Location = new System.Drawing.Point(659, 78);
            this.lblHorarioNocturno.Name = "lblHorarioNocturno";
            this.lblHorarioNocturno.Size = new System.Drawing.Size(88, 13);
            this.lblHorarioNocturno.TabIndex = 65;
            this.lblHorarioNocturno.Text = "Horario Nocturna";
            // 
            // txtPosterioresHorasExtras
            // 
            this.txtPosterioresHorasExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPosterioresHorasExtras.Location = new System.Drawing.Point(799, 49);
            this.txtPosterioresHorasExtras.Name = "txtPosterioresHorasExtras";
            this.txtPosterioresHorasExtras.Size = new System.Drawing.Size(72, 20);
            this.txtPosterioresHorasExtras.TabIndex = 64;
            this.txtPosterioresHorasExtras.Text = "35%";
            this.txtPosterioresHorasExtras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPosterioresHorasExtras
            // 
            this.lblPosterioresHorasExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosterioresHorasExtras.AutoSize = true;
            this.lblPosterioresHorasExtras.Location = new System.Drawing.Point(659, 52);
            this.lblPosterioresHorasExtras.Name = "lblPosterioresHorasExtras";
            this.lblPosterioresHorasExtras.Size = new System.Drawing.Size(134, 13);
            this.lblPosterioresHorasExtras.TabIndex = 63;
            this.lblPosterioresHorasExtras.Text = "Posteriores 2 Horas Extras:";
            // 
            // txtPrimerasHorasExtras
            // 
            this.txtPrimerasHorasExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrimerasHorasExtras.Location = new System.Drawing.Point(799, 23);
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
            this.lblPrimerasHorasExtras.Location = new System.Drawing.Point(659, 26);
            this.lblPrimerasHorasExtras.Name = "lblPrimerasHorasExtras";
            this.lblPrimerasHorasExtras.Size = new System.Drawing.Size(122, 13);
            this.lblPrimerasHorasExtras.TabIndex = 61;
            this.lblPrimerasHorasExtras.Text = "Primeras 2 Horas Extras:";
            // 
            // txtAsignacionFamiliar
            // 
            this.txtAsignacionFamiliar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAsignacionFamiliar.Location = new System.Drawing.Point(466, 49);
            this.txtAsignacionFamiliar.Name = "txtAsignacionFamiliar";
            this.txtAsignacionFamiliar.Size = new System.Drawing.Size(72, 20);
            this.txtAsignacionFamiliar.TabIndex = 60;
            this.txtAsignacionFamiliar.Text = "10%";
            this.txtAsignacionFamiliar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAsignacionFamiliar
            // 
            this.lblAsignacionFamiliar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAsignacionFamiliar.AutoSize = true;
            this.lblAsignacionFamiliar.Location = new System.Drawing.Point(326, 52);
            this.lblAsignacionFamiliar.Name = "lblAsignacionFamiliar";
            this.lblAsignacionFamiliar.Size = new System.Drawing.Size(103, 13);
            this.lblAsignacionFamiliar.TabIndex = 59;
            this.lblAsignacionFamiliar.Text = "Asignación Familiar :";
            // 
            // txtEsSalud
            // 
            this.txtEsSalud.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEsSalud.Location = new System.Drawing.Point(466, 75);
            this.txtEsSalud.Name = "txtEsSalud";
            this.txtEsSalud.Size = new System.Drawing.Size(72, 20);
            this.txtEsSalud.TabIndex = 58;
            this.txtEsSalud.Text = "9%";
            this.txtEsSalud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEsSalud
            // 
            this.lblEsSalud.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEsSalud.AutoSize = true;
            this.lblEsSalud.Location = new System.Drawing.Point(326, 78);
            this.lblEsSalud.Name = "lblEsSalud";
            this.lblEsSalud.Size = new System.Drawing.Size(52, 13);
            this.lblEsSalud.TabIndex = 57;
            this.lblEsSalud.Text = "EsSalud :";
            // 
            // txtDias
            // 
            this.txtDias.Location = new System.Drawing.Point(101, 75);
            this.txtDias.Name = "txtDias";
            this.txtDias.Size = new System.Drawing.Size(72, 20);
            this.txtDias.TabIndex = 56;
            this.txtDias.Text = "31";
            this.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Location = new System.Drawing.Point(36, 78);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(36, 13);
            this.lblDias.TabIndex = 55;
            this.lblDias.Text = "Días :";
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(101, 49);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(72, 20);
            this.txtMes.TabIndex = 54;
            this.txtMes.Text = "Mayo";
            this.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(36, 52);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(33, 13);
            this.lblMes.TabIndex = 53;
            this.lblMes.Text = "Mes :";
            // 
            // txtAnho
            // 
            this.txtAnho.Location = new System.Drawing.Point(101, 23);
            this.txtAnho.Name = "txtAnho";
            this.txtAnho.Size = new System.Drawing.Size(72, 20);
            this.txtAnho.TabIndex = 52;
            this.txtAnho.Text = "2017";
            this.txtAnho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAnho
            // 
            this.lblAnho.AutoSize = true;
            this.lblAnho.Location = new System.Drawing.Point(36, 26);
            this.lblAnho.Name = "lblAnho";
            this.lblAnho.Size = new System.Drawing.Size(32, 13);
            this.lblAnho.TabIndex = 51;
            this.lblAnho.Text = "Año :";
            // 
            // tbpDetalle
            // 
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
            this.tbpDetalle.Size = new System.Drawing.Size(910, 267);
            this.tbpDetalle.TabIndex = 1;
            this.tbpDetalle.Text = "Detalle";
            this.tbpDetalle.UseVisualStyleBackColor = true;
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
            this.cboCalculoPor.Location = new System.Drawing.Point(75, 230);
            this.cboCalculoPor.Name = "cboCalculoPor";
            this.cboCalculoPor.Size = new System.Drawing.Size(111, 21);
            this.cboCalculoPor.TabIndex = 57;
            this.cboCalculoPor.SelectionChangeCommitted += new System.EventHandler(this.cboCalculoPor_SelectionChangeCommitted);
            // 
            // lblCalculoPor
            // 
            this.lblCalculoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCalculoPor.AutoSize = true;
            this.lblCalculoPor.Location = new System.Drawing.Point(5, 233);
            this.lblCalculoPor.Name = "lblCalculoPor";
            this.lblCalculoPor.Size = new System.Drawing.Size(66, 13);
            this.lblCalculoPor.TabIndex = 56;
            this.lblCalculoPor.Text = "Calculo por :";
            // 
            // btnVer
            // 
            this.btnVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVer.Location = new System.Drawing.Point(804, 230);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(100, 21);
            this.btnVer.TabIndex = 51;
            this.btnVer.Text = "Ver";
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
            this.dgvPlanilla.Size = new System.Drawing.Size(898, 193);
            this.dgvPlanilla.TabIndex = 41;
            this.dgvPlanilla.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanilla_CellDoubleClick);
            // 
            // GrpPeriodo
            // 
            this.GrpPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpPeriodo.Controls.Add(this.BtnBuscar);
            this.GrpPeriodo.Controls.Add(this.CbxMes);
            this.GrpPeriodo.Controls.Add(this.CboAnho);
            this.GrpPeriodo.Controls.Add(this.LblFechaHora);
            this.GrpPeriodo.Location = new System.Drawing.Point(9, 3);
            this.GrpPeriodo.Name = "GrpPeriodo";
            this.GrpPeriodo.Size = new System.Drawing.Size(911, 60);
            this.GrpPeriodo.TabIndex = 39;
            this.GrpPeriodo.TabStop = false;
            this.GrpPeriodo.Text = "Periodo";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscar.Location = new System.Drawing.Point(805, 17);
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
            this.CbxMes.Location = new System.Drawing.Point(192, 23);
            this.CbxMes.Name = "CbxMes";
            this.CbxMes.Size = new System.Drawing.Size(72, 21);
            this.CbxMes.TabIndex = 50;
            // 
            // CboAnho
            // 
            this.CboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboAnho.FormattingEnabled = true;
            this.CboAnho.Location = new System.Drawing.Point(105, 23);
            this.CboAnho.Name = "CboAnho";
            this.CboAnho.Size = new System.Drawing.Size(72, 21);
            this.CboAnho.TabIndex = 49;
            // 
            // LblFechaHora
            // 
            this.LblFechaHora.AutoSize = true;
            this.LblFechaHora.Location = new System.Drawing.Point(9, 26);
            this.LblFechaHora.Name = "LblFechaHora";
            this.LblFechaHora.Size = new System.Drawing.Size(63, 13);
            this.LblFechaHora.TabIndex = 18;
            this.LblFechaHora.Text = "Año y Mes :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnGenerate);
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 377);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(934, 44);
            this.panel2.TabIndex = 17;
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGenerate.Location = new System.Drawing.Point(825, 5);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(100, 30);
            this.BtnGenerate.TabIndex = 17;
            this.BtnGenerate.Text = "Generar";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(719, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnBoleta
            // 
            this.btnBoleta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBoleta.Location = new System.Drawing.Point(698, 230);
            this.btnBoleta.Name = "btnBoleta";
            this.btnBoleta.Size = new System.Drawing.Size(100, 21);
            this.btnBoleta.TabIndex = 88;
            this.btnBoleta.Text = "Boleta";
            this.btnBoleta.UseVisualStyleBackColor = true;
            this.btnBoleta.Click += new System.EventHandler(this.btnBoleta_Click);
            // 
            // FrmPlanillaRevisar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 424);
            this.Controls.Add(this.tlpPrincipal);
            this.Name = "FrmPlanillaRevisar";
            this.Text = "Revisar Planilla";
            this.Load += new System.EventHandler(this.FrmAfpComisionMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.tbcPlanilla.ResumeLayout(false);
            this.tbpResumen.ResumeLayout(false);
            this.tbpResumen.PerformLayout();
            this.tbpDetalle.ResumeLayout(false);
            this.tbpDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanilla)).EndInit();
            this.GrpPeriodo.ResumeLayout(false);
            this.GrpPeriodo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        internal System.Windows.Forms.Label LblFechaHora;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button BtnGenerate;
        public System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox GrpPeriodo;
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
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.ComboBox cboCalculoPor;
        internal System.Windows.Forms.Label lblCalculoPor;
        private System.Windows.Forms.TextBox txtEmpleadoCodigo;
        private System.Windows.Forms.ComboBox cboEmpleado;
        internal System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnBoleta;
    }
}