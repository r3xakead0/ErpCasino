namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmHorarioAsignarBonos
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
            this.grpListadoHorarioMensual = new System.Windows.Forms.GroupBox();
            this.dgvHorarioMensual = new System.Windows.Forms.DataGridView();
            this.grpCargarHorarioMensual = new System.Windows.Forms.GroupBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.ss = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpListadoHorarioMensual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarioMensual)).BeginInit();
            this.grpCargarHorarioMensual.SuspendLayout();
            this.pnlBotones.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(595, 431);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.grpListadoHorarioMensual);
            this.pnlPrincipal.Controls.Add(this.grpCargarHorarioMensual);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(589, 365);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // grpListadoHorarioMensual
            // 
            this.grpListadoHorarioMensual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpListadoHorarioMensual.Controls.Add(this.dgvHorarioMensual);
            this.grpListadoHorarioMensual.Location = new System.Drawing.Point(9, 101);
            this.grpListadoHorarioMensual.Name = "grpListadoHorarioMensual";
            this.grpListadoHorarioMensual.Size = new System.Drawing.Size(571, 261);
            this.grpListadoHorarioMensual.TabIndex = 41;
            this.grpListadoHorarioMensual.TabStop = false;
            this.grpListadoHorarioMensual.Text = "Lista Horario Mensual";
            // 
            // dgvHorarioMensual
            // 
            this.dgvHorarioMensual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHorarioMensual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorarioMensual.Location = new System.Drawing.Point(6, 48);
            this.dgvHorarioMensual.Name = "dgvHorarioMensual";
            this.dgvHorarioMensual.Size = new System.Drawing.Size(559, 207);
            this.dgvHorarioMensual.TabIndex = 0;
            // 
            // grpCargarHorarioMensual
            // 
            this.grpCargarHorarioMensual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCargarHorarioMensual.Controls.Add(this.btnCargar);
            this.grpCargarHorarioMensual.Location = new System.Drawing.Point(9, 9);
            this.grpCargarHorarioMensual.Name = "grpCargarHorarioMensual";
            this.grpCargarHorarioMensual.Size = new System.Drawing.Size(571, 86);
            this.grpCargarHorarioMensual.TabIndex = 40;
            this.grpCargarHorarioMensual.TabStop = false;
            this.grpCargarHorarioMensual.Text = "Cargar Horario Mensual";
            // 
            // btnCargar
            // 
            this.btnCargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargar.Location = new System.Drawing.Point(461, 47);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(100, 25);
            this.btnCargar.TabIndex = 19;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Controls.Add(this.ss);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotones.Location = new System.Drawing.Point(3, 374);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(589, 54);
            this.pnlBotones.TabIndex = 17;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(480, 11);
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
            this.ss.Location = new System.Drawing.Point(374, 11);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(100, 30);
            this.ss.TabIndex = 18;
            this.ss.Text = "Cancelar";
            this.ss.UseVisualStyleBackColor = true;
            this.ss.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmHorarioAsignarBonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 431);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "FrmHorarioAsignarBonos";
            this.Text = "Asignar Bonos y Descuentos";
            this.Load += new System.EventHandler(this.FrmHorarioAsignarBonos_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.grpListadoHorarioMensual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarioMensual)).EndInit();
            this.grpCargarHorarioMensual.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlBotones;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.Button ss;
        private System.Windows.Forms.GroupBox grpCargarHorarioMensual;
        public System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.DataGridView dgvHorarioMensual;
        private System.Windows.Forms.GroupBox grpListadoHorarioMensual;
    }
}