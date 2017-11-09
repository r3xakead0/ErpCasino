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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInasistencia = new System.Windows.Forms.TextBox();
            this.txtAsistenciaFeriado = new System.Windows.Forms.TextBox();
            this.txtAsistenciaNormal = new System.Windows.Forms.TextBox();
            this.cboCalculoPor = new System.Windows.Forms.ComboBox();
            this.lblCalculoPor = new System.Windows.Forms.Label();
            this.txtRegistrosAsistencias = new System.Windows.Forms.TextBox();
            this.lblRegistrosAsistencias = new System.Windows.Forms.Label();
            this.dgvAsistencias = new System.Windows.Forms.DataGridView();
            this.tbpCostos = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cboCostoPor = new System.Windows.Forms.ComboBox();
            this.lblCostoPor = new System.Windows.Forms.Label();
            this.txtRegistrosCostos = new System.Windows.Forms.TextBox();
            this.lblRegistrosCostos = new System.Windows.Forms.Label();
            this.dgvCostos = new System.Windows.Forms.DataGridView();
            this.GrpPeriodo = new System.Windows.Forms.GroupBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.CbxMes = new System.Windows.Forms.ComboBox();
            this.CboAnho = new System.Windows.Forms.ComboBox();
            this.LblFechaHora = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.btnExportarCostoCsv = new System.Windows.Forms.Button();
            this.btnExportarAsistenciasCsv = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.tbcPlanilla.SuspendLayout();
            this.tbpAsistencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).BeginInit();
            this.tbpCostos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).BeginInit();
            this.GrpPeriodo.SuspendLayout();
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
            this.pnlPrincipal.Controls.Add(this.GrpPeriodo);
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
            this.tbcPlanilla.Location = new System.Drawing.Point(9, 69);
            this.tbcPlanilla.Name = "tbcPlanilla";
            this.tbcPlanilla.SelectedIndex = 0;
            this.tbcPlanilla.Size = new System.Drawing.Size(964, 334);
            this.tbcPlanilla.TabIndex = 41;
            // 
            // tbpAsistencias
            // 
            this.tbpAsistencias.Controls.Add(this.btnExportarAsistenciasCsv);
            this.tbpAsistencias.Controls.Add(this.label1);
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
            this.tbpAsistencias.Size = new System.Drawing.Size(956, 308);
            this.tbpAsistencias.TabIndex = 0;
            this.tbpAsistencias.Text = "Asistencias";
            this.tbpAsistencias.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(839, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Leyenda :";
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
            this.cboCalculoPor.Location = new System.Drawing.Point(839, 242);
            this.cboCalculoPor.Name = "cboCalculoPor";
            this.cboCalculoPor.Size = new System.Drawing.Size(111, 21);
            this.cboCalculoPor.TabIndex = 55;
            this.cboCalculoPor.SelectionChangeCommitted += new System.EventHandler(this.cboCalculoPor_SelectionChangeCommitted);
            // 
            // lblCalculoPor
            // 
            this.lblCalculoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCalculoPor.AutoSize = true;
            this.lblCalculoPor.Location = new System.Drawing.Point(839, 226);
            this.lblCalculoPor.Name = "lblCalculoPor";
            this.lblCalculoPor.Size = new System.Drawing.Size(66, 13);
            this.lblCalculoPor.TabIndex = 53;
            this.lblCalculoPor.Text = "Calculo por :";
            // 
            // txtRegistrosAsistencias
            // 
            this.txtRegistrosAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistrosAsistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistrosAsistencias.Location = new System.Drawing.Point(839, 282);
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
            this.lblRegistrosAsistencias.Location = new System.Drawing.Point(839, 266);
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
            this.dgvAsistencias.Size = new System.Drawing.Size(827, 296);
            this.dgvAsistencias.TabIndex = 40;
            // 
            // tbpCostos
            // 
            this.tbpCostos.Controls.Add(this.btnExportarCostoCsv);
            this.tbpCostos.Controls.Add(this.label3);
            this.tbpCostos.Controls.Add(this.textBox5);
            this.tbpCostos.Controls.Add(this.textBox4);
            this.tbpCostos.Controls.Add(this.label2);
            this.tbpCostos.Controls.Add(this.textBox1);
            this.tbpCostos.Controls.Add(this.textBox2);
            this.tbpCostos.Controls.Add(this.textBox3);
            this.tbpCostos.Controls.Add(this.cboCostoPor);
            this.tbpCostos.Controls.Add(this.lblCostoPor);
            this.tbpCostos.Controls.Add(this.txtRegistrosCostos);
            this.tbpCostos.Controls.Add(this.lblRegistrosCostos);
            this.tbpCostos.Controls.Add(this.dgvCostos);
            this.tbpCostos.Location = new System.Drawing.Point(4, 22);
            this.tbpCostos.Name = "tbpCostos";
            this.tbpCostos.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCostos.Size = new System.Drawing.Size(956, 308);
            this.tbpCostos.TabIndex = 1;
            this.tbpCostos.Text = "Costos";
            this.tbpCostos.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(838, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Leyenda Descuentos :";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.BackColor = System.Drawing.Color.Yellow;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(838, 120);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(111, 20);
            this.textBox5.TabIndex = 66;
            this.textBox5.Text = "Tardanza Feriado";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.BackColor = System.Drawing.Color.Red;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(838, 146);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(111, 20);
            this.textBox4.TabIndex = 65;
            this.textBox4.Text = "Inasistencia";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(838, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Leyenda Costos :";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.Green;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(838, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 20);
            this.textBox1.TabIndex = 63;
            this.textBox1.Text = "Tardanza Normal";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.LightYellow;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(838, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(111, 20);
            this.textBox2.TabIndex = 62;
            this.textBox2.Text = "Asistencia Feriado";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.LightGreen;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(838, 22);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(111, 20);
            this.textBox3.TabIndex = 61;
            this.textBox3.Text = "Asistencia Normal";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboCostoPor
            // 
            this.cboCostoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCostoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCostoPor.FormattingEnabled = true;
            this.cboCostoPor.Location = new System.Drawing.Point(838, 232);
            this.cboCostoPor.Name = "cboCostoPor";
            this.cboCostoPor.Size = new System.Drawing.Size(111, 21);
            this.cboCostoPor.TabIndex = 52;
            this.cboCostoPor.SelectionChangeCommitted += new System.EventHandler(this.cboCostoPor_SelectionChangeCommitted);
            // 
            // lblCostoPor
            // 
            this.lblCostoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCostoPor.AutoSize = true;
            this.lblCostoPor.Location = new System.Drawing.Point(839, 216);
            this.lblCostoPor.Name = "lblCostoPor";
            this.lblCostoPor.Size = new System.Drawing.Size(58, 13);
            this.lblCostoPor.TabIndex = 51;
            this.lblCostoPor.Text = "Costo por :";
            // 
            // txtRegistrosCostos
            // 
            this.txtRegistrosCostos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistrosCostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistrosCostos.Location = new System.Drawing.Point(838, 272);
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
            this.lblRegistrosCostos.Location = new System.Drawing.Point(838, 256);
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
            this.dgvCostos.Size = new System.Drawing.Size(826, 286);
            this.dgvCostos.TabIndex = 41;
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
            this.GrpPeriodo.Size = new System.Drawing.Size(960, 60);
            this.GrpPeriodo.TabIndex = 39;
            this.GrpPeriodo.TabStop = false;
            this.GrpPeriodo.Text = "Periodo";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscar.Location = new System.Drawing.Point(845, 17);
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
            this.CbxMes.Size = new System.Drawing.Size(241, 21);
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
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.BtnGenerate);
            this.pnlBotones.Controls.Add(this.BtnCancel);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotones.Location = new System.Drawing.Point(3, 415);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(980, 44);
            this.pnlBotones.TabIndex = 17;
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGenerate.Location = new System.Drawing.Point(871, 5);
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
            this.BtnCancel.Location = new System.Drawing.Point(765, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnExportarCostoCsv
            // 
            this.btnExportarCostoCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarCostoCsv.Location = new System.Drawing.Point(838, 192);
            this.btnExportarCostoCsv.Name = "btnExportarCostoCsv";
            this.btnExportarCostoCsv.Size = new System.Drawing.Size(111, 21);
            this.btnExportarCostoCsv.TabIndex = 90;
            this.btnExportarCostoCsv.Text = "Exportar CSV";
            this.btnExportarCostoCsv.UseVisualStyleBackColor = true;
            this.btnExportarCostoCsv.Click += new System.EventHandler(this.btnExportarCostoCsv_Click);
            // 
            // btnExportarAsistenciasCsv
            // 
            this.btnExportarAsistenciasCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarAsistenciasCsv.Location = new System.Drawing.Point(839, 202);
            this.btnExportarAsistenciasCsv.Name = "btnExportarAsistenciasCsv";
            this.btnExportarAsistenciasCsv.Size = new System.Drawing.Size(111, 21);
            this.btnExportarAsistenciasCsv.TabIndex = 91;
            this.btnExportarAsistenciasCsv.Text = "Exportar CSV";
            this.btnExportarAsistenciasCsv.UseVisualStyleBackColor = true;
            this.btnExportarAsistenciasCsv.Click += new System.EventHandler(this.btnExportarAsistenciasCsv_Click);
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
            this.Load += new System.EventHandler(this.FrmAfpComisionMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.tbcPlanilla.ResumeLayout(false);
            this.tbpAsistencias.ResumeLayout(false);
            this.tbpAsistencias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).EndInit();
            this.tbpCostos.ResumeLayout(false);
            this.tbpCostos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).EndInit();
            this.GrpPeriodo.ResumeLayout(false);
            this.GrpPeriodo.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        internal System.Windows.Forms.Label LblFechaHora;
        private System.Windows.Forms.Panel pnlBotones;
        public System.Windows.Forms.Button BtnGenerate;
        public System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox GrpPeriodo;
        private System.Windows.Forms.ComboBox CbxMes;
        private System.Windows.Forms.ComboBox CboAnho;
        private System.Windows.Forms.DataGridView dgvAsistencias;
        public System.Windows.Forms.Button BtnBuscar;
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
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInasistencia;
        private System.Windows.Forms.TextBox txtAsistenciaFeriado;
        private System.Windows.Forms.TextBox txtAsistenciaNormal;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        internal System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnExportarAsistenciasCsv;
        public System.Windows.Forms.Button btnExportarCostoCsv;
    }
}