using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Prestamo : Audit
    {
        public int IdPrestamo { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Motivo { get; set; }
        public double Monto { get; set; }
        public int NumeroCuotas { get; set; }
        public List<PrestamoCuota> Cuotas { get; set; }
        public bool Pagado { get; set; }
    }

    public class PrestamoCuota
    {
        public int IdPrestamoCuota { get; set; }
        public DateTime Fecha { get; set; }
        public double Importe { get; set; }
        public bool Pagado { get; set; }
    }

}