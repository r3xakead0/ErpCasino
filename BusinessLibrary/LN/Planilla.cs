using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Planilla
    {

        private List<BE.Feriado> lstBeFeriados = null;
        private int anho = DateTime.Now.Year;
        private int mes = DateTime.Now.Month;

        private BE.UI.PlanillaAsistencia PlanillaAsistenciaBeToUi(BE.PlanillaAsistencia bePlanillaAsistencia)
        {
            var uiPlanillaDetalle = new BE.UI.PlanillaAsistencia();

            uiPlanillaDetalle.CodigoEmpleado = bePlanillaAsistencia.CodigoEmpleado;
            uiPlanillaDetalle.Fecha = bePlanillaAsistencia.Fecha;
            uiPlanillaDetalle.Semana = bePlanillaAsistencia.Semana;

            uiPlanillaDetalle.FechaHoraInicio = bePlanillaAsistencia.FechaHoraInicio;
            uiPlanillaDetalle.FechaHoraFinal = bePlanillaAsistencia.FechaHoraFinal;

            //Asistencia Normales
            uiPlanillaDetalle.AsistenciaNormalTotal = bePlanillaAsistencia.MinutosAsistenciaNormalTotal;
            uiPlanillaDetalle.AsistenciaNormalDiurna = bePlanillaAsistencia.MinutosAsistenciaNormalDiurna;
            uiPlanillaDetalle.AsistenciaNormalNocturna = bePlanillaAsistencia.MinutosAsistenciaNormalNocturna;
            uiPlanillaDetalle.AsistenciaNormalDiurnaExtra1 = bePlanillaAsistencia.MinutosAsistenciaNormalDiurnaExtra1;
            uiPlanillaDetalle.AsistenciaNormalNocturnaExtra1 = bePlanillaAsistencia.MinutosAsistenciaNormalNocturnaExtra1;
            uiPlanillaDetalle.AsistenciaNormalDiurnaExtra2 = bePlanillaAsistencia.MinutosAsistenciaNormalDiurnaExtra2;
            uiPlanillaDetalle.AsistenciaNormalNocturnaExtra2 = bePlanillaAsistencia.MinutosAsistenciaNormalNocturnaExtra2;

            //Tardanza Normal
            uiPlanillaDetalle.TardanzaNormalTotal = bePlanillaAsistencia.MinutosTardanzaNormalTotal;
            uiPlanillaDetalle.TardanzaNormalDiurna = bePlanillaAsistencia.MinutosTardanzaNormalDiurna;
            uiPlanillaDetalle.TardanzaNormalNocturna = bePlanillaAsistencia.MinutosTardanzaNormalNocturna;

            //Asistencia Feriados
            uiPlanillaDetalle.AsistenciaFeriadoTotal = bePlanillaAsistencia.MinutosAsistenciaFeriadoTotal;
            uiPlanillaDetalle.AsistenciaFeriadoDiurna = bePlanillaAsistencia.MinutosAsistenciaFeriadoDiurna;
            uiPlanillaDetalle.AsistenciaFeriadoNocturna = bePlanillaAsistencia.MinutosAsistenciaFeriadoNocturna;
            uiPlanillaDetalle.AsistenciaFeriadoDiurnaExtra1 = bePlanillaAsistencia.MinutosAsistenciaFeriadoDiurnaExtra1;
            uiPlanillaDetalle.AsistenciaFeriadoNocturnaExtra1 = bePlanillaAsistencia.MinutosAsistenciaFeriadoNocturnaExtra1;
            uiPlanillaDetalle.AsistenciaFeriadoDiurnaExtra2 = bePlanillaAsistencia.MinutosAsistenciaFeriadoDiurnaExtra2;
            uiPlanillaDetalle.AsistenciaFeriadoNocturnaExtra2 = bePlanillaAsistencia.MinutosAsistenciaFeriadoNocturnaExtra2;

            //Tardanza Feriado
            uiPlanillaDetalle.TardanzaFeriadoTotal = bePlanillaAsistencia.MinutosTardanzaFeriadoTotal;
            uiPlanillaDetalle.TardanzaFeriadoDiurna = bePlanillaAsistencia.MinutosTardanzaFeriadoDiurna;
            uiPlanillaDetalle.TardanzaFeriadoNocturna = bePlanillaAsistencia.MinutosTardanzaFeriadoNocturna;

            //Tardanza Inasistencias
            uiPlanillaDetalle.InasistenciaTotal = bePlanillaAsistencia.MinutosInasistenciaTotal;

            return uiPlanillaDetalle;
        }

        public Planilla(int anho, int mes)
        {
            try
            {
                this.anho = anho;
                this.mes = mes;

                this.lstBeFeriados = new DA.Feriado().ListarMes(anho, mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.Planilla bePlanilla)
        {
            try
            {
                return new DA.Planilla().Insertar(ref bePlanilla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Existe()
        {
            try
            {
                return new DA.Planilla().Existe(this.anho, this.mes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Planilla Obtener()
        {
            BE.Planilla bePlanilla = null;
            try
            {
                var daPlanilla = new DA.Planilla();

                bePlanilla = daPlanilla.Obtener(this.anho, this.mes);

                //if (bePlanilla != null)
                //    bePlanilla.Detalles = daPlanilla.Detalle(bePlanilla.ID);

                return bePlanilla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
         *  Listar todos los empleados activos con sus sueldos y si tiene hijos
         */
        public DataTable ListarSueldos()
        {
            try
            {
                return new DA.Planilla().ListarSueldos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista la asistencia que es parte del bono nocturno de la planilla
        /// </summary>
        /// <param name="idPlanilla">ID de la planilla</param>
        /// <param name="codigoEmpleado">Codigo del Empleado</param>
        /// <returns></returns>
        public List<BE.UI.PlanillaAsistencia> ListarAsistenciaHorarioNocturno(int idPlanilla, 
                                                                           string codigoEmpleado)
        {
            try
            {
                var lstDetalleHorarioNocturno = new List<BE.UI.PlanillaAsistencia>();

                var lstBePlanillaAsistencias = new DA.Planilla().ListarPlanillaAsistencia(idPlanilla);

                lstBePlanillaAsistencias = lstBePlanillaAsistencias.Where(x => x.CodigoEmpleado == codigoEmpleado && 
                                           (x.MinutosAsistenciaNormalNocturna > 0 || x.MinutosAsistenciaFeriadoNocturna > 0)
                                           ).ToList();

                foreach (BE.PlanillaAsistencia bePlanillaAsistencia in lstBePlanillaAsistencias)
                {
                    var uiPlanillaAsistencia = this.PlanillaAsistenciaBeToUi(bePlanillaAsistencia);
                    lstDetalleHorarioNocturno.Add(uiPlanillaAsistencia);
                }

                return lstDetalleHorarioNocturno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista la asistencia que es parte del bono de horas extras de la planilla
        /// </summary>
        /// <param name="idPlanilla">ID de la planilla</param>
        /// <param name="codigoEmpleado">Codigo del Empleado</param>
        /// <returns></returns>
        public List<BE.UI.PlanillaAsistencia> ListarAsistenciaHorasExtras(int idPlanilla,
                                                                       string codigoEmpleado)
        {
            try
            {
                var lstDetalleHorasExtras = new List<BE.UI.PlanillaAsistencia>();

                var lstBePlanillaAsistencias = new DA.Planilla().ListarPlanillaAsistencia(idPlanilla);

                lstBePlanillaAsistencias = lstBePlanillaAsistencias.Where(x => x.CodigoEmpleado == codigoEmpleado && 
                                        (x.MinutosAsistenciaNormalDiurnaExtra1 > 0
                                        || x.MinutosAsistenciaNormalDiurnaExtra2 > 0
                                        || x.MinutosAsistenciaNormalNocturnaExtra1 > 0
                                        || x.MinutosAsistenciaNormalNocturnaExtra2 > 0
                                        || x.MinutosAsistenciaFeriadoDiurnaExtra1 > 0
                                        || x.MinutosAsistenciaFeriadoDiurnaExtra2 > 0
                                        || x.MinutosAsistenciaFeriadoNocturnaExtra1 > 0
                                        || x.MinutosAsistenciaFeriadoNocturnaExtra2 > 0)
                                        ).ToList();

                foreach (BE.PlanillaAsistencia bePlanillaAsistencia in lstBePlanillaAsistencias)
                {
                    var uiPlanillaAsistencia = this.PlanillaAsistenciaBeToUi(bePlanillaAsistencia);
                    lstDetalleHorasExtras.Add(uiPlanillaAsistencia);
                }

                return lstDetalleHorasExtras;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista la asistencia que es parte del bono Feriado de la planilla
        /// </summary>
        /// <param name="idPlanilla">ID de la planilla</param>
        /// <param name="codigoEmpleado">Codigo del Empleado</param>
        /// <returns></returns>
        public List<BE.UI.PlanillaAsistencia> ListarAsistenciaFeriado(int idPlanilla,
                                                                   string codigoEmpleado)
        {
            try
            {
                var lstDetalleHorarioNocturno = new List<BE.UI.PlanillaAsistencia>();

                var lstBePlanillaAsistencias = new DA.Planilla().ListarPlanillaAsistencia(idPlanilla);

                lstBePlanillaAsistencias = lstBePlanillaAsistencias.Where(x => x.CodigoEmpleado == codigoEmpleado &&
                                            (x.MinutosAsistenciaFeriadoDiurna > 0 || x.MinutosAsistenciaFeriadoNocturna > 0)
                                            ).ToList();

                foreach (BE.PlanillaAsistencia bePlanillaAsistencia in lstBePlanillaAsistencias)
                {
                    var uiPlanillaAsistencia = this.PlanillaAsistenciaBeToUi(bePlanillaAsistencia);
                    lstDetalleHorarioNocturno.Add(uiPlanillaAsistencia);
                }

                return lstDetalleHorarioNocturno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista la asistencia que es parte del descuento por tardanzas de la planilla
        /// </summary>
        /// <param name="idPlanilla">ID de la planilla</param>
        /// <param name="codigoEmpleado">Codigo del Empleado</param>
        /// <returns></returns>
        public List<BE.UI.PlanillaAsistencia> ListarAsistenciaTardanzas(int idPlanilla,
                                                                     string codigoEmpleado)
        {
            try
            {
                var lstDetalleTardanzas = new List<BE.UI.PlanillaAsistencia>();

                var lstBePlanillaAsistencias = new DA.Planilla().ListarPlanillaAsistencia(idPlanilla);

                lstBePlanillaAsistencias = lstBePlanillaAsistencias.Where(x => 
                                            x.CodigoEmpleado == codigoEmpleado &&
                                            x.MinutosTardanzaTotal > 0
                                            ).ToList();

                foreach (BE.PlanillaAsistencia bePlanillaAsistencia in lstBePlanillaAsistencias)
                {
                    var uiPlanillaAsistencia = this.PlanillaAsistenciaBeToUi(bePlanillaAsistencia);
                    lstDetalleTardanzas.Add(uiPlanillaAsistencia);
                }

                return lstDetalleTardanzas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista la asistencia que es parte del descuento por inasistencia de la planilla
        /// </summary>
        /// <param name="idPlanilla">ID de la planilla</param>
        /// <param name="codigoEmpleado">Codigo del Empleado</param>
        /// <returns></returns>
        public List<BE.UI.PlanillaAsistencia> ListarAsistenciaFaltas(int idPlanilla,
                                                                 string codigoEmpleado)
        {
            try
            {
                var lstDetalleFaltas = new List<BE.UI.PlanillaAsistencia>();

                var lstBePlanillaAsistencias = new DA.Planilla().ListarPlanillaAsistencia(idPlanilla);

                lstBePlanillaAsistencias = lstBePlanillaAsistencias.Where(x =>
                                            x.CodigoEmpleado == codigoEmpleado &&
                                            x.MinutosInasistenciaTotal > 0
                                            ).ToList();

                foreach (BE.PlanillaAsistencia bePlanillaAsistencia in lstBePlanillaAsistencias)
                {
                    var uiPlanillaAsistencia = this.PlanillaAsistenciaBeToUi(bePlanillaAsistencia);
                    lstDetalleFaltas.Add(uiPlanillaAsistencia);
                }

                return lstDetalleFaltas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista la asistencia de la planilla
        /// </summary>
        /// <param name="idPlanilla">ID de la planilla</param>
        /// <param name="codigoEmpleado">Codigo del Empleado</param>
        /// <returns></returns>
        public List<BE.UI.PlanillaAsistencia> ListarAsistencia(int idPlanilla,
                                                             string codigoEmpleado)
        {
            try
            {
                var lstAsistencia = new List<BE.UI.PlanillaAsistencia>();

                var lstBePlanillaAsistencias = new DA.Planilla().ListarPlanillaAsistencia(idPlanilla);

                lstBePlanillaAsistencias = lstBePlanillaAsistencias.Where(x => x.CodigoEmpleado == codigoEmpleado).ToList();

                foreach (BE.PlanillaAsistencia bePlanillaAsistencia in lstBePlanillaAsistencias)
                {
                    var uiPlanillaAsistencia = this.PlanillaAsistenciaBeToUi(bePlanillaAsistencia);
                    lstAsistencia.Add(uiPlanillaAsistencia);
                }

                return lstAsistencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.PlanillaDetalle ObtenerPlantillaDetalle(string codigoEmpleado)
        {
            try
            {
                BE.UI.PlanillaDetalle uiPlanillaDetalle = null;

                var lstPlantillaDetalle = ListarPlantillaDetalle();
                uiPlanillaDetalle = lstPlantillaDetalle.Where(x => x.EmpleadoCodigo == codigoEmpleado).FirstOrDefault();

                return uiPlanillaDetalle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.PlanillaDetalle> ListarPlantillaDetalle()
        {
            try
            {
                var lstUiPlantillaDetalle = new List<BE.UI.PlanillaDetalle>();

                var daPlanilla = new DA.Planilla();

                var bePlanilla = daPlanilla.Obtener(this.anho, this.mes);
                if (bePlanilla != null)
                {
                    int idPlanilla = bePlanilla.ID;
                    var lstBePlanillaDetalle = new DA.Planilla().Detalle(idPlanilla);

                    foreach (BE.PlanillaDetalle beDetalle in lstBePlanillaDetalle)
                    {
                        var uiPlanillaDetalle = new BE.UI.PlanillaDetalle();

                        uiPlanillaDetalle.Periodo = this.anho.ToString() + "/" + this.mes.ToString();

                        uiPlanillaDetalle.EmpleadoCodigo = beDetalle.CodigoEmpleado;
                        uiPlanillaDetalle.EmpleadoNombre = new DA.ClsDaTbEmpleado().ObtenerNombreCompleto(beDetalle.CodigoEmpleado);

                        var beCargo = new DA.Cargo().Obtener(beDetalle.IdCargo);
                        if (beCargo != null)
                        {
                            uiPlanillaDetalle.CargoID = beDetalle.IdCargo;
                            uiPlanillaDetalle.CargoNombre = beCargo.Nombre;
                        }

                        uiPlanillaDetalle.Base = beDetalle.SueldoBase;
                        uiPlanillaDetalle.AsignacionFamiliar = beDetalle.AsignacionFamiliar;

                        uiPlanillaDetalle.CalcularPor = "M";

                        uiPlanillaDetalle.BonoNocturnoCantidad = beDetalle.CantidadMinutosBonoNocturno;
                        uiPlanillaDetalle.BonoNocturnoTotal = beDetalle.TotalMinutoBonoNocturno;
                        uiPlanillaDetalle.BonoHorasExtrasCantidad = beDetalle.CantidadMinutosBonoHorasExtras;
                        uiPlanillaDetalle.BonoHorasExtrasTotal = beDetalle.TotalMinutoBonoHorasExtras;
                        uiPlanillaDetalle.BonoFeriadoCantidad = beDetalle.CantidadMinutosBonoFeriado;
                        uiPlanillaDetalle.BonoFeriadoTotal = beDetalle.TotalMinutoBonoFeriado;

                        uiPlanillaDetalle.DescuentoTardanzaCantidad = beDetalle.CantidadMinutosDescuentoTardanza;
                        uiPlanillaDetalle.DescuentoTardanzaTotal = beDetalle.TotalMinutoDescuentoTardanza;
                        uiPlanillaDetalle.DescuentoInasistenciaCantidad = beDetalle.CantidadMinutosDescuentoInasistencia;
                        uiPlanillaDetalle.DescuentoInasistenciaTotal = beDetalle.TotalDescuentoInasistencia;

                        uiPlanillaDetalle.SnpNombre = "ONP";
                        uiPlanillaDetalle.SnpTotal = beDetalle.SnpTotal;

                        if (beDetalle.Afp != null && beDetalle.Afp.IdAfp > 0)
                        {
                            var beAfp = new BE.Afp() { IdAfp = beDetalle.Afp.IdAfp };
                            if (new DA.Afp().Obtener(ref beAfp))
                            {
                                uiPlanillaDetalle.AfpID = beAfp.IdAfp;
                                uiPlanillaDetalle.AfpNombre = beAfp.Nombre;
                            }
                        }

                        uiPlanillaDetalle.AfpTipo = beDetalle.AfpTipo;
                        uiPlanillaDetalle.AfpAporteObligatorio = beDetalle.AfpAporteObligatorio;
                        uiPlanillaDetalle.AfpAporteVoluntario = beDetalle.AfpAporteVoluntario;
                        uiPlanillaDetalle.AfpSeguro = beDetalle.AfpSeguro;
                        uiPlanillaDetalle.AfpComision = beDetalle.AfpComision;
                        uiPlanillaDetalle.AfpTotal = beDetalle.AfpTotal;

                        uiPlanillaDetalle.ImpuestoTotal = beDetalle.ImpuestoTotal;
                        uiPlanillaDetalle.RetencionJudicialTotal = beDetalle.RetencionJudicialTotal;
                        uiPlanillaDetalle.AdelantoTotal = beDetalle.AdelantoTotal;
                        uiPlanillaDetalle.PrestamoTotal = beDetalle.PrestamoTotal;
                        uiPlanillaDetalle.GratificacionTotal = 0.0;
                        uiPlanillaDetalle.EsSaludTotal = beDetalle.EsSaludTotal;

                        uiPlanillaDetalle.TotalBase = beDetalle.TotalSueldoBase;
                        uiPlanillaDetalle.TotalBruto = beDetalle.TotalSueldoBruto;
                        uiPlanillaDetalle.TotalNeto = beDetalle.TotalSueldoNeto;
                        uiPlanillaDetalle.TotalPagar = beDetalle.TotaPago;

                        lstUiPlantillaDetalle.Add(uiPlanillaDetalle);
                    }
                }
                bePlanilla = null;

                return lstUiPlantillaDetalle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Resumen(out int cantidadEmpleados,
                            out double totalSueldos,
                            out double totalPagos,
                            out double totalEssalud,
                            out double totalSnp,
                            out double totalAfp)
        {
            int cntEmpleados = 0;
            double ttlSueldos = 0.0;
            double ttlPagos = 0.0;
            double ttlEssalud = 0.0;
            double ttlSnp = 0.0;
            double ttlAfp = 0.0;

            try
            {
                DataTable dt = new DA.Planilla().Resumen(this.anho, this.mes);
                if (dt != null)
                {
                    if (dt.Rows.Count == 1)
                    {
                        cntEmpleados = int.Parse(dt.Rows[0]["CantidadEmpleados"].ToString());
                        ttlSueldos = double.Parse(dt.Rows[0]["TotalSueldos"].ToString());
                        ttlPagos = double.Parse(dt.Rows[0]["TotalPagos"].ToString());
                        ttlEssalud = double.Parse(dt.Rows[0]["TotalEsSalud"].ToString());
                        ttlSnp = double.Parse(dt.Rows[0]["TotalSNP"].ToString());
                        ttlAfp = double.Parse(dt.Rows[0]["TotalAFP"].ToString());
                    }
                }

                cantidadEmpleados = cntEmpleados;
                totalSueldos = ttlSueldos;
                totalPagos = ttlPagos;
                totalEssalud = ttlEssalud;
                totalSnp = ttlSnp;
                totalAfp = ttlAfp;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un resumen de las asistencias, inasistencias y tardanzas del empleado
        /// </summary>
        /// <param name="codigoEmpleado">Codigo del Empleado o Candidato</param>
        /// <returns></returns>
        public BE.UI.PlanillaAsistenciaResumenEmpleado ObtenerResumenAsistenciaEmpleado(string codigoEmpleado)
        {

            BE.UI.PlanillaAsistenciaResumenEmpleado uiResumenAsistencia = null;
            try
            {
                DataTable dtAsistencia = new DA.Planilla().ListarAsistenciaResumen(this.anho, this.mes, codigoEmpleado);

                foreach (DataRow drItem in dtAsistencia.Rows)
                {
                    uiResumenAsistencia = new BE.UI.PlanillaAsistenciaResumenEmpleado();

                    uiResumenAsistencia.IdPlanilla = int.Parse(drItem["IdPlanilla"].ToString());
                    uiResumenAsistencia.CodigoEmpleado = drItem["CodigoEmpleado"].ToString();
                    uiResumenAsistencia.CantidadAsistencias = int.Parse(drItem["CantidadAsistencias"].ToString());
                    uiResumenAsistencia.CantidadInasistencias = int.Parse(drItem["CantidadInasistencias"].ToString());
                    uiResumenAsistencia.CantidadTardanzas = int.Parse(drItem["CantidadTardanzas"].ToString());

                    break;
                }

                return uiResumenAsistencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.PlanillaAsistencia> ListarAsistencia()
        {
            List<BE.UI.PlanillaAsistencia> lstResultado = new List<BE.UI.PlanillaAsistencia>();

            try
            {

                var daPlanilla = new DA.Planilla();

                DataTable dtAsistencia = daPlanilla.ListarAsistencia(this.anho, this.mes);
                foreach (DataRow drItem in dtAsistencia.Rows)
                {

                    #region Obtener datos de asistencia

                    string codEmpleado = drItem["Codigo"].ToString();
                    DateTime fecha = DateTime.Parse(drItem["Fecha"].ToString());
                    int semana = int.Parse(drItem["Semana"].ToString());

                    DateTime fechaHoraNocturnoInicio = DateTime.Parse(drItem["FechaHoraNocheInicial"].ToString());
                    DateTime fechaHoraNocturnoFinal = DateTime.Parse(drItem["FechaHoraNocheFinal"].ToString());

                    //Fecha y Hora segun horario programado
                    DateTime fechaHoraHorarioInicio = DateTime.Parse(drItem["FechaHoraHorarioInicial"].ToString());
                    DateTime fechaHoraHorarioFinal = DateTime.Parse(drItem["FechaHoraHorarioFinal"].ToString());
                    int horasHorario = int.Parse(drItem["HorasHorario"].ToString());

                    //Fecha y Hora segun horario Asistencia
                    int horasAsistencia = int.Parse(drItem["HorasAsistencia"].ToString());
                    DateTime fechaHoraAsistenciaInicio = new DateTime(1900, 01, 01);
                    DateTime fechaHoraAsistenciaFinal = new DateTime(1900, 01, 01);
                    if (horasAsistencia > 0) //Si Asistio
                    {
                        fechaHoraAsistenciaInicio = DateTime.Parse(drItem["FechaHoraAsistenciaInicial"].ToString());
                        fechaHoraAsistenciaFinal = DateTime.Parse(drItem["FechaHoraAsistenciaFinal"].ToString());
                    }

                    #endregion

                    int minutosAsistenciaNormalesTotales = 0;
                    int minutosAsistenciaNormalesDiurnas = 0;
                    int minutosAsistenciaNormalesNocturnas = 0;
                    int minutosAsistenciaNormalesDiurnasPrimerasExtras = 0;
                    int minutosAsistenciaNormalesNocturnasPrimerasExtras = 0;
                    int minutosAsistenciaNormalesDiurnasPosterioresExtras = 0;
                    int minutosAsistenciaNormalesNocturnasPosterioresExtras = 0;

                    int minutosTardanzaNormalesTotales = 0;
                    int minutosTardanzaNormalesDiurnas = 0;
                    int minutosTardanzaNormalesNocturnas = 0;

                    int minutosAsistenciaFeriadosTotales = 0;
                    int minutosAsistenciaFeriadosDiurnas = 0;
                    int minutosAsistenciaFeriadosNocturnas = 0;
                    int minutosAsistenciaFeriadosDiurnasPrimerasExtras = 0;
                    int minutosAsistenciaFeriadosNocturnasPrimerasExtras = 0;
                    int minutosAsistenciaFeriadosDiurnasPosterioresExtras = 0;
                    int minutosAsistenciaFeriadosNocturnasPosterioresExtras = 0;

                    int minutosTardanzaFeriadosTotales = 0;
                    int minutosTardanzaFeriadosDiurnas = 0;
                    int minutosTardanzaFeriadosNocturnas = 0;

                    int minutosInasistenciasTotales = 0;

                    #region Calcular Horas Normales y Extras 

                    if (horasAsistencia > 0)
                    {
                        this.ObtenerMinutosAsistencia(fechaHoraNocturnoInicio,
                        fechaHoraNocturnoFinal,
                        fechaHoraHorarioInicio,
                        fechaHoraHorarioFinal,
                        out minutosAsistenciaNormalesDiurnas,
                        out minutosAsistenciaNormalesNocturnas,
                        out minutosAsistenciaNormalesDiurnasPrimerasExtras,
                        out minutosAsistenciaNormalesNocturnasPrimerasExtras,
                        out minutosAsistenciaNormalesDiurnasPosterioresExtras,
                        out minutosAsistenciaNormalesNocturnasPosterioresExtras,
                        out minutosAsistenciaFeriadosDiurnas,
                        out minutosAsistenciaFeriadosNocturnas,
                        out minutosAsistenciaFeriadosDiurnasPrimerasExtras,
                        out minutosAsistenciaFeriadosNocturnasPrimerasExtras,
                        out minutosAsistenciaFeriadosDiurnasPosterioresExtras,
                        out minutosAsistenciaFeriadosNocturnasPosterioresExtras);

                        minutosAsistenciaNormalesTotales = minutosAsistenciaNormalesDiurnas
                                                         + minutosAsistenciaNormalesNocturnas
                                                         + minutosAsistenciaNormalesDiurnasPrimerasExtras
                                                         + minutosAsistenciaNormalesNocturnasPrimerasExtras
                                                         + minutosAsistenciaNormalesDiurnasPosterioresExtras
                                                         + minutosAsistenciaNormalesNocturnasPosterioresExtras;

                        minutosAsistenciaFeriadosTotales = minutosAsistenciaFeriadosDiurnas
                                                         + minutosAsistenciaFeriadosNocturnas
                                                         + minutosAsistenciaFeriadosDiurnasPrimerasExtras
                                                         + minutosAsistenciaFeriadosNocturnasPrimerasExtras
                                                         + minutosAsistenciaFeriadosDiurnasPosterioresExtras
                                                         + minutosAsistenciaFeriadosNocturnasPosterioresExtras;

                        #region Calcular Minutos de Tardanza

                        this.ObtenerMinutosTardanza(fechaHoraNocturnoInicio,
                            fechaHoraNocturnoFinal,
                            fechaHoraHorarioInicio,
                            fechaHoraAsistenciaInicio,
                            out minutosTardanzaNormalesDiurnas,
                            out minutosTardanzaNormalesNocturnas,
                            out minutosTardanzaFeriadosDiurnas,
                            out minutosTardanzaFeriadosNocturnas);

                        minutosTardanzaNormalesTotales = minutosTardanzaNormalesDiurnas
                                                       + minutosTardanzaNormalesNocturnas;

                        minutosTardanzaFeriadosTotales = minutosTardanzaFeriadosDiurnas
                                                       + minutosTardanzaFeriadosNocturnas;

                    }
                    else
                    {
                        minutosInasistenciasTotales = horasHorario * 60;
                    }
                    #endregion

                    #endregion

                    var objRegistro = new BE.UI.PlanillaAsistencia();
                    objRegistro.CodigoEmpleado = codEmpleado;
                    objRegistro.Fecha = fecha;
                    objRegistro.Semana = semana;

                    objRegistro.FechaHoraInicio = fechaHoraHorarioInicio;
                    objRegistro.FechaHoraFinal = fechaHoraHorarioFinal;

                    //Asistencia Normales
                    objRegistro.AsistenciaNormalTotal = minutosAsistenciaNormalesTotales;
                    objRegistro.AsistenciaNormalDiurna = minutosAsistenciaNormalesDiurnas;
                    objRegistro.AsistenciaNormalNocturna = minutosAsistenciaNormalesNocturnas;
                    objRegistro.AsistenciaNormalDiurnaExtra1 = minutosAsistenciaNormalesDiurnasPrimerasExtras;
                    objRegistro.AsistenciaNormalNocturnaExtra1 = minutosAsistenciaNormalesNocturnasPrimerasExtras;
                    objRegistro.AsistenciaNormalDiurnaExtra2 = minutosAsistenciaNormalesDiurnasPosterioresExtras;
                    objRegistro.AsistenciaNormalNocturnaExtra2 = minutosAsistenciaNormalesNocturnasPosterioresExtras;

                    //Tardanza Normales
                    objRegistro.TardanzaNormalTotal = minutosTardanzaNormalesTotales;
                    objRegistro.TardanzaNormalDiurna = minutosTardanzaNormalesDiurnas;
                    objRegistro.TardanzaNormalNocturna = minutosTardanzaNormalesNocturnas;

                    //Asistencia Feriados
                    objRegistro.AsistenciaFeriadoTotal = minutosAsistenciaFeriadosTotales;
                    objRegistro.AsistenciaFeriadoDiurna = minutosAsistenciaFeriadosDiurnas;
                    objRegistro.AsistenciaFeriadoNocturna = minutosAsistenciaFeriadosNocturnas;
                    objRegistro.AsistenciaFeriadoDiurnaExtra1 = minutosAsistenciaFeriadosDiurnasPrimerasExtras;
                    objRegistro.AsistenciaFeriadoNocturnaExtra1 = minutosAsistenciaFeriadosNocturnasPrimerasExtras;
                    objRegistro.AsistenciaFeriadoDiurnaExtra2 = minutosAsistenciaFeriadosDiurnasPosterioresExtras;
                    objRegistro.AsistenciaFeriadoNocturnaExtra2 = minutosAsistenciaFeriadosNocturnasPosterioresExtras;

                    //Tardanza Feriado
                    objRegistro.TardanzaFeriadoTotal = minutosTardanzaFeriadosTotales;
                    objRegistro.TardanzaFeriadoDiurna = minutosTardanzaFeriadosDiurnas;
                    objRegistro.TardanzaFeriadoNocturna = minutosTardanzaFeriadosNocturnas;

                    //Tardanza Inasistencias
                    objRegistro.InasistenciaTotal = minutosInasistenciasTotales;

                    lstResultado.Add(objRegistro);
                }

                return lstResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Obtiene los minutos de asistencia por separado por 
        ///Diurno, Nocturno, Extra25% y Extra35%
        ///Asimismo, separados por fecha normal y feriado
        ///</summary>
        private void ObtenerMinutosAsistencia2(DateTime fechaHoraNocturnoInicio,
                                            DateTime fechaHoraNocturnoFinal,
                                            DateTime fechaHoraAsistenciaInicio,
                                            DateTime fechaHoraAsistenciaFinal,
                                            out int minutosNormalDiurna,
                                            out int minutosNormalNocturna,
                                            out int minutosNormalDiurnaExtra1,
                                            out int minutosNormalNocturnaExtra1,
                                            out int minutosNormalDiurnaExtra2,
                                            out int minutosNormalNocturnaExtra2,
                                            out int minutosFeriadoDiurna,
                                            out int minutosFeriadoNocturna,
                                            out int minutosFeriadoDiurnaExtra1,
                                            out int minutosFeriadoNocturnaExtra1,
                                            out int minutosFeriadoDiurnaExtra2,
                                            out int minutosFeriadoNocturnaExtra2)
        {

            int minutosColchon = 15; //Minutos de colchon
            int minutosLaborales = 480; //Minutos laborales de 8 horas
            int minutosExtras1 = 120; //Minutos de las primeras 2 horas extras

            try
            {

                int minutosTotales = fechaHoraAsistenciaFinal.Subtract(fechaHoraAsistenciaInicio).Minutes;
                minutosTotales -= minutosColchon;

                int minutosNormalDiurnos = 0;
                int minutosNormalDiurnosExtra1 = 0;
                int minutosNormalDiurnosExtra2 = 0;
                int minutosNormalNocturnos = 0;
                int minutosNormalNocturnosExtra1 = 0;
                int minutosNormalNocturnosExtra2 = 0;

                int minutosFeriadoDiurnos = 0;
                int minutosFeriadoDiurnosExtra1 = 0;
                int minutosFeriadoDiurnosExtra2 = 0;
                int minutosFeriadoNocturnos = 0;
                int minutosFeriadoNocturnosExtra1 = 0;
                int minutosFeriadoNocturnosExtra2 = 0;

                if (minutosTotales <= minutosLaborales) //Sin horas extras
                {
                    minutosNormalNocturnos = this.ObtenerMinutosNocturno(fechaHoraAsistenciaInicio, fechaHoraAsistenciaFinal, fechaHoraNocturnoInicio, fechaHoraNocturnoFinal);
                    minutosNormalDiurnos = minutosTotales - minutosNormalNocturnos;
                }
                else
                {

                    //Obtener minutos normales de asistencia (Horario de 8 horas)
                    DateTime fechaHoraFinalNormal = fechaHoraAsistenciaInicio.AddMinutes(minutosLaborales + minutosColchon);

                    minutosNormalNocturnos = this.ObtenerMinutosNocturno(fechaHoraAsistenciaInicio, fechaHoraFinalNormal, fechaHoraNocturnoInicio, fechaHoraNocturnoFinal);
                    minutosNormalDiurnos = minutosLaborales - minutosNormalNocturnos;

                    int minutosExtras = fechaHoraAsistenciaFinal.Subtract(fechaHoraFinalNormal).Minutes;

                    if (minutosExtras < minutosExtras1) //<2Horas
                    {
                        minutosNormalNocturnosExtra1 = this.ObtenerMinutosNocturno(fechaHoraFinalNormal, fechaHoraAsistenciaFinal, fechaHoraNocturnoInicio, fechaHoraNocturnoFinal);
                        minutosNormalDiurnosExtra1 = minutosExtras - minutosNormalNocturnosExtra1;

                    }
                    else //>2Horas
                    {
                        DateTime fechaHoraFinalNormal2 = fechaHoraFinalNormal.AddMinutes((double)minutosExtras1);

                        minutosNormalNocturnosExtra1 = this.ObtenerMinutosNocturno(fechaHoraFinalNormal, fechaHoraFinalNormal2, fechaHoraNocturnoInicio, fechaHoraNocturnoFinal);
                        minutosNormalDiurnosExtra1 = minutosExtras1 - minutosNormalNocturnosExtra1;

                        minutosNormalNocturnosExtra2 = this.ObtenerMinutosNocturno(fechaHoraFinalNormal2, fechaHoraAsistenciaFinal, fechaHoraNocturnoInicio, fechaHoraNocturnoFinal);
                        minutosNormalDiurnosExtra2 = minutosExtras - minutosExtras1 - minutosNormalNocturnosExtra2;
                    }
                }

                minutosNormalDiurna = minutosNormalDiurnos;
                minutosNormalNocturna = minutosNormalNocturnos;
                minutosNormalDiurnaExtra1 = minutosNormalDiurnosExtra1;
                minutosNormalNocturnaExtra1 = minutosNormalNocturnosExtra1;
                minutosNormalDiurnaExtra2 = minutosNormalDiurnosExtra2;
                minutosNormalNocturnaExtra2 = minutosNormalNocturnosExtra2;

                minutosFeriadoDiurna = minutosFeriadoDiurnos;
                minutosFeriadoNocturna = minutosFeriadoNocturnos;
                minutosFeriadoDiurnaExtra1 = minutosFeriadoDiurnosExtra1;
                minutosFeriadoNocturnaExtra1 = minutosFeriadoNocturnosExtra1;
                minutosFeriadoDiurnaExtra2 = minutosFeriadoDiurnosExtra2;
                minutosFeriadoNocturnaExtra2 = minutosFeriadoNocturnosExtra2;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Obtiene los minutos de asistencia por separado por 
        ///Diurno, Nocturno, Extra25% y Extra35%
        ///Asimismo, separados por fecha normal y feriado
        ///</summary>
        private void ObtenerMinutosAsistencia(DateTime fechaHoraNocturnoInicio,
                                            DateTime fechaHoraNocturnoFinal,
                                            DateTime fechaHoraInicio,
                                            DateTime fechaHoraFinal,
                                            out int minutosNormalDiurna,
                                            out int minutosNormalNocturna,
                                            out int minutosNormalDiurnaExtra1,
                                            out int minutosNormalNocturnaExtra1,
                                            out int minutosNormalDiurnaExtra2,
                                            out int minutosNormalNocturnaExtra2,
                                            out int minutosFeriadoDiurna,
                                            out int minutosFeriadoNocturna,
                                            out int minutosFeriadoDiurnaExtra1,
                                            out int minutosFeriadoNocturnaExtra1,
                                            out int minutosFeriadoDiurnaExtra2,
                                            out int minutosFeriadoNocturnaExtra2)
        {

            try
            {
                int minutosLaborales = 480; // 8 horas 
                int minutosComodin = 15;
                int minutosExtras1 = 120; // 2 horas

                int minNorDia = 0;
                int minNorDiaEx1 = 0;
                int minNorDiaEx2 = 0;

                int minNorNoc = 0;
                int minNorNocEx1 = 0;
                int minNorNocEx2 = 0;

                int minFerDia = 0;
                int minFerDiaEx1 = 0;
                int minFerDiaEx2 = 0;

                int minFerNoc = 0;
                int minFerNocEx1 = 0;
                int minFerNocEx2 = 0;

                int minutosTotales = (int)fechaHoraFinal.Subtract(fechaHoraInicio).TotalMinutes;
                DateTime fechaHoraActual = fechaHoraInicio;
                DateTime fechaHoraTermino = fechaHoraFinal;
                int numMinutos = 1;

                while (fechaHoraActual < fechaHoraTermino)
                {

                    bool esFeriado = this.EsFeriado(fechaHoraActual);

                    bool horarioNocturno = false;
                    if (fechaHoraNocturnoInicio <= fechaHoraActual &&
                        fechaHoraNocturnoFinal > fechaHoraActual)
                        horarioNocturno = true;
                    else
                        horarioNocturno = false;

                    if (esFeriado == false) //Asistencia Normal
                    {

                        if (numMinutos > minutosLaborales + minutosComodin) //Extras
                        {
                            if (numMinutos > (minutosLaborales + minutosComodin + minutosExtras1))
                            {
                                if (horarioNocturno == true)
                                    minNorNocEx2++;
                                else
                                    minNorDiaEx2++;
                            }
                            else
                            {
                                if (horarioNocturno == true)
                                    minNorNocEx1++;
                                else
                                    minNorDiaEx1++;
                            }
                        }
                        else if (numMinutos <= minutosLaborales)
                        {
                            if (horarioNocturno == true)
                                minNorNoc++;
                            else
                                minNorDia++;
                        }
                    }
                    else //Asistencia Feriado
                    {

                        if (numMinutos > minutosLaborales + minutosComodin)
                        {
                            if (numMinutos > (minutosLaborales + minutosComodin + minutosExtras1))
                            {
                                if (horarioNocturno == true)
                                    minFerNocEx2++;
                                else
                                    minFerDiaEx2++;
                            }
                            else
                            {
                                if (horarioNocturno == true)
                                    minFerNocEx1++;
                                else
                                    minFerDiaEx1++;
                            }
                        }
                        else if (numMinutos <= minutosLaborales)
                        {
                            if (horarioNocturno == true)
                                minFerNoc++;
                            else
                                minFerDia++;
                        }
                    }

                    fechaHoraActual = fechaHoraInicio.AddMinutes(numMinutos);
                    numMinutos++;
                }

                minutosNormalDiurna = minNorDia;
                minutosNormalDiurnaExtra1 = minNorDiaEx1;
                minutosNormalDiurnaExtra2 = minNorDiaEx2;

                minutosNormalNocturna = minNorNoc;
                minutosNormalNocturnaExtra1 = minNorNocEx1;
                minutosNormalNocturnaExtra2 = minNorNocEx2;

                minutosFeriadoDiurna = minFerDia;
                minutosFeriadoDiurnaExtra1 = minFerDiaEx1;
                minutosFeriadoDiurnaExtra2 = minFerDiaEx2;

                minutosFeriadoNocturna = minFerNoc;
                minutosFeriadoNocturnaExtra1 = minFerNocEx1;
                minutosFeriadoNocturnaExtra2 = minFerNocEx2;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private int ObtenerMinutosNocturno(DateTime fechaHoraInicio,
                                            DateTime fechaHoraFinal,
                                            DateTime fechaHoraNocturnoInicio,
                                            DateTime fechaHoraNocturnoFinal)
        {
            try
            {
                int minutos = 0;

                var range1 = new { start = fechaHoraInicio, end = fechaHoraFinal };
                var range2 = new { start = fechaHoraNocturnoInicio, end = fechaHoraNocturnoFinal };
                var iStart = range1.start < range2.start ? range2.start : range1.start;
                var iEnd = range1.end < range2.end ? range1.end : range2.end;
                var newRange = iStart < iEnd ? new { start = iStart, end = iEnd } : null;

                if (newRange != null)
                {
                    TimeSpan TiempoTardanza = newRange.end.Subtract(newRange.start);
                    minutos = (int)TiempoTardanza.TotalMinutes;
                }

                return minutos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ObtenerMinutosTardanza(DateTime fechaHoraNocturnoInicio,
                                            DateTime fechaHoraNocturnoFinal,
                                            DateTime fechaHoraHorarioInicio,
                                            DateTime fechaHoraAsistenciaInicio,
                                            out int minutosTardanzaNormalDiurnas,
                                            out int minutosTardanzaNormalNocturnas,
                                            out int minutosTardanzaFeriadoDiurnas,
                                            out int minutosTardanzaFeriadoNocturnas)
        {

            try
            {
                int minutosNormalDiurnas = 0;
                int minutosNormalNocturas = 0;
                int minutosFeriadoDiurnas = 0;
                int minutosFeriadoNocturas = 0;

                bool esFeriado = this.EsFeriado(fechaHoraHorarioInicio);

                TimeSpan TiempoTardanza = fechaHoraAsistenciaInicio.Subtract(fechaHoraHorarioInicio);

                if (fechaHoraNocturnoInicio <= fechaHoraHorarioInicio &&
                        fechaHoraNocturnoFinal > fechaHoraHorarioInicio)
                {
                    if (esFeriado)
                        minutosFeriadoNocturas = TiempoTardanza.Minutes;
                    else
                        minutosNormalNocturas = TiempoTardanza.Minutes;
                }
                else
                {
                    if (esFeriado)
                        minutosFeriadoDiurnas = TiempoTardanza.Minutes;
                    else
                        minutosNormalDiurnas = TiempoTardanza.Minutes;
                }

                minutosTardanzaNormalDiurnas = minutosNormalDiurnas > 0 ? minutosNormalDiurnas : 0;
                minutosTardanzaNormalNocturnas = minutosNormalNocturas > 0 ? minutosNormalNocturas : 0;
                minutosTardanzaFeriadoDiurnas = minutosFeriadoDiurnas > 0 ? minutosFeriadoDiurnas : 0;
                minutosTardanzaFeriadoNocturnas = minutosFeriadoNocturas > 0 ? minutosFeriadoNocturas : 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool EsFeriado(DateTime fecha)
        {
            bool rpta = false;
            try
            {

                int countRows = this.lstBeFeriados.Where(x => x.Fecha.ToString("yyyyMMdd").Equals(fecha.ToString("yyyyMMdd"))).Count();
                rpta = countRows > 0 ? true : false;

                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private string ObtenerDia(byte dia)
        {
            string nombreDia = "";

            switch (dia)
            {
                case 1:
                    nombreDia = "Lunes";
                    break;
                case 2:
                    nombreDia = "Martes";
                    break;
                case 3:
                    nombreDia = "Miercoles";
                    break;
                case 4:
                    nombreDia = "Jueves";
                    break;
                case 5:
                    nombreDia = "Viernes";
                    break;
                case 6:
                    nombreDia = "Sabado";
                    break;
                default:
                    nombreDia = "Domingo";
                    break;
            }

            return nombreDia;
        }
    }

}