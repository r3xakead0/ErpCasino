using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Linq;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmPlanillaDetalleBoleta : Form
    {

        #region "Patron Singleton"

        private static FrmPlanillaDetalleBoleta frmInstance = null;

        public static FrmPlanillaDetalleBoleta Instance(int anho, int mes, string codigoEmpleado)
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmPlanillaDetalleBoleta(anho, mes, codigoEmpleado);
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        private BE.UI.PlanillaBoleta uiPlanillaBoleta = null;

        public FrmPlanillaDetalleBoleta(int anho, int mes, string codigoEmpleado)
        {
            try
            {
                InitializeComponent();

                this.Cargar(anho, mes, codigoEmpleado);
                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        #region Metodos

        private void AsignarEventos()
        {
            try
            {
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
                throw ex;
            }
        }


        /// <summary>
        /// Cargar o Calcular los datos de la boleta 
        /// </summary>
        /// <param name="anho">Anho de consulta. Ejm: 2017</param>
        /// <param name="mes">Mes de consulta. Ejm: 1, 12</param>
        /// <param name="codigoEmpleado">Codigo del Empleado</param>
        private void Cargar(int anho, int mes, string codigoEmpleado)
        {
            try
            {
                this.uiPlanillaBoleta = new LN.PlanillaBoleta().Obtener(anho, mes, codigoEmpleado);
                if (uiPlanillaBoleta == null)
                {
                    this.uiPlanillaBoleta = CalcularBoleta(anho, mes, codigoEmpleado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LimpiarControles()
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private BE.UI.PlanillaBoleta CalcularBoleta(int anho, int mes, string codigoEmpleado)
        {
            try
            {
                var uiDetalle = new LN.Planilla(anho, mes).ObtenerPlantillaDetalle(codigoEmpleado);
                if (uiDetalle != null)
                {
                    this.uiPlanillaBoleta = new BE.UI.PlanillaBoleta();

                    this.uiPlanillaBoleta.Id = 0;

                    var uiPlanilla = new LN.Planilla(anho, mes).Obtener();
                    if (this.uiPlanillaBoleta != null)
                        this.uiPlanillaBoleta.IdPlanilla = uiPlanilla.ID;
                    uiPlanilla = null;

                    this.uiPlanillaBoleta.Anho = anho;
                    this.uiPlanillaBoleta.Mes = mes;
                    this.uiPlanillaBoleta.MesNombre = Util.GetNameOfMonth(mes);
                    this.uiPlanillaBoleta.MesDias = DateTime.DaysInMonth(anho, mes);

                    #region Asignar datos de Empresa

                    var beEmpresa = new LN.Empresa().Obtener();
                    this.uiPlanillaBoleta.EmpresaNombre = beEmpresa.NombreComercial;
                    this.uiPlanillaBoleta.EmpresaRuc = beEmpresa.RUC;
                    this.uiPlanillaBoleta.EmpresaDistrito = beEmpresa.Ubigeo.Nombre;
                    this.uiPlanillaBoleta.EmpresaDireccion = beEmpresa.DomicilioFiscal;
                    beEmpresa = null;

                    #endregion

                    #region Asignar datos de Empleado

                    var beEmpleado = new LN.Empleado().Obtener(uiDetalle.EmpleadoCodigo);
                    this.uiPlanillaBoleta.EmpleadoCodigo = beEmpleado.Codigo;
                    this.uiPlanillaBoleta.EmpleadoNombres = beEmpleado.Nombres;
                    this.uiPlanillaBoleta.EmpleadoApellidos = $"{beEmpleado.ApellidoPaterno} {beEmpleado.ApellidoMaterno}";
                    this.uiPlanillaBoleta.EmpleadoNroDocumento = beEmpleado.NumeroDocumento;
                    beEmpleado = null;

                    var beEmpleadoRecurso = new LN.Empleado().ObtenerRecurso(uiDetalle.EmpleadoCodigo);
                    this.uiPlanillaBoleta.EmpleadoCargo = beEmpleadoRecurso.Cargo.Nombre;
                    this.uiPlanillaBoleta.EmpleadoFechaIngreso = beEmpleadoRecurso.FechaInicio;
                    this.uiPlanillaBoleta.EmpleadoFechaCese = beEmpleadoRecurso.FechaCese;
                    this.uiPlanillaBoleta.EmpleadoEsSaludCodigo = beEmpleadoRecurso.Autogenerado;
                    if (beEmpleadoRecurso.ONP == true)
                    {
                        this.uiPlanillaBoleta.EmpleadoSppCodigo = "";
                        this.uiPlanillaBoleta.EmpleadoSppEntidad = uiDetalle.SnpNombre;
                    }
                    else
                    {
                        this.uiPlanillaBoleta.EmpleadoSppCodigo = beEmpleadoRecurso.CUSPP;
                        this.uiPlanillaBoleta.EmpleadoSppEntidad = uiDetalle.AfpNombre;
                    }
                    beEmpleadoRecurso = null;

                    var uiVacacion = new LN.Vacacion().ObtenerUltimo(codigoEmpleado);
                    if (uiVacacion != null)
                    {
                        this.uiPlanillaBoleta.EmpleadoVacacionSalida = uiVacacion.VacacionFechaInicial;
                        this.uiPlanillaBoleta.EmpleadoVacacionRetorno = uiVacacion.VacacionFechaFinal;
                    }
                    uiVacacion = null;

                    #endregion

                    #region Asignar datos del Resumen

                    this.uiPlanillaBoleta.DiasLaborados = 0;
                    this.uiPlanillaBoleta.DiasNoLaborados = 0;
                    this.uiPlanillaBoleta.DiasSinGoceHaber = 0;
                    this.uiPlanillaBoleta.DiasSubsidiado = 0;
                    this.uiPlanillaBoleta.HorasNormales = 0;

                    #endregion

                    #region Asignar datos del Sueldo

                    this.uiPlanillaBoleta.Sueldo = uiDetalle.Base;
                    this.uiPlanillaBoleta.AsignacionFamiliar = uiDetalle.AsignacionFamiliar;
                    this.uiPlanillaBoleta.BonificacionNocturna = uiDetalle.BonoNocturnoTotal;
                    this.uiPlanillaBoleta.MovilidadTranslado = new LN.Movilidad().ObtenerTotal(anho, mes, codigoEmpleado);

                    this.uiPlanillaBoleta.SubsidioDescansoMedico = 0.0; //FALTA
                    this.uiPlanillaBoleta.BonificacionHorasExtras = uiDetalle.BonoHorasExtrasTotal;
                    this.uiPlanillaBoleta.CantidadHorasExtras = uiDetalle.BonoHorasExtrasCantidad;

                    this.uiPlanillaBoleta.Cts = 0.0; //FALTA
                    this.uiPlanillaBoleta.Vacaciones = 0.0; //FALTA
                    this.uiPlanillaBoleta.FeriadoDominical = 0.0; //FALTA
                    this.uiPlanillaBoleta.Gratificacion = 0.0; //FALTA
                    this.uiPlanillaBoleta.BonificacionGratificacion = 0.0; //FALTA

                    #endregion

                    #region Asignar datos de Aportes y Deducciones

                    this.uiPlanillaBoleta.AfpFondoMonto = uiDetalle.AfpAporteObligatorio;
                    this.uiPlanillaBoleta.AfpSeguroMonto = uiDetalle.AfpSeguro;
                    this.uiPlanillaBoleta.AfpComisionMonto = uiDetalle.AfpComision;
                    this.uiPlanillaBoleta.IpssVidaMonto = 0.0; //FALTA
                    this.uiPlanillaBoleta.OnpMonto = uiDetalle.SnpTotal;
                    this.uiPlanillaBoleta.RentaQuintaMonto = 0.0; //FALTA
                    this.uiPlanillaBoleta.InasistenciasDias = uiDetalle.DescuentoInasistenciaCantidad;
                    this.uiPlanillaBoleta.InasistenciasMonto = uiDetalle.DescuentoInasistenciaTotal;
                    this.uiPlanillaBoleta.AdelantoMonto = uiDetalle.AdelantoTotal;
                    this.uiPlanillaBoleta.TardanzaMinutos = uiDetalle.DescuentoTardanzaCantidad;
                    this.uiPlanillaBoleta.TardanzaMonto = uiDetalle.DescuentoTardanzaTotal;
                    this.uiPlanillaBoleta.GratificacionMonto = 0.0; //FALTA
                    this.uiPlanillaBoleta.RetencionJudicialMonto = uiDetalle.RetencionJudicialTotal;
                    this.uiPlanillaBoleta.SeguroVidaTrabajadorMonto = 0.0; //FALTA
                    this.uiPlanillaBoleta.IpssSaludTrabajadorMonto = 0.0; //FALTA
                    this.uiPlanillaBoleta.SeguroVidaEmpleadoMonto = 0.0; //FALTA
                    this.uiPlanillaBoleta.IpssSaludEmpleadoMonto = 0.0; //FALTA

                    #endregion

                    //var propertyInfos = uiBoleta.GetType().GetProperties()
                    //    .Where(x => x.PropertyType == typeof(double) && x.CanWrite == true)
                    //    .ToList();
                    //foreach (var prop in propertyInfos)
                    //{
                    //    prop.SetValue(uiBoleta, Math.Round((double)prop.GetValue(uiBoleta), 2));
                    //}

                    uiPlanillaBoleta.GetType().GetProperties()
                                        .Where(x => x.PropertyType == typeof(double) && x.CanWrite == true)
                                        .ToList()
                                        .ForEach(x => x.SetValue(
                                                uiPlanillaBoleta,
                                                Math.Round((double)x.GetValue(uiPlanillaBoleta), 2)
                                            )
                                        );
                }

                return uiPlanillaBoleta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Mostrar los datos en los controles del formulario
        /// </summary>
        private void Mostrar()
        {
            try
            {

                #region Datos de Empresa

                this.txtEmpresaNombre.Text = uiPlanillaBoleta.EmpresaNombre;
                this.txtEmpresaDireccionCompleta.Text = $"{ uiPlanillaBoleta.EmpresaDireccion } - { uiPlanillaBoleta.EmpresaDistrito }";
                this.txtEmpresaRuc.Text = uiPlanillaBoleta.EmpresaRuc;
                this.txtEmpresaMesAnho.Text = $"{ uiPlanillaBoleta.MesNombre.ToUpper() } DEL { uiPlanillaBoleta.Anho.ToString().ToUpper() }";

                #endregion

                #region Datos de Empleado

                this.txtEmpleadoNombres.Text = $"{uiPlanillaBoleta.EmpleadoNombres} {uiPlanillaBoleta.EmpleadoApellidos}";
                this.txtFechaIngreso.Text = uiPlanillaBoleta.EmpleadoFechaIngreso.ToString("dd/MM/yyyy");
                this.txtFechaCese.Text = uiPlanillaBoleta.EmpleadoFechaCese == null ? "" : ((DateTime)uiPlanillaBoleta.EmpleadoFechaCese).ToString("dd/MM/yyyy");
                this.txtFechaSalidaVacacion.Text = uiPlanillaBoleta.EmpleadoVacacionSalida == null ? "" : ((DateTime)uiPlanillaBoleta.EmpleadoVacacionSalida).ToString("dd/MM/yyyy");
                this.txtFechaRetornoVacacion.Text = uiPlanillaBoleta.EmpleadoVacacionRetorno == null ? "" : ((DateTime)uiPlanillaBoleta.EmpleadoVacacionRetorno).ToString("dd/MM/yyyy");
                this.txtAutogenerado.Text = uiPlanillaBoleta.EmpleadoEsSaludCodigo;
                this.txtCussp.Text = uiPlanillaBoleta.EmpleadoSppCodigo;
                this.txtAfiliacionPension.Text = uiPlanillaBoleta.EmpleadoSppEntidad;
                this.txtCargo.Text = uiPlanillaBoleta.EmpleadoCargo;
                this.txtDNI.Text = uiPlanillaBoleta.EmpleadoNroDocumento;

                #endregion

                #region Datos de Cantidad

                this.txtDiasLaborados.Text = uiPlanillaBoleta.DiasLaborados.ToString();
                this.txtDiasNoLaborados.Text = uiPlanillaBoleta.DiasNoLaborados.ToString();
                this.txtDiasSinGoce.Text = uiPlanillaBoleta.DiasSinGoceHaber.ToString();
                this.txtDiasSubsidiados.Text = uiPlanillaBoleta.DiasSubsidiado.ToString();
                this.txtHorasNormales.Text = uiPlanillaBoleta.HorasNormales.ToString();

                #endregion

                #region Datos de Sueldo

                this.txtSueldo.Text = uiPlanillaBoleta.Sueldo.ToString("N2");
                this.txtAsigFam.Text = uiPlanillaBoleta.AsignacionFamiliar.ToString("N2");
                this.txtBonoNocturno.Text = uiPlanillaBoleta.BonificacionNocturna.ToString("N2");
                this.txtMovilidadTranslado.Text = uiPlanillaBoleta.MovilidadTranslado.ToString("N2");
                this.txtSubsidioDescansoMedico.Text = uiPlanillaBoleta.SubsidioDescansoMedico.ToString("N2");

                //Convertir de minutos a Horas en formato de horas
                this.txtHeCant.Text = Util.ParseMinutesToHours(uiPlanillaBoleta.CantidadHorasExtras);

                this.txtHeMonto.Text = uiPlanillaBoleta.BonificacionHorasExtras.ToString("N2");
                this.txtCts.Text = uiPlanillaBoleta.Cts.ToString("N2");
                this.txtVacaciones.Text = uiPlanillaBoleta.Vacaciones.ToString("N2");
                this.txtFeriadoDominical.Text = uiPlanillaBoleta.FeriadoDominical.ToString("N2");
                this.txtGratificacion.Text = uiPlanillaBoleta.Gratificacion.ToString("N2");
                this.txtBonoGratificacion.Text = uiPlanillaBoleta.BonificacionGratificacion.ToString("N2");

                this.txtTotalSueldo.Text = uiPlanillaBoleta.TotalBruto.ToString("N2");

                #endregion

                #region Datos de Deducciones y Aportes

                this.txtFondoAfpTrab.Text = uiPlanillaBoleta.AfpFondoMonto.ToString("N2");
                this.txtSeguroAfpTrab.Text = uiPlanillaBoleta.AfpSeguroMonto.ToString("N2");
                this.txtComisionAfpTrab.Text = uiPlanillaBoleta.AfpComisionMonto.ToString("N2");
                this.txtIpssVidaTrab.Text = uiPlanillaBoleta.IpssVidaMonto.ToString("N2");
                this.txtOnpTrab.Text = uiPlanillaBoleta.OnpMonto.ToString("N2");
                this.txtQuintaTrab.Text = uiPlanillaBoleta.RentaQuintaMonto.ToString("N2");

                //Convertir de minutos a dias
                int diasInasistencias = (uiPlanillaBoleta.InasistenciasDias / 60) / 60;
                this.txtInasistenciaCantidad.Text = diasInasistencias.ToString();

                this.txtInasistenciaMontoTrab.Text = uiPlanillaBoleta.InasistenciasMonto.ToString("N2");
                this.txtAdelantoTrab.Text = uiPlanillaBoleta.AdelantoMonto.ToString("N2");
                this.txtTardanzaCantidad.Text = uiPlanillaBoleta.TardanzaMinutos.ToString();
                this.txtTardanzaMontoTrab.Text = uiPlanillaBoleta.TardanzaMonto.ToString("N2");
                this.txtGratificacionTrab.Text = uiPlanillaBoleta.GratificacionMonto.ToString("N2");
                this.txtRetJudTrab.Text = uiPlanillaBoleta.RetencionJudicialMonto.ToString("N2");
                this.txtSegVidaTrab.Text = uiPlanillaBoleta.SeguroVidaTrabajadorMonto.ToString("N2");
                this.txtSegVidaEmp.Text = uiPlanillaBoleta.SeguroVidaEmpleadoMonto.ToString("N2");
                this.txtIpssSaludTrab.Text = uiPlanillaBoleta.IpssSaludTrabajadorMonto.ToString("N2");
                this.txtIpssSaludEmp.Text = uiPlanillaBoleta.IpssSaludEmpleadoMonto.ToString("N2");

                this.txtTotalTrab.Text = uiPlanillaBoleta.TotalDescuentos.ToString("N2");
                this.txtTotalEmp.Text = uiPlanillaBoleta.TotalAportes.ToString("N2");

                #endregion

                #region Datos de Resumen

                this.txtResumenSueldo.Text = uiPlanillaBoleta.TotalBruto.ToString("N2");
                this.txtResumenDescuentos.Text = uiPlanillaBoleta.TotalDescuentos.ToString("N2");
                this.txtTotalNeto.Text = uiPlanillaBoleta.TotalNeto.ToString("N2");

                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Formulario

        #endregion



        private void FrmPlanillaDetalleBoleta_Load(object sender, EventArgs e)
        {
            try
            {
                this.LimpiarControles();

                this.Mostrar();

                this.AsignarEventos();

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

                if (this.uiPlanillaBoleta == null)
                    return;

                bool rpta = false;

                rpta = Util.ConfirmationMessage($"¿Desea generar la boleta del empleado '{ this.txtEmpleadoNombres.Text }'?");
                if (rpta == false)
                    return;

                //Guardar
                rpta = new LN.PlanillaBoleta().Registrar(ref this.uiPlanillaBoleta);
                if (rpta == false)
                    return;

                //Mostrar
                var frmPlanillaVista = new FrmImpresion();
                frmPlanillaVista.MdiParent = this.MdiParent;
                frmPlanillaVista.Show();
                frmPlanillaVista.ImpresionBoleta(this.uiPlanillaBoleta.Anho, this.uiPlanillaBoleta.Mes, this.uiPlanillaBoleta.EmpleadoCodigo);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        
    }
}
