using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Movilidad: Audit
    {
        public int IdMovilidad { get; set; }
        public int Anho { get; set; }
        public int Mes { get; set; }
        public string CodigoEmpleado { get; set; }
        public double Monto { get; set; }
    }
}
