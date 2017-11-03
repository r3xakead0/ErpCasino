namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmAfpComisionMant
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
            this.GrpPeriodo = new System.Windows.Forms.GroupBox();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.LblFechaHora = new System.Windows.Forms.Label();
            this.GrpComisiones = new System.Windows.Forms.GroupBox();
            this.dgvComisiones = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.GrpPeriodo.SuspendLayout();
            this.GrpComisiones.SuspendLayout();
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
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPrincipal.Size = new System.Drawing.Size(577, 355);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.GrpPeriodo);
            this.pnlPrincipal.Controls.Add(this.GrpComisiones);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(571, 299);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // GrpPeriodo
            // 
            this.GrpPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpPeriodo.Controls.Add(this.cboMes);
            this.GrpPeriodo.Controls.Add(this.cboAnho);
            this.GrpPeriodo.Controls.Add(this.LblFechaHora);
            this.GrpPeriodo.Location = new System.Drawing.Point(9, 9);
            this.GrpPeriodo.Name = "GrpPeriodo";
            this.GrpPeriodo.Size = new System.Drawing.Size(553, 60);
            this.GrpPeriodo.TabIndex = 39;
            this.GrpPeriodo.TabStop = false;
            this.GrpPeriodo.Text = "Periodo";
            // 
            // cboMes
            // 
            this.cboMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(189, 23);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(358, 21);
            this.cboMes.TabIndex = 50;
            this.cboMes.SelectionChangeCommitted += new System.EventHandler(this.CbxAnhoMes_SelectionChangeCommitted);
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(105, 23);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(78, 21);
            this.cboAnho.TabIndex = 49;
            this.cboAnho.SelectionChangeCommitted += new System.EventHandler(this.CbxAnhoMes_SelectionChangeCommitted);
            // 
            // LblFechaHora
            // 
            this.LblFechaHora.AutoSize = true;
            this.LblFechaHora.Location = new System.Drawing.Point(6, 26);
            this.LblFechaHora.Name = "LblFechaHora";
            this.LblFechaHora.Size = new System.Drawing.Size(63, 13);
            this.LblFechaHora.TabIndex = 18;
            this.LblFechaHora.Text = "Año y Mes :";
            // 
            // GrpComisiones
            // 
            this.GrpComisiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpComisiones.Controls.Add(this.dgvComisiones);
            this.GrpComisiones.Location = new System.Drawing.Point(9, 75);
            this.GrpComisiones.Name = "GrpComisiones";
            this.GrpComisiones.Size = new System.Drawing.Size(553, 221);
            this.GrpComisiones.TabIndex = 38;
            this.GrpComisiones.TabStop = false;
            this.GrpComisiones.Text = "Comisiones";
            // 
            // dgvComisiones
            // 
            this.dgvComisiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComisiones.Location = new System.Drawing.Point(6, 19);
            this.dgvComisiones.Name = "dgvComisiones";
            this.dgvComisiones.Size = new System.Drawing.Size(541, 195);
            this.dgvComisiones.TabIndex = 0;
            this.dgvComisiones.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvComisiones_EditingControlShowing);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnSave);
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 308);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(571, 44);
            this.panel2.TabIndex = 17;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(462, 5);
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
            this.BtnCancel.Location = new System.Drawing.Point(356, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmAfpComisionMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 355);
            this.Controls.Add(this.tlpPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmAfpComisionMant";
            this.Text = "Mantenimiento de Comisiones de AFP";
            this.Load += new System.EventHandler(this.FrmAfpComisionMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.GrpPeriodo.ResumeLayout(false);
            this.GrpPeriodo.PerformLayout();
            this.GrpComisiones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisiones)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        internal System.Windows.Forms.Label LblFechaHora;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox GrpComisiones;
        private System.Windows.Forms.DataGridView dgvComisiones;
        private System.Windows.Forms.GroupBox GrpPeriodo;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAnho;
    }
}