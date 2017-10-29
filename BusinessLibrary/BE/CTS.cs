using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class CTS
    {
        public int IdCts { get; set; }
        public int Anho { get; set; }
        public int Periodo { get; set; }
        public DateTime PeriodoFechaInicial { get; set; }
        public DateTime PeriodoFechaFinal { get; set; }
        public string EmpleadoCodigo { get; set; }
        public DateTime EmpleadoFechaIngreso { get; set; }
        public double EmpleadoSueldo { get; set; }
        public double EmpleadoAsigFam { get; set; }
        public double TotalBonificacion { get; set; }
        public double TotalHorasExtras { get; set; }
        public double TotalGratificacion { get; set; }
        public double PromedioBonificacion { get; set; }
        public double PromedioHorasExtras { get; set; }
        public double PromedioGratificacion { get; set; }
        public double ComputableTotal { get; set; }
        public DateTime ComputableFechaInicial { get; set; }
        public DateTime ComputableFechaFinal { get; set; }
        public int ComputableMeses { get; set; }
        public int ComputableDias { get; set; }
        public double ComputablePagar { get; set; }
        public Banco Banco { get; set; }
        public string Cuenta { get; set; }
        public DateTime DepositoFecha { get; set; }
        public double DepositoMonto { get; set; }
        public string DepositoOperacion { get; set; }

    }
}
