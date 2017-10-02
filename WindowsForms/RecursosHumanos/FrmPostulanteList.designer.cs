namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmPostulanteList
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
            this.dgvPostulantes = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnCandidato = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.txtNroPostulantes = new System.Windows.Forms.TextBox();
            this.lblRegistrosAsistencias = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostulantes)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPostulantes
            // 
            this.dgvPostulantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPostulantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPostulantes.Location = new System.Drawing.Point(0, 0);
            this.dgvPostulantes.Name = "dgvPostulantes";
            this.dgvPostulantes.Size = new System.Drawing.Size(901, 318);
            this.dgvPostulantes.TabIndex = 0;
            this.dgvPostulantes.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPostulante_ColumnHeaderMouseClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Location = new System.Drawing.Point(792, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 30);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Location = new System.Drawing.Point(686, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 30);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(580, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlResumen, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(907, 404);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnCandidato);
            this.panel2.Controls.Add(this.btnNuevo);
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.btnEditar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 357);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(901, 44);
            this.panel2.TabIndex = 1;
            // 
            // BtnCandidato
            // 
            this.BtnCandidato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCandidato.Location = new System.Drawing.Point(474, 3);
            this.BtnCandidato.Name = "BtnCandidato";
            this.BtnCandidato.Size = new System.Drawing.Size(100, 30);
            this.BtnCandidato.TabIndex = 19;
            this.BtnCandidato.Text = "Candidato";
            this.BtnCandidato.UseVisualStyleBackColor = true;
            this.BtnCandidato.Click += new System.EventHandler(this.BtnCandidato_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvPostulantes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 318);
            this.panel1.TabIndex = 0;
            // 
            // pnlResumen
            // 
            this.pnlResumen.Controls.Add(this.txtNroPostulantes);
            this.pnlResumen.Controls.Add(this.lblRegistrosAsistencias);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResumen.Location = new System.Drawing.Point(3, 327);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(901, 24);
            this.pnlResumen.TabIndex = 2;
            // 
            // txtNroPostulantes
            // 
            this.txtNroPostulantes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNroPostulantes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroPostulantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroPostulantes.Location = new System.Drawing.Point(839, 0);
            this.txtNroPostulantes.Name = "txtNroPostulantes";
            this.txtNroPostulantes.ReadOnly = true;
            this.txtNroPostulantes.Size = new System.Drawing.Size(62, 20);
            this.txtNroPostulantes.TabIndex = 62;
            this.txtNroPostulantes.Text = "0";
            this.txtNroPostulantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRegistrosAsistencias
            // 
            this.lblRegistrosAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistrosAsistencias.AutoSize = true;
            this.lblRegistrosAsistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosAsistencias.Location = new System.Drawing.Point(776, 3);
            this.lblRegistrosAsistencias.Name = "lblRegistrosAsistencias";
            this.lblRegistrosAsistencias.Size = new System.Drawing.Size(57, 13);
            this.lblRegistrosAsistencias.TabIndex = 61;
            this.lblRegistrosAsistencias.Text = "Registros :";
            // 
            // FrmPostulanteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 404);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmPostulanteList";
            this.Text = "Listado de Postulantes";
            this.Load += new System.EventHandler(this.FrmPostulanteList_Load);
            this.ResizeEnd += new System.EventHandler(this.FrmPostulanteList_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostulantes)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPostulantes;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCandidato;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.TextBox txtNroPostulantes;
        internal System.Windows.Forms.Label lblRegistrosAsistencias;
    }
}