using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmPlanillaDetalleBoleta : Form
    {

        private int anho = 0;
        private int mes = 0;
        private string codigoEmpleado = "";

        public FrmPlanillaDetalleBoleta(int anho, int mes, string codigoEmpleado)
        {
            try
            {
                InitializeComponent();

                this.anho = anho;
                this.mes = mes;
                this.codigoEmpleado = codigoEmpleado;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void Cargar()
        {
            try
            {

                var lnPlanilla = new LN.Planilla(this.anho, this.mes);

                var uiBoleta = lnPlanilla.ObtenerPlanillaBoleta(this.codigoEmpleado);
                if (uiBoleta == null)
                {
                    var uiDetalle = lnPlanilla.ObtenerPlantillaDetalle(this.codigoEmpleado);

                    uiBoleta = new BE.UI.PlanillaBoleta();

                    uiBoleta.Anho = this.anho;
                    uiBoleta.Mes = this.mes;
                    uiBoleta.MesNombre = Util.GetNameOfMonth(this.mes);
                    uiBoleta.MesDias = DateTime.DaysInMonth(this.anho, this.mes);

                    var beEmpresa = new LN.Empresa().Obtener();
                    uiBoleta.EmpresaNombre = beEmpresa.NombreComercial;
                    uiBoleta.EmpresaRuc = beEmpresa.RUC;
                    uiBoleta.EmpresaDistrito = beEmpresa.Ubigeo.Nombre;
                    uiBoleta.EmpresaDireccion = beEmpresa.DomicilioFiscal;
                    beEmpresa = null;

                    var beEmpleado = new LN.Empleado().Obtener(uiDetalle.EmpleadoCodigo);
                    uiBoleta.EmpleadoCodigo = beEmpleado.Codigo;
                    uiBoleta.EmpleadoNombres = beEmpleado.Nombres;
                    uiBoleta.EmpleadoApellidos = $"{beEmpleado.ApellidoPaterno} {beEmpleado.ApellidoMaterno}";
                    uiBoleta.EmpleadoNroDocumento = beEmpleado.NumeroDocumento;
                    beEmpleado = null;

                    var beEmpleadoRecurso = new LN.Empleado().ObtenerRecurso(uiDetalle.EmpleadoCodigo);
                    uiBoleta.EmpleadoCargo = beEmpleadoRecurso.Cargo.Nombre;
                    uiBoleta.EmpleadoFechaIngreso = beEmpleadoRecurso.FechaInicio;
                    uiBoleta.EmpleadoFechaCese = beEmpleadoRecurso.FechaCese;
                    uiBoleta.EmpleadoEsSaludCodigo = beEmpleadoRecurso.Autogenerado; 
                    if (beEmpleadoRecurso.ONP == true)
                    {
                        uiBoleta.EmpleadoSppCodigo = "";
                        uiBoleta.EmpleadoSppEntidad = uiDetalle.SnpNombre;
                    }
                    else
                    {
                        uiBoleta.EmpleadoSppCodigo = beEmpleadoRecurso.CUSPP;
                        uiBoleta.EmpleadoSppEntidad = uiDetalle.AfpNombre;
                    }
                    uiBoleta.EmpleadoVacacionSalida = beEmpleadoRecurso.FechaUltimaVacacion;
                    uiBoleta.EmpleadoVacacionRetorno = null; //FALTA
                    beEmpleadoRecurso = null;

                    uiBoleta.DiasLaborados = 0;
                    uiBoleta.DiasNoLaborados = 0;
                    uiBoleta.DiasSinGoceHaber = 0;
                    uiBoleta.DiasSubsidiado = 0;
                    uiBoleta.HorasNormales = 0;

                    uiBoleta.Sueldo = uiDetalle.Base;
                    uiBoleta.AsignacionFamiliar = uiDetalle.AsignacionFamiliar;
                    uiBoleta.BonificacionNocturna = uiDetalle.BonoNocturnoTotal;
                    uiBoleta.MovilidadTranslado = 0.0; //FALTA
                    uiBoleta.SubsidioDescansoMedico = 0.0; //FALTA
                    uiBoleta.BonificacionHorasExtras = uiDetalle.BonoHorasExtrasTotal;
                    uiBoleta.CantidadHorasExtras = uiDetalle.BonoHorasExtrasCantidad;

                    uiBoleta.Cts = 0.0; //FALTA
                    uiBoleta.Vacaciones = 0.0; //FALTA
                    uiBoleta.FeriadoDominical = 0.0; //FALTA
                    uiBoleta.Gratificacion = 0.0; //FALTA
                    uiBoleta.BonificacionGratificacion = 0.0; //FALTA

                    uiBoleta.AfpFondoMonto = uiDetalle.AfpAporteObligatorio;
                    uiBoleta.AfpSeguroMonto = uiDetalle.AfpSeguro;
                    uiBoleta.AfpComisionMonto = uiDetalle.AfpComision;
                    uiBoleta.IpssVidaMonto = 0.0;
                    uiBoleta.OnpMonto = uiDetalle.SnpTotal;
                    uiBoleta.RentaQuintaMonto = 0.0;
                    uiBoleta.InasistenciasDias = uiDetalle.DescuentoInasistenciaCantidad;
                    uiBoleta.InasistenciasMonto = uiDetalle.DescuentoInasistenciaTotal;
                    uiBoleta.AdelantoMonto = uiDetalle.AdelantoTotal;
                    uiBoleta.TardanzaMinutos = uiDetalle.DescuentoTardanzaCantidad;
                    uiBoleta.TardanzaMonto = uiDetalle.DescuentoTardanzaTotal;
                    uiBoleta.GratificacionMonto = 0.0; //FALTA
                    uiBoleta.RetencionJudicialMonto = uiDetalle.RetencionJudicialTotal;
                    uiBoleta.SeguroVidaTrabajadorMonto = 0.0; //FALTA
                    uiBoleta.IpssSaludTrabajadorMonto = 0.0; //FALTA
                    uiBoleta.SeguroVidaEmpleadoMonto = 0.0; //FALTA
                    uiBoleta.IpssSaludEmpleadoMonto = 0.0; //FALTA

                }
                lnPlanilla = null;

                #region Datos de Empresa

                this.txtEmpresaNombre.Text = uiBoleta.EmpresaNombre;
                this.txtEmpresaDireccionCompleta.Text = $"{ uiBoleta.EmpresaDireccion } - { uiBoleta.EmpresaDistrito }";
                this.txtEmpresaRuc.Text = uiBoleta.EmpresaRuc;
                this.txtEmpresaMesAnho.Text = $"{ uiBoleta.MesNombre.ToUpper() } DEL { uiBoleta.Anho.ToString().ToUpper() }";

                #endregion

                #region Datos de Empleado

                this.txtEmpleadoNombres.Text = $"{uiBoleta.EmpleadoNombres} {uiBoleta.EmpleadoApellidos}";
                this.txtFechaIngreso.Text = uiBoleta.EmpleadoFechaIngreso.ToString("dd/MM/yyyy");
                this.txtFechaCese.Text = uiBoleta.EmpleadoFechaCese == null ? "" : ((DateTime)uiBoleta.EmpleadoFechaCese).ToString("dd/MM/yyyy");
                this.txtFechaSalidaVacacion.Text = uiBoleta.EmpleadoVacacionSalida == null ? "" : ((DateTime)uiBoleta.EmpleadoVacacionSalida).ToString("dd/MM/yyyy");
                this.txtFechaRetornoVacacion.Text = uiBoleta.EmpleadoVacacionRetorno == null ? "" : ((DateTime)uiBoleta.EmpleadoVacacionRetorno).ToString("dd/MM/yyyy");
                this.txtAutogenerado.Text = uiBoleta.EmpleadoEsSaludCodigo;
                this.txtCussp.Text = uiBoleta.EmpleadoSppCodigo;
                this.txtAfiliacionPension.Text = uiBoleta.EmpleadoSppEntidad;
                this.txtCargo.Text = uiBoleta.EmpleadoCargo;
                this.txtDNI.Text = uiBoleta.EmpleadoNroDocumento;

                #endregion

                #region Datos de Cantidad

                this.txtDiasLaborados.Text = uiBoleta.DiasLaborados.ToString();
                this.txtDiasNoLaborados.Text = uiBoleta.DiasNoLaborados.ToString();
                this.txtDiasSinGoce.Text = uiBoleta.DiasSinGoceHaber.ToString();
                this.txtDiasSubsidiados.Text = uiBoleta.DiasSubsidiado.ToString();
                this.txtHorasNormales.Text = uiBoleta.HorasNormales.ToString();

                #endregion

                #region Datos de Sueldo

                this.txtSueldo.Text = uiBoleta.Sueldo.ToString("N2");
                this.txtAsigFam.Text = uiBoleta.AsignacionFamiliar.ToString("N2");
                this.txtBonoNocturno.Text = uiBoleta.BonificacionNocturna.ToString("N2");
                this.txtMovilidadTranslado.Text = uiBoleta.MovilidadTranslado.ToString("N2");
                this.txtSubsidioDescansoMedico.Text = uiBoleta.SubsidioDescansoMedico.ToString("N2");

                //Convertir de minutos a Horas en formato de horas
                this.txtHeCant.Text = Util.ParseMinutesToHours(uiBoleta.CantidadHorasExtras);

                this.txtHeMonto.Text = uiBoleta.BonificacionHorasExtras.ToString("N2");
                this.txtCts.Text = uiBoleta.Cts.ToString("N2");
                this.txtVacaciones.Text = uiBoleta.Vacaciones.ToString("N2");
                this.txtFeriadoDominical.Text = uiBoleta.FeriadoDominical.ToString("N2");
                this.txtGratificacion.Text = uiBoleta.Gratificacion.ToString("N2");
                this.txtBonoGratificacion.Text = uiBoleta.BonificacionGratificacion.ToString("N2");

                this.txtTotalSueldo.Text = uiBoleta.TotalBruto.ToString("N2");

                #endregion

                #region Datos de Deducciones y Aportes

                this.txtFondoAfpTrab.Text = uiBoleta.AfpFondoMonto.ToString("N2");
                this.txtSeguroAfpTrab.Text = uiBoleta.AfpSeguroMonto.ToString("N2");
                this.txtComisionAfpTrab.Text = uiBoleta.AfpComisionMonto.ToString("N2");
                this.txtIpssVidaTrab.Text = uiBoleta.IpssVidaMonto.ToString("N2");
                this.txtOnpTrab.Text = uiBoleta.OnpMonto.ToString("N2");
                this.txtQuintaTrab.Text = uiBoleta.RentaQuintaMonto.ToString("N2");

                //Convertir de minutos a dias
                int diasInasistencias = (uiBoleta.InasistenciasDias / 60) / 60;
                this.txtInasistenciaCantidad.Text = diasInasistencias.ToString();

                this.txtInasistenciaMontoTrab.Text = uiBoleta.InasistenciasMonto.ToString("N2");
                this.txtAdelantoTrab.Text = uiBoleta.AdelantoMonto.ToString("N2");
                this.txtTardanzaCantidad.Text = uiBoleta.TardanzaMinutos.ToString();
                this.txtTardanzaMontoTrab.Text = uiBoleta.TardanzaMonto.ToString("N2");
                this.txtGratificacionTrab.Text = uiBoleta.GratificacionMonto.ToString("N2");
                this.txtRetJudTrab.Text = uiBoleta.RetencionJudicialMonto.ToString("N2");
                this.txtSegVidaTrab.Text = uiBoleta.SeguroVidaTrabajadorMonto.ToString("N2");
                this.txtSegVidaEmp.Text = uiBoleta.SeguroVidaEmpleadoMonto.ToString("N2");
                this.txtIpssSaludTrab.Text = uiBoleta.IpssSaludTrabajadorMonto.ToString("N2");
                this.txtIpssSaludEmp.Text = uiBoleta.IpssSaludEmpleadoMonto.ToString("N2");

                this.txtTotalTrab.Text = uiBoleta.TotalDescuentos.ToString("N2");
                this.txtTotalEmp.Text = uiBoleta.TotalAportes.ToString("N2");

                #endregion

                #region Datos de Resumen

                this.txtResumenSueldo.Text = uiBoleta.TotalBruto.ToString("N2");
                this.txtResumenDescuentos.Text = uiBoleta.TotalDescuentos.ToString("N2");
                this.txtTotalNeto.Text = uiBoleta.TotalNeto.ToString("N2");

                #endregion

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void FrmPlanillaDetalleBoleta_Load(object sender, EventArgs e)
        {
            try
            {

                #region Limpiar Controles de Empresa
                foreach (var crtl in this.grpEmpresa.Controls)
                {
                    if (crtl is TextBox)
                    {
                        var textCrtl = (crtl as TextBox);
                        textCrtl.Clear();
                    }
                }
                #endregion

                #region Limpiar Controles de Empleado
                foreach (var crtl in this.grpEmpleado.Controls)
                {
                    if (crtl is TextBox)
                    {
                        var textCrtl = (crtl as TextBox);
                        textCrtl.Clear();
                    }
                }
                #endregion

                #region Limpiar Controles de Cantidad
                foreach (var crtl in this.grpCantidad.Controls)
                {
                    if (crtl is TextBox)
                    {
                        var textCrtl = (crtl as TextBox);
                        textCrtl.Text = "0";
                    }
                }
                #endregion

                #region Limpiar Controles de Resumen
                foreach (var crtl in this.grpResumen.Controls)
                {
                    if (crtl is TextBox)
                    {
                        var textCrtl = (crtl as TextBox);
                        textCrtl.Text = "0.00";
                    }
                }
                #endregion

                #region Limpiar Controles de Sueldo
                foreach (var crtl in this.grpSueldo.Controls)
                {
                    if (crtl is TextBox)
                    {
                        var textCrtl = (crtl as TextBox);

                        if (textCrtl.Name == "txtHeCant")
                            textCrtl.Text = "00:00";
                        else
                            textCrtl.Text = "0.00";
                    }
                }
                #endregion

                #region Limpiar Controles de Deduccion y Aporte
                foreach (var crtl in this.grpDeduccionAporte.Controls)
                {
                    if (crtl is TextBox)
                    {
                        var textCrtl = (crtl as TextBox);

                        if (textCrtl.Name == "txtInasistenciaCantidadTrab"
                            && textCrtl.Name == "txtTardanzaCantidadTrab")
                            textCrtl.Text = "0";
                        else
                            textCrtl.Text = "0.00";

                    }
                }
                #endregion

                this.Cargar();

                #region Eventos Controles de Sueldo
                foreach (var crtl in this.grpSueldo.Controls)
                {
                    if (crtl is TextBox)
                    {
                        var textCrtl = (crtl as TextBox);

                        if (textCrtl.ReadOnly == false)
                        {
                            textCrtl.Enter += new EventHandler(this.txtNumero_Enter);

                            if (textCrtl.Name == "txtHeCant")
                                textCrtl.KeyPress += new KeyPressEventHandler(this.txtEntero_KeyPress);
                            else
                            {
                                textCrtl.KeyPress += new KeyPressEventHandler(this.txtDecimal_KeyPress);
                                textCrtl.Leave += new EventHandler(this.txtDecimal_Leave);
                                textCrtl.TextChanged += new EventHandler(this.txtSueldo_TextChanged);
                            }
                        }

                    }
                }
                #endregion

                #region Eventos Controles de Deduccion y Aporte
                foreach (var crtl in this.grpDeduccionAporte.Controls)
                {
                    if (crtl is TextBox)
                    {
                        var textCrtl = (crtl as TextBox);

                        if (textCrtl.ReadOnly == false)
                        {
                            textCrtl.Enter += new EventHandler(this.txtNumero_Enter);

                            if (textCrtl.Name == "txtInasistenciaCantidadTrab" 
                                && textCrtl.Name == "txtTardanzaCantidadTrab")
                                textCrtl.KeyPress += new KeyPressEventHandler(this.txtEntero_KeyPress);
                            else
                            {
                                textCrtl.KeyPress += new KeyPressEventHandler(this.txtDecimal_KeyPress);
                                textCrtl.Leave += new EventHandler(this.txtDecimal_Leave);
                                textCrtl.TextChanged += new EventHandler(this.txtDeduccionAporte_TextChanged); 
                            }
                        }

                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                var rpta = Util.ConfirmationMessage($"¿Desea salir del formulario { this.Text }?");

                if (rpta == false)
                    return;

                this.Close();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtEntero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtNumero_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                (sender as TextBox).SelectAll();
            });
        }

        private void txtDecimal_Leave(object sender, EventArgs e)
        {
            try
            {
                double sueldo = 0.0;
                var ctrl = (sender as TextBox);

                if (ctrl.Text.Length > 0)
                    sueldo = double.Parse(ctrl.Text);

                ctrl.Text = sueldo.ToString("N2");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtSueldo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double total = 0.0;

                foreach (var crtl in this.grpSueldo.Controls)
                {
                    if (crtl is TextBox)
                    {
                        var textCrtl = (crtl as TextBox);

                        if (textCrtl.ReadOnly == false)
                        {
                            if (textCrtl.Name != "txtHeCant")
                            {
                                total += double.Parse(textCrtl.Text);
                            }
                        }

                    }
                }

                this.txtTotalSueldo.Text = total.ToString("N2");

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtDeduccionAporte_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double totalTrab = 0.0;
                double totalEmp = 0.0;

                foreach (var crtl in this.grpDeduccionAporte.Controls)
                {
                    if (crtl is TextBox)
                    {
                        var textCrtl = (crtl as TextBox);

                        if (textCrtl.ReadOnly == false)
                        {
                            if (textCrtl.Name.EndsWith("Trab"))
                            {
                                totalTrab += double.Parse(textCrtl.Text);
                            }
                            else if (textCrtl.Name.EndsWith("Emp"))
                            {
                                totalEmp += double.Parse(textCrtl.Text);
                            }
                        }    
                    }
                }

                this.txtTotalTrab.Text = totalTrab.ToString("N2");
                this.txtTotalEmp.Text = totalEmp.ToString("N2");

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {

                var rpta = Util.ConfirmationMessage($"¿Desea generar la boleta del empleado '{ this.txtEmpleadoNombres.Text }'?");

                if (rpta == false)
                    return;

                var frmPlanillaVista = new FrmImpresion();
                frmPlanillaVista.MdiParent = this.MdiParent;
                frmPlanillaVista.Show();
                frmPlanillaVista.ImpresionBoleta(this.anho, this.mes, this.codigoEmpleado);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        
    }
}
