using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class Gratificacion
    {

        public int Id { get; set; }
        public int Anho { get; set; }
        public string Periodo { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int Dias { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoNombres { get; set; }
        public int DiasCalculo { get; set; }
        public double SueldoBase { get; set; }
        public double AsignacionFamiliar { get; set; }
        public double BonoNocturno { get; set; }
        public double BonoHorasExtras { get; set; }
        public double DescuentoRetencioJudicial { get; set; }
        public double DescuentoImpuestos { get; set; }
        public double GratificacionBruta { get; set; }
        public double GratificacionBono { get; set; }
        public double GratificacionNeta { get; set; }
        public double GratificacionPago { get; set; }

        public List<GratificacionDetalle> Detalle { get; set; }

    }

    public class GratificacionDetalle
    {

        public int Id { get; set; }
        public int Anho { get; set; }
        public int MesId { get; set; }
        public string MesNombre { get; set; }
        public string EmpleadoCodigo { get; set; }
        public double BonoNocturno { get; set; }
        public double BonoHorasExtras { get; set; }
        public int DiasMes { get; set; }
        public int DiasInasistencias { get; set; }
        public int DiasCalculo { get; set; }

    }
}
