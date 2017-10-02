using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class PlanillaAsistencia: ICloneable 
    {

        public string CodigoEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public int Semana { get; set; }
        public string CalcularPor { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFinal { get; set; }
        public double AsistenciaNormalTotal { get; set; }
        public double AsistenciaNormalDiurna { get; set; }
        public double AsistenciaNormalNocturna { get; set; }
        public double AsistenciaNormalDiurnaExtra1 { get; set; }
        public double AsistenciaNormalNocturnaExtra1 { get; set; }
        public double AsistenciaNormalDiurnaExtra2 { get; set; }
        public double AsistenciaNormalNocturnaExtra2 { get; set; }
        public double TardanzaNormalTotal { get; set; }
        public double TardanzaNormalDiurna { get; set; }
        public double TardanzaNormalNocturna { get; set; }
        public double AsistenciaFeriadoTotal { get; set; }
        public double AsistenciaFeriadoDiurna { get; set; }
        public double AsistenciaFeriadoNocturna { get; set; }
        public double AsistenciaFeriadoDiurnaExtra1 { get; set; }
        public double AsistenciaFeriadoNocturnaExtra1 { get; set; }
        public double AsistenciaFeriadoDiurnaExtra2 { get; set; }
        public double AsistenciaFeriadoNocturnaExtra2 { get; set; }
        public double TardanzaFeriadoTotal { get; set; }
        public double TardanzaFeriadoDiurna { get; set; }
        public double TardanzaFeriadoNocturna { get; set; }
        public double InasistenciaTotal { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class PlanillaCosto : ICloneable
    {

        public string CodigoEmpleado { get; set; }

        #region Sueldo
        public double Sueldo { get; set; }
        public double AsignacionFamiliar { get; set; }
        #endregion

        public string CostosPor { get; set; }

        #region Costo Normal
        public double NormalDiurno { get; set; }
        public double NormalDiurnoExtra1 { get; set; }
        public double NormalDiurnoExtra2 { get; set; }
        public double NormalNocturno { get; set; }
        public double NormalNocturnoExtra1 { get; set; }
        public double NormalNocturnoExtra2 { get; set; }
        #endregion

        #region Costo Feriado
        public double FeriadoDiurno { get; set; }
        public double FeriadoDiurnoExtra1 { get; set; }
        public double FeriadoDiurnoExtra2 { get; set; }
        public double FeriadoNocturno { get; set; }
        public double FeriadoNocturnoExtra1 { get; set; }
        public double FeriadoNocturnoExtra2 { get; set; }
        #endregion

        #region Descuento Tardanza
        public double TardanzaNormalDiurno { get; set; }
        public double TardanzaNormalNocturno { get; set; }
        public double TardanzaFeriadoDiurno { get; set; }
        public double TardanzaFeriadoNocturno { get; set; }
        #endregion

        #region Descuento Inasistencia
        public double Dominical { get; set; }
        public double Inasistencia { get; set; }
        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }
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

        public string CalcularPor { get; set; }

        #region Bonos
        public double BonoNocturnoCantidad { get; set; }  
        public double BonoNocturnoTotal { get; set; }
        public double BonoHorasExtrasCantidad { get; set; }
        public double BonoHorasExtrasTotal { get; set; }
        public double BonoFeriadoCantidad { get; set; }
        public double BonoFeriadoTotal { get; set; }
        #endregion

        #region Descuentos 
        public double DescuentoTardanzaCantidad { get; set; }
        public double DescuentoTardanzaTotal { get; set; }
        public double DescuentoInasistenciaCantidad { get; set; }
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

        #region Totales
        public double TotalBase { get; set; }
        public double TotalBruto { get; set; }
        public double TotalNeto { get; set; }
        public double TotalPagar { get; set; }
        #endregion
    }
}
