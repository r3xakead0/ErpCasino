namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmReporteAsistencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteAsistencias));
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.cboAnhos = new System.Windows.Forms.ComboBox();
            this.lblAnho = new System.Windows.Forms.Label();
            this.cboMeses = new System.Windows.Forms.ComboBox();
            this.cboSalas = new System.Windows.Forms.ComboBox();
            this.lblSala = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
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
            this.tlpPrincipal.Size = new System.Drawing.Size(317, 159);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.cboAnhos);
            this.pnlPrincipal.Controls.Add(this.lblAnho);
            this.pnlPrincipal.Controls.Add(this.cboMeses);
            this.pnlPrincipal.Controls.Add(this.cboSalas);
            this.pnlPrincipal.Controls.Add(this.lblSala);
            this.pnlPrincipal.Controls.Add(this.lblMes);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(311, 103);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // cboAnhos
            // 
            this.cboAnhos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAnhos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnhos.FormattingEnabled = true;
            this.cboAnhos.Location = new System.Drawing.Point(99, 14);
            this.cboAnhos.Name = "cboAnhos";
            this.cboAnhos.Size = new System.Drawing.Size(198, 21);
            this.cboAnhos.TabIndex = 52;
            // 
            // lblAnho
            // 
            this.lblAnho.AutoSize = true;
            this.lblAnho.Location = new System.Drawing.Point(12, 17);
            this.lblAnho.Name = "lblAnho";
            this.lblAnho.Size = new System.Drawing.Size(32, 13);
            this.lblAnho.TabIndex = 51;
            this.lblAnho.Text = "Año :";
            // 
            // cboMeses
            // 
            this.cboMeses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMeses.FormattingEnabled = true;
            this.cboMeses.Location = new System.Drawing.Point(99, 41);
            this.cboMeses.Name = "cboMeses";
            this.cboMeses.Size = new System.Drawing.Size(198, 21);
            this.cboMeses.TabIndex = 50;
            // 
            // cboSalas
            // 
            this.cboSalas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSalas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSalas.FormattingEnabled = true;
            this.cboSalas.Location = new System.Drawing.Point(99, 67);
            this.cboSalas.Name = "cboSalas";
            this.cboSalas.Size = new System.Drawing.Size(198, 21);
            this.cboSalas.TabIndex = 49;
            // 
            // lblSala
            // 
            this.lblSala.AutoSize = true;
            this.lblSala.Location = new System.Drawing.Point(12, 70);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(34, 13);
            this.lblSala.TabIndex = 20;
            this.lblSala.Text = "Sala :";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(12, 44);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(33, 13);
            this.lblMes.TabIndex = 18;
            this.lblMes.Text = "Mes :";
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnGenerar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 112);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(311, 44);
            this.pnlInferior.TabIndex = 17;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerar.Location = new System.Drawing.Point(202, 5);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(100, 30);
            this.btnGenerar.TabIndex = 17;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // FrmReporteAsistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 159);
            this.Controls.Add(this.tlpPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmReporteAsistencias";
            this.Text = "Reporte de Asistencias";
            this.Load += new System.EventHandler(this.FrmReporteAsistencias_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        internal System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Panel pnlInferior;
        public System.Windows.Forms.Button btnGenerar;
        internal System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.ComboBox cboSalas;
        private System.Windows.Forms.ComboBox cboMeses;
        private System.Windows.Forms.ComboBox cboAnhos;
        internal System.Windows.Forms.Label lblAnho;
    }
}