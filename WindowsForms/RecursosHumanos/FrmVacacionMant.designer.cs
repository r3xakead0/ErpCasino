﻿namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmVacacionMant
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
            this.grpDetalles = new System.Windows.Forms.GroupBox();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.grpEmpleado = new System.Windows.Forms.GroupBox();
            this.txtFechaUltimaVacacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpleadoCodigo = new System.Windows.Forms.TextBox();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.txtFechaIngreso = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInicioVacacion = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiasVacacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFinVacacion = new System.Windows.Forms.TextBox();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.grpEmpleado.SuspendLayout();
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
            this.tlpPrincipal.Size = new System.Drawing.Size(442, 424);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.grpDetalles);
            this.pnlPrincipal.Controls.Add(this.grpEmpleado);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(436, 368);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // grpDetalles
            // 
            this.grpDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetalles.Controls.Add(this.dgvDetalles);
            this.grpDetalles.Location = new System.Drawing.Point(9, 120);
            this.grpDetalles.Name = "grpDetalles";
            this.grpDetalles.Size = new System.Drawing.Size(418, 245);
            this.grpDetalles.TabIndex = 91;
            this.grpDetalles.TabStop = false;
            this.grpDetalles.Text = "Detalle";
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(12, 19);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.Size = new System.Drawing.Size(395, 211);
            this.dgvDetalles.TabIndex = 1;
            // 
            // grpEmpleado
            // 
            this.grpEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEmpleado.Controls.Add(this.txtFinVacacion);
            this.grpEmpleado.Controls.Add(this.label4);
            this.grpEmpleado.Controls.Add(this.txtDiasVacacion);
            this.grpEmpleado.Controls.Add(this.label3);
            this.grpEmpleado.Controls.Add(this.dtpInicioVacacion);
            this.grpEmpleado.Controls.Add(this.label2);
            this.grpEmpleado.Controls.Add(this.txtFechaUltimaVacacion);
            this.grpEmpleado.Controls.Add(this.label1);
            this.grpEmpleado.Controls.Add(this.txtEmpleadoCodigo);
            this.grpEmpleado.Controls.Add(this.cboEmpleado);
            this.grpEmpleado.Controls.Add(this.txtFechaIngreso);
            this.grpEmpleado.Controls.Add(this.lblMonto);
            this.grpEmpleado.Controls.Add(this.lblEmpleado);
            this.grpEmpleado.Location = new System.Drawing.Point(9, 3);
            this.grpEmpleado.Name = "grpEmpleado";
            this.grpEmpleado.Size = new System.Drawing.Size(418, 111);
            this.grpEmpleado.TabIndex = 39;
            this.grpEmpleado.TabStop = false;
            this.grpEmpleado.Text = "Empleado";
            // 
            // txtFechaUltimaVacacion
            // 
            this.txtFechaUltimaVacacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFechaUltimaVacacion.Location = new System.Drawing.Point(312, 45);
            this.txtFechaUltimaVacacion.Name = "txtFechaUltimaVacacion";
            this.txtFechaUltimaVacacion.ReadOnly = true;
            this.txtFechaUltimaVacacion.Size = new System.Drawing.Size(95, 20);
            this.txtFechaUltimaVacacion.TabIndex = 92;
            this.txtFechaUltimaVacacion.Text = "01/01/2017";
            this.txtFechaUltimaVacacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "Ultima Vacación :";
            // 
            // txtEmpleadoCodigo
            // 
            this.txtEmpleadoCodigo.Location = new System.Drawing.Point(78, 19);
            this.txtEmpleadoCodigo.Name = "txtEmpleadoCodigo";
            this.txtEmpleadoCodigo.Size = new System.Drawing.Size(95, 20);
            this.txtEmpleadoCodigo.TabIndex = 90;
            this.txtEmpleadoCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmpleadoCodigo.Leave += new System.EventHandler(this.txtEmpleadoCodigo_Leave);
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(179, 19);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(228, 21);
            this.cboEmpleado.TabIndex = 49;
            this.cboEmpleado.SelectionChangeCommitted += new System.EventHandler(this.cboEmpleado_SelectionChangeCommitted);
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.Location = new System.Drawing.Point(78, 45);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.ReadOnly = true;
            this.txtFechaIngreso.Size = new System.Drawing.Size(95, 20);
            this.txtFechaIngreso.TabIndex = 23;
            this.txtFechaIngreso.Text = "01/01/2017";
            this.txtFechaIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(9, 48);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(48, 13);
            this.lblMonto.TabIndex = 22;
            this.lblMonto.Text = "Ingreso :";
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
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnGuardar);
            this.pnlInferior.Controls.Add(this.btnCancelar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 377);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(436, 44);
            this.pnlInferior.TabIndex = 17;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(327, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(221, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 93;
            this.label2.Text = " Vacación :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpInicioVacacion
            // 
            this.dtpInicioVacacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInicioVacacion.CustomFormat = "dd/MM/yyyy";
            this.dtpInicioVacacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicioVacacion.Location = new System.Drawing.Point(189, 72);
            this.dtpInicioVacacion.Name = "dtpInicioVacacion";
            this.dtpInicioVacacion.Size = new System.Drawing.Size(95, 20);
            this.dtpInicioVacacion.TabIndex = 95;
            this.dtpInicioVacacion.ValueChanged += new System.EventHandler(this.dtpInicioVacacion_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Al";
            // 
            // txtDiasVacacion
            // 
            this.txtDiasVacacion.Location = new System.Drawing.Point(78, 72);
            this.txtDiasVacacion.Name = "txtDiasVacacion";
            this.txtDiasVacacion.Size = new System.Drawing.Size(50, 20);
            this.txtDiasVacacion.TabIndex = 97;
            this.txtDiasVacacion.Text = "30";
            this.txtDiasVacacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiasVacacion.Enter += new System.EventHandler(this.txtDiasVacacion_Enter);
            this.txtDiasVacacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiasVacacion_KeyPress);
            this.txtDiasVacacion.Leave += new System.EventHandler(this.txtDiasVacacion_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 98;
            this.label4.Text = "Días";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFinVacacion
            // 
            this.txtFinVacacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinVacacion.Location = new System.Drawing.Point(312, 72);
            this.txtFinVacacion.Name = "txtFinVacacion";
            this.txtFinVacacion.ReadOnly = true;
            this.txtFinVacacion.Size = new System.Drawing.Size(95, 20);
            this.txtFinVacacion.TabIndex = 99;
            this.txtFinVacacion.Text = "01/01/2017";
            this.txtFinVacacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmVacacionMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 424);
            this.Controls.Add(this.tlpPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmVacacionMant";
            this.Text = "Mantenimiento de Calculo de Vacaciones";
            this.Load += new System.EventHandler(this.FrmVacacionMant_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmVacacionMant_ResizeEnd);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.grpDetalles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.grpEmpleado.ResumeLayout(false);
            this.grpEmpleado.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlInferior;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpEmpleado;
        private System.Windows.Forms.TextBox txtFechaIngreso;
        internal System.Windows.Forms.Label lblMonto;
        internal System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cboEmpleado;
        private System.Windows.Forms.TextBox txtEmpleadoCodigo;
        private System.Windows.Forms.GroupBox grpDetalles;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.TextBox txtFechaUltimaVacacion;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiasVacacion;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpInicioVacacion;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFinVacacion;
    }
}