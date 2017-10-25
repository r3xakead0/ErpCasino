using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Recibo
    {

        public int IdRecibo { get; set; }
        public int Anho { get; set; }
        public int Mes { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Tipo { get; set; }
        public string Concepto { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
    }
}
