namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmHorarioSemanalMant
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
            this.PnlFormulario = new System.Windows.Forms.Panel();
            this.grpDatosHorario = new System.Windows.Forms.GroupBox();
            this.txtEmpleadoCodigo = new System.Windows.Forms.TextBox();
            this.btnHorarioLimpiar = new System.Windows.Forms.Button();
            this.txtHoras = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.LblCargo = new System.Windows.Forms.Label();
            this.CboCargo = new System.Windows.Forms.ComboBox();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFechaDia = new System.Windows.Forms.TextBox();
            this.btnHorarioAgregar = new System.Windows.Forms.Button();
            this.nudTurno = new System.Windows.Forms.NumericUpDown();
            this.LblTurno = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.CboDia = new System.Windows.Forms.ComboBox();
            this.dtpTurnoDesde = new System.Windows.Forms.DateTimePicker();
            this.LblDia = new System.Windows.Forms.Label();
            this.dtpTurnoHasta = new System.Windows.Forms.DateTimePicker();
            this.grpHorarios = new System.Windows.Forms.GroupBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblHorarios = new System.Windows.Forms.Label();
            this.txtNroRegistros = new System.Windows.Forms.TextBox();
            this.lblNroRegistros = new System.Windows.Forms.Label();
            this.dgvHorarios = new System.Windows.Forms.DataGridView();
            this.btnHorarioQuitar = new System.Windows.Forms.Button();
            this.grpDatosSemana = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.LblAnho = new System.Windows.Forms.Label();
            this.LblSala = new System.Windows.Forms.Label();
            this.LblSemana = new System.Windows.Forms.Label();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.cboSemana = new System.Windows.Forms.ComboBox();
            this.cboSala = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRangoFechas = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PnlBotones = new System.Windows.Forms.Panel();
            this.btnVista = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.PnlFormulario.SuspendLayout();
            this.grpDatosHorario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTurno)).BeginInit();
            this.grpHorarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).BeginInit();
            this.grpDatosSemana.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.PnlFormulario, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(991, 492);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // PnlFormulario
            // 
            this.PnlFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlFormulario.Controls.Add(this.grpDatosHorario);
            this.PnlFormulario.Controls.Add(this.grpHorarios);
            this.PnlFormulario.Controls.Add(this.grpDatosSemana);
            this.PnlFormulario.Location = new System.Drawing.Point(3, 3);
            this.PnlFormulario.Name = "PnlFormulario";
            this.PnlFormulario.Size = new System.Drawing.Size(985, 436);
            this.PnlFormulario.TabIndex = 16;
            // 
            // grpDatosHorario
            // 
            this.grpDatosHorario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDatosHorario.Controls.Add(this.txtEmpleadoCodigo);
            this.grpDatosHorario.Controls.Add(this.btnHorarioLimpiar);
            this.grpDatosHorario.Controls.Add(this.txtHoras);
            this.grpDatosHorario.Controls.Add(this.label4);
            this.grpDatosHorario.Controls.Add(this.lblHasta);
            this.grpDatosHorario.Controls.Add(this.LblCargo);
            this.grpDatosHorario.Controls.Add(this.CboCargo);
            this.grpDatosHorario.Controls.Add(this.cboEmpleado);
            this.grpDatosHorario.Controls.Add(this.label3);
            this.grpDatosHorario.Controls.Add(this.label2);
            this.grpDatosHorario.Controls.Add(this.txtFechaDia);
            this.grpDatosHorario.Controls.Add(this.btnHorarioAgregar);
            this.grpDatosHorario.Controls.Add(this.nudTurno);
            this.grpDatosHorario.Controls.Add(this.LblTurno);
            this.grpDatosHorario.Controls.Add(this.lblDesde);
            this.grpDatosHorario.Controls.Add(this.CboDia);
            this.grpDatosHorario.Controls.Add(this.dtpTurnoDesde);
            this.grpDatosHorario.Controls.Add(this.LblDia);
            this.grpDatosHorario.Controls.Add(this.dtpTurnoHasta);
            this.grpDatosHorario.Enabled = false;
            this.grpDatosHorario.Location = new System.Drawing.Point(10, 320);
            this.grpDatosHorario.Name = "grpDatosHorario";
            this.grpDatosHorario.Size = new System.Drawing.Size(966, 113);
            this.grpDatosHorario.TabIndex = 82;
            this.grpDatosHorario.TabStop = false;
            this.grpDatosHorario.Text = "Dato del Horario";
            // 
            // txtEmpleadoCodigo
            // 
            this.txtEmpleadoCodigo.Location = new System.Drawing.Point(100, 78);
            this.txtEmpleadoCodigo.Name = "txtEmpleadoCodigo";
            this.txtEmpleadoCodigo.Size = new System.Drawing.Size(142, 20);
            this.txtEmpleadoCodigo.TabIndex = 84;
            this.txtEmpleadoCodigo.Leave += new System.EventHandler(this.txtEmpleadoCodigo_Leave);
            // 
            // btnHorarioLimpiar
            // 
            this.btnHorarioLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHorarioLimpiar.Location = new System.Drawing.Point(866, 50);
            this.btnHorarioLimpiar.Name = "btnHorarioLimpiar";
            this.btnHorarioLimpiar.Size = new System.Drawing.Size(81, 21);
            this.btnHorarioLimpiar.TabIndex = 83;
            this.btnHorarioLimpiar.Text = "Limpiar";
            this.btnHorarioLimpiar.UseVisualStyleBackColor = true;
            this.btnHorarioLimpiar.Click += new System.EventHandler(this.btnHorarioLimpiar_Click);
            // 
            // txtHoras
            // 
            this.txtHoras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoras.Location = new System.Drawing.Point(771, 25);
            this.txtHoras.Name = "txtHoras";
            this.txtHoras.ReadOnly = true;
            this.txtHoras.Size = new System.Drawing.Size(46, 20);
            this.txtHoras.TabIndex = 81;
            this.txtHoras.Text = "0";
            this.txtHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(819, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 82;
            this.label4.Text = "Hrs";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHasta
            // 
            this.lblHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(649, 81);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 80;
            this.lblHasta.Text = "Hasta:";
            // 
            // LblCargo
            // 
            this.LblCargo.AutoSize = true;
            this.LblCargo.Location = new System.Drawing.Point(23, 27);
            this.LblCargo.Name = "LblCargo";
            this.LblCargo.Size = new System.Drawing.Size(38, 13);
            this.LblCargo.TabIndex = 58;
            this.LblCargo.Text = "Cargo:";
            // 
            // CboCargo
            // 
            this.CboCargo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CboCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboCargo.FormattingEnabled = true;
            this.CboCargo.Location = new System.Drawing.Point(100, 24);
            this.CboCargo.Name = "CboCargo";
            this.CboCargo.Size = new System.Drawing.Size(481, 21);
            this.CboCargo.TabIndex = 59;
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(248, 78);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(333, 21);
            this.cboEmpleado.TabIndex = 61;
            this.cboEmpleado.SelectionChangeCommitted += new System.EventHandler(this.cboEmpleado_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Empleado:";
            // 
            // txtFechaDia
            // 
            this.txtFechaDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFechaDia.Location = new System.Drawing.Point(439, 51);
            this.txtFechaDia.Name = "txtFechaDia";
            this.txtFechaDia.ReadOnly = true;
            this.txtFechaDia.Size = new System.Drawing.Size(142, 20);
            this.txtFechaDia.TabIndex = 78;
            this.txtFechaDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnHorarioAgregar
            // 
            this.btnHorarioAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHorarioAgregar.Location = new System.Drawing.Point(866, 23);
            this.btnHorarioAgregar.Name = "btnHorarioAgregar";
            this.btnHorarioAgregar.Size = new System.Drawing.Size(81, 21);
            this.btnHorarioAgregar.TabIndex = 19;
            this.btnHorarioAgregar.Text = "Agregar";
            this.btnHorarioAgregar.UseVisualStyleBackColor = true;
            this.btnHorarioAgregar.Click += new System.EventHandler(this.btnHorarioAgregar_Click);
            // 
            // nudTurno
            // 
            this.nudTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTurno.Location = new System.Drawing.Point(726, 25);
            this.nudTurno.Name = "nudTurno";
            this.nudTurno.Size = new System.Drawing.Size(39, 20);
            this.nudTurno.TabIndex = 77;
            this.nudTurno.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LblTurno
            // 
            this.LblTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTurno.AutoSize = true;
            this.LblTurno.Location = new System.Drawing.Point(649, 27);
            this.LblTurno.Name = "LblTurno";
            this.LblTurno.Size = new System.Drawing.Size(38, 13);
            this.LblTurno.TabIndex = 76;
            this.LblTurno.Text = "Turno:";
            // 
            // lblDesde
            // 
            this.lblDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(649, 54);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 63;
            this.lblDesde.Text = "Desde:";
            // 
            // CboDia
            // 
            this.CboDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboDia.FormattingEnabled = true;
            this.CboDia.Location = new System.Drawing.Point(100, 51);
            this.CboDia.Name = "CboDia";
            this.CboDia.Size = new System.Drawing.Size(142, 21);
            this.CboDia.TabIndex = 75;
            this.CboDia.SelectionChangeCommitted += new System.EventHandler(this.CboDia_SelectionChangeCommitted);
            // 
            // dtpTurnoDesde
            // 
            this.dtpTurnoDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTurnoDesde.CustomFormat = "dd/MM/yyyy - HH:mm";
            this.dtpTurnoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTurnoDesde.Location = new System.Drawing.Point(726, 51);
            this.dtpTurnoDesde.Name = "dtpTurnoDesde";
            this.dtpTurnoDesde.ShowUpDown = true;
            this.dtpTurnoDesde.Size = new System.Drawing.Size(116, 20);
            this.dtpTurnoDesde.TabIndex = 64;
            this.dtpTurnoDesde.ValueChanged += new System.EventHandler(this.dtpTurnoDesdeHasta_ValueChanged);
            // 
            // LblDia
            // 
            this.LblDia.AutoSize = true;
            this.LblDia.Location = new System.Drawing.Point(23, 54);
            this.LblDia.Name = "LblDia";
            this.LblDia.Size = new System.Drawing.Size(26, 13);
            this.LblDia.TabIndex = 74;
            this.LblDia.Text = "Dia:";
            // 
            // dtpTurnoHasta
            // 
            this.dtpTurnoHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTurnoHasta.CustomFormat = "dd/MM/yyyy - HH:mm";
            this.dtpTurnoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTurnoHasta.Location = new System.Drawing.Point(726, 78);
            this.dtpTurnoHasta.Name = "dtpTurnoHasta";
            this.dtpTurnoHasta.ShowUpDown = true;
            this.dtpTurnoHasta.Size = new System.Drawing.Size(116, 20);
            this.dtpTurnoHasta.TabIndex = 65;
            this.dtpTurnoHasta.ValueChanged += new System.EventHandler(this.dtpTurnoDesdeHasta_ValueChanged);
            // 
            // grpHorarios
            // 
            this.grpHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHorarios.Controls.Add(this.btnEditar);
            this.grpHorarios.Controls.Add(this.lblHorarios);
            this.grpHorarios.Controls.Add(this.txtNroRegistros);
            this.grpHorarios.Controls.Add(this.lblNroRegistros);
            this.grpHorarios.Controls.Add(this.dgvHorarios);
            this.grpHorarios.Controls.Add(this.btnHorarioQuitar);
            this.grpHorarios.Location = new System.Drawing.Point(10, 106);
            this.grpHorarios.Name = "grpHorarios";
            this.grpHorarios.Size = new System.Drawing.Size(966, 208);
            this.grpHorarios.TabIndex = 81;
            this.grpHorarios.TabStop = false;
            this.grpHorarios.Text = "Horarios";
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.Location = new System.Drawing.Point(93, 181);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(81, 21);
            this.btnEditar.TabIndex = 66;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblHorarios
            // 
            this.lblHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorarios.BackColor = System.Drawing.Color.Navy;
            this.lblHorarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorarios.ForeColor = System.Drawing.Color.White;
            this.lblHorarios.Location = new System.Drawing.Point(6, 16);
            this.lblHorarios.Name = "lblHorarios";
            this.lblHorarios.Size = new System.Drawing.Size(954, 13);
            this.lblHorarios.TabIndex = 65;
            this.lblHorarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNroRegistros
            // 
            this.txtNroRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNroRegistros.Location = new System.Drawing.Point(905, 182);
            this.txtNroRegistros.Name = "txtNroRegistros";
            this.txtNroRegistros.ReadOnly = true;
            this.txtNroRegistros.Size = new System.Drawing.Size(55, 20);
            this.txtNroRegistros.TabIndex = 64;
            this.txtNroRegistros.Text = "0";
            this.txtNroRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNroRegistros
            // 
            this.lblNroRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNroRegistros.AutoSize = true;
            this.lblNroRegistros.Location = new System.Drawing.Point(822, 185);
            this.lblNroRegistros.Name = "lblNroRegistros";
            this.lblNroRegistros.Size = new System.Drawing.Size(77, 13);
            this.lblNroRegistros.TabIndex = 63;
            this.lblNroRegistros.Text = "Nro. Registros:";
            // 
            // dgvHorarios
            // 
            this.dgvHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorarios.Location = new System.Drawing.Point(6, 32);
            this.dgvHorarios.Name = "dgvHorarios";
            this.dgvHorarios.Size = new System.Drawing.Size(954, 145);
            this.dgvHorarios.TabIndex = 54;
            // 
            // btnHorarioQuitar
            // 
            this.btnHorarioQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHorarioQuitar.Location = new System.Drawing.Point(6, 181);
            this.btnHorarioQuitar.Name = "btnHorarioQuitar";
            this.btnHorarioQuitar.Size = new System.Drawing.Size(81, 21);
            this.btnHorarioQuitar.TabIndex = 62;
            this.btnHorarioQuitar.Text = "Quitar";
            this.btnHorarioQuitar.UseVisualStyleBackColor = true;
            this.btnHorarioQuitar.Click += new System.EventHandler(this.btnHorarioQuitar_Click);
            // 
            // grpDatosSemana
            // 
            this.grpDatosSemana.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDatosSemana.Controls.Add(this.btnBuscar);
            this.grpDatosSemana.Controls.Add(this.LblAnho);
            this.grpDatosSemana.Controls.Add(this.LblSala);
            this.grpDatosSemana.Controls.Add(this.LblSemana);
            this.grpDatosSemana.Controls.Add(this.cboAnho);
            this.grpDatosSemana.Controls.Add(this.cboSemana);
            this.grpDatosSemana.Controls.Add(this.cboSala);
            this.grpDatosSemana.Controls.Add(this.label1);
            this.grpDatosSemana.Controls.Add(this.txtRangoFechas);
            this.grpDatosSemana.Location = new System.Drawing.Point(9, 9);
            this.grpDatosSemana.Name = "grpDatosSemana";
            this.grpDatosSemana.Size = new System.Drawing.Size(967, 91);
            this.grpDatosSemana.TabIndex = 80;
            this.grpDatosSemana.TabStop = false;
            this.grpDatosSemana.Text = "Filtro de Horario Semanal";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(867, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(81, 47);
            this.btnBuscar.TabIndex = 57;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // LblAnho
            // 
            this.LblAnho.AutoSize = true;
            this.LblAnho.Location = new System.Drawing.Point(23, 30);
            this.LblAnho.Name = "LblAnho";
            this.LblAnho.Size = new System.Drawing.Size(29, 13);
            this.LblAnho.TabIndex = 19;
            this.LblAnho.Text = "Año:";
            // 
            // LblSala
            // 
            this.LblSala.AutoSize = true;
            this.LblSala.Location = new System.Drawing.Point(285, 30);
            this.LblSala.Name = "LblSala";
            this.LblSala.Size = new System.Drawing.Size(31, 13);
            this.LblSala.TabIndex = 25;
            this.LblSala.Text = "Sala:";
            // 
            // LblSemana
            // 
            this.LblSemana.AutoSize = true;
            this.LblSemana.Location = new System.Drawing.Point(24, 57);
            this.LblSemana.Name = "LblSemana";
            this.LblSemana.Size = new System.Drawing.Size(49, 13);
            this.LblSemana.TabIndex = 22;
            this.LblSemana.Text = "Semana:";
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(141, 27);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(84, 21);
            this.cboAnho.TabIndex = 43;
            this.cboAnho.SelectionChangeCommitted += new System.EventHandler(this.cboAnhoSemana_SelectionChangeCommitted);
            // 
            // cboSemana
            // 
            this.cboSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemana.FormattingEnabled = true;
            this.cboSemana.Location = new System.Drawing.Point(142, 54);
            this.cboSemana.Name = "cboSemana";
            this.cboSemana.Size = new System.Drawing.Size(84, 21);
            this.cboSemana.TabIndex = 44;
            this.cboSemana.SelectionChangeCommitted += new System.EventHandler(this.cboAnhoSemana_SelectionChangeCommitted);
            // 
            // cboSala
            // 
            this.cboSala.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSala.FormattingEnabled = true;
            this.cboSala.Location = new System.Drawing.Point(403, 27);
            this.cboSala.Name = "cboSala";
            this.cboSala.Size = new System.Drawing.Size(403, 21);
            this.cboSala.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Rango de la Semana:";
            // 
            // txtRangoFechas
            // 
            this.txtRangoFechas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRangoFechas.Location = new System.Drawing.Point(403, 54);
            this.txtRangoFechas.Name = "txtRangoFechas";
            this.txtRangoFechas.ReadOnly = true;
            this.txtRangoFechas.Size = new System.Drawing.Size(403, 20);
            this.txtRangoFechas.TabIndex = 56;
            this.txtRangoFechas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PnlBotones);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 445);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(985, 44);
            this.panel2.TabIndex = 17;
            // 
            // PnlBotones
            // 
            this.PnlBotones.Controls.Add(this.btnVista);
            this.PnlBotones.Controls.Add(this.BtnSave);
            this.PnlBotones.Controls.Add(this.BtnCancel);
            this.PnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBotones.Location = new System.Drawing.Point(0, 0);
            this.PnlBotones.Name = "PnlBotones";
            this.PnlBotones.Size = new System.Drawing.Size(985, 44);
            this.PnlBotones.TabIndex = 20;
            // 
            // btnVista
            // 
            this.btnVista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVista.Location = new System.Drawing.Point(662, 5);
            this.btnVista.Name = "btnVista";
            this.btnVista.Size = new System.Drawing.Size(100, 30);
            this.btnVista.TabIndex = 19;
            this.btnVista.Text = "Vista";
            this.btnVista.UseVisualStyleBackColor = true;
            this.btnVista.Click += new System.EventHandler(this.btnVista_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(876, 5);
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
            this.BtnCancel.Location = new System.Drawing.Point(770, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(542, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 30);
            this.button3.TabIndex = 19;
            this.button3.Text = "Personalizar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(662, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 18;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FrmHorarioSemanalMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 492);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "FrmHorarioSemanalMant";
            this.Text = "Mantenimiento de Horario Semanal";
            this.Load += new System.EventHandler(this.FrmHorarioSemanalMant_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmHorarioSemanalMant_ResizeEnd);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.PnlFormulario.ResumeLayout(false);
            this.grpDatosHorario.ResumeLayout(false);
            this.grpDatosHorario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTurno)).EndInit();
            this.grpHorarios.ResumeLayout(false);
            this.grpHorarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).EndInit();
            this.grpDatosSemana.ResumeLayout(false);
            this.grpDatosSemana.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.PnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel PnlFormulario;
        public System.Windows.Forms.ComboBox cboSala;
        public System.Windows.Forms.ComboBox CboCargo;
        public System.Windows.Forms.ComboBox cboSemana;
        public System.Windows.Forms.ComboBox cboAnho;
        private System.Windows.Forms.TextBox txtRangoFechas;
        internal System.Windows.Forms.Label LblAnho;
        internal System.Windows.Forms.Label LblSemana;
        internal System.Windows.Forms.Label LblSala;
        private System.Windows.Forms.DataGridView dgvHorarios;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label LblCargo;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboEmpleado;
        public System.Windows.Forms.Button btnHorarioAgregar;
        public System.Windows.Forms.Button btnHorarioQuitar;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtpTurnoHasta;
        private System.Windows.Forms.DateTimePicker dtpTurnoDesde;
        internal System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.TextBox txtFechaDia;
        private System.Windows.Forms.NumericUpDown nudTurno;
        internal System.Windows.Forms.Label LblTurno;
        public System.Windows.Forms.ComboBox CboDia;
        internal System.Windows.Forms.Label LblDia;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpHorarios;
        private System.Windows.Forms.GroupBox grpDatosSemana;
        private System.Windows.Forms.GroupBox grpDatosHorario;
        internal System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PnlBotones;
        public System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox txtHoras;
        internal System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnHorarioLimpiar;
        private System.Windows.Forms.TextBox txtNroRegistros;
        internal System.Windows.Forms.Label lblNroRegistros;
        public System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.Label lblHorarios;
        public System.Windows.Forms.Button btnVista;
        private System.Windows.Forms.TextBox txtEmpleadoCodigo;
        public System.Windows.Forms.Button btnEditar;
    }
}