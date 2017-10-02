namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmOnpComisionMant
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
            this.grpPeriodo = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtAportePrc = new System.Windows.Forms.TextBox();
            this.lblAportePorcentual = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.LblAnho = new System.Windows.Forms.Label();
            this.grpComisiones = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvComisiones = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpPeriodo.SuspendLayout();
            this.grpComisiones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisiones)).BeginInit();
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
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpPrincipal.Size = new System.Drawing.Size(341, 458);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.grpPeriodo);
            this.pnlPrincipal.Controls.Add(this.grpComisiones);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(335, 392);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // grpPeriodo
            // 
            this.grpPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPeriodo.Controls.Add(this.btnAgregar);
            this.grpPeriodo.Controls.Add(this.txtAportePrc);
            this.grpPeriodo.Controls.Add(this.lblAportePorcentual);
            this.grpPeriodo.Controls.Add(this.lblMes);
            this.grpPeriodo.Controls.Add(this.cboMes);
            this.grpPeriodo.Controls.Add(this.cboAnho);
            this.grpPeriodo.Controls.Add(this.LblAnho);
            this.grpPeriodo.Location = new System.Drawing.Point(9, 9);
            this.grpPeriodo.Name = "grpPeriodo";
            this.grpPeriodo.Size = new System.Drawing.Size(317, 110);
            this.grpPeriodo.TabIndex = 39;
            this.grpPeriodo.TabStop = false;
            this.grpPeriodo.Text = "Periodo";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(208, 23);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(98, 73);
            this.btnAgregar.TabIndex = 19;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtAportePrc
            // 
            this.txtAportePrc.Location = new System.Drawing.Point(73, 76);
            this.txtAportePrc.Name = "txtAportePrc";
            this.txtAportePrc.Size = new System.Drawing.Size(98, 20);
            this.txtAportePrc.TabIndex = 53;
            this.txtAportePrc.Text = "0.00";
            this.txtAportePrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAportePrc.Enter += new System.EventHandler(this.txtAportePrc_Enter);
            this.txtAportePrc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAportePrc_KeyPress);
            this.txtAportePrc.Leave += new System.EventHandler(this.txtAportePrc_Leave);
            // 
            // lblAportePorcentual
            // 
            this.lblAportePorcentual.AutoSize = true;
            this.lblAportePorcentual.Location = new System.Drawing.Point(9, 79);
            this.lblAportePorcentual.Name = "lblAportePorcentual";
            this.lblAportePorcentual.Size = new System.Drawing.Size(55, 13);
            this.lblAportePorcentual.TabIndex = 52;
            this.lblAportePorcentual.Text = "Aporte % :";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(9, 52);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(33, 13);
            this.lblMes.TabIndex = 51;
            this.lblMes.Text = "Mes :";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(73, 49);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(98, 21);
            this.cboMes.TabIndex = 50;
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(73, 23);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(98, 21);
            this.cboAnho.TabIndex = 49;
            // 
            // LblAnho
            // 
            this.LblAnho.AutoSize = true;
            this.LblAnho.Location = new System.Drawing.Point(9, 26);
            this.LblAnho.Name = "LblAnho";
            this.LblAnho.Size = new System.Drawing.Size(32, 13);
            this.LblAnho.TabIndex = 18;
            this.LblAnho.Text = "Año :";
            // 
            // grpComisiones
            // 
            this.grpComisiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpComisiones.Controls.Add(this.btnEliminar);
            this.grpComisiones.Controls.Add(this.dgvComisiones);
            this.grpComisiones.Location = new System.Drawing.Point(9, 134);
            this.grpComisiones.Name = "grpComisiones";
            this.grpComisiones.Size = new System.Drawing.Size(317, 245);
            this.grpComisiones.TabIndex = 38;
            this.grpComisiones.TabStop = false;
            this.grpComisiones.Text = "Comisiones";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(234, 274);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(72, 20);
            this.btnEliminar.TabIndex = 54;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvComisiones
            // 
            this.dgvComisiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComisiones.Location = new System.Drawing.Point(12, 19);
            this.dgvComisiones.Name = "dgvComisiones";
            this.dgvComisiones.Size = new System.Drawing.Size(294, 209);
            this.dgvComisiones.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 401);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 54);
            this.panel2.TabIndex = 17;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(226, 12);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmOnpComisionMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 458);
            this.Controls.Add(this.tlpPrincipal);
            this.Name = "FrmOnpComisionMant";
            this.Text = "Mantenimiento de Comisiones de ONP";
            this.Load += new System.EventHandler(this.FrmAfpComisionMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.grpPeriodo.ResumeLayout(false);
            this.grpPeriodo.PerformLayout();
            this.grpComisiones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisiones)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        internal System.Windows.Forms.Label LblAnho;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox grpComisiones;
        private System.Windows.Forms.DataGridView dgvComisiones;
        private System.Windows.Forms.GroupBox grpPeriodo;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAnho;
        internal System.Windows.Forms.Label lblMes;
        internal System.Windows.Forms.Label lblAportePorcentual;
        private System.Windows.Forms.TextBox txtAportePrc;
        public System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.Button btnEliminar;
    }
}