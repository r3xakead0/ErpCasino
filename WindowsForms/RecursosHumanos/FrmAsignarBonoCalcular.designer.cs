namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmAsignarBonoCalcular
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
            this.grpCalcular = new System.Windows.Forms.GroupBox();
            this.LblFechaHora = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.cboBono = new System.Windows.Forms.ComboBox();
            this.lblBono = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.grpBonificaciones = new System.Windows.Forms.GroupBox();
            this.txtTipoBono = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnhoMes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroBonos = new System.Windows.Forms.TextBox();
            this.lblRegistrosAsistencias = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvBonos = new System.Windows.Forms.DataGridView();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpCalcular.SuspendLayout();
            this.grpBonificaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).BeginInit();
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
            this.tlpPrincipal.Size = new System.Drawing.Size(567, 483);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.grpCalcular);
            this.pnlPrincipal.Controls.Add(this.grpBonificaciones);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(561, 427);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // grpCalcular
            // 
            this.grpCalcular.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCalcular.Controls.Add(this.LblFechaHora);
            this.grpCalcular.Controls.Add(this.btnCalcular);
            this.grpCalcular.Controls.Add(this.cboBono);
            this.grpCalcular.Controls.Add(this.lblBono);
            this.grpCalcular.Controls.Add(this.label4);
            this.grpCalcular.Controls.Add(this.label1);
            this.grpCalcular.Controls.Add(this.cboMes);
            this.grpCalcular.Controls.Add(this.cboAnho);
            this.grpCalcular.Location = new System.Drawing.Point(9, 9);
            this.grpCalcular.Name = "grpCalcular";
            this.grpCalcular.Size = new System.Drawing.Size(543, 110);
            this.grpCalcular.TabIndex = 102;
            this.grpCalcular.TabStop = false;
            this.grpCalcular.Text = "Carcular Bonos";
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
            this.btnCalcular.Location = new System.Drawing.Point(437, 73);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(100, 21);
            this.btnCalcular.TabIndex = 101;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // cboBono
            // 
            this.cboBono.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBono.Location = new System.Drawing.Point(98, 46);
            this.cboBono.Name = "cboBono";
            this.cboBono.Size = new System.Drawing.Size(439, 21);
            this.cboBono.TabIndex = 66;
            // 
            // lblBono
            // 
            this.lblBono.AutoSize = true;
            this.lblBono.Location = new System.Drawing.Point(6, 49);
            this.lblBono.Name = "lblBono";
            this.lblBono.Size = new System.Drawing.Size(77, 13);
            this.lblBono.TabIndex = 67;
            this.lblBono.Text = "Tipo de Bono :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(85, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "*";
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
            this.cboMes.Location = new System.Drawing.Point(190, 19);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(347, 21);
            this.cboMes.TabIndex = 97;
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(98, 19);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(86, 21);
            this.cboAnho.TabIndex = 96;
            // 
            // grpBonificaciones
            // 
            this.grpBonificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBonificaciones.Controls.Add(this.txtTipoBono);
            this.grpBonificaciones.Controls.Add(this.label3);
            this.grpBonificaciones.Controls.Add(this.txtAnhoMes);
            this.grpBonificaciones.Controls.Add(this.label2);
            this.grpBonificaciones.Controls.Add(this.txtNroBonos);
            this.grpBonificaciones.Controls.Add(this.lblRegistrosAsistencias);
            this.grpBonificaciones.Controls.Add(this.btnGuardar);
            this.grpBonificaciones.Controls.Add(this.dgvBonos);
            this.grpBonificaciones.Location = new System.Drawing.Point(9, 125);
            this.grpBonificaciones.Name = "grpBonificaciones";
            this.grpBonificaciones.Size = new System.Drawing.Size(543, 288);
            this.grpBonificaciones.TabIndex = 100;
            this.grpBonificaciones.TabStop = false;
            this.grpBonificaciones.Text = "Bonos Calculados";
            // 
            // txtTipoBono
            // 
            this.txtTipoBono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoBono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoBono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoBono.Location = new System.Drawing.Point(355, 24);
            this.txtTipoBono.Name = "txtTipoBono";
            this.txtTipoBono.ReadOnly = true;
            this.txtTipoBono.Size = new System.Drawing.Size(182, 20);
            this.txtTipoBono.TabIndex = 107;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Tipo de Bono :";
            // 
            // txtAnhoMes
            // 
            this.txtAnhoMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAnhoMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnhoMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnhoMes.Location = new System.Drawing.Point(98, 24);
            this.txtAnhoMes.Name = "txtAnhoMes";
            this.txtAnhoMes.ReadOnly = true;
            this.txtAnhoMes.Size = new System.Drawing.Size(86, 20);
            this.txtAnhoMes.TabIndex = 105;
            this.txtAnhoMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Año y Mes :";
            // 
            // txtNroBonos
            // 
            this.txtNroBonos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNroBonos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroBonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroBonos.Location = new System.Drawing.Point(98, 259);
            this.txtNroBonos.Name = "txtNroBonos";
            this.txtNroBonos.ReadOnly = true;
            this.txtNroBonos.Size = new System.Drawing.Size(41, 20);
            this.txtNroBonos.TabIndex = 104;
            this.txtNroBonos.Text = "0";
            this.txtNroBonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRegistrosAsistencias
            // 
            this.lblRegistrosAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegistrosAsistencias.AutoSize = true;
            this.lblRegistrosAsistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosAsistencias.Location = new System.Drawing.Point(6, 262);
            this.lblRegistrosAsistencias.Name = "lblRegistrosAsistencias";
            this.lblRegistrosAsistencias.Size = new System.Drawing.Size(80, 13);
            this.lblRegistrosAsistencias.TabIndex = 103;
            this.lblRegistrosAsistencias.Text = "Nro. Registros :";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(437, 258);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 21);
            this.btnGuardar.TabIndex = 102;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvBonos
            // 
            this.dgvBonos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonos.Location = new System.Drawing.Point(6, 50);
            this.dgvBonos.Name = "dgvBonos";
            this.dgvBonos.Size = new System.Drawing.Size(531, 202);
            this.dgvBonos.TabIndex = 0;
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnCancelar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 436);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(561, 44);
            this.pnlInferior.TabIndex = 17;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(452, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAsignarBonoCalcular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 483);
            this.Controls.Add(this.tlpPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmAsignarBonoCalcular";
            this.Text = "Calcular Bonos de Empleados";
            this.Load += new System.EventHandler(this.FrmAfpComisionMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.grpCalcular.ResumeLayout(false);
            this.grpCalcular.PerformLayout();
            this.grpBonificaciones.ResumeLayout(false);
            this.grpBonificaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlInferior;
        internal System.Windows.Forms.Label lblBono;
        internal System.Windows.Forms.ComboBox cboBono;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAnho;
        internal System.Windows.Forms.Label LblFechaHora;
        private System.Windows.Forms.GroupBox grpBonificaciones;
        private System.Windows.Forms.DataGridView dgvBonos;
        private System.Windows.Forms.GroupBox grpCalcular;
        public System.Windows.Forms.Button btnCalcular;
        public System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNroBonos;
        internal System.Windows.Forms.Label lblRegistrosAsistencias;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtTipoBono;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnhoMes;
        internal System.Windows.Forms.Label label2;
    }
}