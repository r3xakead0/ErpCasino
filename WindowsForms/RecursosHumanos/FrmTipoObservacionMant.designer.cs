namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmTipoObservacionMant
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
            this.dgvObservaciones = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservaciones)).BeginInit();
            this.tlpPrincipal.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvObservaciones
            // 
            this.dgvObservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvObservaciones.Location = new System.Drawing.Point(0, 0);
            this.dgvObservaciones.Name = "dgvObservaciones";
            this.dgvObservaciones.Size = new System.Drawing.Size(663, 209);
            this.dgvObservaciones.TabIndex = 0;
            this.dgvObservaciones.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObservaciones_RowLeave);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(554, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(448, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlInferior, 0, 1);
            this.tlpPrincipal.Controls.Add(this.pnlSuperior, 0, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpPrincipal.Size = new System.Drawing.Size(669, 275);
            this.tlpPrincipal.TabIndex = 19;
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnGuardar);
            this.pnlInferior.Controls.Add(this.btnEliminar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 218);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(663, 54);
            this.pnlInferior.TabIndex = 1;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.dgvObservaciones);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSuperior.Location = new System.Drawing.Point(3, 3);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(663, 209);
            this.pnlSuperior.TabIndex = 0;
            // 
            // FrmTipoObservacionMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 275);
            this.Controls.Add(this.tlpPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmTipoObservacionMant";
            this.Text = "Mantenimiento de Observaciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTipoObservacionMant_FormClosing);
            this.Load += new System.EventHandler(this.FrmTipoObservacionMant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservaciones)).EndInit();
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.pnlSuperior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvObservaciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel pnlSuperior;
    }
}