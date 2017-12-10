namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmAdelantoCarga
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
            this.grpAdelantos = new System.Windows.Forms.GroupBox();
            this.txtTotalMonto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNroRegistros = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAdelantos = new System.Windows.Forms.DataGridView();
            this.grpCargaArchivo = new System.Windows.Forms.GroupBox();
            this.lblTipoAdelanto = new System.Windows.Forms.Label();
            this.btnArchivo = new System.Windows.Forms.Button();
            this.cboTipos = new System.Windows.Forms.ComboBox();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpAdelantos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdelantos)).BeginInit();
            this.grpCargaArchivo.SuspendLayout();
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
            this.tlpPrincipal.Size = new System.Drawing.Size(947, 452);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.grpAdelantos);
            this.pnlPrincipal.Controls.Add(this.grpCargaArchivo);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(941, 396);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // grpAdelantos
            // 
            this.grpAdelantos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAdelantos.Controls.Add(this.txtTotalMonto);
            this.grpAdelantos.Controls.Add(this.label3);
            this.grpAdelantos.Controls.Add(this.txtNroRegistros);
            this.grpAdelantos.Controls.Add(this.label2);
            this.grpAdelantos.Controls.Add(this.dgvAdelantos);
            this.grpAdelantos.Location = new System.Drawing.Point(9, 98);
            this.grpAdelantos.Name = "grpAdelantos";
            this.grpAdelantos.Size = new System.Drawing.Size(923, 295);
            this.grpAdelantos.TabIndex = 42;
            this.grpAdelantos.TabStop = false;
            this.grpAdelantos.Text = "Listado de Adelantos";
            // 
            // txtTotalMonto
            // 
            this.txtTotalMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalMonto.Location = new System.Drawing.Point(846, 265);
            this.txtTotalMonto.Name = "txtTotalMonto";
            this.txtTotalMonto.ReadOnly = true;
            this.txtTotalMonto.Size = new System.Drawing.Size(71, 20);
            this.txtTotalMonto.TabIndex = 65;
            this.txtTotalMonto.Text = "0.00";
            this.txtTotalMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(803, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Total :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNroRegistros
            // 
            this.txtNroRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNroRegistros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroRegistros.Location = new System.Drawing.Point(95, 265);
            this.txtNroRegistros.Name = "txtNroRegistros";
            this.txtNroRegistros.ReadOnly = true;
            this.txtNroRegistros.Size = new System.Drawing.Size(71, 20);
            this.txtNroRegistros.TabIndex = 63;
            this.txtNroRegistros.Text = "0";
            this.txtNroRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 62;
            this.label2.Text = "Nro. Registros :";
            // 
            // dgvAdelantos
            // 
            this.dgvAdelantos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdelantos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdelantos.Location = new System.Drawing.Point(6, 19);
            this.dgvAdelantos.Name = "dgvAdelantos";
            this.dgvAdelantos.Size = new System.Drawing.Size(911, 240);
            this.dgvAdelantos.TabIndex = 0;
            // 
            // grpCargaArchivo
            // 
            this.grpCargaArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCargaArchivo.Controls.Add(this.lblTipoAdelanto);
            this.grpCargaArchivo.Controls.Add(this.btnArchivo);
            this.grpCargaArchivo.Controls.Add(this.cboTipos);
            this.grpCargaArchivo.Controls.Add(this.txtArchivo);
            this.grpCargaArchivo.Controls.Add(this.lblArchivo);
            this.grpCargaArchivo.Controls.Add(this.btnCargar);
            this.grpCargaArchivo.Location = new System.Drawing.Point(9, 9);
            this.grpCargaArchivo.Name = "grpCargaArchivo";
            this.grpCargaArchivo.Size = new System.Drawing.Size(923, 83);
            this.grpCargaArchivo.TabIndex = 39;
            this.grpCargaArchivo.TabStop = false;
            this.grpCargaArchivo.Text = "Cargar Adelantos";
            // 
            // lblTipoAdelanto
            // 
            this.lblTipoAdelanto.AutoSize = true;
            this.lblTipoAdelanto.Location = new System.Drawing.Point(16, 50);
            this.lblTipoAdelanto.Name = "lblTipoAdelanto";
            this.lblTipoAdelanto.Size = new System.Drawing.Size(34, 13);
            this.lblTipoAdelanto.TabIndex = 69;
            this.lblTipoAdelanto.Text = "Tipo :";
            // 
            // btnArchivo
            // 
            this.btnArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchivo.Location = new System.Drawing.Point(884, 19);
            this.btnArchivo.Name = "btnArchivo";
            this.btnArchivo.Size = new System.Drawing.Size(25, 20);
            this.btnArchivo.TabIndex = 24;
            this.btnArchivo.UseVisualStyleBackColor = true;
            this.btnArchivo.Click += new System.EventHandler(this.btnArchivo_Click);
            // 
            // cboTipos
            // 
            this.cboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipos.Location = new System.Drawing.Point(85, 47);
            this.cboTipos.Name = "cboTipos";
            this.cboTipos.Size = new System.Drawing.Size(118, 21);
            this.cboTipos.TabIndex = 68;
            // 
            // txtArchivo
            // 
            this.txtArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArchivo.Location = new System.Drawing.Point(85, 19);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(793, 20);
            this.txtArchivo.TabIndex = 22;
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(16, 23);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(49, 13);
            this.lblArchivo.TabIndex = 21;
            this.lblArchivo.Text = "Archivo :";
            // 
            // btnCargar
            // 
            this.btnCargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargar.Location = new System.Drawing.Point(809, 44);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(100, 25);
            this.btnCargar.TabIndex = 23;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnGuardar);
            this.pnlInferior.Controls.Add(this.btnCancelar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 405);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(941, 44);
            this.pnlInferior.TabIndex = 17;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(832, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(726, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAdelantoCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 452);
            this.Controls.Add(this.tlpPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmAdelantoCarga";
            this.Text = "Carga Masiva de Adelantos";
            this.Load += new System.EventHandler(this.FrmAfpComisionMant_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.grpAdelantos.ResumeLayout(false);
            this.grpAdelantos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdelantos)).EndInit();
            this.grpCargaArchivo.ResumeLayout(false);
            this.grpCargaArchivo.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlInferior;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpCargaArchivo;
        public System.Windows.Forms.Button btnArchivo;
        internal System.Windows.Forms.TextBox txtArchivo;
        public System.Windows.Forms.Button btnCargar;
        internal System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.GroupBox grpAdelantos;
        private System.Windows.Forms.DataGridView dgvAdelantos;
        private System.Windows.Forms.TextBox txtNroRegistros;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalMonto;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lblTipoAdelanto;
        internal System.Windows.Forms.ComboBox cboTipos;
    }
}