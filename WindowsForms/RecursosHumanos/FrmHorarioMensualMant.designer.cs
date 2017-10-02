namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmHorarioMensualMant
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.dgvHorarioMensual = new System.Windows.Forms.DataGridView();
            this.grpCargarHorarioMensual = new System.Windows.Forms.GroupBox();
            this.cboSala = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnArchivo = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.ss = new System.Windows.Forms.Button();
            this.grpListadoHorarioMensual = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarioMensual)).BeginInit();
            this.grpCargarHorarioMensual.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.grpListadoHorarioMensual.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlPrincipal, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlBotones, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(991, 499);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.grpListadoHorarioMensual);
            this.pnlPrincipal.Controls.Add(this.grpCargarHorarioMensual);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(985, 433);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // dgvHorarioMensual
            // 
            this.dgvHorarioMensual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHorarioMensual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorarioMensual.Location = new System.Drawing.Point(6, 19);
            this.dgvHorarioMensual.Name = "dgvHorarioMensual";
            this.dgvHorarioMensual.Size = new System.Drawing.Size(955, 304);
            this.dgvHorarioMensual.TabIndex = 0;
            // 
            // grpCargarHorarioMensual
            // 
            this.grpCargarHorarioMensual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCargarHorarioMensual.Controls.Add(this.cboSala);
            this.grpCargarHorarioMensual.Controls.Add(this.label1);
            this.grpCargarHorarioMensual.Controls.Add(this.btnArchivo);
            this.grpCargarHorarioMensual.Controls.Add(this.txtArchivo);
            this.grpCargarHorarioMensual.Controls.Add(this.btnCargar);
            this.grpCargarHorarioMensual.Controls.Add(this.lblArchivo);
            this.grpCargarHorarioMensual.Location = new System.Drawing.Point(9, 9);
            this.grpCargarHorarioMensual.Name = "grpCargarHorarioMensual";
            this.grpCargarHorarioMensual.Size = new System.Drawing.Size(967, 86);
            this.grpCargarHorarioMensual.TabIndex = 40;
            this.grpCargarHorarioMensual.TabStop = false;
            this.grpCargarHorarioMensual.Text = "Cargar Horario Mensual";
            // 
            // cboSala
            // 
            this.cboSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSala.FormattingEnabled = true;
            this.cboSala.Location = new System.Drawing.Point(73, 22);
            this.cboSala.Name = "cboSala";
            this.cboSala.Size = new System.Drawing.Size(252, 21);
            this.cboSala.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Sala :";
            // 
            // btnArchivo
            // 
            this.btnArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchivo.Location = new System.Drawing.Point(932, 22);
            this.btnArchivo.Name = "btnArchivo";
            this.btnArchivo.Size = new System.Drawing.Size(25, 20);
            this.btnArchivo.TabIndex = 20;
            this.btnArchivo.UseVisualStyleBackColor = true;
            this.btnArchivo.Click += new System.EventHandler(this.btnArchivo_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArchivo.Location = new System.Drawing.Point(458, 22);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(468, 20);
            this.txtArchivo.TabIndex = 17;
            // 
            // btnCargar
            // 
            this.btnCargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargar.Location = new System.Drawing.Point(857, 47);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(100, 25);
            this.btnCargar.TabIndex = 19;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(392, 25);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(49, 13);
            this.lblArchivo.TabIndex = 15;
            this.lblArchivo.Text = "Archivo :";
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Controls.Add(this.ss);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotones.Location = new System.Drawing.Point(3, 442);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(985, 54);
            this.pnlBotones.TabIndex = 17;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(876, 11);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ss
            // 
            this.ss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ss.Location = new System.Drawing.Point(770, 11);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(100, 30);
            this.ss.TabIndex = 18;
            this.ss.Text = "Cancelar";
            this.ss.UseVisualStyleBackColor = true;
            this.ss.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grpListadoHorarioMensual
            // 
            this.grpListadoHorarioMensual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpListadoHorarioMensual.Controls.Add(this.dgvHorarioMensual);
            this.grpListadoHorarioMensual.Location = new System.Drawing.Point(9, 101);
            this.grpListadoHorarioMensual.Name = "grpListadoHorarioMensual";
            this.grpListadoHorarioMensual.Size = new System.Drawing.Size(967, 329);
            this.grpListadoHorarioMensual.TabIndex = 41;
            this.grpListadoHorarioMensual.TabStop = false;
            this.grpListadoHorarioMensual.Text = "Lista Horario Mensual";
            // 
            // FrmHorarioMensualMant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 499);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "FrmHorarioMensualMant";
            this.Text = "Mantenimiento de Horario Mensual";
            this.Load += new System.EventHandler(this.FrmHorarioMensualMant_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarioMensual)).EndInit();
            this.grpCargarHorarioMensual.ResumeLayout(false);
            this.grpCargarHorarioMensual.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.grpListadoHorarioMensual.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlBotones;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button ss;
        private System.Windows.Forms.GroupBox grpCargarHorarioMensual;
        internal System.Windows.Forms.TextBox txtArchivo;
        public System.Windows.Forms.Button btnCargar;
        internal System.Windows.Forms.Label lblArchivo;
        public System.Windows.Forms.Button btnArchivo;
        internal System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cboSala;
        private System.Windows.Forms.DataGridView dgvHorarioMensual;
        private System.Windows.Forms.GroupBox grpListadoHorarioMensual;
    }
}