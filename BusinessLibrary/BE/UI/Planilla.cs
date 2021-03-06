using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class PlanillaAsistenciaResumenSala
    {
        public int IdPlanilla { get; set; }
        public int IdSala { get; set; }
        public int CantidadAsistencias { get; set; }
        public int CantidadInasistencias { get; set; }
        public int CantidadTardanzas { get; set; }
    }

    public class PlanillaAsistenciaResumenEmpleado
    {
        public int IdPlanilla { get; set; }
        public string CodigoEmpleado { get; set; }
        public int CantidadAsistencias { get; set; }
        public int CantidadInasistencias
        {
            get
            {
                return CantidadInasistenciasNormales + CantidadInasistenciasFeriados;
            }
        }
        public int CantidadInasistenciasNormales { get; set; }
        public int CantidadInasistenciasFeriados { get; set; }
        public int CantidadTardanzas { get; set; }
    }

    /// <summary>
    /// Calculo de Asistencia de Empleados para Planilla
    /// </summary>
    public class PlanillaAsistencia: AsistenciaCalculo
    {
    }

    public class PlanillaCosto : CostoCalculo
    {
    }

    public class PlanillaDetalle
    {

        public string Periodo { get; set; }

        public string EmpleadoCodigo { get; set; }
        public string EmpleadoNombre { get; set; }
        public int CargoID { get; set; }
        public string CargoNombre { get; set; }

        #region Sueldo
        public double Base { get; set; }
        public double AsignacionFamiliar { get; set; }
        #endregion

        public string CalcularPor { get; set; } //Horas - H | Minutos - M

        #region Bonos
        public int BonoNocturnoCantidad { get; set; }
        public string BonoNocturnoFormato { get { return AplicarFormato(BonoNocturnoCantidad); } }
        public double BonoNocturnoTotal { get; set; }

        public int BonoHorasExtrasCantidad { get; set; }
        public string BonoHorasExtrasFormato { get { return AplicarFormato(BonoHorasExtrasCantidad); } }
        public double BonoHorasExtrasTotal { get; set; }

        public int BonoFeriadoCantidad { get; set; }
        public string BonoFeriadoFormato { get { return AplicarFormato(BonoFeriadoCantidad); } }
        public double BonoFeriadoTotal { get; set; }
        #endregion

        #region Descuentos 
        public int DescuentoTardanzaCantidad { get; set; }
        public string DescuentoTardanzaFormato { get { return AplicarFormato(DescuentoTardanzaCantidad); } }
        public double DescuentoTardanzaTotal { get; set; }

        public int DescuentoInasistenciaCantidad { get; set; }
        public string DescuentoInasistenciaFormato { get { return AplicarFormato(DescuentoInasistenciaCantidad); } }
        public double DescuentoInasistenciaTotal { get; set; }
        #endregion

        #region Pension

        #region SNP
        public string SnpNombre { get; set; }
        public double SnpTotal { get; set; }
        #endregion

        #region AFP
        public int AfpID { get; set; }
        public string AfpNombre { get; set; }
        public string AfpTipo { get; set; }
        public double AfpAporteObligatorio { get; set; }
        public double AfpAporteVoluntario { get; set; }
        public double AfpSeguro { get; set; }
        public double AfpComision { get; set; }
        public double AfpTotal { get; set; }
        #endregion

        #endregion

        public double ImpuestoTotal { get; set; }
        public double RetencionJudicialTotal { get; set; }
        public double AdelantoTotal { get; set; }
        public double PrestamoTotal { get; set; }
        public double GratificacionTotal { get; set; }
        public double EsSaludTotal { get; set; }
        public double MovilidadTotal { get; set; }

        #region Totales
        public double TotalBase { get; set; }
        public double TotalBruto { get; set; }
        public double TotalNeto { get; set; }
        public double TotalPagar { get; set; }
        #endregion

        private string AplicarFormato(int valor)
        {
            string strValor = "";

            if (CalcularPor == "H") //Hora
            {
                var span = TimeSpan.FromMinutes(valor);
                strValor = string.Format("{0:00}:{1:00}", (int)span.TotalHours, span.Minutes);
            }
            else if (CalcularPor == "M") //Minuto
            {
                strValor = valor.ToString();
            }

            return strValor;
        }
    }

    public class PlanillaBoleta
    {
        public int Id { get; set; } = 0;

        public int IdPlanilla { get; set; } = 0;

        public int Anho { get; set; } = 0;
        public int Mes { get; set; } = 0;
        public string MesNombre { get; set; } = "";
        public int MesDias { get; set; } = 0;

        #region Empresa
        public string EmpresaNombre { get; set; } = "";
        public string EmpresaRuc { get; set; } = "";
        public string EmpresaDistrito { get; set; } = "";
        public string EmpresaDireccion { get; set; } = "";
        #endregion

        #region Empreado
        public string EmpleadoCodigo { get; set; } = "";
        public string EmpleadoNombres { get; set; } = "";
        public string EmpleadoApellidos { get; set; } = "";
        public string EmpleadoCargo { get; set; } = "";
        public string EmpleadoNroDocumento { get; set; } = "";
        public DateTime EmpleadoFechaIngreso { get; set; } = DateTime.Now;
        public DateTime? EmpleadoFechaCese { get; set; } = null;
        public DateTime? EmpleadoVacacionSalida { get; set; } = null;
        public DateTime? EmpleadoVacacionRetorno { get; set; } = null;
        public string EmpleadoEsSaludCodigo { get; set; } = "";
        public string EmpleadoSppCodigo { get; set; } = "";
        public string EmpleadoSppEntidad { get; set; } = "";
        #endregion

        public int DiasLaborados { get; set; } = 0;
        public int DiasNoLaborados { get; set; } = 0;
        public int DiasSinGoceHaber { get; set; } = 0;
        public int DiasSubsidiado { get; set; } = 0;
        public int HorasNormales { get; set; } = 0;

        #region Sueldo
        public double Sueldo { get; set; } = 0.0;
        public double AsignacionFamiliar { get; set; } = 0.0;
        public double BonificacionNocturna { get; set; } = 0.0;
        public double MovilidadTranslado { get; set; } = 0.0;
        public double SubsidioDescansoMedico { get; set; } = 0.0;
        public double BonificacionHorasExtras { get; set; } = 0.0;
        public int CantidadHorasExtras { get; set; } = 0;
        public double Cts { get; set; } = 0.0;
        public double Vacaciones { get; set; } = 0.0;
        public double FeriadoDominical { get; set; } = 0.0;
        public double Gratificacion { get; set; } = 0.0;
        public double BonificacionGratificacion { get; set; } = 0.0;

        #endregion

        #region Descuentos del Empleado
        public double AfpFondoMonto { get; set; } = 0.0;
        public double AfpSeguroMonto { get; set; } = 0.0;
        public double AfpComisionMonto { get; set; } = 0.0;
        public double IpssVidaMonto { get; set; } = 0.0;
        public double OnpMonto { get; set; } = 0.0;
        public double RentaQuintaMonto { get; set; } = 0.0;
        public int InasistenciasDias { get; set; } = 0;
        public double InasistenciasMonto { get; set; } = 0.0;
        public double AdelantoMonto { get; set; } = 0.0;
        public int TardanzaMinutos { get; set; } = 0;
        public double TardanzaMonto { get; set; } = 0.0;
        public double GratificacionMonto { get; set; } = 0.0;
        public double RetencionJudicialMonto { get; set; } = 0.0;
        public double SeguroVidaTrabajadorMonto { get; set; } = 0.0;
        public double IpssSaludTrabajadorMonto { get; set; } = 0.0;
        #endregion

        #region Aportes del Empleador
        public double SeguroVidaEmpleadoMonto { get; set; } = 0.0;
        public double IpssSaludEmpleadoMonto { get; set; } = 0.0;
        #endregion

        public double TotalBruto
        {
            get
            {
                double sueldo = 0.0;

                sueldo += Sueldo + AsignacionFamiliar;
                sueldo += BonificacionNocturna + BonificacionHorasExtras;
                sueldo += MovilidadTranslado + SubsidioDescansoMedico;
                sueldo += Cts + Vacaciones;
                sueldo += FeriadoDominical + Gratificacion + BonificacionGratificacion;

                return sueldo;
            }
        }
        public double TotalDescuentos
        {
            get
            {
                double descuento = 0.0;

                descuento += AfpFondoMonto + AfpSeguroMonto + AfpComisionMonto;
                descuento += IpssVidaMonto + OnpMonto + RentaQuintaMonto;
                descuento += InasistenciasMonto + AdelantoMonto + TardanzaMonto;
                descuento += GratificacionMonto + RetencionJudicialMonto;
                descuento += SeguroVidaTrabajadorMonto + IpssSaludTrabajadorMonto;
                descuento += SeguroVidaTrabajadorMonto + IpssSaludTrabajadorMonto;

                return descuento;
            }
        }
      
        public double TotalAportes
        {
            get
            {
                double aporte = 0.0;

                aporte += SeguroVidaEmpleadoMonto + IpssSaludEmpleadoMonto;

                return aporte;
            }
        }
        public double TotalNeto
        {
            get
            {
                double total = 0.0;

                total = TotalBruto - TotalDescuentos;

                return total;
            }
        }

    }

}
