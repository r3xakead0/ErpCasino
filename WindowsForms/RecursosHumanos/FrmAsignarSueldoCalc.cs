using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;
using System.Drawing;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarSueldoCalc : Form
    {

        private FrmAsignarSueldoList frmList = null;

        private int Anho = 0;
        private int Mes = 0;

        //Calculo detallado de Sueldos de los Candidatos
        private List<BE.UI.SueldoCandidato> lstUiSueldosCandidatos = null;

        private List<BE.UI.CandidatoCosto> lstUiCostosCandidatos = null;
        private List<BE.UI.CandidatoAsistencia> lstUiAsistenciasCandidatos = null;
        private List<BE.UI.CandidatoAsistenciaResumen> lstUiAsistenciasCandidatosResumen = null;

        public FrmAsignarSueldoCalc(FrmAsignarSueldoList frmList)
        {
            try
            {
                InitializeComponent();
                this.frmList = frmList;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void Limpiar()
        {
            try
            {
                this.Anho = 0;
                this.Mes = 0;

                this.CargarAnhos();
                this.CargarMes();
                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarAsistenciasPor();
                this.CargarAsistenciasCandidatos();
                this.FormatoAsistenciasCandidatos();

                this.CargarAsistenciasResumenPor();
                this.CargarAsistenciasCandidatosResumen();
                this.FormatoAsistenciasCandidatosResumen();

                this.CargarCostosPor();
                this.CargarCostosCandidatos();
                this.FormatoCostosCandidatos();

                this.CargarSueldosCandidatos();
                this.FormatoSueldosCandidatos();

                this.txtMes.Clear();
                this.txtAnho.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private double SueldoInasistencia(string codigoCandidato)
        {
            try
            {
                double SueldoInasistencia = 0.0;

                double sueldoMinimo = 0.0;
                int diasMes = 0;
                int horasDia = 0;
                using (var beParametros = new BE.Parametros())
                {
                    sueldoMinimo = beParametros.SueldoMinimo;
                    diasMes = beParametros.BaseDias;
                    horasDia = beParametros.BaseHoras;
                }

                double costoMinuto = ((sueldoMinimo / diasMes) / horasDia) / 60;
                double penalidadNormal = costoMinuto * 3;
                double penalidadFeriado = costoMinuto * 5;

                //var lnRecibo = new LN.Recibo(this.Anho, this.Mes);

                //var uiAsistenciaResumen = lnRecibo.ObtenerResumenAsistenciaCandidato(codigoCandidato);
                //if (uiAsistenciaResumen != null)
                //{
                //    double SueldoInasistenciaNormal = uiAsistenciaResumen.CantidadInasistenciasNormales * penalidadNormal;
                //    double SueldoInasistenciaFeriado = uiAsistenciaResumen.CantidadInasistenciasFeriados * penalidadFeriado;

                //    double SueldoInasistenciaRecibo = 0.0;
                //    var uiPlanillDetalle = lnRecibo.ObtenerPlantillaDetalle(codigoCandidato);
                //    if (uiPlanillDetalle != null)
                //        SueldoInasistenciaRecibo = uiPlanillDetalle.SueldoInasistenciaTotal;

                //    SueldoInasistencia = SueldoInasistenciaNormal 
                //                          + SueldoInasistenciaFeriado 
                //                          - SueldoInasistenciaRecibo;
                //}
                //else
                //{
                //    DateTime fechaPeriodo = new DateTime(this.Anho, this.Mes, 1);
                //    string mensajeError = $"No encuentra calculo de Recibo para el periodo {fechaPeriodo.ToString("yyyy/MM")}";
                //    throw new Exception(mensajeError);
                //}
                //uiAsistenciaResumen = null;

                return SueldoInasistencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarAnhos()
        {
            try
            {
                int anhoInicio = 2017;
                int anhoFinal = DateTime.Now.Year + 5;

                var lstAnhos = new List<BE.Record>();
                for (int i = anhoInicio; i < anhoFinal; i++)
                {
                    lstAnhos.Add(new BE.Record() { Codigo = i.ToString(), Nombre = i.ToString() });
                }

                this.cboAnho.DataSource = lstAnhos;
                this.cboAnho.DisplayMember = "Nombre";
                this.cboAnho.ValueMember = "Codigo";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE.Record> ListaCandidatos()
        {
            try
            {
                var lstCandidatos = new LN.Candidato().Combo();
                lstCandidatos = lstCandidatos.OrderBy(o => o.Codigo).ToList();
                return lstCandidatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarMes()
        {
            try
            {

                var lstMes = new List<BE.Record>();

                for (int i = 1; i <= 12; i++)
                {
                    lstMes.Add(new BE.Record() { Codigo = i.ToString(), Nombre = Util.GetNameOfMonth(i) });
                }

                this.cboMes.DataSource = lstMes;
                this.cboMes.DisplayMember = "Nombre";
                this.cboMes.ValueMember = "Codigo";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Cargar los tipos de Costos en combobox
        ///</summary>
        private void CargarCostosPor()
        {
            try
            {

                var lstCostoPor = new List<BE.Record>();

                lstCostoPor.Add(new BE.Record() { Codigo = "D", Nombre = "Dia" });
                lstCostoPor.Add(new BE.Record() { Codigo = "H", Nombre = "Hora" });
                lstCostoPor.Add(new BE.Record() { Codigo = "M", Nombre = "Minuto" });

                this.cboCostoPor.DataSource = lstCostoPor;
                this.cboCostoPor.DisplayMember = "Nombre";
                this.cboCostoPor.ValueMember = "Codigo";

                this.cboCostoPor.SelectedValue = "M";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Cargar los tipos de Calculo en combobox
        ///</summary>
        private void CargarAsistenciasPor()
        {
            try
            {

                var lstCalculoPor = new List<BE.Record>();

                lstCalculoPor.Add(new BE.Record() { Codigo = "H", Nombre = "Hora" });
                lstCalculoPor.Add(new BE.Record() { Codigo = "M", Nombre = "Minuto" });

                this.cboAsistenciaPor.DataSource = lstCalculoPor;
                this.cboAsistenciaPor.DisplayMember = "Nombre";
                this.cboAsistenciaPor.ValueMember = "Codigo";

                this.cboAsistenciaPor.SelectedValue = "H";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Cargar los tipos de Calculo en combobox
        ///</summary>
        private void CargarAsistenciasResumenPor()
        {
            try
            {

                var lstCalculoPor = new List<BE.Record>();

                lstCalculoPor.Add(new BE.Record() { Codigo = "H", Nombre = "Hora" });
                lstCalculoPor.Add(new BE.Record() { Codigo = "M", Nombre = "Minuto" });

                this.cboAsistenciaResumenPor.DataSource = lstCalculoPor;
                this.cboAsistenciaResumenPor.DisplayMember = "Nombre";
                this.cboAsistenciaResumenPor.ValueMember = "Codigo";

                this.cboAsistenciaResumenPor.SelectedValue = "H";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Obtener calculo del costo segun el tipo (D = Dia, H = Hora, M = Minuto)
        ///</summary>
        private double ObtenerCostoPor(string tipo,
                                        double valor,
                                        BE.Parametros beParametros)
        {
            double costoPor = 0.0;
            try
            {
                if (beParametros != null)
                {
                    switch (tipo)
                    {
                        case "D":
                            costoPor = valor / beParametros.BaseDias;
                            break;
                        case "H":
                            costoPor = (valor / beParametros.BaseDias) / beParametros.BaseHoras;
                            break;
                        case "M":
                            costoPor = ((valor / beParametros.BaseDias) / beParametros.BaseHoras) / 60;
                            break;
                        default:
                            costoPor = 0.0;
                            break;
                    }
                }

                return Math.Round(costoPor, 4);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Calcular y Mostrar la lista de los costos por Candidato
        /// </summary>
        /// <param name="anho">Año en formato de 4 digitos</param>
        /// <param name="mes">Mes en rango de 1 al 12</param>
        private void CargarCostosCandidatos(int anho = 0, int mes = 0)
        {
            try
            {

                if (anho == 0 && mes == 0) //No realiza calculo
                {
                    this.lstUiCostosCandidatos = new List<BE.UI.CandidatoCosto>();
                }
                else
                {
                    double sueldoMinimo = 0.0;
                    int dias = DateTime.DaysInMonth(anho, mes);

                    var beSueldoMinimo = new LN.SueldoMinimo().Actual(new DateTime(anho, mes, dias));
                    if (beSueldoMinimo == null)
                    {
                        string periodo = string.Format("{0:D4}/{1:D2}", anho, mes);
                        string msg = $"No existe el sueldo minimo para el periodo { periodo }";
                        throw new Exception(msg);
                    }
                    else
                        sueldoMinimo = beSueldoMinimo.Monto;

                    var beParametros = new BE.Parametros(sueldoMinimo);

                    this.lstUiCostosCandidatos = new List<BE.UI.CandidatoCosto>();

                    var lstUiCandidatosSueldos = new LN.Recibo().ListarSueldos();
                    foreach (BE.UI.CandidatoSueldo uiCandidatoSueldo in lstUiCandidatosSueldos)
                    {

                        string codigoCandidato = uiCandidatoSueldo.Codigo;
                        string nombreCandidato = new LN.Empleado().ObtenerNombreCompleto(codigoCandidato);
                        double sueldoBase = uiCandidatoSueldo.Sueldo;
                        double asigFamBase = 0.0; //No se usa para candidatos
                        string codCostoPor = "M"; //Por Minuto = M

                        #region Calculo de Costos

                        double costoBase = this.ObtenerCostoPor(codCostoPor, (sueldoBase + asigFamBase), beParametros);

                        double normalDiurno = costoBase;
                        double normalDiurnoExtra1 = normalDiurno * beParametros.HorasExtras1Factor;
                        double normalDiurnoExtra2 = normalDiurno * beParametros.HorasExtras2Factor;
                        double normalNocturno = normalDiurno * beParametros.HorarioNocturnoFactor;
                        double normalNocturnoExtra1 = normalNocturno * beParametros.HorasExtras1Factor;
                        double normalNocturnoExtra2 = normalNocturno * beParametros.HorasExtras2Factor;

                        double feriadoDiurno = costoBase * beParametros.FeriadoFactor;
                        double feriadoDiurnoExtra1 = feriadoDiurno * beParametros.HorasExtras1Factor;
                        double feriadoDiurnoExtra2 = feriadoDiurno * beParametros.HorasExtras2Factor;
                        double feriadoNocturno = feriadoDiurno * beParametros.HorarioNocturnoFactor;
                        double feriadoNocturnoExtra1 = feriadoNocturno * beParametros.HorasExtras1Factor;
                        double feriadoNocturnoExtra2 = feriadoNocturno * beParametros.HorasExtras2Factor;

                        #endregion

                        #region Descuento

                        double descuentoBase = this.ObtenerCostoPor(codCostoPor, sueldoBase, beParametros);

                        double tardanzaNormalDiurno = descuentoBase;
                        double tardanzaNormalNocturno = tardanzaNormalDiurno * beParametros.HorarioNocturnoFactor;
                        double tardanzaFeriadoDiurno = descuentoBase * beParametros.FeriadoFactor;
                        double tardanzaFeriadoNocturno = tardanzaFeriadoDiurno * beParametros.HorarioNocturnoFactor;

                        double dominical = Math.Round(descuentoBase / beParametros.BaseDias, 4);
                        double inasistencia = descuentoBase + dominical;

                        #endregion

                        #region Cargar

                        var uiCandidatoCosto = new BE.UI.CandidatoCosto();

                        uiCandidatoCosto.Codigo = codigoCandidato;
                        uiCandidatoCosto.NombleCompleto = nombreCandidato;
                        uiCandidatoCosto.Sueldo = sueldoBase;
                        uiCandidatoCosto.AsignacionFamiliar = asigFamBase;
                        uiCandidatoCosto.CostosPor = codCostoPor;
                        uiCandidatoCosto.NormalDiurno = normalDiurno;
                        uiCandidatoCosto.NormalDiurnoExtra1 = normalDiurnoExtra1;
                        uiCandidatoCosto.NormalDiurnoExtra2 = normalDiurnoExtra2;
                        uiCandidatoCosto.NormalNocturno = normalNocturno;
                        uiCandidatoCosto.NormalNocturnoExtra1 = normalNocturnoExtra1;
                        uiCandidatoCosto.NormalNocturnoExtra2 = normalNocturnoExtra2;
                        uiCandidatoCosto.FeriadoDiurno = feriadoDiurno;
                        uiCandidatoCosto.FeriadoDiurnoExtra1 = feriadoDiurnoExtra1;
                        uiCandidatoCosto.FeriadoDiurnoExtra2 = feriadoDiurnoExtra2;
                        uiCandidatoCosto.FeriadoNocturno = feriadoNocturno;
                        uiCandidatoCosto.FeriadoNocturnoExtra1 = feriadoNocturnoExtra1;
                        uiCandidatoCosto.FeriadoNocturnoExtra2 = feriadoNocturnoExtra2;
                        uiCandidatoCosto.TardanzaNormalDiurno = tardanzaNormalDiurno;
                        uiCandidatoCosto.TardanzaNormalNocturno = tardanzaNormalNocturno;
                        uiCandidatoCosto.TardanzaFeriadoDiurno = tardanzaFeriadoDiurno;
                        uiCandidatoCosto.TardanzaFeriadoNocturno = tardanzaFeriadoNocturno;
                        uiCandidatoCosto.Dominical = dominical;
                        uiCandidatoCosto.Inasistencia = inasistencia;

                        this.lstUiCostosCandidatos.Add(uiCandidatoCosto);

                        #endregion

                    }
                }

                var sorted = new SortableBindingList<BE.UI.CandidatoCosto>(this.lstUiCostosCandidatos);
                this.dgvCostos.DataSource = sorted;

                int nroCostos = this.lstUiCostosCandidatos.Count;
                this.txtRegistrosCostos.Text = nroCostos.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Mostrar la lista resumida de las Asistencias de los Candidatos
        /// </summary>
        private void CargarAsistenciasCandidatosResumen()
        {
            try
            {

                if (this.lstUiAsistenciasCandidatos == null
                    || this.lstUiAsistenciasCandidatos.Count == 0)
                {
                    this.lstUiAsistenciasCandidatosResumen = new List<BE.UI.CandidatoAsistenciaResumen>();
                }
                else
                {
                    //Limpiar lista de asistencias resumida
                    if (this.lstUiAsistenciasCandidatosResumen == null)
                        this.lstUiAsistenciasCandidatosResumen = new List<BE.UI.CandidatoAsistenciaResumen>();
                    else
                        this.lstUiAsistenciasCandidatosResumen.Clear();

                    //Cargar la lista resumida de asistencias
                    string[] lstCodigosCandidatos = this.lstUiAsistenciasCandidatos.OrderBy(x => x.Codigo).Select(x => x.Codigo).Distinct().ToArray();
                    
                    foreach (string codigoCandidato in lstCodigosCandidatos)
                    {
                        string nombreCompletoCandidato = new LN.Empleado().ObtenerNombreCompleto(codigoCandidato);
                        var lstUiAsistenciasDelCandidato = this.lstUiAsistenciasCandidatos.Where(x => x.Codigo == codigoCandidato).ToList();

                        var uiCandidatoAsistenciaResumen = new BE.UI.CandidatoAsistenciaResumen();
                        uiCandidatoAsistenciaResumen.Codigo = codigoCandidato;
                        uiCandidatoAsistenciaResumen.NombleCompleto = nombreCompletoCandidato;
                        uiCandidatoAsistenciaResumen.FormateadoCalculo = "H";

                        #region Asistencias

                        int cantidadMinutoHorarioDiurno = 0;
                        int cantidadMinutoHorarioNocturno = 0;
                        int cantidadMinutoExtra25Diurno = 0;
                        int cantidadMinutoExtra25Nocturno = 0;
                        int cantidadMinutoExtra35Diurno = 0;
                        int cantidadMinutoExtra35Nocturno = 0;

                        #region Asistencias Normal
                        cantidadMinutoHorarioDiurno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.AsistenciaNormalDiurna);
                        cantidadMinutoHorarioNocturno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.AsistenciaNormalNocturna);
                        cantidadMinutoExtra25Diurno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.AsistenciaNormalDiurnaExtra1);
                        cantidadMinutoExtra25Nocturno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.AsistenciaNormalNocturnaExtra1);
                        cantidadMinutoExtra35Diurno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.AsistenciaNormalDiurnaExtra2);
                        cantidadMinutoExtra35Nocturno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.AsistenciaNormalNocturnaExtra2);

                        uiCandidatoAsistenciaResumen.AsistenciaNormalDiurna = cantidadMinutoHorarioDiurno;
                        uiCandidatoAsistenciaResumen.AsistenciaFeriadoNocturna = cantidadMinutoHorarioNocturno;
                        uiCandidatoAsistenciaResumen.AsistenciaNormalDiurnaExtra1 = cantidadMinutoExtra25Diurno;
                        uiCandidatoAsistenciaResumen.AsistenciaNormalNocturnaExtra1 = cantidadMinutoExtra25Nocturno;
                        uiCandidatoAsistenciaResumen.AsistenciaNormalDiurnaExtra2 = cantidadMinutoExtra35Diurno;
                        uiCandidatoAsistenciaResumen.AsistenciaNormalNocturnaExtra2 = cantidadMinutoExtra35Nocturno;
                        #endregion

                        #region Asistencias Feriado
                        cantidadMinutoHorarioDiurno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.AsistenciaFeriadoDiurna);
                        cantidadMinutoHorarioNocturno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.AsistenciaFeriadoNocturna);
                        cantidadMinutoExtra25Diurno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.AsistenciaFeriadoDiurnaExtra1);
                        cantidadMinutoExtra25Nocturno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.AsistenciaFeriadoNocturnaExtra1);
                        cantidadMinutoExtra35Diurno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.AsistenciaFeriadoDiurnaExtra2);
                        cantidadMinutoExtra35Nocturno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.AsistenciaFeriadoNocturnaExtra2);

                        uiCandidatoAsistenciaResumen.AsistenciaFeriadoDiurna = cantidadMinutoHorarioDiurno;
                        uiCandidatoAsistenciaResumen.AsistenciaFeriadoNocturna = cantidadMinutoHorarioNocturno;
                        uiCandidatoAsistenciaResumen.AsistenciaFeriadoDiurnaExtra1 = cantidadMinutoExtra25Diurno;
                        uiCandidatoAsistenciaResumen.AsistenciaFeriadoNocturnaExtra1 = cantidadMinutoExtra25Nocturno;
                        uiCandidatoAsistenciaResumen.AsistenciaFeriadoDiurnaExtra2 = cantidadMinutoExtra35Diurno;
                        uiCandidatoAsistenciaResumen.AsistenciaFeriadoNocturnaExtra2 = cantidadMinutoExtra35Nocturno;
                        #endregion

                        #endregion

                        #region Tardanzas

                        int cantidadMinutoTardanzaDiurno = 0;
                        int cantidadMinutoTardanzaNocturno = 0;

                        #region Tardanzas Normal
                        cantidadMinutoTardanzaDiurno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.TardanzaNormalDiurna);
                        cantidadMinutoTardanzaNocturno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.TardanzaNormalNocturna);

                        uiCandidatoAsistenciaResumen.TardanzaNormalDiurna = cantidadMinutoTardanzaDiurno;
                        uiCandidatoAsistenciaResumen.TardanzaNormalNocturna = cantidadMinutoTardanzaNocturno;
                        #endregion

                        #region Tardanzas Feriado
                        cantidadMinutoTardanzaDiurno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.TardanzaFeriadoDiurna);
                        cantidadMinutoTardanzaNocturno = (int)lstUiAsistenciasDelCandidato.Sum(x => x.TardanzaFeriadoNocturna);

                        uiCandidatoAsistenciaResumen.TardanzaFeriadoDiurna = cantidadMinutoTardanzaDiurno;
                        uiCandidatoAsistenciaResumen.TardanzaFeriadoNocturna = cantidadMinutoTardanzaNocturno;
                        #endregion

                        #endregion

                        #region Inasistencias
                        int cantidadMinutoInasistenciaNormal = (int)lstUiAsistenciasDelCandidato.Sum(x => x.InasistenciaTotal);
                        int cantidadMinutoInasistenciaFeriado = (int)lstUiAsistenciasDelCandidato.Sum(x => x.InasistenciaTotal);

                        uiCandidatoAsistenciaResumen.InasistenciaNormal = cantidadMinutoInasistenciaNormal;
                        uiCandidatoAsistenciaResumen.InasistenciaFeriado = cantidadMinutoInasistenciaFeriado;
                        #endregion

                        this.lstUiAsistenciasCandidatosResumen.Add(uiCandidatoAsistenciaResumen);
                    }

               

                }

                var sorted = new SortableBindingList<BE.UI.CandidatoAsistenciaResumen>(this.lstUiAsistenciasCandidatosResumen);
                this.dgvAsistenciasResumen.DataSource = sorted;

                int nroAsistencias = this.lstUiAsistenciasCandidatosResumen.Count;
                this.txtRegistrosAsistenciasResumen.Text = nroAsistencias.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Mostrar la lista detallada de las Asistencias de los Candidatos
        /// </summary>
        /// <param name="anho">Año en formato de 4 digitos</param>
        /// <param name="mes">Mes en rango de 1 al 12</param>
        private void CargarAsistenciasCandidatos(int anho = 0, int mes = 0)
        {
            try
            {

                if (anho == 0 && mes == 0)
                {
                    this.lstUiAsistenciasCandidatos = new List<BE.UI.CandidatoAsistencia>();
                }
                else
                {
                    this.lstUiAsistenciasCandidatos = new LN.Recibo().ListarAsistencias(anho, mes);
                    for (int i = 0; i < this.lstUiAsistenciasCandidatos.Count; i++)
                        this.lstUiAsistenciasCandidatos[i].FormateadoCalculo = "H";
                }

                var sorted = new SortableBindingList<BE.UI.CandidatoAsistencia>(this.lstUiAsistenciasCandidatos);
                this.dgvAsistenciasDetalle.DataSource = sorted;

                int nroAsistencias = this.lstUiAsistenciasCandidatos.Count;
                this.txtRegistrosAsistencias.Text = nroAsistencias.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarSueldosCandidatos(int anho = 0, int mes = 0)
        {
            try
            {

                if (anho == 0 && mes == 0)
                {
                    this.lstUiSueldosCandidatos = new List<BE.UI.SueldoCandidato>();
                }
                else
                {

                    //Calcular
                    this.lstUiSueldosCandidatos = new List<BE.UI.SueldoCandidato>();

                    foreach (BE.UI.CandidatoCosto uiCandidatoCosto in this.lstUiCostosCandidatos)
                    {
                        var uiSueldoCandidato = new BE.UI.SueldoCandidato();

                        uiSueldoCandidato.ID = 0; //Nuevo

                        #region Candidato

                        uiSueldoCandidato.CandidatoCodigo = uiCandidatoCosto.Codigo;
                        uiSueldoCandidato.CandidatoNombreCompleto = uiCandidatoCosto.NombleCompleto;

                        #endregion

                        #region Sueldo

                        uiSueldoCandidato.Sueldo = uiCandidatoCosto.Sueldo;
                        uiSueldoCandidato.AsignacionFamiliar = uiCandidatoCosto.AsignacionFamiliar;

                        #endregion

                        #region Bonos

                        #region Bono Horario Nocturno

                        int cantidadMinutoNormalNocturno = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.AsistenciaNormalNocturna);
                        double costoMinutoNormalNocturno = Math.Round(uiCandidatoCosto.NormalNocturno, 4);
                        double costoMinutoNormalDiurno = Math.Round(uiCandidatoCosto.NormalDiurno, 4);
                        double totalMinutoNormalNocturno = Math.Round(cantidadMinutoNormalNocturno * costoMinutoNormalNocturno, 4)
                                                        - Math.Round(cantidadMinutoNormalNocturno * costoMinutoNormalDiurno, 4);

                        int cantidadMinutoFeriadoNocturno = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.AsistenciaFeriadoNocturna);
                        double costoMinutoFeriadoNocturno = Math.Round(uiCandidatoCosto.FeriadoNocturno, 4);
                        double costoMinutoFeriadoDiurno = Math.Round(uiCandidatoCosto.FeriadoDiurno, 4);
                        double totalMinutoFeriadoNocturno = Math.Round(cantidadMinutoFeriadoNocturno * costoMinutoFeriadoNocturno, 4)
                                                        - Math.Round(cantidadMinutoFeriadoNocturno * costoMinutoFeriadoDiurno, 4);

                        uiSueldoCandidato.BonoNocturnoMinutos = cantidadMinutoNormalNocturno
                                                            + cantidadMinutoFeriadoNocturno;
                        uiSueldoCandidato.BonoNocturnoTotal = totalMinutoNormalNocturno
                                                            + totalMinutoFeriadoNocturno;

                        #endregion

                        #region Bono Horas Extras

                        int cantidadMinutoNormalDiurnoExtra25 = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.AsistenciaNormalDiurnaExtra1);
                        double costoMinutoNormalDiurnoExtra25 = Math.Round(uiCandidatoCosto.NormalDiurnoExtra1, 4);
                        double totalMinutoNormalDiurnoExtra25 = Math.Round(cantidadMinutoNormalDiurnoExtra25 * costoMinutoNormalDiurnoExtra25, 4);

                        int cantidadMinutoNormalNocturnoExtra25 = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.AsistenciaNormalNocturnaExtra1);
                        double costoMinutoNormalNocturnoExtra25 = Math.Round(uiCandidatoCosto.NormalNocturnoExtra1, 4);
                        double totalMinutoNormalNocturnoExtra25 = Math.Round(cantidadMinutoNormalNocturnoExtra25 * costoMinutoNormalNocturnoExtra25, 4);

                        int cantidadMinutoNormalDiurnoExtra35 = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.AsistenciaNormalDiurnaExtra2);
                        double costoMinutoNormalDiurnoExtra35 = Math.Round(uiCandidatoCosto.NormalDiurnoExtra2, 4);
                        double totalMinutoNormalDiurnoExtra35 = Math.Round(cantidadMinutoNormalDiurnoExtra35 * costoMinutoNormalDiurnoExtra35, 4);

                        int cantidadMinutoNormalNocturnoExtra35 = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.AsistenciaNormalNocturnaExtra2);
                        double costoMinutoNormalNocturnoExtra35 = Math.Round(uiCandidatoCosto.NormalNocturnoExtra2, 4);
                        double totalMinutoNormalNocturnoExtra35 = Math.Round(cantidadMinutoNormalNocturnoExtra35 * costoMinutoNormalNocturnoExtra35, 4);

                        int cantidadMinutoFeriadoDiurnoExtra25 = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.AsistenciaFeriadoDiurnaExtra1);
                        double costoMinutoFeriadoDiurnoExtra25 = Math.Round(uiCandidatoCosto.FeriadoDiurnoExtra1, 4);
                        double totalMinutoFeriadoDiurnoExtra25 = Math.Round(cantidadMinutoFeriadoDiurnoExtra25 * costoMinutoFeriadoDiurnoExtra25, 4);

                        int cantidadMinutoFeriadoNocturnoExtra25 = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.AsistenciaFeriadoNocturnaExtra1);
                        double costoMinutoFeriadoNocturnoExtra25 = Math.Round(uiCandidatoCosto.FeriadoNocturnoExtra1, 4);
                        double totalMinutoFeriadoNocturnoExtra25 = Math.Round(cantidadMinutoFeriadoNocturnoExtra25 * costoMinutoFeriadoNocturnoExtra25, 4);

                        int cantidadMinutoFeriadoDiurnoExtra35 = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.AsistenciaFeriadoDiurnaExtra2);
                        double costoMinutoFeriadoDiurnoExtra35 = Math.Round(uiCandidatoCosto.FeriadoDiurnoExtra2, 4);
                        double totalMinutoFeriadoDiurnoExtra35 = Math.Round(cantidadMinutoFeriadoDiurnoExtra35 * costoMinutoFeriadoDiurnoExtra35, 4);

                        int cantidadMinutoFeriadoNocturnoExtra35 = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.AsistenciaFeriadoNocturnaExtra2);
                        double costoMinutoFeriadoNocturnoExtra35 = Math.Round(uiCandidatoCosto.FeriadoNocturnoExtra2, 4);
                        double totalMinutoFeriadoNocturnoExtra35 = Math.Round(cantidadMinutoFeriadoNocturnoExtra35 * costoMinutoFeriadoNocturnoExtra35, 4);

                        uiSueldoCandidato.BonoHorasExtrasMinutos = cantidadMinutoNormalDiurnoExtra25
                                                                + cantidadMinutoNormalNocturnoExtra25
                                                                + cantidadMinutoNormalDiurnoExtra35
                                                                + cantidadMinutoNormalNocturnoExtra35
                                                                + cantidadMinutoFeriadoDiurnoExtra25
                                                                + cantidadMinutoFeriadoNocturnoExtra25
                                                                + cantidadMinutoFeriadoDiurnoExtra35
                                                                + cantidadMinutoFeriadoNocturnoExtra35;
                        uiSueldoCandidato.BonoHorasExtrasTotal = totalMinutoNormalDiurnoExtra25
                                                                + totalMinutoNormalNocturnoExtra25
                                                                + totalMinutoNormalDiurnoExtra35
                                                                + totalMinutoNormalNocturnoExtra35
                                                                + totalMinutoFeriadoDiurnoExtra25
                                                                + totalMinutoFeriadoNocturnoExtra25
                                                                + totalMinutoFeriadoDiurnoExtra35
                                                                + totalMinutoFeriadoNocturnoExtra35;

                        #endregion

                        #region Bono Feriado o Dominical

                        int cantidadMinutoFeriadoDiurno = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.AsistenciaFeriadoDiurna);
                        double totalMinutoFeriadoDiurno = Math.Round(cantidadMinutoFeriadoDiurno * costoMinutoFeriadoDiurno, 4);

                        uiSueldoCandidato.BonoFeriadoMinutos = cantidadMinutoFeriadoDiurno
                                                            + cantidadMinutoFeriadoNocturno;
                        uiSueldoCandidato.BonoFeriadoTotal = totalMinutoFeriadoDiurno
                                                            + totalMinutoFeriadoNocturno;

                        #endregion

                        #endregion

                        #region Descuentos 

                        #region Tardanzas 

                        int cantidadMinutoTardanzaNormalDiurno = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.TardanzaNormalDiurna);
                        double costoMinutoTardanzaNormalDiurno = Math.Round(uiCandidatoCosto.TardanzaNormalDiurno, 4);
                        double totalMinutoTardanzaNormalDiurno = Math.Round(cantidadMinutoTardanzaNormalDiurno * costoMinutoTardanzaNormalDiurno, 4);

                        int cantidadMinutoTardanzaNormalNocturno = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.TardanzaNormalNocturna);
                        double costoMinutoTardanzaNormalNocturno = Math.Round(uiCandidatoCosto.TardanzaNormalNocturno, 4);
                        double totalMinutoTardanzaNormalNocturno = Math.Round(cantidadMinutoTardanzaNormalNocturno * costoMinutoTardanzaNormalNocturno, 4);

                        int cantidadMinutoTardanzaFeriadoDiurno = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.TardanzaFeriadoDiurna);
                        double costoMinutoTardanzaFeriadoDiurno = Math.Round(uiCandidatoCosto.TardanzaFeriadoDiurno, 4);
                        double totalMinutoTardanzaFeriadoDiurno = Math.Round(cantidadMinutoTardanzaFeriadoDiurno * costoMinutoTardanzaFeriadoDiurno, 4);

                        int cantidadMinutoTardanzaFeriadoNocturno = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.TardanzaFeriadoNocturna);
                        double costoMinutoTardanzaFeriadoNocturno = Math.Round(uiCandidatoCosto.TardanzaFeriadoNocturno, 4);
                        double totalMinutoTardanzaFeriadoNocturno = Math.Round(cantidadMinutoTardanzaFeriadoNocturno * costoMinutoTardanzaFeriadoNocturno, 4);

                        uiSueldoCandidato.DescuentoTardanzaMinutos = cantidadMinutoTardanzaNormalDiurno
                                                                    + cantidadMinutoTardanzaNormalNocturno
                                                                    + cantidadMinutoTardanzaFeriadoDiurno
                                                                    + cantidadMinutoTardanzaFeriadoNocturno;
                        uiSueldoCandidato.DescuentoTardanzaTotal = totalMinutoTardanzaNormalDiurno
                                                                    + totalMinutoTardanzaNormalNocturno
                                                                    + totalMinutoTardanzaFeriadoDiurno
                                                                    + totalMinutoTardanzaFeriadoNocturno;

                        #endregion

                        int cantidadMinutoInasistencia = this.lstUiAsistenciasCandidatos.AsEnumerable().Where(x => x.Codigo == uiSueldoCandidato.CandidatoCodigo).Sum(x => x.InasistenciaTotal);
                        double costoMinutoInasistencia = Math.Round(uiCandidatoCosto.Inasistencia, 4);
                        double totalMinutoInasistencia = Math.Round(cantidadMinutoTardanzaFeriadoNocturno * costoMinutoTardanzaFeriadoNocturno, 4);

                        uiSueldoCandidato.DescuentoInasistenciaMinutos = cantidadMinutoInasistencia;
                        uiSueldoCandidato.DescuentoInasistenciaTotal = totalMinutoInasistencia;

                        #endregion

                        this.lstUiSueldosCandidatos.Add(uiSueldoCandidato);
                    }


                    //Asignar valores globales de año y mes 
                    this.Anho = anho;
                    this.Mes = mes;

                    //Mostrar valores globales
                    this.txtAnho.Text = anho.ToString();
                    this.txtMes.Text = Util.GetNameOfMonth(Mes);

                }

                var sorted = new SortableBindingList<BE.UI.SueldoCandidato>(this.lstUiSueldosCandidatos);
                this.dgvSueldos.DataSource = sorted;

                int nroSueldos = this.lstUiSueldosCandidatos.Count;
                this.txtNroSueldos.Text = nroSueldos.ToString();

                double totalSueldos = this.lstUiSueldosCandidatos.Sum(x => x.TotalNeto);
                this.txtTotalSueldos.Text = totalSueldos.ToString("N2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoSueldosCandidatos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvSueldos);

                for (int col = 0; col < this.dgvSueldos.Columns.Count; col++)
                    this.dgvSueldos.Columns[col].Visible = false;

                this.dgvSueldos.Columns["CandidatoCodigo"].Visible = true;
                this.dgvSueldos.Columns["CandidatoCodigo"].HeaderText = "Codigo";
                this.dgvSueldos.Columns["CandidatoCodigo"].Width = 80;
                this.dgvSueldos.Columns["CandidatoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSueldos.Columns["CandidatoNombreCompleto"].Visible = true;
                this.dgvSueldos.Columns["CandidatoNombreCompleto"].HeaderText = "Candidato";
                this.dgvSueldos.Columns["CandidatoNombreCompleto"].Width = 200;
                this.dgvSueldos.Columns["CandidatoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvSueldos.Columns["Sueldo"].Visible = true;
                this.dgvSueldos.Columns["Sueldo"].HeaderText = "Sueldo";
                this.dgvSueldos.Columns["Sueldo"].Width = 70;
                this.dgvSueldos.Columns["Sueldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldos.Columns["Sueldo"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["BonoNocturnoTotal"].Visible = true;
                this.dgvSueldos.Columns["BonoNocturnoTotal"].HeaderText = "Bono Nocturno";
                this.dgvSueldos.Columns["BonoNocturnoTotal"].Width = 70;
                this.dgvSueldos.Columns["BonoNocturnoTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldos.Columns["BonoNocturnoTotal"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["BonoHorasExtrasTotal"].Visible = true;
                this.dgvSueldos.Columns["BonoHorasExtrasTotal"].HeaderText = "Bono Horas Extras";
                this.dgvSueldos.Columns["BonoHorasExtrasTotal"].Width = 70;
                this.dgvSueldos.Columns["BonoHorasExtrasTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldos.Columns["BonoHorasExtrasTotal"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["BonoFeriadoTotal"].Visible = true;
                this.dgvSueldos.Columns["BonoFeriadoTotal"].HeaderText = "Bono Feriado";
                this.dgvSueldos.Columns["BonoFeriadoTotal"].Width = 70;
                this.dgvSueldos.Columns["BonoFeriadoTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldos.Columns["BonoFeriadoTotal"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["DescuentoTardanzaTotal"].Visible = true;
                this.dgvSueldos.Columns["DescuentoTardanzaTotal"].HeaderText = "Descuento Tardanza";
                this.dgvSueldos.Columns["DescuentoTardanzaTotal"].Width = 70;
                this.dgvSueldos.Columns["DescuentoTardanzaTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldos.Columns["DescuentoTardanzaTotal"].DefaultCellStyle.Format = "N2";

                this.dgvSueldos.Columns["DescuentoInasistenciaTotal"].Visible = true;
                this.dgvSueldos.Columns["DescuentoInasistenciaTotal"].HeaderText = "Descuento Inasistencia";
                this.dgvSueldos.Columns["DescuentoInasistenciaTotal"].Width = 70;
                this.dgvSueldos.Columns["DescuentoInasistenciaTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvSueldos.Columns["DescuentoInasistenciaTotal"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvSueldos, "CandidatoNombreCompleto");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoAsistenciasCandidatos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvAsistenciasDetalle);

                for (int col = 0; col < this.dgvAsistenciasDetalle.Columns.Count; col++)
                    this.dgvAsistenciasDetalle.Columns[col].Visible = false;

                this.dgvAsistenciasDetalle.Columns["Codigo"].Visible = true;
                this.dgvAsistenciasDetalle.Columns["Codigo"].HeaderText = "Codigo";
                this.dgvAsistenciasDetalle.Columns["Codigo"].Width = 80;
                this.dgvAsistenciasDetalle.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvAsistenciasDetalle.Columns["Fecha"].Visible = true;
                this.dgvAsistenciasDetalle.Columns["Fecha"].Width = 70;
                this.dgvAsistenciasDetalle.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAsistenciasDetalle.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvAsistenciasDetalle.Columns["FechaHoraInicio"].Visible = true;
                this.dgvAsistenciasDetalle.Columns["FechaHoraInicio"].HeaderText = "Inicio Horario";
                this.dgvAsistenciasDetalle.Columns["FechaHoraInicio"].Width = 120;
                this.dgvAsistenciasDetalle.Columns["FechaHoraInicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAsistenciasDetalle.Columns["FechaHoraInicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                this.dgvAsistenciasDetalle.Columns["FechaHoraFinal"].Visible = true;
                this.dgvAsistenciasDetalle.Columns["FechaHoraFinal"].HeaderText = "Final Horario";
                this.dgvAsistenciasDetalle.Columns["FechaHoraFinal"].Width = 120;
                this.dgvAsistenciasDetalle.Columns["FechaHoraFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvAsistenciasDetalle.Columns["FechaHoraFinal"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                int iniHoras = 0;
                int finHoras = 0;

                //Asistencias Normal
                iniHoras = this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaNormalTotal"].Index;
                finHoras = this.dgvAsistenciasDetalle.Columns["FormateadoTardanzaNormalNocturna"].Index + 1;
                for (int i = iniHoras; i < finHoras; i++)
                {
                    this.dgvAsistenciasDetalle.Columns[i].Visible = true;
                    this.dgvAsistenciasDetalle.Columns[i].Width = 70;
                    this.dgvAsistenciasDetalle.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvAsistenciasDetalle.Columns[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }

                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaNormalTotal"].Visible = false;
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaNormalTotal"].HeaderText = "Asistencia Total";

                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaNormalDiurna"].HeaderText = "Horario Diurno";
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaNormalNocturna"].HeaderText = "Horario Nocturno";
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaNormalDiurnaExtra1"].HeaderText = "Extras 25% Diurno";
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaNormalNocturnaExtra1"].HeaderText = "Extras 25% Nocturno";
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaNormalDiurnaExtra2"].HeaderText = "Extras 35% Diurno";
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaNormalNocturnaExtra2"].HeaderText = "Extras 35% Nocturno";

                this.dgvAsistenciasDetalle.Columns["FormateadoTardanzaNormalTotal"].Visible = false;
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaNormalTotal"].HeaderText = "Tardanza Total";

                this.dgvAsistenciasDetalle.Columns["FormateadoTardanzaNormalDiurna"].HeaderText = "Tardanza Diurna";
                this.dgvAsistenciasDetalle.Columns["FormateadoTardanzaNormalNocturna"].HeaderText = "Tardanza Nocturna";

                //Asistencias Feriados
                iniHoras = this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaFeriadoTotal"].Index;
                finHoras = this.dgvAsistenciasDetalle.Columns["FormateadoTardanzaFeriadoNocturna"].Index + 1;
                for (int i = iniHoras; i < finHoras; i++)
                {
                    this.dgvAsistenciasDetalle.Columns[i].Visible = true;
                    this.dgvAsistenciasDetalle.Columns[i].Width = 70;
                    this.dgvAsistenciasDetalle.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvAsistenciasDetalle.Columns[i].DefaultCellStyle.BackColor = Color.LightYellow;
                }

                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaFeriadoTotal"].Visible = false;
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaFeriadoTotal"].HeaderText = "Asistencia Total";

                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaFeriadoDiurna"].HeaderText = "Horario Diurno";
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaFeriadoNocturna"].HeaderText = "Horario Nocturno";
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaFeriadoDiurnaExtra1"].HeaderText = "Extras 25% Diurno";
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaFeriadoNocturnaExtra1"].HeaderText = "Extras 25% Nocturno";
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaFeriadoDiurnaExtra2"].HeaderText = "Extras 35% Diurno";
                this.dgvAsistenciasDetalle.Columns["FormateadoAsistenciaFeriadoNocturnaExtra2"].HeaderText = "Extras 35% Nocturno";

                this.dgvAsistenciasDetalle.Columns["FormateadoTardanzaFeriadoTotal"].Visible = false;
                this.dgvAsistenciasDetalle.Columns["TardanzaFeriadoTotal"].HeaderText = "Tardanza Total";

                this.dgvAsistenciasDetalle.Columns["FormateadoTardanzaFeriadoDiurna"].HeaderText = "Tardanza Diurna";
                this.dgvAsistenciasDetalle.Columns["FormateadoTardanzaFeriadoNocturna"].HeaderText = "Tardanza Nocturna";

                //Inasistencias
                iniHoras = this.dgvAsistenciasDetalle.Columns["FormateadoInasistenciaNormal"].Index;
                finHoras = this.dgvAsistenciasDetalle.Columns["FormateadoInasistenciaFeriado"].Index + 1;
                for (int i = iniHoras; i < finHoras; i++)
                {
                    this.dgvAsistenciasDetalle.Columns[i].Visible = true;
                    this.dgvAsistenciasDetalle.Columns[i].Width = 70;
                    this.dgvAsistenciasDetalle.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvAsistenciasDetalle.Columns[i].DefaultCellStyle.BackColor = Color.Red;
                }
                this.dgvAsistenciasDetalle.Columns["FormateadoInasistenciaNormal"].HeaderText = "Inasistencia Normal";
                this.dgvAsistenciasDetalle.Columns["FormateadoInasistenciaFeriado"].HeaderText = "Inasistencia Feriado";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoAsistenciasCandidatosResumen()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvAsistenciasResumen);

                for (int col = 0; col < this.dgvAsistenciasResumen.Columns.Count; col++)
                    this.dgvAsistenciasResumen.Columns[col].Visible = false;

                this.dgvAsistenciasResumen.Columns["Codigo"].Visible = true;
                this.dgvAsistenciasResumen.Columns["Codigo"].HeaderText = "Codigo";
                this.dgvAsistenciasResumen.Columns["Codigo"].Width = 80;
                this.dgvAsistenciasResumen.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvAsistenciasResumen.Columns["Codigo"].DisplayIndex = 0;

                this.dgvAsistenciasResumen.Columns["NombleCompleto"].Visible = true;
                this.dgvAsistenciasResumen.Columns["NombleCompleto"].HeaderText = "Candidato";
                this.dgvAsistenciasResumen.Columns["NombleCompleto"].Width = 200;
                this.dgvAsistenciasResumen.Columns["NombleCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvAsistenciasResumen.Columns["NombleCompleto"].DisplayIndex = 1;

                int iniHoras = 0;
                int finHoras = 0;

                //Asistencias Normal
                iniHoras = this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaNormalTotal"].Index;
                finHoras = this.dgvAsistenciasResumen.Columns["FormateadoTardanzaNormalNocturna"].Index + 1;
                for (int i = iniHoras; i < finHoras; i++)
                {
                    this.dgvAsistenciasResumen.Columns[i].Visible = true;
                    this.dgvAsistenciasResumen.Columns[i].Width = 60;
                    this.dgvAsistenciasResumen.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvAsistenciasResumen.Columns[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }

                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaNormalTotal"].Visible = false;
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaNormalTotal"].HeaderText = "Asistencia Total";

                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaNormalDiurna"].HeaderText = "Horario Diurno";
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaNormalNocturna"].HeaderText = "Horario Nocturno";
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaNormalDiurnaExtra1"].HeaderText = "Extras 25% Diurno";
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaNormalNocturnaExtra1"].HeaderText = "Extras 25% Nocturno";
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaNormalDiurnaExtra2"].HeaderText = "Extras 35% Diurno";
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaNormalNocturnaExtra2"].HeaderText = "Extras 35% Nocturno";

                this.dgvAsistenciasResumen.Columns["FormateadoTardanzaNormalTotal"].Visible = false;
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaNormalTotal"].HeaderText = "Tardanza Total";

                this.dgvAsistenciasResumen.Columns["FormateadoTardanzaNormalDiurna"].HeaderText = "Tardanza Diurna";
                this.dgvAsistenciasResumen.Columns["FormateadoTardanzaNormalNocturna"].HeaderText = "Tardanza Nocturna";

                //Asistencias Feriados
                iniHoras = this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaFeriadoTotal"].Index;
                finHoras = this.dgvAsistenciasResumen.Columns["FormateadoTardanzaFeriadoNocturna"].Index + 1;
                for (int i = iniHoras; i < finHoras; i++)
                {
                    this.dgvAsistenciasResumen.Columns[i].Visible = true;
                    this.dgvAsistenciasResumen.Columns[i].Width = 60;
                    this.dgvAsistenciasResumen.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvAsistenciasResumen.Columns[i].DefaultCellStyle.BackColor = Color.LightYellow;
                }

                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaFeriadoTotal"].Visible = false;
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaFeriadoTotal"].HeaderText = "Asistencia Total";

                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaFeriadoDiurna"].HeaderText = "Horario Diurno";
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaFeriadoNocturna"].HeaderText = "Horario Nocturno";
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaFeriadoDiurnaExtra1"].HeaderText = "Extras 25% Diurno";
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaFeriadoNocturnaExtra1"].HeaderText = "Extras 25% Nocturno";
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaFeriadoDiurnaExtra2"].HeaderText = "Extras 35% Diurno";
                this.dgvAsistenciasResumen.Columns["FormateadoAsistenciaFeriadoNocturnaExtra2"].HeaderText = "Extras 35% Nocturno";

                this.dgvAsistenciasResumen.Columns["FormateadoTardanzaFeriadoTotal"].Visible = false;
                this.dgvAsistenciasResumen.Columns["TardanzaFeriadoTotal"].HeaderText = "Tardanza Total";

                this.dgvAsistenciasResumen.Columns["FormateadoTardanzaFeriadoDiurna"].HeaderText = "Tardanza Diurna";
                this.dgvAsistenciasResumen.Columns["FormateadoTardanzaFeriadoNocturna"].HeaderText = "Tardanza Nocturna";

                //Inasistencias
                iniHoras = this.dgvAsistenciasResumen.Columns["FormateadoInasistenciaNormal"].Index;
                finHoras = this.dgvAsistenciasResumen.Columns["FormateadoInasistenciaFeriado"].Index + 1;
                for (int i = iniHoras; i < finHoras; i++)
                {
                    this.dgvAsistenciasResumen.Columns[i].Visible = true;
                    this.dgvAsistenciasResumen.Columns[i].Width = 60;
                    this.dgvAsistenciasResumen.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvAsistenciasResumen.Columns[i].DefaultCellStyle.BackColor = Color.Red;
                }
                this.dgvAsistenciasResumen.Columns["FormateadoInasistenciaNormal"].HeaderText = "Inasistencia Normal";
                this.dgvAsistenciasResumen.Columns["FormateadoInasistenciaFeriado"].HeaderText = "Inasistencia Feriado";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoCostosCandidatos()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvCostos);

                for (int col = 0; col < this.dgvCostos.Columns.Count; col++)
                    this.dgvCostos.Columns[col].Visible = false;

                this.dgvCostos.Columns["Codigo"].Visible = true;
                this.dgvCostos.Columns["Codigo"].HeaderText = "Codigo";
                this.dgvCostos.Columns["Codigo"].Width = 80;
                this.dgvCostos.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvCostos.Columns["Codigo"].DisplayIndex = 0;

                this.dgvCostos.Columns["NombleCompleto"].Visible = true;
                this.dgvCostos.Columns["NombleCompleto"].HeaderText = "Candidato";
                this.dgvCostos.Columns["NombleCompleto"].Width = 200;
                this.dgvCostos.Columns["NombleCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.dgvCostos.Columns["NombleCompleto"].DisplayIndex = 1;

                this.dgvCostos.Columns["Sueldo"].Visible = true;
                this.dgvCostos.Columns["Sueldo"].HeaderText = "Sueldo";
                this.dgvCostos.Columns["Sueldo"].Width = 70;
                this.dgvCostos.Columns["Sueldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvCostos.Columns["Sueldo"].DefaultCellStyle.Format = "N2";

                int iniInx = 0;
                int finInx = 0;

                //Costo Normal
                iniInx = this.dgvCostos.Columns["NormalDiurno"].Index;
                finInx = this.dgvCostos.Columns["NormalNocturnoExtra2"].Index + 1;
                for (int i = iniInx; i < finInx; i++)
                {
                    this.dgvCostos.Columns[i].Visible = true;
                    this.dgvCostos.Columns[i].Width = 70;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Format = "N4";
                    this.dgvCostos.Columns[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }

                this.dgvCostos.Columns["NormalDiurno"].HeaderText = "Horario Diurno";
                this.dgvCostos.Columns["NormalDiurnoExtra1"].HeaderText = "Extras 25% Diurno";
                this.dgvCostos.Columns["NormalDiurnoExtra2"].HeaderText = "Extras 35% Diurno";
                this.dgvCostos.Columns["NormalNocturno"].HeaderText = "Horario Nocturno";
                this.dgvCostos.Columns["NormalNocturnoExtra1"].HeaderText = "Extras 25% Nocturno";
                this.dgvCostos.Columns["NormalNocturnoExtra2"].HeaderText = "Extras 35% Nocturno";

                //Costo Feriado
                iniInx = this.dgvCostos.Columns["FeriadoDiurno"].Index;
                finInx = this.dgvCostos.Columns["FeriadoNocturnoExtra2"].Index + 1;
                for (int i = iniInx; i < finInx; i++)
                {
                    this.dgvCostos.Columns[i].Visible = true;
                    this.dgvCostos.Columns[i].Width = 70;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Format = "N4";
                    this.dgvCostos.Columns[i].DefaultCellStyle.BackColor = Color.LightYellow;
                }

                this.dgvCostos.Columns["FeriadoDiurno"].HeaderText = "Feriado Diurno";
                this.dgvCostos.Columns["FeriadoDiurnoExtra1"].HeaderText = "Extras 25% Diurno";
                this.dgvCostos.Columns["FeriadoDiurnoExtra2"].HeaderText = "Extras 35% Diurno";
                this.dgvCostos.Columns["FeriadoNocturno"].HeaderText = "Feriado Nocturno";
                this.dgvCostos.Columns["FeriadoNocturnoExtra1"].HeaderText = "Extras 25% Nocturno";
                this.dgvCostos.Columns["FeriadoNocturnoExtra2"].HeaderText = "Extras 35% Nocturno";

                //Descuento Tardanza Normal
                iniInx = this.dgvCostos.Columns["TardanzaNormalDiurno"].Index;
                finInx = this.dgvCostos.Columns["TardanzaNormalNocturno"].Index + 1;
                for (int i = iniInx; i < finInx; i++)
                {
                    this.dgvCostos.Columns[i].Visible = true;
                    this.dgvCostos.Columns[i].Width = 70;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Format = "N4";
                    this.dgvCostos.Columns[i].DefaultCellStyle.BackColor = Color.Green;
                }

                this.dgvCostos.Columns["TardanzaNormalDiurno"].HeaderText = "Tardanza Diurno";
                this.dgvCostos.Columns["TardanzaNormalNocturno"].HeaderText = "Tardanza Nocturno";

                //Descuento Tardanza Feriado
                iniInx = this.dgvCostos.Columns["TardanzaFeriadoDiurno"].Index;
                finInx = this.dgvCostos.Columns["TardanzaFeriadoNocturno"].Index + 1;
                for (int i = iniInx; i < finInx; i++)
                {
                    this.dgvCostos.Columns[i].Visible = true;
                    this.dgvCostos.Columns[i].Width = 70;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Format = "N4";
                    this.dgvCostos.Columns[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                this.dgvCostos.Columns["TardanzaFeriadoDiurno"].HeaderText = "Tardanza Diurno";
                this.dgvCostos.Columns["TardanzaFeriadoNocturno"].HeaderText = "Tardanza Nocturno";

                //Descuento Inasistencia
                iniInx = this.dgvCostos.Columns["Dominical"].Index;
                finInx = this.dgvCostos.Columns["Inasistencia"].Index + 1;
                for (int i = iniInx; i < finInx; i++)
                {
                    this.dgvCostos.Columns[i].Visible = true;
                    this.dgvCostos.Columns[i].Width = 70;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.dgvCostos.Columns[i].DefaultCellStyle.Format = "N4";
                    this.dgvCostos.Columns[i].DefaultCellStyle.BackColor = Color.Red;
                }
                this.dgvCostos.Columns["Dominical"].HeaderText = "Dominical";
                this.dgvCostos.Columns["Inasistencia"].HeaderText = "Inasistencia";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region Formulario

        private void FrmAsignarSueldoCalc_Load(object sender, EventArgs e)
        {
            try
            {
                this.Limpiar();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {

                Util.PointerLoad(this);

                #region Validar Existencia del calculo

                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());
                if (new LN.SueldoCandidato().ExisteCalculo(anho, mes))
                {
                    if (Util.ConfirmationMessage("Ya existe un calculo de Sueldos para este periodo. ¿Desea continua?") == false)
                        return;
                }

                #endregion

                #region Calcular y Mostrar

                this.CargarCostosCandidatos(anho, mes);
                this.CargarAsistenciasCandidatos(anho, mes);
                this.CargarAsistenciasCandidatosResumen();
                this.CargarSueldosCandidatos(anho, mes);

                ////Limpiar Lista Global de los Sueldos
                //this.lstUiSueldosCandidatos = new List<BE.UI.SueldoCandidato>();

                //int dia = DateTime.DaysInMonth(anho, mes);
                //DateTime fechaPeriodo = new DateTime(anho, mes, dia);

                ////Obtener la lista de Candidatos
                //List<BE.Record> lstCandidatos = ListaCandidatos();
                //foreach (BE.Record beCandidato in lstCandidatos)
                //{

                //    var uiSueldoCandidato = new BE.UI.SueldoCandidato();

                //    uiSueldoCandidato.Fecha = fechaPeriodo;

                //    uiSueldoCandidato.CandidatoCodigo = beCandidato.Codigo;
                //    uiSueldoCandidato.CandidatoNombreCompleto = beCandidato.Nombre;

                //    //uiSueldoCandidato.Sueldo = SueldoId;
                //    //uiSueldoCandidato.SueldoTipo = SueldoTipo;
                //    //uiSueldoCandidato.SueldoNombre = SueldoNombre;

                //    //uiSueldoCandidato.Monto = SueldoMonto;
                //    //uiSueldoCandidato.Motivo = "";

                //    //if (SueldoMonto > 0.0)
                //    //    lstUiSueldosCandidatos.Add(uiSueldoCandidato);

                //}

                #endregion

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
            finally
            {
                Util.PointerReady(this);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.lstUiAsistenciasCandidatos.Count == 0)
                    throw new Exception("Debe realizar un calculo de Sueldos");

                if (this.lstUiCostosCandidatos.Count == 0)
                    throw new Exception("Debe realizar un calculo de Sueldos");

                if (this.lstUiSueldosCandidatos.Count == 0)
                    throw new Exception("Debe realizar un calculo de Sueldos");

                if (Util.ConfirmationMessage("¿Desea guardar los sueldos calculados?") == false)
                    return;

                bool rpta = false;
                var lnSueldoCandidato = new LN.SueldoCandidato();
                for (int i = 0; i < this.lstUiSueldosCandidatos.Count; i++)
                {
                    BE.UI.SueldoCandidato uiSueldoCandidato = this.lstUiSueldosCandidatos[i];
                    rpta = lnSueldoCandidato.Insertar(ref uiSueldoCandidato);
                    this.lstUiSueldosCandidatos[i].ID = uiSueldoCandidato.ID;
                }

                Util.InformationMessage("Se guardo los sueldos calculados");

                if (this.frmList != null)
                    this.frmList.CargarListadoSueldos();

                this.Close();

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

        private void cboAsistenciaResumenPor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                string calcular = this.cboAsistenciaResumenPor.SelectedValue.ToString();

                for (int i = 0; i < this.lstUiAsistenciasCandidatosResumen.Count; i++)
                    this.lstUiAsistenciasCandidatosResumen[i].FormateadoCalculo = calcular;

                this.dgvAsistenciasDetalle.Refresh();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboAsistenciaPor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                string calcular = this.cboAsistenciaPor.SelectedValue.ToString();

                for (int i = 0; i < this.lstUiAsistenciasCandidatos.Count; i++)
                    this.lstUiAsistenciasCandidatos[i].FormateadoCalculo = calcular;

                this.dgvAsistenciasDetalle.Refresh();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        private void cboCostoPor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string calcular = this.cboCostoPor.SelectedValue.ToString();

                for (int i = 0; i < this.lstUiCostosCandidatos.Count; i++)
                    this.lstUiCostosCandidatos[i].CostosPor = calcular;

                this.dgvCostos.Refresh();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnExportarAsistenciasCsv_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Comma-separated Values (*.csv)|*.csv";
                sfd.FileName = "export.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Util.PointerLoad(this);
                    Util.DatagridviewToCsv(this.dgvAsistenciasDetalle, sfd.FileName);
                    Util.InformationMessage("Se exporto correctamente el archivo CSV");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
            finally
            {
                Util.PointerReady(this);
            }
        }

        private void btnExportarAsistenciasResumenCsv_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Comma-separated Values (*.csv)|*.csv";
                sfd.FileName = "export.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Util.PointerLoad(this);
                    Util.DatagridviewToCsv(this.dgvAsistenciasResumen, sfd.FileName);
                    Util.InformationMessage("Se exporto correctamente el archivo CSV");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
            finally
            {
                Util.PointerReady(this);
            }
        }

        private void btnExportarCostoCsv_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Comma-separated Values (*.csv)|*.csv";
                sfd.FileName = "export.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Util.PointerLoad(this);
                    Util.DatagridviewToCsv(this.dgvCostos, sfd.FileName);
                    Util.InformationMessage("Se exporto correctamente el archivo CSV");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
            finally
            {
                Util.PointerReady(this);
            }
        }

        #endregion


    }
}
