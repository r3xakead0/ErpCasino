namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmCandidatoList
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
            this.dgvCandidatos = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.BtnContratar = new System.Windows.Forms.Button();
            this.pnlListado = new System.Windows.Forms.Panel();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.txtNroCandidatos = new System.Windows.Forms.TextBox();
            this.lblRegistrosAsistencias = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidatos)).BeginInit();
            this.tlpPrincipal.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.pnlListado.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCandidatos
            // 
            this.dgvCandidatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCandidatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCandidatos.Location = new System.Drawing.Point(0, 0);
            this.dgvCandidatos.Name = "dgvCandidatos";
            this.dgvCandidatos.Size = new System.Drawing.Size(913, 311);
            this.dgvCandidatos.TabIndex = 0;
            this.dgvCandidatos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCandidato_ColumnHeaderMouseClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Location = new System.Drawing.Point(804, 3);
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
            this.btnEditar.Location = new System.Drawing.Point(698, 3);
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
            this.btnEliminar.Location = new System.Drawing.Point(592, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlBotones, 0, 2);
            this.tlpPrincipal.Controls.Add(this.pnlListado, 0, 0);
            this.tlpPrincipal.Controls.Add(this.pnlResumen, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPrincipal.Size = new System.Drawing.Size(919, 397);
            this.tlpPrincipal.TabIndex = 19;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.BtnContratar);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Controls.Add(this.btnEditar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotones.Location = new System.Drawing.Point(3, 350);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(913, 44);
            this.pnlBotones.TabIndex = 1;
            // 
            // BtnContratar
            // 
            this.BtnContratar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnContratar.Location = new System.Drawing.Point(486, 3);
            this.BtnContratar.Name = "BtnContratar";
            this.BtnContratar.Size = new System.Drawing.Size(100, 30);
            this.BtnContratar.TabIndex = 19;
            this.BtnContratar.Text = "Contratar";
            this.BtnContratar.UseVisualStyleBackColor = true;
            this.BtnContratar.Click += new System.EventHandler(this.BtnContratar_Click);
            // 
            // pnlListado
            // 
            this.pnlListado.Controls.Add(this.dgvCandidatos);
            this.pnlListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListado.Location = new System.Drawing.Point(3, 3);
            this.pnlListado.Name = "pnlListado";
            this.pnlListado.Size = new System.Drawing.Size(913, 311);
            this.pnlListado.TabIndex = 0;
            // 
            // pnlResumen
            // 
            this.pnlResumen.Controls.Add(this.txtNroCandidatos);
            this.pnlResumen.Controls.Add(this.lblRegistrosAsistencias);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResumen.Location = new System.Drawing.Point(3, 320);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(913, 24);
            this.pnlResumen.TabIndex = 2;
            // 
            // txtNroCandidatos
            // 
            this.txtNroCandidatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNroCandidatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroCandidatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroCandidatos.Location = new System.Drawing.Point(851, 1);
            this.txtNroCandidatos.Name = "txtNroCandidatos";
            this.txtNroCandidatos.ReadOnly = true;
            this.txtNroCandidatos.Size = new System.Drawing.Size(62, 20);
            this.txtNroCandidatos.TabIndex = 60;
            this.txtNroCandidatos.Text = "0";
            this.txtNroCandidatos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRegistrosAsistencias
            // 
            this.lblRegistrosAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistrosAsistencias.AutoSize = true;
            this.lblRegistrosAsistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosAsistencias.Location = new System.Drawing.Point(788, 4);
            this.lblRegistrosAsistencias.Name = "lblRegistrosAsistencias";
            this.lblRegistrosAsistencias.Size = new System.Drawing.Size(57, 13);
            this.lblRegistrosAsistencias.TabIndex = 59;
            this.lblRegistrosAsistencias.Text = "Registros :";
            // 
            // FrmCandidatoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 397);
            this.Controls.Add(this.tlpPrincipal);
            this.Name = "FrmCandidatoList";
            this.Text = "Listado de Candidatos";
            this.Load += new System.EventHandler(this.FrmCandidatoList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidatos)).EndInit();
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.pnlListado.ResumeLayout(false);
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCandidatos;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Panel pnlListado;
        private System.Windows.Forms.Button BtnContratar;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.TextBox txtNroCandidatos;
        internal System.Windows.Forms.Label lblRegistrosAsistencias;
    }
}