namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmCargoMant
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
            this.dgvCargos = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).BeginInit();
            this.tlpPrincipal.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCargos
            // 
            this.dgvCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCargos.Location = new System.Drawing.Point(0, 0);
            this.dgvCargos.Name = "dgvCargos";
            this.dgvCargos.Size = new System.Drawing.Size(609, 331);
            this.dgvCargos.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(500, 10);
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
            this.btnEliminar.Location = new System.Drawing.Point(394, 10);
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
            this.tlpPrincipal.Size = new System.Drawing.Size(615, 397);
            this.tlpPrincipal.TabIndex = 19;
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnGuardar);
            this.pnlInferior.Controls.Add(this.btnEliminar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 340);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(609, 54);
            this.pnlInferior.TabIndex = 1;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.dgvCargos);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSuperior.Location = new System.Drawing.Point(3, 3);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(609, 331);
            this.pnlSuperior.TabIndex = 0;
            // 
            // FrmCargoMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 397);
            this.Controls.Add(this.tlpPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmCargoMant";
            this.Text = "Mantenimiento de Cargos";
            this.Load += new System.EventHandler(this.FrmCargoMant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargos)).EndInit();
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlInferior.ResumeLayout(false);
            this.pnlSuperior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCargos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel pnlSuperior;
    }
}