namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmHorarioSemanalVista
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.TlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.PnlGrilla = new System.Windows.Forms.Panel();
            this.dgvHorarioSemanal = new System.Windows.Forms.DataGridView();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.LblSala = new System.Windows.Forms.Label();
            this.cboSala = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRangoFechas = new System.Windows.Forms.TextBox();
            this.LblAnho = new System.Windows.Forms.Label();
            this.LblSemana = new System.Windows.Forms.Label();
            this.cboAnho = new System.Windows.Forms.ComboBox();
            this.cboSemana = new System.Windows.Forms.ComboBox();
            this.TlpPrincipal.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.PnlGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarioSemanal)).BeginInit();
            this.pnlCabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.Location = new System.Drawing.Point(615, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // TlpPrincipal
            // 
            this.TlpPrincipal.ColumnCount = 1;
            this.TlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPrincipal.Controls.Add(this.pnlBotones, 0, 2);
            this.TlpPrincipal.Controls.Add(this.PnlGrilla, 0, 1);
            this.TlpPrincipal.Controls.Add(this.pnlCabecera, 0, 0);
            this.TlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.TlpPrincipal.Name = "TlpPrincipal";
            this.TlpPrincipal.RowCount = 3;
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TlpPrincipal.Size = new System.Drawing.Size(730, 492);
            this.TlpPrincipal.TabIndex = 19;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotones.Location = new System.Drawing.Point(3, 445);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(724, 44);
            this.pnlBotones.TabIndex = 1;
            // 
            // PnlGrilla
            // 
            this.PnlGrilla.Controls.Add(this.dgvHorarioSemanal);
            this.PnlGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlGrilla.Location = new System.Drawing.Point(3, 83);
            this.PnlGrilla.Name = "PnlGrilla";
            this.PnlGrilla.Size = new System.Drawing.Size(724, 356);
            this.PnlGrilla.TabIndex = 0;
            // 
            // dgvHorarioSemanal
            // 
            this.dgvHorarioSemanal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorarioSemanal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHorarioSemanal.Location = new System.Drawing.Point(0, 0);
            this.dgvHorarioSemanal.Name = "dgvHorarioSemanal";
            this.dgvHorarioSemanal.Size = new System.Drawing.Size(724, 356);
            this.dgvHorarioSemanal.TabIndex = 0;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this.LblSala);
            this.pnlCabecera.Controls.Add(this.cboSala);
            this.pnlCabecera.Controls.Add(this.label1);
            this.pnlCabecera.Controls.Add(this.txtRangoFechas);
            this.pnlCabecera.Controls.Add(this.LblAnho);
            this.pnlCabecera.Controls.Add(this.LblSemana);
            this.pnlCabecera.Controls.Add(this.cboAnho);
            this.pnlCabecera.Controls.Add(this.cboSemana);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCabecera.Location = new System.Drawing.Point(3, 3);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(724, 74);
            this.pnlCabecera.TabIndex = 2;
            // 
            // LblSala
            // 
            this.LblSala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSala.AutoSize = true;
            this.LblSala.Location = new System.Drawing.Point(292, 17);
            this.LblSala.Name = "LblSala";
            this.LblSala.Size = new System.Drawing.Size(31, 13);
            this.LblSala.TabIndex = 57;
            this.LblSala.Text = "Sala:";
            // 
            // cboSala
            // 
            this.cboSala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSala.FormattingEnabled = true;
            this.cboSala.Location = new System.Drawing.Point(410, 14);
            this.cboSala.Name = "cboSala";
            this.cboSala.Size = new System.Drawing.Size(300, 21);
            this.cboSala.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Rango de la Semana:";
            // 
            // txtRangoFechas
            // 
            this.txtRangoFechas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRangoFechas.Location = new System.Drawing.Point(410, 41);
            this.txtRangoFechas.Name = "txtRangoFechas";
            this.txtRangoFechas.ReadOnly = true;
            this.txtRangoFechas.Size = new System.Drawing.Size(300, 20);
            this.txtRangoFechas.TabIndex = 60;
            this.txtRangoFechas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LblAnho
            // 
            this.LblAnho.AutoSize = true;
            this.LblAnho.Location = new System.Drawing.Point(17, 17);
            this.LblAnho.Name = "LblAnho";
            this.LblAnho.Size = new System.Drawing.Size(29, 13);
            this.LblAnho.TabIndex = 45;
            this.LblAnho.Text = "Año:";
            // 
            // LblSemana
            // 
            this.LblSemana.AutoSize = true;
            this.LblSemana.Location = new System.Drawing.Point(17, 44);
            this.LblSemana.Name = "LblSemana";
            this.LblSemana.Size = new System.Drawing.Size(49, 13);
            this.LblSemana.TabIndex = 46;
            this.LblSemana.Text = "Semana:";
            // 
            // cboAnho
            // 
            this.cboAnho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnho.FormattingEnabled = true;
            this.cboAnho.Location = new System.Drawing.Point(71, 14);
            this.cboAnho.Name = "cboAnho";
            this.cboAnho.Size = new System.Drawing.Size(84, 21);
            this.cboAnho.TabIndex = 47;
            // 
            // cboSemana
            // 
            this.cboSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemana.FormattingEnabled = true;
            this.cboSemana.Location = new System.Drawing.Point(72, 41);
            this.cboSemana.Name = "cboSemana";
            this.cboSemana.Size = new System.Drawing.Size(84, 21);
            this.cboSemana.TabIndex = 48;
            // 
            // FrmHorarioSemanalVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 492);
            this.Controls.Add(this.TlpPrincipal);
            this.Name = "FrmHorarioSemanalVista";
            this.Text = "Vista del Horario Semanal";
            this.Load += new System.EventHandler(this.FrmHorarioSemanalVista_Load);
            this.TlpPrincipal.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.PnlGrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarioSemanal)).EndInit();
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TableLayoutPanel TlpPrincipal;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Panel PnlGrilla;
        private System.Windows.Forms.DataGridView dgvHorarioSemanal;
        private System.Windows.Forms.Panel pnlCabecera;
        internal System.Windows.Forms.Label LblAnho;
        internal System.Windows.Forms.Label LblSemana;
        public System.Windows.Forms.ComboBox cboAnho;
        public System.Windows.Forms.ComboBox cboSemana;
        internal System.Windows.Forms.Label LblSala;
        public System.Windows.Forms.ComboBox cboSala;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRangoFechas;
    }
}