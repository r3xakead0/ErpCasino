namespace ErpCasino.WindowsForms.Seguridad
{
    partial class FrmCambioClave
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClaveActual = new System.Windows.Forms.Label();
            this.txtClaveActual = new System.Windows.Forms.TextBox();
            this.lblClaveNueva = new System.Windows.Forms.Label();
            this.txtClaveNueva = new System.Windows.Forms.TextBox();
            this.lblClaveRepetir = new System.Windows.Forms.Label();
            this.txtClaveRepetir = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(315, 172);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblClaveActual);
            this.panel1.Controls.Add(this.txtClaveActual);
            this.panel1.Controls.Add(this.lblClaveNueva);
            this.panel1.Controls.Add(this.txtClaveNueva);
            this.panel1.Controls.Add(this.lblClaveRepetir);
            this.panel1.Controls.Add(this.txtClaveRepetir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 116);
            this.panel1.TabIndex = 16;
            // 
            // lblClaveActual
            // 
            this.lblClaveActual.AutoSize = true;
            this.lblClaveActual.Location = new System.Drawing.Point(27, 23);
            this.lblClaveActual.Name = "lblClaveActual";
            this.lblClaveActual.Size = new System.Drawing.Size(73, 13);
            this.lblClaveActual.TabIndex = 15;
            this.lblClaveActual.Text = "Clave Actual :";
            // 
            // txtClaveActual
            // 
            this.txtClaveActual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClaveActual.Location = new System.Drawing.Point(145, 20);
            this.txtClaveActual.Name = "txtClaveActual";
            this.txtClaveActual.PasswordChar = '*';
            this.txtClaveActual.Size = new System.Drawing.Size(127, 20);
            this.txtClaveActual.TabIndex = 17;
            this.txtClaveActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblClaveNueva
            // 
            this.lblClaveNueva.AutoSize = true;
            this.lblClaveNueva.Location = new System.Drawing.Point(27, 49);
            this.lblClaveNueva.Name = "lblClaveNueva";
            this.lblClaveNueva.Size = new System.Drawing.Size(72, 13);
            this.lblClaveNueva.TabIndex = 18;
            this.lblClaveNueva.Text = "Nueva Clave:";
            // 
            // txtClaveNueva
            // 
            this.txtClaveNueva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClaveNueva.Location = new System.Drawing.Point(145, 46);
            this.txtClaveNueva.Name = "txtClaveNueva";
            this.txtClaveNueva.PasswordChar = '*';
            this.txtClaveNueva.Size = new System.Drawing.Size(127, 20);
            this.txtClaveNueva.TabIndex = 20;
            this.txtClaveNueva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblClaveRepetir
            // 
            this.lblClaveRepetir.AutoSize = true;
            this.lblClaveRepetir.Location = new System.Drawing.Point(27, 75);
            this.lblClaveRepetir.Name = "lblClaveRepetir";
            this.lblClaveRepetir.Size = new System.Drawing.Size(112, 13);
            this.lblClaveRepetir.TabIndex = 21;
            this.lblClaveRepetir.Text = "Repetir Nueva Clave :";
            // 
            // txtClaveRepetir
            // 
            this.txtClaveRepetir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClaveRepetir.Location = new System.Drawing.Point(145, 72);
            this.txtClaveRepetir.Name = "txtClaveRepetir";
            this.txtClaveRepetir.PasswordChar = '*';
            this.txtClaveRepetir.Size = new System.Drawing.Size(127, 20);
            this.txtClaveRepetir.TabIndex = 22;
            this.txtClaveRepetir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnSave);
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 44);
            this.panel2.TabIndex = 17;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(200, 5);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(100, 30);
            this.BtnSave.TabIndex = 17;
            this.BtnSave.Text = "Guardar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(94, 5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 30);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmCambioClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 172);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "FrmCambioClave";
            this.Text = "Cambiar Clave";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lblClaveActual;
        internal System.Windows.Forms.TextBox txtClaveActual;
        internal System.Windows.Forms.Label lblClaveNueva;
        internal System.Windows.Forms.TextBox txtClaveNueva;
        internal System.Windows.Forms.Label lblClaveRepetir;
        internal System.Windows.Forms.TextBox txtClaveRepetir;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.Button BtnCancel;
    }
}