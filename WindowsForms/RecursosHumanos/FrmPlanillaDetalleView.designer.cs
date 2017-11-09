namespace ErpCasino.WindowsForms.RecursosHumanos
{
    partial class FrmPlanillaDetalleView
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
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.grpResumen = new System.Windows.Forms.GroupBox();
            this.txtSueldoPago = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSueldoNeto = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.grpDeducciones = new System.Windows.Forms.GroupBox();
            this.txtDeduccionPrestamos = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDeduccionAdelantos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeduccionRJ = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grpPension = new System.Windows.Forms.GroupBox();
            this.txtEssalud = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPensionPublica = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPensionPrivada = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.grpSueldo = new System.Windows.Forms.GroupBox();
            this.txtSueldoAsigFam = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSueldoBase = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpDescuentos = new System.Windows.Forms.GroupBox();
            this.txtDescuentoInasistenciasCantidad = new System.Windows.Forms.TextBox();
            this.txtDescuentoTardanzasCantidad = new System.Windows.Forms.TextBox();
            this.txtDescuentoInasistencias = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescuentoTardanzas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpBonos = new System.Windows.Forms.GroupBox();
            this.txtBonoFeriadosCantidad = new System.Windows.Forms.TextBox();
            this.txtBonoExtrasCantidad = new System.Windows.Forms.TextBox();
            this.txtBonoNocturnoCantidad = new System.Windows.Forms.TextBox();
            this.txtBonoFeriado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBonoExtra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBonoNocturno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpEmpleado = new System.Windows.Forms.GroupBox();
            this.cboCalculoPor = new System.Windows.Forms.ComboBox();
            this.lblCalculoPor = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpleadoCodigo = new System.Windows.Forms.TextBox();
            this.txtEmpleadoNombres = new System.Windows.Forms.TextBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.grpResumen.SuspendLayout();
            this.grpDeducciones.SuspendLayout();
            this.grpPension.SuspendLayout();
            this.grpSueldo.SuspendLayout();
            this.grpDescuentos.SuspendLayout();
            this.grpBonos.SuspendLayout();
            this.grpEmpleado.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlPrincipal, 0, 0);
            this.tlpPrincipal.Controls.Add(this.pnlInferior, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPrincipal.Size = new System.Drawing.Size(758, 355);
            this.tlpPrincipal.TabIndex = 16;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.grpResumen);
            this.pnlPrincipal.Controls.Add(this.grpDeducciones);
            this.pnlPrincipal.Controls.Add(this.grpPension);
            this.pnlPrincipal.Controls.Add(this.grpSueldo);
            this.pnlPrincipal.Controls.Add(this.grpDescuentos);
            this.pnlPrincipal.Controls.Add(this.grpBonos);
            this.pnlPrincipal.Controls.Add(this.grpEmpleado);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(3, 3);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(752, 299);
            this.pnlPrincipal.TabIndex = 16;
            // 
            // grpResumen
            // 
            this.grpResumen.Controls.Add(this.txtSueldoPago);
            this.grpResumen.Controls.Add(this.label16);
            this.grpResumen.Controls.Add(this.txtSueldoNeto);
            this.grpResumen.Controls.Add(this.label17);
            this.grpResumen.Location = new System.Drawing.Point(536, 196);
            this.grpResumen.Name = "grpResumen";
            this.grpResumen.Size = new System.Drawing.Size(213, 81);
            this.grpResumen.TabIndex = 81;
            this.grpResumen.TabStop = false;
            this.grpResumen.Text = "Resumen";
            // 
            // txtSueldoPago
            // 
            this.txtSueldoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSueldoPago.Location = new System.Drawing.Point(121, 45);
            this.txtSueldoPago.Name = "txtSueldoPago";
            this.txtSueldoPago.ReadOnly = true;
            this.txtSueldoPago.Size = new System.Drawing.Size(81, 20);
            this.txtSueldoPago.TabIndex = 75;
            this.txtSueldoPago.Text = "1,000.00";
            this.txtSueldoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 13);
            this.label16.TabIndex = 74;
            this.label16.Text = "Sueldo a Pagar :";
            // 
            // txtSueldoNeto
            // 
            this.txtSueldoNeto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSueldoNeto.Location = new System.Drawing.Point(121, 20);
            this.txtSueldoNeto.Name = "txtSueldoNeto";
            this.txtSueldoNeto.ReadOnly = true;
            this.txtSueldoNeto.Size = new System.Drawing.Size(81, 20);
            this.txtSueldoNeto.TabIndex = 73;
            this.txtSueldoNeto.Text = "1,000.00";
            this.txtSueldoNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "Sueldo Neto :";
            // 
            // grpDeducciones
            // 
            this.grpDeducciones.Controls.Add(this.txtDeduccionPrestamos);
            this.grpDeducciones.Controls.Add(this.label13);
            this.grpDeducciones.Controls.Add(this.txtDeduccionAdelantos);
            this.grpDeducciones.Controls.Add(this.label5);
            this.grpDeducciones.Controls.Add(this.txtDeduccionRJ);
            this.grpDeducciones.Controls.Add(this.label10);
            this.grpDeducciones.Location = new System.Drawing.Point(308, 171);
            this.grpDeducciones.Name = "grpDeducciones";
            this.grpDeducciones.Size = new System.Drawing.Size(213, 106);
            this.grpDeducciones.TabIndex = 80;
            this.grpDeducciones.TabStop = false;
            this.grpDeducciones.Text = "Deducciones";
            // 
            // txtDeduccionPrestamos
            // 
            this.txtDeduccionPrestamos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeduccionPrestamos.Location = new System.Drawing.Point(121, 71);
            this.txtDeduccionPrestamos.Name = "txtDeduccionPrestamos";
            this.txtDeduccionPrestamos.ReadOnly = true;
            this.txtDeduccionPrestamos.Size = new System.Drawing.Size(81, 20);
            this.txtDeduccionPrestamos.TabIndex = 77;
            this.txtDeduccionPrestamos.Text = "1,000.00";
            this.txtDeduccionPrestamos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 76;
            this.label13.Text = "Prestamos :";
            // 
            // txtDeduccionAdelantos
            // 
            this.txtDeduccionAdelantos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeduccionAdelantos.Location = new System.Drawing.Point(121, 45);
            this.txtDeduccionAdelantos.Name = "txtDeduccionAdelantos";
            this.txtDeduccionAdelantos.ReadOnly = true;
            this.txtDeduccionAdelantos.Size = new System.Drawing.Size(81, 20);
            this.txtDeduccionAdelantos.TabIndex = 75;
            this.txtDeduccionAdelantos.Text = "1,000.00";
            this.txtDeduccionAdelantos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Adelantos :";
            // 
            // txtDeduccionRJ
            // 
            this.txtDeduccionRJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeduccionRJ.Location = new System.Drawing.Point(121, 19);
            this.txtDeduccionRJ.Name = "txtDeduccionRJ";
            this.txtDeduccionRJ.ReadOnly = true;
            this.txtDeduccionRJ.Size = new System.Drawing.Size(81, 20);
            this.txtDeduccionRJ.TabIndex = 73;
            this.txtDeduccionRJ.Text = "1,000.00";
            this.txtDeduccionRJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Retencion Judicial :";
            // 
            // grpPension
            // 
            this.grpPension.Controls.Add(this.txtEssalud);
            this.grpPension.Controls.Add(this.label14);
            this.grpPension.Controls.Add(this.txtPensionPublica);
            this.grpPension.Controls.Add(this.label11);
            this.grpPension.Controls.Add(this.txtPensionPrivada);
            this.grpPension.Controls.Add(this.label12);
            this.grpPension.Location = new System.Drawing.Point(536, 84);
            this.grpPension.Name = "grpPension";
            this.grpPension.Size = new System.Drawing.Size(213, 106);
            this.grpPension.TabIndex = 80;
            this.grpPension.TabStop = false;
            this.grpPension.Text = "Aportes";
            // 
            // txtEssalud
            // 
            this.txtEssalud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEssalud.Location = new System.Drawing.Point(121, 71);
            this.txtEssalud.Name = "txtEssalud";
            this.txtEssalud.ReadOnly = true;
            this.txtEssalud.Size = new System.Drawing.Size(81, 20);
            this.txtEssalud.TabIndex = 77;
            this.txtEssalud.Text = "1,000.00";
            this.txtEssalud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 76;
            this.label14.Text = "ESSALUD :";
            // 
            // txtPensionPublica
            // 
            this.txtPensionPublica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPensionPublica.Location = new System.Drawing.Point(121, 46);
            this.txtPensionPublica.Name = "txtPensionPublica";
            this.txtPensionPublica.ReadOnly = true;
            this.txtPensionPublica.Size = new System.Drawing.Size(81, 20);
            this.txtPensionPublica.TabIndex = 75;
            this.txtPensionPublica.Text = "1,000.00";
            this.txtPensionPublica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 74;
            this.label11.Text = "ONP :";
            // 
            // txtPensionPrivada
            // 
            this.txtPensionPrivada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPensionPrivada.Location = new System.Drawing.Point(121, 19);
            this.txtPensionPrivada.Name = "txtPensionPrivada";
            this.txtPensionPrivada.ReadOnly = true;
            this.txtPensionPrivada.Size = new System.Drawing.Size(81, 20);
            this.txtPensionPrivada.TabIndex = 73;
            this.txtPensionPrivada.Text = "1,000.00";
            this.txtPensionPrivada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "AFP :";
            // 
            // grpSueldo
            // 
            this.grpSueldo.Controls.Add(this.txtSueldoAsigFam);
            this.grpSueldo.Controls.Add(this.label8);
            this.grpSueldo.Controls.Add(this.txtSueldoBase);
            this.grpSueldo.Controls.Add(this.label9);
            this.grpSueldo.Location = new System.Drawing.Point(308, 84);
            this.grpSueldo.Name = "grpSueldo";
            this.grpSueldo.Size = new System.Drawing.Size(213, 81);
            this.grpSueldo.TabIndex = 79;
            this.grpSueldo.TabStop = false;
            this.grpSueldo.Text = "Sueldo";
            // 
            // txtSueldoAsigFam
            // 
            this.txtSueldoAsigFam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSueldoAsigFam.Location = new System.Drawing.Point(121, 45);
            this.txtSueldoAsigFam.Name = "txtSueldoAsigFam";
            this.txtSueldoAsigFam.ReadOnly = true;
            this.txtSueldoAsigFam.Size = new System.Drawing.Size(81, 20);
            this.txtSueldoAsigFam.TabIndex = 75;
            this.txtSueldoAsigFam.Text = "1,000.00";
            this.txtSueldoAsigFam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Asignación Familiar :";
            // 
            // txtSueldoBase
            // 
            this.txtSueldoBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSueldoBase.Location = new System.Drawing.Point(121, 19);
            this.txtSueldoBase.Name = "txtSueldoBase";
            this.txtSueldoBase.ReadOnly = true;
            this.txtSueldoBase.Size = new System.Drawing.Size(81, 20);
            this.txtSueldoBase.TabIndex = 73;
            this.txtSueldoBase.Text = "1,000.00";
            this.txtSueldoBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Sueldo :";
            // 
            // grpDescuentos
            // 
            this.grpDescuentos.Controls.Add(this.txtDescuentoInasistenciasCantidad);
            this.grpDescuentos.Controls.Add(this.txtDescuentoTardanzasCantidad);
            this.grpDescuentos.Controls.Add(this.txtDescuentoInasistencias);
            this.grpDescuentos.Controls.Add(this.label6);
            this.grpDescuentos.Controls.Add(this.txtDescuentoTardanzas);
            this.grpDescuentos.Controls.Add(this.label7);
            this.grpDescuentos.Location = new System.Drawing.Point(3, 196);
            this.grpDescuentos.Name = "grpDescuentos";
            this.grpDescuentos.Size = new System.Drawing.Size(290, 81);
            this.grpDescuentos.TabIndex = 78;
            this.grpDescuentos.TabStop = false;
            this.grpDescuentos.Text = "Descuentos";
            // 
            // txtDescuentoInasistenciasCantidad
            // 
            this.txtDescuentoInasistenciasCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescuentoInasistenciasCantidad.Location = new System.Drawing.Point(137, 46);
            this.txtDescuentoInasistenciasCantidad.Name = "txtDescuentoInasistenciasCantidad";
            this.txtDescuentoInasistenciasCantidad.ReadOnly = true;
            this.txtDescuentoInasistenciasCantidad.Size = new System.Drawing.Size(55, 20);
            this.txtDescuentoInasistenciasCantidad.TabIndex = 81;
            this.txtDescuentoInasistenciasCantidad.Text = "120 h";
            this.txtDescuentoInasistenciasCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuentoInasistenciasCantidad.DoubleClick += new System.EventHandler(this.txtDescuentoInasistenciasCantidad_DoubleClick);
            // 
            // txtDescuentoTardanzasCantidad
            // 
            this.txtDescuentoTardanzasCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescuentoTardanzasCantidad.Location = new System.Drawing.Point(137, 19);
            this.txtDescuentoTardanzasCantidad.Name = "txtDescuentoTardanzasCantidad";
            this.txtDescuentoTardanzasCantidad.ReadOnly = true;
            this.txtDescuentoTardanzasCantidad.Size = new System.Drawing.Size(55, 20);
            this.txtDescuentoTardanzasCantidad.TabIndex = 81;
            this.txtDescuentoTardanzasCantidad.Text = "120 m";
            this.txtDescuentoTardanzasCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuentoTardanzasCantidad.DoubleClick += new System.EventHandler(this.txtDescuentoTardanzasCantidad_DoubleClick);
            // 
            // txtDescuentoInasistencias
            // 
            this.txtDescuentoInasistencias.Location = new System.Drawing.Point(197, 46);
            this.txtDescuentoInasistencias.Name = "txtDescuentoInasistencias";
            this.txtDescuentoInasistencias.ReadOnly = true;
            this.txtDescuentoInasistencias.Size = new System.Drawing.Size(81, 20);
            this.txtDescuentoInasistencias.TabIndex = 75;
            this.txtDescuentoInasistencias.Text = "1,000.00";
            this.txtDescuentoInasistencias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 74;
            this.label6.Text = "Inasistencias :";
            // 
            // txtDescuentoTardanzas
            // 
            this.txtDescuentoTardanzas.Location = new System.Drawing.Point(198, 19);
            this.txtDescuentoTardanzas.Name = "txtDescuentoTardanzas";
            this.txtDescuentoTardanzas.ReadOnly = true;
            this.txtDescuentoTardanzas.Size = new System.Drawing.Size(81, 20);
            this.txtDescuentoTardanzas.TabIndex = 73;
            this.txtDescuentoTardanzas.Text = "1,000.00";
            this.txtDescuentoTardanzas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Tardanzas :";
            // 
            // grpBonos
            // 
            this.grpBonos.Controls.Add(this.txtBonoFeriadosCantidad);
            this.grpBonos.Controls.Add(this.txtBonoExtrasCantidad);
            this.grpBonos.Controls.Add(this.txtBonoNocturnoCantidad);
            this.grpBonos.Controls.Add(this.txtBonoFeriado);
            this.grpBonos.Controls.Add(this.label4);
            this.grpBonos.Controls.Add(this.txtBonoExtra);
            this.grpBonos.Controls.Add(this.label2);
            this.grpBonos.Controls.Add(this.txtBonoNocturno);
            this.grpBonos.Controls.Add(this.label3);
            this.grpBonos.Location = new System.Drawing.Point(3, 84);
            this.grpBonos.Name = "grpBonos";
            this.grpBonos.Size = new System.Drawing.Size(290, 106);
            this.grpBonos.TabIndex = 76;
            this.grpBonos.TabStop = false;
            this.grpBonos.Text = "Bonos";
            // 
            // txtBonoFeriadosCantidad
            // 
            this.txtBonoFeriadosCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBonoFeriadosCantidad.Location = new System.Drawing.Point(137, 71);
            this.txtBonoFeriadosCantidad.Name = "txtBonoFeriadosCantidad";
            this.txtBonoFeriadosCantidad.ReadOnly = true;
            this.txtBonoFeriadosCantidad.Size = new System.Drawing.Size(55, 20);
            this.txtBonoFeriadosCantidad.TabIndex = 80;
            this.txtBonoFeriadosCantidad.Text = "120 h";
            this.txtBonoFeriadosCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBonoFeriadosCantidad.DoubleClick += new System.EventHandler(this.txtBonoFeriadosCantidad_DoubleClick);
            // 
            // txtBonoExtrasCantidad
            // 
            this.txtBonoExtrasCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBonoExtrasCantidad.Location = new System.Drawing.Point(137, 45);
            this.txtBonoExtrasCantidad.Name = "txtBonoExtrasCantidad";
            this.txtBonoExtrasCantidad.ReadOnly = true;
            this.txtBonoExtrasCantidad.Size = new System.Drawing.Size(55, 20);
            this.txtBonoExtrasCantidad.TabIndex = 79;
            this.txtBonoExtrasCantidad.Text = "120 h";
            this.txtBonoExtrasCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBonoExtrasCantidad.DoubleClick += new System.EventHandler(this.txtBonoExtrasCantidad_DoubleClick);
            // 
            // txtBonoNocturnoCantidad
            // 
            this.txtBonoNocturnoCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBonoNocturnoCantidad.Location = new System.Drawing.Point(137, 19);
            this.txtBonoNocturnoCantidad.Name = "txtBonoNocturnoCantidad";
            this.txtBonoNocturnoCantidad.ReadOnly = true;
            this.txtBonoNocturnoCantidad.Size = new System.Drawing.Size(55, 20);
            this.txtBonoNocturnoCantidad.TabIndex = 78;
            this.txtBonoNocturnoCantidad.Text = "120 h";
            this.txtBonoNocturnoCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBonoNocturnoCantidad.DoubleClick += new System.EventHandler(this.txtBonoNocturnoCantidad_DoubleClick);
            // 
            // txtBonoFeriado
            // 
            this.txtBonoFeriado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBonoFeriado.Location = new System.Drawing.Point(198, 71);
            this.txtBonoFeriado.Name = "txtBonoFeriado";
            this.txtBonoFeriado.ReadOnly = true;
            this.txtBonoFeriado.Size = new System.Drawing.Size(81, 20);
            this.txtBonoFeriado.TabIndex = 77;
            this.txtBonoFeriado.Text = "1,000.00";
            this.txtBonoFeriado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Feriados :";
            // 
            // txtBonoExtra
            // 
            this.txtBonoExtra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBonoExtra.Location = new System.Drawing.Point(198, 45);
            this.txtBonoExtra.Name = "txtBonoExtra";
            this.txtBonoExtra.ReadOnly = true;
            this.txtBonoExtra.Size = new System.Drawing.Size(81, 20);
            this.txtBonoExtra.TabIndex = 75;
            this.txtBonoExtra.Text = "1,000.00";
            this.txtBonoExtra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Horas Extras :";
            // 
            // txtBonoNocturno
            // 
            this.txtBonoNocturno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBonoNocturno.Location = new System.Drawing.Point(198, 19);
            this.txtBonoNocturno.Name = "txtBonoNocturno";
            this.txtBonoNocturno.ReadOnly = true;
            this.txtBonoNocturno.Size = new System.Drawing.Size(81, 20);
            this.txtBonoNocturno.TabIndex = 73;
            this.txtBonoNocturno.Text = "1,000.00";
            this.txtBonoNocturno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Horario Nocturno :";
            // 
            // grpEmpleado
            // 
            this.grpEmpleado.Controls.Add(this.cboCalculoPor);
            this.grpEmpleado.Controls.Add(this.lblCalculoPor);
            this.grpEmpleado.Controls.Add(this.txtPeriodo);
            this.grpEmpleado.Controls.Add(this.label1);
            this.grpEmpleado.Controls.Add(this.txtEmpleadoCodigo);
            this.grpEmpleado.Controls.Add(this.txtEmpleadoNombres);
            this.grpEmpleado.Controls.Add(this.lblEmpleado);
            this.grpEmpleado.Location = new System.Drawing.Point(3, 3);
            this.grpEmpleado.Name = "grpEmpleado";
            this.grpEmpleado.Size = new System.Drawing.Size(746, 75);
            this.grpEmpleado.TabIndex = 39;
            this.grpEmpleado.TabStop = false;
            this.grpEmpleado.Text = "Datos del Registro";
            // 
            // cboCalculoPor
            // 
            this.cboCalculoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboCalculoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalculoPor.Enabled = false;
            this.cboCalculoPor.FormattingEnabled = true;
            this.cboCalculoPor.Location = new System.Drawing.Point(621, 45);
            this.cboCalculoPor.Name = "cboCalculoPor";
            this.cboCalculoPor.Size = new System.Drawing.Size(114, 21);
            this.cboCalculoPor.TabIndex = 77;
            // 
            // lblCalculoPor
            // 
            this.lblCalculoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCalculoPor.AutoSize = true;
            this.lblCalculoPor.Location = new System.Drawing.Point(542, 48);
            this.lblCalculoPor.Name = "lblCalculoPor";
            this.lblCalculoPor.Size = new System.Drawing.Size(48, 13);
            this.lblCalculoPor.TabIndex = 76;
            this.lblCalculoPor.Text = "Calculo :";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(78, 45);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.ReadOnly = true;
            this.txtPeriodo.Size = new System.Drawing.Size(114, 20);
            this.txtPeriodo.TabIndex = 75;
            this.txtPeriodo.Text = "2017/05";
            this.txtPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Año/Mes :";
            // 
            // txtEmpleadoCodigo
            // 
            this.txtEmpleadoCodigo.Location = new System.Drawing.Point(78, 19);
            this.txtEmpleadoCodigo.Name = "txtEmpleadoCodigo";
            this.txtEmpleadoCodigo.ReadOnly = true;
            this.txtEmpleadoCodigo.Size = new System.Drawing.Size(114, 20);
            this.txtEmpleadoCodigo.TabIndex = 73;
            this.txtEmpleadoCodigo.Text = "GLA00000000";
            this.txtEmpleadoCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEmpleadoNombres
            // 
            this.txtEmpleadoNombres.Location = new System.Drawing.Point(197, 19);
            this.txtEmpleadoNombres.Name = "txtEmpleadoNombres";
            this.txtEmpleadoNombres.ReadOnly = true;
            this.txtEmpleadoNombres.Size = new System.Drawing.Size(538, 20);
            this.txtEmpleadoNombres.TabIndex = 72;
            this.txtEmpleadoNombres.Text = "Paterno Materno, Nombres";
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(9, 22);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(60, 13);
            this.lblEmpleado.TabIndex = 20;
            this.lblEmpleado.Text = "Empleado :";
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.btnCancelar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Location = new System.Drawing.Point(3, 308);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(752, 44);
            this.pnlInferior.TabIndex = 17;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(643, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmPlanillaDetalleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 355);
            this.Controls.Add(this.tlpPrincipal);
            this.MaximizeBox = false;
            this.Name = "FrmPlanillaDetalleView";
            this.Text = "Detalle de la Planilla del Empleado";
            this.Load += new System.EventHandler(this.FrmPlanillaDetalleView_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlPrincipal.ResumeLayout(false);
            this.grpResumen.ResumeLayout(false);
            this.grpResumen.PerformLayout();
            this.grpDeducciones.ResumeLayout(false);
            this.grpDeducciones.PerformLayout();
            this.grpPension.ResumeLayout(false);
            this.grpPension.PerformLayout();
            this.grpSueldo.ResumeLayout(false);
            this.grpSueldo.PerformLayout();
            this.grpDescuentos.ResumeLayout(false);
            this.grpDescuentos.PerformLayout();
            this.grpBonos.ResumeLayout(false);
            this.grpBonos.PerformLayout();
            this.grpEmpleado.ResumeLayout(false);
            this.grpEmpleado.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlInferior;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpEmpleado;
        internal System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.TextBox txtPeriodo;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmpleadoCodigo;
        private System.Windows.Forms.TextBox txtEmpleadoNombres;
        private System.Windows.Forms.GroupBox grpDescuentos;
        private System.Windows.Forms.TextBox txtDescuentoInasistencias;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescuentoTardanzas;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpBonos;
        private System.Windows.Forms.TextBox txtBonoFeriado;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBonoExtra;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBonoNocturno;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescuentoInasistenciasCantidad;
        private System.Windows.Forms.TextBox txtDescuentoTardanzasCantidad;
        private System.Windows.Forms.TextBox txtBonoFeriadosCantidad;
        private System.Windows.Forms.TextBox txtBonoExtrasCantidad;
        private System.Windows.Forms.TextBox txtBonoNocturnoCantidad;
        private System.Windows.Forms.GroupBox grpPension;
        private System.Windows.Forms.TextBox txtPensionPublica;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPensionPrivada;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grpSueldo;
        private System.Windows.Forms.TextBox txtSueldoAsigFam;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSueldoBase;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label lblCalculoPor;
        private System.Windows.Forms.GroupBox grpDeducciones;
        private System.Windows.Forms.TextBox txtDeduccionPrestamos;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDeduccionAdelantos;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeduccionRJ;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEssalud;
        internal System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox grpResumen;
        private System.Windows.Forms.TextBox txtSueldoPago;
        internal System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSueldoNeto;
        internal System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboCalculoPor;
    }
}