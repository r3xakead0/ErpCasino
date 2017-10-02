namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmTipoBonoMant
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
            this.grpDetalleTipoBono = new System.Windows.Forms.GroupBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.grpListadoTipoBono = new System.Windows.Forms.GroupBox();
            this.dgvListadoBonos = new System.Windows.Forms.DataGridView();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpDetalleTipoBono.SuspendLayout();
            this.grpListadoTipoBono.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoBonos)).BeginInit();
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
            this.pnlPrincipal.Controls.Add(this.grpDetalleTipoBono);
            this.pnlPrincipal.Controls.Add(this.grpListadoTipoBono);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(638, 413);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // grpDetalleTipoBono
            // 
            this.grpDetalleTipoBono.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetalleTipoBono.Controls.Add(this.chkActivo);
            this.grpDetalleTipoBono.Controls.Add(this.txtMonto);
            this.grpDetalleTipoBono.Controls.Add(this.lblMonto);
            this.grpDetalleTipoBono.Controls.Add(this.txtDescripcion);
            this.grpDetalleTipoBono.Controls.Add(this.lblDescripcion);
            this.grpDetalleTipoBono.Controls.Add(this.txtNombre);
            this.grpDetalleTipoBono.Controls.Add(this.lblNombre);
            this.grpDetalleTipoBono.Location = new System.Drawing.Point(3, 271);
            this.grpDetalleTipoBono.Name = "grpDetalleTipoBono";
            this.grpDetalleTipoBono.Size = new System.Drawing.Size(632, 139);
            this.grpDetalleTipoBono.TabIndex = 39;
            this.grpDetalleTipoBono.TabStop = false;
            this.grpDetalleTipoBono.Text = "Detalle de Bono";
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
            // grpListadoTipoBono
            // 
            this.grpListadoTipoBono.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpListadoTipoBono.Controls.Add(this.dgvListadoBonos);
            this.grpListadoTipoBono.Location = new System.Drawing.Point(3, 9);
            this.grpListadoTipoBono.Name = "grpListadoTipoBono";
            this.grpListadoTipoBono.Size = new System.Drawing.Size(632, 256);
            this.grpListadoTipoBono.TabIndex = 38;
            this.grpListadoTipoBono.TabStop = false;
            this.grpListadoTipoBono.Text = "Listado de Bonos";
            // 
            // dgvListadoBonos
            // 
            this.dgvListadoBonos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListadoBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoBonos.Location = new System.Drawing.Point(12, 19);
            this.dgvListadoBonos.Name = "dgvListadoBonos";
            this.dgvListadoBonos.Size = new System.Drawing.Size(609, 230);
            this.dgvListadoBonos.TabIndex = 0;
            this.dgvListadoBonos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoBonos_CellClick);
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
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(9, 110);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(43, 13);
            this.lblMonto.TabIndex = 22;
            this.lblMonto.Text = "Monto :";
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
            // FrmTipoBonoMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 479);
            this.Controls.Add(this.tlpPrincipal);
            this.Name = "FrmTipoBonoMant";
            this.Text = "Mantenimiento de TIpos de Bonos";
            this.Load += new System.EventHandler(this.FrmTipoBonoMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.grpDetalleTipoBono.ResumeLayout(false);
            this.grpDetalleTipoBono.PerformLayout();
            this.grpListadoTipoBono.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoBonos)).EndInit();
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
        private System.Windows.Forms.GroupBox grpListadoTipoBono;
        private System.Windows.Forms.DataGridView dgvListadoBonos;
        private System.Windows.Forms.GroupBox grpDetalleTipoBono;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        public System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.TextBox txtMonto;
        internal System.Windows.Forms.Label lblMonto;
    }
}