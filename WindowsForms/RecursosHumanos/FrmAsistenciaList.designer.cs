namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmAsistenciaList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsistenciaList));
            this.dgvAsistencias = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.TlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.PnlGrilla = new System.Windows.Forms.Panel();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.LblFechaHora = new System.Windows.Forms.Label();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.txtNroBonos = new System.Windows.Forms.TextBox();
            this.lblRegistrosAsistencias = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).BeginInit();
            this.TlpPrincipal.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.PnlGrilla.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAsistencias
            // 
            this.dgvAsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsistencias.Location = new System.Drawing.Point(0, 0);
            this.dgvAsistencias.Name = "dgvAsistencias";
            this.dgvAsistencias.Size = new System.Drawing.Size(325, 366);
            this.dgvAsistencias.TabIndex = 0;
            this.dgvAsistencias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsistencias_CellDoubleClick);
            this.dgvAsistencias.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAsistencias_ColumnHeaderMouseClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Location = new System.Drawing.Point(218, 7);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 30);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Location = new System.Drawing.Point(112, 7);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 30);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // TlpPrincipal
            // 
            this.TlpPrincipal.ColumnCount = 1;
            this.TlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPrincipal.Controls.Add(this.pnlInferior, 0, 3);
            this.TlpPrincipal.Controls.Add(this.PnlGrilla, 0, 1);
            this.TlpPrincipal.Controls.Add(this.pnlSuperior, 0, 0);
            this.TlpPrincipal.Controls.Add(this.pnlResumen, 0, 2);
            this.TlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.TlpPrincipal.Name = "TlpPrincipal";
            this.TlpPrincipal.RowCount = 4;
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TlpPrincipal.Size = new System.Drawing.Size(331, 492);
            this.TlpPrincipal.TabIndex = 19;
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnEliminar);
            this.pnlInferior.Controls.Add(this.btnNuevo);
            this.pnlInferior.Controls.Add(this.btnEditar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 445);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(325, 44);
            this.pnlInferior.TabIndex = 1;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(6, 7);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // PnlGrilla
            // 
            this.PnlGrilla.Controls.Add(this.dgvAsistencias);
            this.PnlGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlGrilla.Location = new System.Drawing.Point(3, 43);
            this.PnlGrilla.Name = "PnlGrilla";
            this.PnlGrilla.Size = new System.Drawing.Size(325, 366);
            this.PnlGrilla.TabIndex = 0;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.label1);
            this.pnlSuperior.Controls.Add(this.cboMes);
            this.pnlSuperior.Controls.Add(this.cboAnho);
            this.pnlSuperior.Controls.Add(this.LblFechaHora);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSuperior.Location = new System.Drawing.Point(3, 3);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(325, 34);
            this.pnlSuperior.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "-";
            // 
            // cboMes
            // 
            this.cboMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(172, 7);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(144, 21);
            this.cboMes.TabIndex = 57;
            this.cboMes.SelectionChangeCommitted += new System.EventHandler(this.cboAnhoMes_SelectionChangeCommitted);
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(78, 7);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(72, 21);
            this.cboAnho.TabIndex = 56;
            this.cboAnho.SelectionChangeCommitted += new System.EventHandler(this.cboAnhoMes_SelectionChangeCommitted);
            // 
            // LblFechaHora
            // 
            this.LblFechaHora.AutoSize = true;
            this.LblFechaHora.Location = new System.Drawing.Point(9, 10);
            this.LblFechaHora.Name = "LblFechaHora";
            this.LblFechaHora.Size = new System.Drawing.Size(63, 13);
            this.LblFechaHora.TabIndex = 55;
            this.LblFechaHora.Text = "Año y Mes :";
            // 
            // pnlResumen
            // 
            this.pnlResumen.Controls.Add(this.txtNroBonos);
            this.pnlResumen.Controls.Add(this.lblRegistrosAsistencias);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResumen.Location = new System.Drawing.Point(3, 415);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(325, 24);
            this.pnlResumen.TabIndex = 3;
            // 
            // txtNroBonos
            // 
            this.txtNroBonos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNroBonos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroBonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroBonos.Location = new System.Drawing.Point(284, 0);
            this.txtNroBonos.Name = "txtNroBonos";
            this.txtNroBonos.ReadOnly = true;
            this.txtNroBonos.Size = new System.Drawing.Size(41, 20);
            this.txtNroBonos.TabIndex = 106;
            this.txtNroBonos.Text = "0";
            this.txtNroBonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRegistrosAsistencias
            // 
            this.lblRegistrosAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistrosAsistencias.AutoSize = true;
            this.lblRegistrosAsistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosAsistencias.Location = new System.Drawing.Point(192, 3);
            this.lblRegistrosAsistencias.Name = "lblRegistrosAsistencias";
            this.lblRegistrosAsistencias.Size = new System.Drawing.Size(80, 13);
            this.lblRegistrosAsistencias.TabIndex = 105;
            this.lblRegistrosAsistencias.Text = "Nro. Registros :";
            // 
            // FrmAsistenciaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 492);
            this.Controls.Add(this.TlpPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAsistenciaList";
            this.Text = "Listado de Asistencias";
            this.Load += new System.EventHandler(this.FrmAsistenciaList_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmAsistenciaList_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencias)).EndInit();
            this.TlpPrincipal.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.PnlGrilla.ResumeLayout(false);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAsistencias;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TableLayoutPanel TlpPrincipal;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel PnlGrilla;
        private System.Windows.Forms.Panel pnlSuperior;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAnho;
        internal System.Windows.Forms.Label LblFechaHora;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.TextBox txtNroBonos;
        internal System.Windows.Forms.Label lblRegistrosAsistencias;
    }
}