namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmReciboDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReciboDetalle));
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalSueldo = new System.Windows.Forms.Label();
            this.txtTotalSueldo = new System.Windows.Forms.TextBox();
            this.lblTotalBonos = new System.Windows.Forms.Label();
            this.txtTotalBonos = new System.Windows.Forms.TextBox();
            this.lblTotalDescuentos = new System.Windows.Forms.Label();
            this.txtTotalDescuentos = new System.Windows.Forms.TextBox();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.txtTotalGeneral = new System.Windows.Forms.TextBox();
            this.btnExportarAsistenciasCsv = new System.Windows.Forms.Button();
            this.dgvRecibos = new System.Windows.Forms.DataGridView();
            this.GrpPeriodo = new System.Windows.Forms.GroupBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.LblFechaHora = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).BeginInit();
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
            this.tlpPrincipal.Size = new System.Drawing.Size(567, 458);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.groupBox1);
            this.pnlPrincipal.Controls.Add(this.GrpPeriodo);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(561, 402);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblTotalSueldo);
            this.groupBox1.Controls.Add(this.txtTotalSueldo);
            this.groupBox1.Controls.Add(this.lblTotalBonos);
            this.groupBox1.Controls.Add(this.txtTotalBonos);
            this.groupBox1.Controls.Add(this.lblTotalDescuentos);
            this.groupBox1.Controls.Add(this.txtTotalDescuentos);
            this.groupBox1.Controls.Add(this.lblTotalGeneral);
            this.groupBox1.Controls.Add(this.txtTotalGeneral);
            this.groupBox1.Controls.Add(this.btnExportarAsistenciasCsv);
            this.groupBox1.Controls.Add(this.dgvRecibos);
            this.groupBox1.Location = new System.Drawing.Point(11, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 301);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recibos";
            // 
            // lblTotalSueldo
            // 
            this.lblTotalSueldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSueldo.AutoSize = true;
            this.lblTotalSueldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSueldo.Location = new System.Drawing.Point(452, 142);
            this.lblTotalSueldo.Name = "lblTotalSueldo";
            this.lblTotalSueldo.Size = new System.Drawing.Size(46, 13);
            this.lblTotalSueldo.TabIndex = 98;
            this.lblTotalSueldo.Text = "Sueldo :";
            // 
            // txtTotalSueldo
            // 
            this.txtTotalSueldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalSueldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSueldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSueldo.Location = new System.Drawing.Point(453, 158);
            this.txtTotalSueldo.Name = "txtTotalSueldo";
            this.txtTotalSueldo.ReadOnly = true;
            this.txtTotalSueldo.Size = new System.Drawing.Size(81, 20);
            this.txtTotalSueldo.TabIndex = 99;
            this.txtTotalSueldo.Text = "0.00";
            this.txtTotalSueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalBonos
            // 
            this.lblTotalBonos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalBonos.AutoSize = true;
            this.lblTotalBonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBonos.Location = new System.Drawing.Point(453, 181);
            this.lblTotalBonos.Name = "lblTotalBonos";
            this.lblTotalBonos.Size = new System.Drawing.Size(43, 13);
            this.lblTotalBonos.TabIndex = 96;
            this.lblTotalBonos.Text = "Bonos :";
            // 
            // txtTotalBonos
            // 
            this.txtTotalBonos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalBonos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalBonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBonos.Location = new System.Drawing.Point(454, 197);
            this.txtTotalBonos.Name = "txtTotalBonos";
            this.txtTotalBonos.ReadOnly = true;
            this.txtTotalBonos.Size = new System.Drawing.Size(81, 20);
            this.txtTotalBonos.TabIndex = 97;
            this.txtTotalBonos.Text = "0.00";
            this.txtTotalBonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalDescuentos
            // 
            this.lblTotalDescuentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDescuentos.AutoSize = true;
            this.lblTotalDescuentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDescuentos.Location = new System.Drawing.Point(453, 220);
            this.lblTotalDescuentos.Name = "lblTotalDescuentos";
            this.lblTotalDescuentos.Size = new System.Drawing.Size(70, 13);
            this.lblTotalDescuentos.TabIndex = 94;
            this.lblTotalDescuentos.Text = "Descuentos :";
            // 
            // txtTotalDescuentos
            // 
            this.txtTotalDescuentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalDescuentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDescuentos.Location = new System.Drawing.Point(454, 236);
            this.txtTotalDescuentos.Name = "txtTotalDescuentos";
            this.txtTotalDescuentos.ReadOnly = true;
            this.txtTotalDescuentos.Size = new System.Drawing.Size(81, 20);
            this.txtTotalDescuentos.TabIndex = 95;
            this.txtTotalDescuentos.Text = "0.00";
            this.txtTotalDescuentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeneral.Location = new System.Drawing.Point(453, 259);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(37, 13);
            this.lblTotalGeneral.TabIndex = 67;
            this.lblTotalGeneral.Text = "Total :";
            // 
            // txtTotalGeneral
            // 
            this.txtTotalGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalGeneral.Location = new System.Drawing.Point(454, 275);
            this.txtTotalGeneral.Name = "txtTotalGeneral";
            this.txtTotalGeneral.ReadOnly = true;
            this.txtTotalGeneral.Size = new System.Drawing.Size(81, 20);
            this.txtTotalGeneral.TabIndex = 68;
            this.txtTotalGeneral.Text = "0.00";
            this.txtTotalGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnExportarAsistenciasCsv
            // 
            this.btnExportarAsistenciasCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarAsistenciasCsv.Location = new System.Drawing.Point(454, 19);
            this.btnExportarAsistenciasCsv.Name = "btnExportarAsistenciasCsv";
            this.btnExportarAsistenciasCsv.Size = new System.Drawing.Size(81, 21);
            this.btnExportarAsistenciasCsv.TabIndex = 93;
            this.btnExportarAsistenciasCsv.Text = "Exportar CSV";
            this.btnExportarAsistenciasCsv.UseVisualStyleBackColor = true;
            this.btnExportarAsistenciasCsv.Click += new System.EventHandler(this.btnExportarAsistenciasCsv_Click);
            // 
            // dgvRecibos
            // 
            this.dgvRecibos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecibos.Location = new System.Drawing.Point(6, 19);
            this.dgvRecibos.Name = "dgvRecibos";
            this.dgvRecibos.Size = new System.Drawing.Size(441, 276);
            this.dgvRecibos.TabIndex = 0;
            // 
            // GrpPeriodo
            // 
            this.GrpPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpPeriodo.Controls.Add(this.txtTipo);
            this.GrpPeriodo.Controls.Add(this.lblEmpleado);
            this.GrpPeriodo.Controls.Add(this.cboEmpleado);
            this.GrpPeriodo.Controls.Add(this.cboMes);
            this.GrpPeriodo.Controls.Add(this.cboAnho);
            this.GrpPeriodo.Controls.Add(this.LblFechaHora);
            this.GrpPeriodo.Location = new System.Drawing.Point(9, 3);
            this.GrpPeriodo.Name = "GrpPeriodo";
            this.GrpPeriodo.Size = new System.Drawing.Size(541, 89);
            this.GrpPeriodo.TabIndex = 39;
            this.GrpPeriodo.TabStop = false;
            this.GrpPeriodo.Text = "Filtro";
            // 
            // txtTipo
            // 
            this.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Location = new System.Drawing.Point(75, 50);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(72, 20);
            this.txtTipo.TabIndex = 98;
            this.txtTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(9, 53);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(60, 13);
            this.lblEmpleado.TabIndex = 96;
            this.lblEmpleado.Text = "Empleado :";
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(153, 49);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(372, 21);
            this.cboEmpleado.TabIndex = 97;
            this.cboEmpleado.SelectionChangeCommitted += new System.EventHandler(this.cboAnhoMesEmpleado_SelectionChangeCommitted);
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(153, 23);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(173, 21);
            this.cboMes.TabIndex = 50;
            this.cboMes.SelectionChangeCommitted += new System.EventHandler(this.cboAnhoMesEmpleado_SelectionChangeCommitted);
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(75, 23);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(72, 21);
            this.cboAnho.TabIndex = 49;
            this.cboAnho.SelectionChangeCommitted += new System.EventHandler(this.cboAnhoMesEmpleado_SelectionChangeCommitted);
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
            this.pnlBotones.Controls.Add(this.btnImprimir);
            this.pnlBotones.Controls.Add(this.BtnCancel);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotones.Location = new System.Drawing.Point(3, 411);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(561, 44);
            this.pnlBotones.TabIndex = 17;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Location = new System.Drawing.Point(346, 5);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 30);
            this.btnImprimir.TabIndex = 19;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(452, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmReciboDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 458);
            this.Controls.Add(this.tlpPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmReciboDetalle";
            this.Text = "Detalle de Recibos";
            this.Load += new System.EventHandler(this.FrmReciboDetalle_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmReciboDetalle_ResizeEnd);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).EndInit();
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
        public System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox GrpPeriodo;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAnho;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRecibos;
        internal System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cboEmpleado;
        public System.Windows.Forms.Button btnImprimir;
        public System.Windows.Forms.Button btnExportarAsistenciasCsv;
        internal System.Windows.Forms.Label lblTotalBonos;
        private System.Windows.Forms.TextBox txtTotalBonos;
        internal System.Windows.Forms.Label lblTotalDescuentos;
        private System.Windows.Forms.TextBox txtTotalDescuentos;
        internal System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.TextBox txtTotalGeneral;
        private System.Windows.Forms.TextBox txtTipo;
        internal System.Windows.Forms.Label lblTotalSueldo;
        private System.Windows.Forms.TextBox txtTotalSueldo;
    }
}