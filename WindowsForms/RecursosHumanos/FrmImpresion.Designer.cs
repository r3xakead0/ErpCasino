namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmImpresion
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
            this.crvVisorInforme = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvVisorInforme
            // 
            this.crvVisorInforme.ActiveViewIndex = -1;
            this.crvVisorInforme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVisorInforme.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVisorInforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVisorInforme.Location = new System.Drawing.Point(0, 0);
            this.crvVisorInforme.Name = "crvVisorInforme";
            this.crvVisorInforme.ShowCloseButton = false;
            this.crvVisorInforme.ShowLogo = false;
            this.crvVisorInforme.Size = new System.Drawing.Size(708, 496);
            this.crvVisorInforme.TabIndex = 0;
            this.crvVisorInforme.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 496);
            this.Controls.Add(this.crvVisorInforme);
            this.Name = "FrmImpresion";
            this.Text = "Vista de Impresión";
            this.Load += new System.EventHandler(this.FrmImpresion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVisorInforme;
    }
}