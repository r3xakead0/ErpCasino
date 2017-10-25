using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class ReciboResumen
    {
        public int Anho { get; set; }
        public int Mes { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoNombreCompleto { get; set; }
        public double TotalBonos { get; set; }
        public double TotalDescuentos { get; set; }
    }

    public class ReciboResumenDetalle
    {
        public int Anho { get; set; }
        public int Mes { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoNombreCompleto { get; set; }
        public string Tipo { get; set; }
        public string Concepto { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
    }

}
