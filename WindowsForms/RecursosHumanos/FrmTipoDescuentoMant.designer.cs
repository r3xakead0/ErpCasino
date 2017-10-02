namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmTipoDescuentoMant
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
            this.grpDetalleTipoDescuento = new System.Windows.Forms.GroupBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.grpListadoTipoDescuento = new System.Windows.Forms.GroupBox();
            this.dgvListadoDescuentos = new System.Windows.Forms.DataGridView();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpDetalleTipoDescuento.SuspendLayout();
            this.grpListadoTipoDescuento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDescuentos)).BeginInit();
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
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpPrincipal.Size = new System.Drawing.Size(644, 479);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.grpDetalleTipoDescuento);
            this.pnlPrincipal.Controls.Add(this.grpListadoTipoDescuento);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(638, 413);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // grpDetalleTipoDescuento
            // 
            this.grpDetalleTipoDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetalleTipoDescuento.Controls.Add(this.chkActivo);
            this.grpDetalleTipoDescuento.Controls.Add(this.txtMonto);
            this.grpDetalleTipoDescuento.Controls.Add(this.lblMonto);
            this.grpDetalleTipoDescuento.Controls.Add(this.txtDescripcion);
            this.grpDetalleTipoDescuento.Controls.Add(this.lblDescripcion);
            this.grpDetalleTipoDescuento.Controls.Add(this.txtNombre);
            this.grpDetalleTipoDescuento.Controls.Add(this.lblNombre);
            this.grpDetalleTipoDescuento.Location = new System.Drawing.Point(3, 271);
            this.grpDetalleTipoDescuento.Name = "grpDetalleTipoDescuento";
            this.grpDetalleTipoDescuento.Size = new System.Drawing.Size(632, 139);
            this.grpDetalleTipoDescuento.TabIndex = 39;
            this.grpDetalleTipoDescuento.TabStop = false;
            this.grpDetalleTipoDescuento.Text = "Detalle de Descuento";
            // 
            // chkActivo
            // 
            this.chkActivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkActivo.AutoSize = true;
            this.chkActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Location = new System.Drawing.Point(565, 109);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 24;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(78, 107);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(118, 20);
            this.txtMonto.TabIndex = 23;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.Enter += new System.EventHandler(this.txtMonto_Enter);
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            this.txtMonto.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(9, 110);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(43, 13);
            this.lblMonto.TabIndex = 22;
            this.lblMonto.Text = "Monto :";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.Location = new System.Drawing.Point(78, 49);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(543, 52);
            this.txtDescripcion.TabIndex = 21;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(9, 52);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(69, 13);
            this.lblDescripcion.TabIndex = 20;
            this.lblDescripcion.Text = "Descripcion :";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(78, 23);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(543, 20);
            this.txtNombre.TabIndex = 19;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(9, 26);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.TabIndex = 18;
            this.lblNombre.Text = "Nombre :";
            // 
            // grpListadoTipoDescuento
            // 
            this.grpListadoTipoDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpListadoTipoDescuento.Controls.Add(this.dgvListadoDescuentos);
            this.grpListadoTipoDescuento.Location = new System.Drawing.Point(3, 9);
            this.grpListadoTipoDescuento.Name = "grpListadoTipoDescuento";
            this.grpListadoTipoDescuento.Size = new System.Drawing.Size(632, 256);
            this.grpListadoTipoDescuento.TabIndex = 38;
            this.grpListadoTipoDescuento.TabStop = false;
            this.grpListadoTipoDescuento.Text = "Listado de Descuentos";
            // 
            // dgvListadoDescuentos
            // 
            this.dgvListadoDescuentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListadoDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoDescuentos.Location = new System.Drawing.Point(12, 19);
            this.dgvListadoDescuentos.Name = "dgvListadoDescuentos";
            this.dgvListadoDescuentos.Size = new System.Drawing.Size(609, 230);
            this.dgvListadoDescuentos.TabIndex = 0;
            this.dgvListadoDescuentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoDescuentos_CellClick);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.BtnDelete);
            this.pnlInferior.Controls.Add(this.BtnSave);
            this.pnlInferior.Controls.Add(this.BtnCancel);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 422);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(638, 54);
            this.pnlInferior.TabIndex = 17;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDelete.Location = new System.Drawing.Point(404, 5);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(100, 30);
            this.BtnDelete.TabIndex = 19;
            this.BtnDelete.Text = "Eliminar";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(524, 5);
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
            this.BtnCancel.Location = new System.Drawing.Point(284, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmTipoDescuentoMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 479);
            this.Controls.Add(this.tlpPrincipal);
            this.Name = "FrmTipoDescuentoMant";
            this.Text = "Mantenimiento de Tipos de Descuentos";
            this.Load += new System.EventHandler(this.FrmTipoDescuentoMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.grpDetalleTipoDescuento.ResumeLayout(false);
            this.grpDetalleTipoDescuento.PerformLayout();
            this.grpListadoTipoDescuento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDescuentos)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        internal System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel pnlInferior;
        public System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox grpListadoTipoDescuento;
        private System.Windows.Forms.DataGridView dgvListadoDescuentos;
        private System.Windows.Forms.GroupBox grpDetalleTipoDescuento;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.TextBox txtMonto;
        internal System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        public System.Windows.Forms.Button BtnDelete;
    }
}