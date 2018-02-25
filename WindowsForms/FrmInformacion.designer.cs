namespace ErpCasino.WindowsForms
{
    partial class FrmInformacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInformacion));
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAcceso = new System.Windows.Forms.Panel();
            this.lnkConctacto = new System.Windows.Forms.LinkLabel();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtSistema = new System.Windows.Forms.TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblSistema = new System.Windows.Forms.Label();
            this.pnlLogoMain = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.tlpPrincipal.SuspendLayout();
            this.pnlAcceso.SuspendLayout();
            this.pnlLogoMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 2;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlAcceso, 1, 0);
            this.tlpPrincipal.Controls.Add(this.pnlLogoMain, 0, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 1;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpPrincipal.Size = new System.Drawing.Size(435, 120);
            this.tlpPrincipal.TabIndex = 5;
            // 
            // pnlAcceso
            // 
            this.pnlAcceso.Controls.Add(this.lnkConctacto);
            this.pnlAcceso.Controls.Add(this.txtVersion);
            this.pnlAcceso.Controls.Add(this.txtSistema);
            this.pnlAcceso.Controls.Add(this.lblContacto);
            this.pnlAcceso.Controls.Add(this.lblVersion);
            this.pnlAcceso.Controls.Add(this.lblSistema);
            this.pnlAcceso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAcceso.Location = new System.Drawing.Point(120, 3);
            this.pnlAcceso.Name = "pnlAcceso";
            this.pnlAcceso.Size = new System.Drawing.Size(312, 114);
            this.pnlAcceso.TabIndex = 0;
            // 
            // lnkConctacto
            // 
            this.lnkConctacto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkConctacto.Location = new System.Drawing.Point(111, 75);
            this.lnkConctacto.Name = "lnkConctacto";
            this.lnkConctacto.Size = new System.Drawing.Size(163, 13);
            this.lnkConctacto.TabIndex = 61;
            this.lnkConctacto.TabStop = true;
            this.lnkConctacto.Text = "Chainiz Software";
            this.lnkConctacto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkConctacto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkConctacto_LinkClicked);
            // 
            // txtVersion
            // 
            this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersion.Location = new System.Drawing.Point(114, 46);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(159, 20);
            this.txtVersion.TabIndex = 60;
            this.txtVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSistema
            // 
            this.txtSistema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSistema.Location = new System.Drawing.Point(114, 20);
            this.txtSistema.Name = "txtSistema";
            this.txtSistema.ReadOnly = true;
            this.txtSistema.Size = new System.Drawing.Size(159, 20);
            this.txtSistema.TabIndex = 59;
            this.txtSistema.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Location = new System.Drawing.Point(34, 75);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(66, 13);
            this.lblContacto.TabIndex = 58;
            this.lblContacto.Text = "Contacto :";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(34, 49);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(57, 13);
            this.lblVersion.TabIndex = 57;
            this.lblVersion.Text = "Versión :";
            // 
            // lblSistema
            // 
            this.lblSistema.AutoSize = true;
            this.lblSistema.Location = new System.Drawing.Point(34, 23);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(59, 13);
            this.lblSistema.TabIndex = 56;
            this.lblSistema.Text = "Sistema :";
            // 
            // pnlLogoMain
            // 
            this.pnlLogoMain.BackColor = System.Drawing.Color.Navy;
            this.pnlLogoMain.Controls.Add(this.picLogo);
            this.pnlLogoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogoMain.Location = new System.Drawing.Point(0, 0);
            this.pnlLogoMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLogoMain.Name = "pnlLogoMain";
            this.pnlLogoMain.Size = new System.Drawing.Size(117, 120);
            this.pnlLogoMain.TabIndex = 2;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.ErrorImage = null;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.InitialImage = null;
            this.picLogo.Location = new System.Drawing.Point(3, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(110, 114);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // FrmInformacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 120);
            this.Controls.Add(this.tlpPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmInformacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información";
            this.Load += new System.EventHandler(this.FrmInformacion_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlAcceso.ResumeLayout(false);
            this.pnlAcceso.PerformLayout();
            this.pnlLogoMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlAcceso;
        private System.Windows.Forms.Panel pnlLogoMain;
        internal System.Windows.Forms.Label lblContacto;
        internal System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.TextBox txtSistema;
        private System.Windows.Forms.LinkLabel lnkConctacto;
        private System.Windows.Forms.PictureBox picLogo;
    }
}