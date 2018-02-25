namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmAsignarDescuentoCalcular
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsignarDescuentoCalcular));
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.grpCalcular = new System.Windows.Forms.GroupBox();
            this.LblFechaHora = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.cboDescuento = new System.Windows.Forms.ComboBox();
            this.lblBono = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.pnlCalculo = new System.Windows.Forms.Panel();
            this.grpBonificaciones = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipoDescuento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnhoMes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroDescuentos = new System.Windows.Forms.TextBox();
            this.lblRegistrosAsistencias = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvDescuentos = new System.Windows.Forms.DataGridView();
            this.tlpPrincipal.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.grpCalcular.SuspendLayout();
            this.pnlCalculo.SuspendLayout();
            this.grpBonificaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).BeginInit();
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
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Size = new System.Drawing.Size(716, 489);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Controls.Add(this.grpCalcular);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiltro.Location = new System.Drawing.Point(3, 3);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(710, 134);
            this.pnlFiltro.TabIndex = 16;
            // 
            // grpCalcular
            // 
            this.grpCalcular.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCalcular.Controls.Add(this.LblFechaHora);
            this.grpCalcular.Controls.Add(this.btnCalcular);
            this.grpCalcular.Controls.Add(this.cboDescuento);
            this.grpCalcular.Controls.Add(this.lblBono);
            this.grpCalcular.Controls.Add(this.label1);
            this.grpCalcular.Controls.Add(this.cboMes);
            this.grpCalcular.Controls.Add(this.cboAnho);
            this.grpCalcular.Location = new System.Drawing.Point(9, 9);
            this.grpCalcular.Name = "grpCalcular";
            this.grpCalcular.Size = new System.Drawing.Size(692, 115);
            this.grpCalcular.TabIndex = 102;
            this.grpCalcular.TabStop = false;
            this.grpCalcular.Text = "Carcular Descuentos";
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
            this.btnCalcular.Location = new System.Drawing.Point(586, 73);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(100, 31);
            this.btnCalcular.TabIndex = 101;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // cboDescuento
            // 
            this.cboDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDescuento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDescuento.Location = new System.Drawing.Point(116, 46);
            this.cboDescuento.Name = "cboDescuento";
            this.cboDescuento.Size = new System.Drawing.Size(570, 21);
            this.cboDescuento.TabIndex = 66;
            // 
            // lblBono
            // 
            this.lblBono.AutoSize = true;
            this.lblBono.Location = new System.Drawing.Point(6, 49);
            this.lblBono.Name = "lblBono";
            this.lblBono.Size = new System.Drawing.Size(104, 13);
            this.lblBono.TabIndex = 67;
            this.lblBono.Text = "Tipo de Descuento :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(85, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "*";
            // 
            // cboMes
            // 
            this.cboMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(208, 19);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(478, 21);
            this.cboMes.TabIndex = 97;
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(116, 19);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(86, 21);
            this.cboAnho.TabIndex = 96;
            // 
            // pnlCalculo
            // 
            this.pnlCalculo.Controls.Add(this.grpBonificaciones);
            this.pnlCalculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCalculo.Location = new System.Drawing.Point(3, 143);
            this.pnlCalculo.Name = "pnlCalculo";
            this.pnlCalculo.Size = new System.Drawing.Size(710, 343);
            this.pnlCalculo.TabIndex = 17;
            // 
            // grpBonificaciones
            // 
            this.grpBonificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBonificaciones.Controls.Add(this.txtTotal);
            this.grpBonificaciones.Controls.Add(this.label4);
            this.grpBonificaciones.Controls.Add(this.txtTipoDescuento);
            this.grpBonificaciones.Controls.Add(this.label3);
            this.grpBonificaciones.Controls.Add(this.txtAnhoMes);
            this.grpBonificaciones.Controls.Add(this.label2);
            this.grpBonificaciones.Controls.Add(this.txtNroDescuentos);
            this.grpBonificaciones.Controls.Add(this.lblRegistrosAsistencias);
            this.grpBonificaciones.Controls.Add(this.btnGuardar);
            this.grpBonificaciones.Controls.Add(this.dgvDescuentos);
            this.grpBonificaciones.Location = new System.Drawing.Point(9, 3);
            this.grpBonificaciones.Name = "grpBonificaciones";
            this.grpBonificaciones.Size = new System.Drawing.Size(692, 331);
            this.grpBonificaciones.TabIndex = 100;
            this.grpBonificaciones.TabStop = false;
            this.grpBonificaciones.Text = "Descuentos Calculados";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(482, 292);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(98, 20);
            this.txtTotal.TabIndex = 109;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 108;
            this.label4.Text = "Total :";
            // 
            // txtTipoDescuento
            // 
            this.txtTipoDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoDescuento.Location = new System.Drawing.Point(482, 19);
            this.txtTipoDescuento.Name = "txtTipoDescuento";
            this.txtTipoDescuento.ReadOnly = true;
            this.txtTipoDescuento.Size = new System.Drawing.Size(204, 20);
            this.txtTipoDescuento.TabIndex = 107;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Tipo de Descuento :";
            // 
            // txtAnhoMes
            // 
            this.txtAnhoMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnhoMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnhoMes.Location = new System.Drawing.Point(75, 19);
            this.txtAnhoMes.Name = "txtAnhoMes";
            this.txtAnhoMes.ReadOnly = true;
            this.txtAnhoMes.Size = new System.Drawing.Size(86, 20);
            this.txtAnhoMes.TabIndex = 105;
            this.txtAnhoMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Año y Mes :";
            // 
            // txtNroDescuentos
            // 
            this.txtNroDescuentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNroDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroDescuentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDescuentos.Location = new System.Drawing.Point(98, 291);
            this.txtNroDescuentos.Name = "txtNroDescuentos";
            this.txtNroDescuentos.ReadOnly = true;
            this.txtNroDescuentos.Size = new System.Drawing.Size(41, 20);
            this.txtNroDescuentos.TabIndex = 104;
            this.txtNroDescuentos.Text = "0";
            this.txtNroDescuentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRegistrosAsistencias
            // 
            this.lblRegistrosAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegistrosAsistencias.AutoSize = true;
            this.lblRegistrosAsistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosAsistencias.Location = new System.Drawing.Point(6, 294);
            this.lblRegistrosAsistencias.Name = "lblRegistrosAsistencias";
            this.lblRegistrosAsistencias.Size = new System.Drawing.Size(80, 13);
            this.lblRegistrosAsistencias.TabIndex = 103;
            this.lblRegistrosAsistencias.Text = "Nro. Registros :";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(586, 291);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 31);
            this.btnGuardar.TabIndex = 102;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvDescuentos
            // 
            this.dgvDescuentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescuentos.Location = new System.Drawing.Point(6, 45);
            this.dgvDescuentos.Name = "dgvDescuentos";
            this.dgvDescuentos.Size = new System.Drawing.Size(680, 240);
            this.dgvDescuentos.TabIndex = 0;
            // 
            // FrmAsignarDescuentoCalcular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 489);
            this.Controls.Add(this.tlpPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAsignarDescuentoCalcular";
            this.Text = "Calcular Descuentos de Empleados";
            this.Load += new System.EventHandler(this.FrmAsignarDescuentoCalcular_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlFiltro.ResumeLayout(false);
            this.grpCalcular.ResumeLayout(false);
            this.grpCalcular.PerformLayout();
            this.pnlCalculo.ResumeLayout(false);
            this.grpBonificaciones.ResumeLayout(false);
            this.grpBonificaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlFiltro;
        internal System.Windows.Forms.Label lblBono;
        internal System.Windows.Forms.ComboBox cboDescuento;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAnho;
        internal System.Windows.Forms.Label LblFechaHora;
        private System.Windows.Forms.GroupBox grpBonificaciones;
        private System.Windows.Forms.DataGridView dgvDescuentos;
        private System.Windows.Forms.GroupBox grpCalcular;
        public System.Windows.Forms.Button btnCalcular;
        public System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNroDescuentos;
        internal System.Windows.Forms.Label lblRegistrosAsistencias;
        private System.Windows.Forms.TextBox txtTipoDescuento;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnhoMes;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCalculo;
        private System.Windows.Forms.TextBox txtTotal;
        internal System.Windows.Forms.Label label4;
    }
}