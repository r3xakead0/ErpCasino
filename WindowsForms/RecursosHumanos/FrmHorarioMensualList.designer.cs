namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmHorarioMensualList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHorarioMensualList));
            this.btnNuevo = new System.Windows.Forms.Button();
            this.TlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.PnlBotones = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.PnlGrilla = new System.Windows.Forms.Panel();
            this.dgvHorariosMensuales = new System.Windows.Forms.DataGridView();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.LblSala = new System.Windows.Forms.Label();
            this.cboSala = new System.Windows.Forms.ComboBox();
            this.TlpPrincipal.SuspendLayout();
            this.PnlBotones.SuspendLayout();
            this.PnlGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorariosMensuales)).BeginInit();
            this.pnlFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Location = new System.Drawing.Point(177, 5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 30);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // TlpPrincipal
            // 
            this.TlpPrincipal.ColumnCount = 1;
            this.TlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPrincipal.Controls.Add(this.PnlBotones, 0, 2);
            this.TlpPrincipal.Controls.Add(this.PnlGrilla, 0, 1);
            this.TlpPrincipal.Controls.Add(this.pnlFiltro, 0, 0);
            this.TlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.TlpPrincipal.Name = "TlpPrincipal";
            this.TlpPrincipal.RowCount = 3;
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TlpPrincipal.Size = new System.Drawing.Size(292, 382);
            this.TlpPrincipal.TabIndex = 19;
            // 
            // PnlBotones
            // 
            this.PnlBotones.Controls.Add(this.btnEliminar);
            this.PnlBotones.Controls.Add(this.btnNuevo);
            this.PnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBotones.Location = new System.Drawing.Point(3, 335);
            this.PnlBotones.Name = "PnlBotones";
            this.PnlBotones.Size = new System.Drawing.Size(286, 44);
            this.PnlBotones.TabIndex = 1;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(71, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // PnlGrilla
            // 
            this.PnlGrilla.Controls.Add(this.dgvHorariosMensuales);
            this.PnlGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlGrilla.Location = new System.Drawing.Point(3, 53);
            this.PnlGrilla.Name = "PnlGrilla";
            this.PnlGrilla.Size = new System.Drawing.Size(286, 276);
            this.PnlGrilla.TabIndex = 0;
            // 
            // dgvHorariosMensuales
            // 
            this.dgvHorariosMensuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorariosMensuales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHorariosMensuales.Location = new System.Drawing.Point(0, 0);
            this.dgvHorariosMensuales.Name = "dgvHorariosMensuales";
            this.dgvHorariosMensuales.Size = new System.Drawing.Size(286, 276);
            this.dgvHorariosMensuales.TabIndex = 1;
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Controls.Add(this.LblSala);
            this.pnlFiltro.Controls.Add(this.cboSala);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiltro.Location = new System.Drawing.Point(3, 3);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(286, 44);
            this.pnlFiltro.TabIndex = 2;
            // 
            // LblSala
            // 
            this.LblSala.AutoSize = true;
            this.LblSala.Location = new System.Drawing.Point(9, 16);
            this.LblSala.Name = "LblSala";
            this.LblSala.Size = new System.Drawing.Size(34, 13);
            this.LblSala.TabIndex = 57;
            this.LblSala.Text = "Sala :";
            // 
            // cboSala
            // 
            this.cboSala.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSala.FormattingEnabled = true;
            this.cboSala.Location = new System.Drawing.Point(49, 13);
            this.cboSala.Name = "cboSala";
            this.cboSala.Size = new System.Drawing.Size(228, 21);
            this.cboSala.TabIndex = 58;
            this.cboSala.SelectionChangeCommitted += new System.EventHandler(this.cboSala_SelectionChangeCommitted);
            // 
            // FrmHorarioMensualList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 382);
            this.Controls.Add(this.TlpPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmHorarioMensualList";
            this.Text = "Listado de Horarios Mensuales";
            this.Load += new System.EventHandler(this.FrmHorarioMensualList_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmHorarioMensualList_ResizeEnd);
            this.TlpPrincipal.ResumeLayout(false);
            this.PnlBotones.ResumeLayout(false);
            this.PnlGrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorariosMensuales)).EndInit();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TableLayoutPanel TlpPrincipal;
        private System.Windows.Forms.Panel PnlBotones;
        private System.Windows.Forms.Panel PnlGrilla;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvHorariosMensuales;
        private System.Windows.Forms.Panel pnlFiltro;
        internal System.Windows.Forms.Label LblSala;
        public System.Windows.Forms.ComboBox cboSala;
    }
}