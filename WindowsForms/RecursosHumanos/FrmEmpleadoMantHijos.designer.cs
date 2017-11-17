namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmEmpleadoMantHijos
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
            this.grpEmpleado = new System.Windows.Forms.GroupBox();
            this.LblNumeroHijos = new System.Windows.Forms.Label();
            this.txtEmpleadoNroHijos = new System.Windows.Forms.TextBox();
            this.txtEmpleadoCodigo = new System.Windows.Forms.TextBox();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.grpHijos = new System.Windows.Forms.GroupBox();
            this.dgvHijos = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpEmpleado.SuspendLayout();
            this.grpHijos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHijos)).BeginInit();
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
            this.tlpPrincipal.Size = new System.Drawing.Size(696, 299);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.grpEmpleado);
            this.pnlPrincipal.Controls.Add(this.grpHijos);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(690, 243);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // grpEmpleado
            // 
            this.grpEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEmpleado.Controls.Add(this.LblNumeroHijos);
            this.grpEmpleado.Controls.Add(this.txtEmpleadoNroHijos);
            this.grpEmpleado.Controls.Add(this.txtEmpleadoCodigo);
            this.grpEmpleado.Controls.Add(this.cboEmpleado);
            this.grpEmpleado.Controls.Add(this.lblEmpleado);
            this.grpEmpleado.Location = new System.Drawing.Point(9, 9);
            this.grpEmpleado.Name = "grpEmpleado";
            this.grpEmpleado.Size = new System.Drawing.Size(672, 86);
            this.grpEmpleado.TabIndex = 39;
            this.grpEmpleado.TabStop = false;
            this.grpEmpleado.Text = "Empleado";
            // 
            // LblNumeroHijos
            // 
            this.LblNumeroHijos.AutoSize = true;
            this.LblNumeroHijos.Location = new System.Drawing.Point(6, 51);
            this.LblNumeroHijos.Name = "LblNumeroHijos";
            this.LblNumeroHijos.Size = new System.Drawing.Size(73, 13);
            this.LblNumeroHijos.TabIndex = 95;
            this.LblNumeroHijos.Text = "Numero Hijos:";
            // 
            // txtEmpleadoNroHijos
            // 
            this.txtEmpleadoNroHijos.Location = new System.Drawing.Point(98, 48);
            this.txtEmpleadoNroHijos.Name = "txtEmpleadoNroHijos";
            this.txtEmpleadoNroHijos.ReadOnly = true;
            this.txtEmpleadoNroHijos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEmpleadoNroHijos.Size = new System.Drawing.Size(55, 20);
            this.txtEmpleadoNroHijos.TabIndex = 94;
            this.txtEmpleadoNroHijos.Text = "0";
            // 
            // txtEmpleadoCodigo
            // 
            this.txtEmpleadoCodigo.Location = new System.Drawing.Point(98, 22);
            this.txtEmpleadoCodigo.Name = "txtEmpleadoCodigo";
            this.txtEmpleadoCodigo.Size = new System.Drawing.Size(113, 20);
            this.txtEmpleadoCodigo.TabIndex = 93;
            this.txtEmpleadoCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmpleadoCodigo.Leave += new System.EventHandler(this.txtEmpleadoCodigo_Leave);
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(217, 22);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(449, 21);
            this.cboEmpleado.TabIndex = 92;
            this.cboEmpleado.SelectionChangeCommitted += new System.EventHandler(this.cboEmpleado_SelectionChangeCommitted);
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(6, 25);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(46, 13);
            this.lblEmpleado.TabIndex = 91;
            this.lblEmpleado.Text = "Codigo :";
            // 
            // grpHijos
            // 
            this.grpHijos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHijos.Controls.Add(this.dgvHijos);
            this.grpHijos.Location = new System.Drawing.Point(9, 101);
            this.grpHijos.Name = "grpHijos";
            this.grpHijos.Size = new System.Drawing.Size(672, 139);
            this.grpHijos.TabIndex = 38;
            this.grpHijos.TabStop = false;
            this.grpHijos.Text = "Datos de Hijos";
            // 
            // dgvHijos
            // 
            this.dgvHijos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHijos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHijos.Location = new System.Drawing.Point(6, 19);
            this.dgvHijos.Name = "dgvHijos";
            this.dgvHijos.Size = new System.Drawing.Size(660, 114);
            this.dgvHijos.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnSave);
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 252);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 44);
            this.panel2.TabIndex = 17;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(581, 5);
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
            this.BtnCancel.Location = new System.Drawing.Point(475, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmEmpleadoMantHijos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 299);
            this.Controls.Add(this.tlpPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmEmpleadoMantHijos";
            this.Text = "Mantenimiento de Hijos del Empleado";
            this.Load += new System.EventHandler(this.FrmEmpleadoMantHijos_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.grpEmpleado.ResumeLayout(false);
            this.grpEmpleado.PerformLayout();
            this.grpHijos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHijos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox grpHijos;
        private System.Windows.Forms.DataGridView dgvHijos;
        private System.Windows.Forms.GroupBox grpEmpleado;
        private System.Windows.Forms.TextBox txtEmpleadoCodigo;
        private System.Windows.Forms.ComboBox cboEmpleado;
        internal System.Windows.Forms.Label lblEmpleado;
        internal System.Windows.Forms.Label LblNumeroHijos;
        internal System.Windows.Forms.TextBox txtEmpleadoNroHijos;
    }
}