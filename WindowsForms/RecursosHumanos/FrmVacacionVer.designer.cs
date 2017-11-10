namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmVacacionVer
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
            this.grpVacacion = new System.Windows.Forms.GroupBox();
            this.txtTotalDescuento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPromedios = new System.Windows.Forms.GroupBox();
            this.txtPromedioHorasExtras = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPromedioBonificaciones = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPensionPorcentaje = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDescansoInicio = new System.Windows.Forms.TextBox();
            this.txtPensionTipo = new System.Windows.Forms.TextBox();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.txtPensionDescipcion = new System.Windows.Forms.TextBox();
            this.txtTotalBruto = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalNeto = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPensionMonto = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRetencionJudicial = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.txtAsignacionFamiliar = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPeriodoInicio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPeriodoFinal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescansoDias = new System.Windows.Forms.TextBox();
            this.txtDescansoFin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.grpVacacion.SuspendLayout();
            this.grpPromedios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // grpVacacion
            // 
            this.grpVacacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVacacion.Controls.Add(this.txtTotalDescuento);
            this.grpVacacion.Controls.Add(this.label1);
            this.grpVacacion.Controls.Add(this.grpPromedios);
            this.grpVacacion.Controls.Add(this.txtPensionPorcentaje);
            this.grpVacacion.Controls.Add(this.txtNombres);
            this.grpVacacion.Controls.Add(this.txtCodigo);
            this.grpVacacion.Controls.Add(this.label20);
            this.grpVacacion.Controls.Add(this.txtDescansoInicio);
            this.grpVacacion.Controls.Add(this.txtPensionTipo);
            this.grpVacacion.Controls.Add(this.dgvDetalles);
            this.grpVacacion.Controls.Add(this.txtPensionDescipcion);
            this.grpVacacion.Controls.Add(this.txtTotalBruto);
            this.grpVacacion.Controls.Add(this.label14);
            this.grpVacacion.Controls.Add(this.txtTotalNeto);
            this.grpVacacion.Controls.Add(this.label15);
            this.grpVacacion.Controls.Add(this.txtPensionMonto);
            this.grpVacacion.Controls.Add(this.label13);
            this.grpVacacion.Controls.Add(this.txtRetencionJudicial);
            this.grpVacacion.Controls.Add(this.label12);
            this.grpVacacion.Controls.Add(this.txtSueldo);
            this.grpVacacion.Controls.Add(this.txtAsignacionFamiliar);
            this.grpVacacion.Controls.Add(this.label10);
            this.grpVacacion.Controls.Add(this.label9);
            this.grpVacacion.Controls.Add(this.txtPeriodoInicio);
            this.grpVacacion.Controls.Add(this.label6);
            this.grpVacacion.Controls.Add(this.label2);
            this.grpVacacion.Controls.Add(this.txtPeriodoFinal);
            this.grpVacacion.Controls.Add(this.label3);
            this.grpVacacion.Controls.Add(this.label5);
            this.grpVacacion.Controls.Add(this.txtDescansoDias);
            this.grpVacacion.Controls.Add(this.txtDescansoFin);
            this.grpVacacion.Controls.Add(this.label4);
            this.grpVacacion.Location = new System.Drawing.Point(12, 12);
            this.grpVacacion.Name = "grpVacacion";
            this.grpVacacion.Size = new System.Drawing.Size(500, 406);
            this.grpVacacion.TabIndex = 116;
            this.grpVacacion.TabStop = false;
            this.grpVacacion.Text = "Calculo de Vacaciones";
            // 
            // txtTotalDescuento
            // 
            this.txtTotalDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDescuento.Location = new System.Drawing.Point(415, 349);
            this.txtTotalDescuento.Name = "txtTotalDescuento";
            this.txtTotalDescuento.ReadOnly = true;
            this.txtTotalDescuento.Size = new System.Drawing.Size(75, 20);
            this.txtTotalDescuento.TabIndex = 142;
            this.txtTotalDescuento.Text = "0.00";
            this.txtTotalDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 141;
            this.label1.Text = "Total Descuento :";
            // 
            // grpPromedios
            // 
            this.grpPromedios.Controls.Add(this.txtPromedioHorasExtras);
            this.grpPromedios.Controls.Add(this.label7);
            this.grpPromedios.Controls.Add(this.txtPromedioBonificaciones);
            this.grpPromedios.Controls.Add(this.label8);
            this.grpPromedios.Location = new System.Drawing.Point(13, 149);
            this.grpPromedios.Name = "grpPromedios";
            this.grpPromedios.Size = new System.Drawing.Size(173, 72);
            this.grpPromedios.TabIndex = 140;
            this.grpPromedios.TabStop = false;
            this.grpPromedios.Text = "Promedio";
            // 
            // txtPromedioHorasExtras
            // 
            this.txtPromedioHorasExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPromedioHorasExtras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPromedioHorasExtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPromedioHorasExtras.Location = new System.Drawing.Point(108, 19);
            this.txtPromedioHorasExtras.Name = "txtPromedioHorasExtras";
            this.txtPromedioHorasExtras.ReadOnly = true;
            this.txtPromedioHorasExtras.Size = new System.Drawing.Size(59, 20);
            this.txtPromedioHorasExtras.TabIndex = 118;
            this.txtPromedioHorasExtras.Text = "0.00";
            this.txtPromedioHorasExtras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "Bonificaciones :";
            // 
            // txtPromedioBonificaciones
            // 
            this.txtPromedioBonificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPromedioBonificaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPromedioBonificaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPromedioBonificaciones.Location = new System.Drawing.Point(108, 45);
            this.txtPromedioBonificaciones.Name = "txtPromedioBonificaciones";
            this.txtPromedioBonificaciones.ReadOnly = true;
            this.txtPromedioBonificaciones.Size = new System.Drawing.Size(59, 20);
            this.txtPromedioBonificaciones.TabIndex = 65;
            this.txtPromedioBonificaciones.Text = "0.00";
            this.txtPromedioBonificaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 66;
            this.label8.Text = "Horas Extras :";
            // 
            // txtPensionPorcentaje
            // 
            this.txtPensionPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPensionPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPensionPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPensionPorcentaje.Location = new System.Drawing.Point(441, 298);
            this.txtPensionPorcentaje.Name = "txtPensionPorcentaje";
            this.txtPensionPorcentaje.ReadOnly = true;
            this.txtPensionPorcentaje.Size = new System.Drawing.Size(49, 20);
            this.txtPensionPorcentaje.TabIndex = 139;
            this.txtPensionPorcentaje.Text = "0.00 %";
            this.txtPensionPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNombres
            // 
            this.txtNombres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombres.Location = new System.Drawing.Point(202, 19);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.ReadOnly = true;
            this.txtNombres.Size = new System.Drawing.Size(288, 20);
            this.txtNombres.TabIndex = 138;
            this.txtNombres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(90, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(96, 20);
            this.txtCodigo.TabIndex = 137;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 13);
            this.label20.TabIndex = 137;
            this.label20.Text = "Empleado :";
            // 
            // txtDescansoInicio
            // 
            this.txtDescansoInicio.Location = new System.Drawing.Point(91, 71);
            this.txtDescansoInicio.Name = "txtDescansoInicio";
            this.txtDescansoInicio.ReadOnly = true;
            this.txtDescansoInicio.Size = new System.Drawing.Size(95, 20);
            this.txtDescansoInicio.TabIndex = 131;
            this.txtDescansoInicio.Text = "01/01/2017";
            this.txtDescansoInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPensionTipo
            // 
            this.txtPensionTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPensionTipo.Location = new System.Drawing.Point(202, 298);
            this.txtPensionTipo.Name = "txtPensionTipo";
            this.txtPensionTipo.ReadOnly = true;
            this.txtPensionTipo.Size = new System.Drawing.Size(31, 20);
            this.txtPensionTipo.TabIndex = 130;
            this.txtPensionTipo.Text = "SNP";
            this.txtPensionTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(202, 97);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.Size = new System.Drawing.Size(288, 169);
            this.dgvDetalles.TabIndex = 1;
            // 
            // txtPensionDescipcion
            // 
            this.txtPensionDescipcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPensionDescipcion.Location = new System.Drawing.Point(239, 298);
            this.txtPensionDescipcion.Name = "txtPensionDescipcion";
            this.txtPensionDescipcion.ReadOnly = true;
            this.txtPensionDescipcion.Size = new System.Drawing.Size(196, 20);
            this.txtPensionDescipcion.TabIndex = 129;
            this.txtPensionDescipcion.Text = "ONP";
            // 
            // txtTotalBruto
            // 
            this.txtTotalBruto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBruto.Location = new System.Drawing.Point(415, 272);
            this.txtTotalBruto.Name = "txtTotalBruto";
            this.txtTotalBruto.ReadOnly = true;
            this.txtTotalBruto.Size = new System.Drawing.Size(75, 20);
            this.txtTotalBruto.TabIndex = 128;
            this.txtTotalBruto.Text = "0.00";
            this.txtTotalBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(331, 274);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 127;
            this.label14.Text = "Total Bruto :";
            // 
            // txtTotalNeto
            // 
            this.txtTotalNeto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalNeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNeto.Location = new System.Drawing.Point(415, 375);
            this.txtTotalNeto.Name = "txtTotalNeto";
            this.txtTotalNeto.ReadOnly = true;
            this.txtTotalNeto.Size = new System.Drawing.Size(75, 20);
            this.txtTotalNeto.TabIndex = 126;
            this.txtTotalNeto.Text = "0.00";
            this.txtTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(334, 377);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 125;
            this.label15.Text = "Total Neto :";
            // 
            // txtPensionMonto
            // 
            this.txtPensionMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPensionMonto.Location = new System.Drawing.Point(127, 298);
            this.txtPensionMonto.Name = "txtPensionMonto";
            this.txtPensionMonto.ReadOnly = true;
            this.txtPensionMonto.Size = new System.Drawing.Size(59, 20);
            this.txtPensionMonto.TabIndex = 124;
            this.txtPensionMonto.Text = "0.00";
            this.txtPensionMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 300);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 123;
            this.label13.Text = "Pensión :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRetencionJudicial
            // 
            this.txtRetencionJudicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRetencionJudicial.Location = new System.Drawing.Point(127, 324);
            this.txtRetencionJudicial.Name = "txtRetencionJudicial";
            this.txtRetencionJudicial.ReadOnly = true;
            this.txtRetencionJudicial.Size = new System.Drawing.Size(59, 20);
            this.txtRetencionJudicial.TabIndex = 122;
            this.txtRetencionJudicial.Text = "0.00";
            this.txtRetencionJudicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 327);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 121;
            this.label12.Text = "Ret. Judicial :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSueldo
            // 
            this.txtSueldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSueldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSueldo.Location = new System.Drawing.Point(127, 97);
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.ReadOnly = true;
            this.txtSueldo.Size = new System.Drawing.Size(59, 20);
            this.txtSueldo.TabIndex = 67;
            this.txtSueldo.Text = "0.00";
            this.txtSueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAsignacionFamiliar
            // 
            this.txtAsignacionFamiliar.Location = new System.Drawing.Point(127, 123);
            this.txtAsignacionFamiliar.Name = "txtAsignacionFamiliar";
            this.txtAsignacionFamiliar.ReadOnly = true;
            this.txtAsignacionFamiliar.Size = new System.Drawing.Size(59, 20);
            this.txtAsignacionFamiliar.TabIndex = 117;
            this.txtAsignacionFamiliar.Text = "0.00";
            this.txtAsignacionFamiliar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 116;
            this.label10.Text = "Asig. Fam. :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 114;
            this.label9.Text = "Sueldo :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPeriodoInicio
            // 
            this.txtPeriodoInicio.Location = new System.Drawing.Point(91, 45);
            this.txtPeriodoInicio.Name = "txtPeriodoInicio";
            this.txtPeriodoInicio.ReadOnly = true;
            this.txtPeriodoInicio.Size = new System.Drawing.Size(95, 20);
            this.txtPeriodoInicio.TabIndex = 111;
            this.txtPeriodoInicio.Text = "01/01/2017";
            this.txtPeriodoInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 113;
            this.label6.Text = "Al";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "Descanso :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPeriodoFinal
            // 
            this.txtPeriodoFinal.Location = new System.Drawing.Point(202, 45);
            this.txtPeriodoFinal.Name = "txtPeriodoFinal";
            this.txtPeriodoFinal.ReadOnly = true;
            this.txtPeriodoFinal.Size = new System.Drawing.Size(95, 20);
            this.txtPeriodoFinal.TabIndex = 112;
            this.txtPeriodoFinal.Text = "01/01/2017";
            this.txtPeriodoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Al";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 110;
            this.label5.Text = "Periodo :";
            // 
            // txtDescansoDias
            // 
            this.txtDescansoDias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescansoDias.Location = new System.Drawing.Point(441, 71);
            this.txtDescansoDias.Name = "txtDescansoDias";
            this.txtDescansoDias.ReadOnly = true;
            this.txtDescansoDias.Size = new System.Drawing.Size(23, 20);
            this.txtDescansoDias.TabIndex = 107;
            this.txtDescansoDias.Text = "30";
            this.txtDescansoDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescansoFin
            // 
            this.txtDescansoFin.Location = new System.Drawing.Point(202, 71);
            this.txtDescansoFin.Name = "txtDescansoFin";
            this.txtDescansoFin.ReadOnly = true;
            this.txtDescansoFin.Size = new System.Drawing.Size(95, 20);
            this.txtDescansoFin.TabIndex = 109;
            this.txtDescansoFin.Text = "01/01/2017";
            this.txtDescansoFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 108;
            this.label4.Text = "Días";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(412, 426);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Location = new System.Drawing.Point(306, 426);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 30);
            this.btnImprimir.TabIndex = 117;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FrmVacacionVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 468);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grpVacacion);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.Name = "FrmVacacionVer";
            this.Text = "Visualización del Calculo de Vacaciones";
            this.Load += new System.EventHandler(this.FrmVacacionVer_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmVacacionVer_ResizeEnd);
            this.grpVacacion.ResumeLayout(false);
            this.grpVacacion.PerformLayout();
            this.grpPromedios.ResumeLayout(false);
            this.grpPromedios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpVacacion;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDescansoInicio;
        private System.Windows.Forms.TextBox txtPensionTipo;
        private System.Windows.Forms.TextBox txtPensionDescipcion;
        private System.Windows.Forms.TextBox txtTotalBruto;
        internal System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalNeto;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPensionMonto;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRetencionJudicial;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPromedioHorasExtras;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.TextBox txtPromedioBonificaciones;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAsignacionFamiliar;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPeriodoInicio;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPeriodoFinal;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescansoDias;
        private System.Windows.Forms.TextBox txtDescansoFin;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.TextBox txtPensionPorcentaje;
        private System.Windows.Forms.TextBox txtTotalDescuento;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpPromedios;
        private System.Windows.Forms.Button btnImprimir;
    }
}