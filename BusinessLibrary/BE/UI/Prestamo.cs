using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoEmpleado { get; set; }
        public string NombreCompletoEmpleado { get; set; }
        public string Motivo { get; set; }
        public double Monto { get; set; }
        public int NumeroCuotas { get; set; }
        public List<Cuota> Cuotas { get; set; }
        public bool Pagado { get; set; }
    }

}