namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmSalaMetaMant
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
            this.grpPeriodoFiltro = new System.Windows.Forms.GroupBox();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.LblFechaHora = new System.Windows.Forms.Label();
            this.grpMetaSala = new System.Windows.Forms.GroupBox();
            this.dgvMetaSala = new System.Windows.Forms.DataGridView();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpPeriodoFiltro.SuspendLayout();
            this.grpMetaSala.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetaSala)).BeginInit();
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
            this.tlpPrincipal.Size = new System.Drawing.Size(399, 337);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.grpPeriodoFiltro);
            this.pnlPrincipal.Controls.Add(this.grpMetaSala);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(393, 281);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // grpPeriodoFiltro
            // 
            this.grpPeriodoFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPeriodoFiltro.Controls.Add(this.cboMes);
            this.grpPeriodoFiltro.Controls.Add(this.cboAnho);
            this.grpPeriodoFiltro.Controls.Add(this.LblFechaHora);
            this.grpPeriodoFiltro.Location = new System.Drawing.Point(9, 9);
            this.grpPeriodoFiltro.Name = "grpPeriodoFiltro";
            this.grpPeriodoFiltro.Size = new System.Drawing.Size(375, 60);
            this.grpPeriodoFiltro.TabIndex = 39;
            this.grpPeriodoFiltro.TabStop = false;
            this.grpPeriodoFiltro.Text = "Periodo";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(174, 23);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(182, 21);
            this.cboMes.TabIndex = 50;
            this.cboMes.SelectionChangeCommitted += new System.EventHandler(this.CbxAnhoMes_SelectionChangeCommitted);
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(105, 23);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(63, 21);
            this.cboAnho.TabIndex = 49;
            this.cboAnho.SelectionChangeCommitted += new System.EventHandler(this.CbxAnhoMes_SelectionChangeCommitted);
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
            // grpMetaSala
            // 
            this.grpMetaSala.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMetaSala.Controls.Add(this.dgvMetaSala);
            this.grpMetaSala.Location = new System.Drawing.Point(9, 75);
            this.grpMetaSala.Name = "grpMetaSala";
            this.grpMetaSala.Size = new System.Drawing.Size(375, 203);
            this.grpMetaSala.TabIndex = 38;
            this.grpMetaSala.TabStop = false;
            this.grpMetaSala.Text = "Metas";
            // 
            // dgvMetaSala
            // 
            this.dgvMetaSala.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMetaSala.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetaSala.Location = new System.Drawing.Point(6, 19);
            this.dgvMetaSala.Name = "dgvMetaSala";
            this.dgvMetaSala.Size = new System.Drawing.Size(363, 177);
            this.dgvMetaSala.TabIndex = 0;
            this.dgvMetaSala.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvMetaSala_EditingControlShowing);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnGuardar);
            this.pnlInferior.Controls.Add(this.btnCancel);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 290);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(393, 44);
            this.pnlInferior.TabIndex = 17;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(284, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(178, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmSalaMetaMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 337);
            this.Controls.Add(this.tlpPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmSalaMetaMant";
            this.Text = "Mantenimiento de Metas por Salas";
            this.Load += new System.EventHandler(this.FrmSalaMetaMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.grpPeriodoFiltro.ResumeLayout(false);
            this.grpPeriodoFiltro.PerformLayout();
            this.grpMetaSala.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetaSala)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        internal System.Windows.Forms.Label LblFechaHora;
        private System.Windows.Forms.Panel pnlInferior;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpMetaSala;
        private System.Windows.Forms.DataGridView dgvMetaSala;
        private System.Windows.Forms.GroupBox grpPeriodoFiltro;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAnho;
    }
}