using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Vacacion
    {
        public int IdVacacion { get; set; }

        public string CodigoEmpleado { get; set; }
        public DateTime PeriodoFechaInicial { get; set; }
        public DateTime PeriodoFechaFinal { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int Dias { get; set; }

        public double Sueldo { get; set; }
        public double AsignacionFamiliar { get; set; }
        public double PromedioHorasExtras { get; set; }
        public double PromedioBonificacion { get; set; }

        public AfpComision ComisionAfp { get; set; }
        public string TipoComisionAfp { get; set; }
        public OnpComision ComisionOnp { get; set; }
        public double PensionMonto { get; set; }
        public double RetencionJudicialMonto { get; set; }

        public double TotalBruto { get; set; }
        public double TotalDescuento { get; set; }
        public double TotalNeto { get; set; }

        public List<BE.VacacionDetalle> Detalle { get; set; } = new List<BE.VacacionDetalle>();
    }

    public class VacacionDetalle
    {
        public int IdVacacionDetalle { get; set; }
        public int Numero { get; set; }
        public int Anho { get; set; }
        public int Mes { get; set; }
        public double HorasExtrasMonto { get; set; }
        public double BonificacionMonto { get; set; }
    }
}