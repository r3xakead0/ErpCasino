namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmInasistenciaList
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
            this.dgvInasistencias = new System.Windows.Forms.DataGridView();
            this.btnClasificar = new System.Windows.Forms.Button();
            this.TlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.PnlFiltro = new System.Windows.Forms.Panel();
            this.LblSala = new System.Windows.Forms.Label();
            this.cboSala = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.LblFechaHora = new System.Windows.Forms.Label();
            this.PnlGrilla = new System.Windows.Forms.Panel();
            this.PnlBotones = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInasistencias)).BeginInit();
            this.TlpPrincipal.SuspendLayout();
            this.PnlFiltro.SuspendLayout();
            this.PnlGrilla.SuspendLayout();
            this.PnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInasistencias
            // 
            this.dgvInasistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInasistencias.Location = new System.Drawing.Point(3, 3);
            this.dgvInasistencias.Name = "dgvInasistencias";
            this.dgvInasistencias.Size = new System.Drawing.Size(938, 249);
            this.dgvInasistencias.TabIndex = 0;
            // 
            // btnClasificar
            // 
            this.btnClasificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClasificar.Location = new System.Drawing.Point(827, 11);
            this.btnClasificar.Name = "btnClasificar";
            this.btnClasificar.Size = new System.Drawing.Size(100, 30);
            this.btnClasificar.TabIndex = 16;
            this.btnClasificar.Text = "Clasificar";
            this.btnClasificar.UseVisualStyleBackColor = true;
            this.btnClasificar.Click += new System.EventHandler(this.btnClasificar_Click);
            // 
            // TlpPrincipal
            // 
            this.TlpPrincipal.ColumnCount = 1;
            this.TlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPrincipal.Controls.Add(this.PnlFiltro, 0, 0);
            this.TlpPrincipal.Controls.Add(this.PnlGrilla, 0, 1);
            this.TlpPrincipal.Controls.Add(this.PnlBotones, 0, 2);
            this.TlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.TlpPrincipal.Name = "TlpPrincipal";
            this.TlpPrincipal.RowCount = 3;
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.TlpPrincipal.Size = new System.Drawing.Size(950, 376);
            this.TlpPrincipal.TabIndex = 19;
            // 
            // PnlFiltro
            // 
            this.PnlFiltro.Controls.Add(this.LblSala);
            this.PnlFiltro.Controls.Add(this.cboSala);
            this.PnlFiltro.Controls.Add(this.label1);
            this.PnlFiltro.Controls.Add(this.cboMes);
            this.PnlFiltro.Controls.Add(this.cboAnho);
            this.PnlFiltro.Controls.Add(this.LblFechaHora);
            this.PnlFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlFiltro.Location = new System.Drawing.Point(3, 3);
            this.PnlFiltro.Name = "PnlFiltro";
            this.PnlFiltro.Size = new System.Drawing.Size(944, 54);
            this.PnlFiltro.TabIndex = 0;
            // 
            // LblSala
            // 
            this.LblSala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSala.AutoSize = true;
            this.LblSala.Location = new System.Drawing.Point(692, 20);
            this.LblSala.Name = "LblSala";
            this.LblSala.Size = new System.Drawing.Size(31, 13);
            this.LblSala.TabIndex = 55;
            this.LblSala.Text = "Sala:";
            // 
            // cboSala
            // 
            this.cboSala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSala.FormattingEnabled = true;
            this.cboSala.Location = new System.Drawing.Point(761, 17);
            this.cboSala.Name = "cboSala";
            this.cboSala.Size = new System.Drawing.Size(166, 21);
            this.cboSala.TabIndex = 56;
            this.cboSala.SelectionChangeCommitted += new System.EventHandler(this.CboAnhoMesSala_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "-";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(181, 17);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(72, 21);
            this.cboMes.TabIndex = 53;
            this.cboMes.SelectionChangeCommitted += new System.EventHandler(this.CboAnhoMesSala_SelectionChangeCommitted);
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(87, 17);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(72, 21);
            this.cboAnho.TabIndex = 52;
            this.cboAnho.SelectionChangeCommitted += new System.EventHandler(this.CboAnhoMesSala_SelectionChangeCommitted);
            // 
            // LblFechaHora
            // 
            this.LblFechaHora.AutoSize = true;
            this.LblFechaHora.Location = new System.Drawing.Point(18, 20);
            this.LblFechaHora.Name = "LblFechaHora";
            this.LblFechaHora.Size = new System.Drawing.Size(63, 13);
            this.LblFechaHora.TabIndex = 51;
            this.LblFechaHora.Text = "Año y Mes :";
            // 
            // PnlGrilla
            // 
            this.PnlGrilla.Controls.Add(this.dgvInasistencias);
            this.PnlGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlGrilla.Location = new System.Drawing.Point(3, 63);
            this.PnlGrilla.Name = "PnlGrilla";
            this.PnlGrilla.Size = new System.Drawing.Size(944, 255);
            this.PnlGrilla.TabIndex = 1;
            // 
            // PnlBotones
            // 
            this.PnlBotones.Controls.Add(this.btnClasificar);
            this.PnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBotones.Location = new System.Drawing.Point(3, 324);
            this.PnlBotones.Name = "PnlBotones";
            this.PnlBotones.Size = new System.Drawing.Size(944, 49);
            this.PnlBotones.TabIndex = 2;
            // 
            // FrmInasistenciaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 376);
            this.Controls.Add(this.TlpPrincipal);
            this.Name = "FrmInasistenciaList";
            this.Text = "Listado de Inasistencias";
            this.Load += new System.EventHandler(this.FrmInasistenciaList_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmInasistenciaList_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInasistencias)).EndInit();
            this.TlpPrincipal.ResumeLayout(false);
            this.PnlFiltro.ResumeLayout(false);
            this.PnlFiltro.PerformLayout();
            this.PnlGrilla.ResumeLayout(false);
            this.PnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInasistencias;
        private System.Windows.Forms.Button btnClasificar;
        private System.Windows.Forms.TableLayoutPanel TlpPrincipal;
        private System.Windows.Forms.Panel PnlBotones;
        private System.Windows.Forms.Panel PnlGrilla;
        private System.Windows.Forms.Panel PnlFiltro;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.ComboBox cboAnho;
        internal System.Windows.Forms.Label LblFechaHora;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label LblSala;
        public System.Windows.Forms.ComboBox cboSala;
    }
}