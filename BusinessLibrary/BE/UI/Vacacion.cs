using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class Vacacion
    {
        public int Id { get; set; }
        public DateTime PeriodoFechaInicial { get; set; }
        public DateTime PeriodoFechaFinal { get; set; }
        public DateTime VacacionFechaInicial { get; set; }
        public DateTime VacacionFechaFinal { get; set; }
        public int VacacionDias { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoNombreCompleto { get; set; }
        public double EmpleadoSueldo { get; set; }
        public double EmpleadoAsignacionFamiliar { get; set; }
        public double PromedioHorasExtras { get; set; }
        public double PromedioBonificacion { get; set; }
        public double TotalBruto
        {
            get
            {
                return EmpleadoSueldo + EmpleadoAsignacionFamiliar + PromedioHorasExtras + PromedioBonificacion;
            }
        }
        public TipoPension PensionTipo { get; set; }
        public string PensionTipoComision { get; set; } //Solo para AFPs
        public int PensionId { get; set; }
        public string PensionNombre { get; set; } //ONP o Nombre de AFPs (PRIMA, PROFUTURO, ETC)
        public double PensionPorcentaje { get; set; } //ONP = 13% 
        public double PensionMonto { get; set; }
        public double RetencionJudicialMonto { get; set; }
        public double TotalDescuento
        {
            get
            {
                return PensionMonto + RetencionJudicialMonto;
            }
        }
        public double TotalNeto
        {
            get
            {
                return TotalBruto - TotalDescuento;
            }
        }
        public List<VacacionDetalle> Detalle { get; set; } = new List<VacacionDetalle>();

    }

    public class VacacionDetalle
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Anho { get; set; }
        public int MesNumero { get; set; }
        public string MesNombre { get; set; }
        public double HorasExtrasMonto { get; set; }
        public double BonificacionMonto { get; set; }

    }

}
