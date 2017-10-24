namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmPlanillaDetalleAsistencia
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
            this.dgvAsistencias = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblTituloAsistencias = new System.Windows.Forms.Label();
            this.txtNroRegistros = new System.Windows.Forms.TextBox();
            this.lblNroRegistros = new System.Windows.Forms.Label();
            this.cboCalculoPor = new System.Windows.Forms.ComboBox();
            this.lblCalculoPor = new System.Windows.Forms.Label();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.grpFiltro = new System.Windows.Forms.GroupBox();
            this.cboHorario = new System.Windows.Forms.ComboBox();
            this.lblHorario = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpleadoCodigo = new System.Windows.Forms.TextBox();
            this.txtEmpleadoNombres = new System.Windows.Forms.TextBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).BeginInit();
            this.tlpPrincipal.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.grpFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAsistencias
            // 
            this.dgvAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencias.Location = new System.Drawing.Point(3, 22);
            this.dgvAsistencias.Name = "dgvAsistencias";
            this.dgvAsistencias.Size = new System.Drawing.Size(747, 191);
            this.dgvAsistencias.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCerrar.Location = new System.Drawing.Point(644, 5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlInferior, 0, 2);
            this.tlpPrincipal.Controls.Add(this.pnlSuperior, 0, 1);
            this.tlpPrincipal.Controls.Add(this.pnlCabecera, 0, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPrincipal.Size = new System.Drawing.Size(759, 389);
            this.tlpPrincipal.TabIndex = 19;
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnCerrar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 342);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(753, 44);
            this.pnlInferior.TabIndex = 1;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.lblTituloAsistencias);
            this.pnlSuperior.Controls.Add(this.txtNroRegistros);
            this.pnlSuperior.Controls.Add(this.lblNroRegistros);
            this.pnlSuperior.Controls.Add(this.cboCalculoPor);
            this.pnlSuperior.Controls.Add(this.lblCalculoPor);
            this.pnlSuperior.Controls.Add(this.dgvAsistencias);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSuperior.Location = new System.Drawing.Point(3, 93);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(753, 243);
            this.pnlSuperior.TabIndex = 0;
            // 
            // lblTituloAsistencias
            // 
            this.lblTituloAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloAsistencias.BackColor = System.Drawing.Color.Navy;
            this.lblTituloAsistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAsistencias.ForeColor = System.Drawing.Color.White;
            this.lblTituloAsistencias.Location = new System.Drawing.Point(3, 0);
            this.lblTituloAsistencias.Name = "lblTituloAsistencias";
            this.lblTituloAsistencias.Size = new System.Drawing.Size(747, 19);
            this.lblTituloAsistencias.TabIndex = 80;
            this.lblTituloAsistencias.Text = "Todas las Asistencias";
            this.lblTituloAsistencias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNroRegistros
            // 
            this.txtNroRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNroRegistros.Location = new System.Drawing.Point(676, 219);
            this.txtNroRegistros.Name = "txtNroRegistros";
            this.txtNroRegistros.ReadOnly = true;
            this.txtNroRegistros.Size = new System.Drawing.Size(74, 20);
            this.txtNroRegistros.TabIndex = 79;
            this.txtNroRegistros.Text = "0";
            this.txtNroRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNroRegistros
            // 
            this.lblNroRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNroRegistros.AutoSize = true;
            this.lblNroRegistros.Location = new System.Drawing.Point(590, 222);
            this.lblNroRegistros.Name = "lblNroRegistros";
            this.lblNroRegistros.Size = new System.Drawing.Size(80, 13);
            this.lblNroRegistros.TabIndex = 78;
            this.lblNroRegistros.Text = "Nro. Registros :";
            // 
            // cboCalculoPor
            // 
            this.cboCalculoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboCalculoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalculoPor.FormattingEnabled = true;
            this.cboCalculoPor.Location = new System.Drawing.Point(75, 218);
            this.cboCalculoPor.Name = "cboCalculoPor";
            this.cboCalculoPor.Size = new System.Drawing.Size(74, 21);
            this.cboCalculoPor.TabIndex = 77;
            this.cboCalculoPor.SelectionChangeCommitted += new System.EventHandler(this.cboCalculoPor_SelectionChangeCommitted);
            // 
            // lblCalculoPor
            // 
            this.lblCalculoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCalculoPor.AutoSize = true;
            this.lblCalculoPor.Location = new System.Drawing.Point(3, 222);
            this.lblCalculoPor.Name = "lblCalculoPor";
            this.lblCalculoPor.Size = new System.Drawing.Size(66, 13);
            this.lblCalculoPor.TabIndex = 76;
            this.lblCalculoPor.Text = "Calculo por :";
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this.grpFiltro);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCabecera.Location = new System.Drawing.Point(3, 3);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(753, 84);
            this.pnlCabecera.TabIndex = 2;
            // 
            // grpFiltro
            // 
            this.grpFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiltro.Controls.Add(this.cboHorario);
            this.grpFiltro.Controls.Add(this.lblHorario);
            this.grpFiltro.Controls.Add(this.txtPeriodo);
            this.grpFiltro.Controls.Add(this.label1);
            this.grpFiltro.Controls.Add(this.txtEmpleadoCodigo);
            this.grpFiltro.Controls.Add(this.txtEmpleadoNombres);
            this.grpFiltro.Controls.Add(this.lblEmpleado);
            this.grpFiltro.Location = new System.Drawing.Point(3, 3);
            this.grpFiltro.Name = "grpFiltro";
            this.grpFiltro.Size = new System.Drawing.Size(747, 75);
            this.grpFiltro.TabIndex = 40;
            this.grpFiltro.TabStop = false;
            this.grpFiltro.Text = "Filtros";
            // 
            // cboHorario
            // 
            this.cboHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboHorario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHorario.FormattingEnabled = true;
            this.cboHorario.Location = new System.Drawing.Point(621, 45);
            this.cboHorario.Name = "cboHorario";
            this.cboHorario.Size = new System.Drawing.Size(114, 21);
            this.cboHorario.TabIndex = 79;
            this.cboHorario.SelectionChangeCommitted += new System.EventHandler(this.cboHorario_SelectionChangeCommitted);
            // 
            // lblHorario
            // 
            this.lblHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorario.AutoSize = true;
            this.lblHorario.Location = new System.Drawing.Point(552, 48);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(47, 13);
            this.lblHorario.TabIndex = 78;
            this.lblHorario.Text = "Horario :";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(78, 45);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.ReadOnly = true;
            this.txtPeriodo.Size = new System.Drawing.Size(114, 20);
            this.txtPeriodo.TabIndex = 75;
            this.txtPeriodo.Text = "2017/05";
            this.txtPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Año/Mes :";
            // 
            // txtEmpleadoCodigo
            // 
            this.txtEmpleadoCodigo.Location = new System.Drawing.Point(78, 19);
            this.txtEmpleadoCodigo.Name = "txtEmpleadoCodigo";
            this.txtEmpleadoCodigo.ReadOnly = true;
            this.txtEmpleadoCodigo.Size = new System.Drawing.Size(114, 20);
            this.txtEmpleadoCodigo.TabIndex = 73;
            this.txtEmpleadoCodigo.Text = "GLA00000000";
            this.txtEmpleadoCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEmpleadoNombres
            // 
            this.txtEmpleadoNombres.Location = new System.Drawing.Point(197, 19);
            this.txtEmpleadoNombres.Name = "txtEmpleadoNombres";
            this.txtEmpleadoNombres.ReadOnly = true;
            this.txtEmpleadoNombres.Size = new System.Drawing.Size(538, 20);
            this.txtEmpleadoNombres.TabIndex = 72;
            this.txtEmpleadoNombres.Text = "Paterno Materno, Nombres";
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(9, 22);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(60, 13);
            this.lblEmpleado.TabIndex = 20;
            this.lblEmpleado.Text = "Empleado :";
            // 
            // FrmPlanillaDetalleAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 389);
            this.Controls.Add(this.tlpPrincipal);
            this.Name = "FrmPlanillaDetalleAsistencia";
            this.Text = "Detalle de la Asistencia en Planilla";
            this.Load += new System.EventHandler(this.FrmPlanillaDetalleAsistencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).EndInit();
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlCabecera.ResumeLayout(false);
            this.grpFiltro.ResumeLayout(false);
            this.grpFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAsistencias;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.GroupBox grpFiltro;
        private System.Windows.Forms.ComboBox cboCalculoPor;
        internal System.Windows.Forms.Label lblCalculoPor;
        private System.Windows.Forms.TextBox txtPeriodo;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmpleadoCodigo;
        private System.Windows.Forms.TextBox txtEmpleadoNombres;
        internal System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cboHorario;
        internal System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.TextBox txtNroRegistros;
        internal System.Windows.Forms.Label lblNroRegistros;
        internal System.Windows.Forms.Label lblTituloAsistencias;
    }
}