namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmPrestamoList
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
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.LblFechaHora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            this.tlpPrincipal.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrestamos.Location = new System.Drawing.Point(0, 0);
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.Size = new System.Drawing.Size(786, 191);
            this.dgvPrestamos.TabIndex = 0;
            this.dgvPrestamos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrestamos_CellDoubleClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNuevo.Location = new System.Drawing.Point(462, 10);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 30);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditar.Location = new System.Drawing.Point(344, 10);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 30);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEliminar.Location = new System.Drawing.Point(223, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlInferior, 0, 2);
            this.tlpPrincipal.Controls.Add(this.pnlSuperior, 0, 1);
            this.tlpPrincipal.Controls.Add(this.pnlFiltro, 0, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpPrincipal.Size = new System.Drawing.Size(792, 297);
            this.tlpPrincipal.TabIndex = 19;
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnNuevo);
            this.pnlInferior.Controls.Add(this.btnEliminar);
            this.pnlInferior.Controls.Add(this.btnEditar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 240);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(786, 54);
            this.pnlInferior.TabIndex = 1;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.dgvPrestamos);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSuperior.Location = new System.Drawing.Point(3, 43);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(786, 191);
            this.pnlSuperior.TabIndex = 0;
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Controls.Add(this.label1);
            this.pnlFiltro.Controls.Add(this.cboMes);
            this.pnlFiltro.Controls.Add(this.cboAnho);
            this.pnlFiltro.Controls.Add(this.LblFechaHora);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiltro.Location = new System.Drawing.Point(3, 3);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(786, 34);
            this.pnlFiltro.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "-";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(172, 7);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(72, 21);
            this.cboMes.TabIndex = 61;
            this.cboMes.SelectionChangeCommitted += new System.EventHandler(this.cboAnhoMes_SelectionChangeCommitted);
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(78, 7);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(72, 21);
            this.cboAnho.TabIndex = 60;
            this.cboAnho.SelectionChangeCommitted += new System.EventHandler(this.cboAnhoMes_SelectionChangeCommitted);
            // 
            // LblFechaHora
            // 
            this.LblFechaHora.AutoSize = true;
            this.LblFechaHora.Location = new System.Drawing.Point(9, 10);
            this.LblFechaHora.Name = "LblFechaHora";
            this.LblFechaHora.Size = new System.Drawing.Size(63, 13);
            this.LblFechaHora.TabIndex = 59;
            this.LblFechaHora.Text = "Año y Mes :";
            // 
            // FrmPrestamoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 297);
            this.Controls.Add(this.tlpPrincipal);
            this.Name = "FrmPrestamoList";
            this.Text = "Listado de Prestamos";
            this.Load += new System.EventHandler(this.FrmPrestamoList_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmPrestamoList_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pnlFiltro;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAnho;
        internal System.Windows.Forms.Label LblFechaHora;
    }
}