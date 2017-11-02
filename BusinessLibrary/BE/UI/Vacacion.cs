using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class Vacacion
    {
        public int Id { get; set; }
        public DateTime PeriodoFechaInicial { get; set; }
        public DateTime PeriodoFechaFinal { get; set; }
        public int PeriodoDias { get; set; }
        public DateTime VacacionFechaInicial { get; set; }
        public DateTime VacacionFechaFinal { get; set; }
        public int VacacionDias { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoNombreCompleto { get; set; }
        public double EmpleadoSueldo { get; set; }
        public double EmpleadoAsignacionFamiliar { get; set; }
        public double PromedioHorasExtras { get; set; }
        public double PromedioBonificacion { get; set; }
        public double OtrosMonto { get; set; }
        public double TotalBruto { get; set; }
        public string PensionTipo { get; set; }
        public double PensionPorcentaje { get; set; }
        public double PensionTotal { get; set; }
        public double RetencionJudicialMonto { get; set; }
        public double TotalDescuento { get; set; }
        public double TotalNeto { get; set; }
        public List<VacacionDetalle> Detalle { get; set; }

        public Vacacion()
        {
            Detalle = new List<VacacionDetalle>();

            for (int i = 0; i < 6; i++)
            {
                var detalle = new VacacionDetalle();
                detalle.Id = 0;
                detalle.Numero = i + 1;
                detalle.Anho = DateTime.Now.AddMonths(i - 6).Year;
                detalle.Mes = DateTime.Now.AddMonths(i - 6).Month;
                detalle.HorasExtrasMonto = 0.0;
                detalle.BonificacionMonto = 0.0;
                Detalle.Add(detalle);
            }
        }

    }

    public class VacacionDetalle
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Anho { get; set; }
        public int Mes { get; set; }
        public double HorasExtrasMonto { get; set; }
        public double BonificacionMonto { get; set; }

    }

}
