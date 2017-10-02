using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Adelanto: Audit
    {

        public int IdAdelanto { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Tipo { get; set; }
        public int IdBanco { get; set; }
        public string Numero { get; set; }
        public double Monto { get; set; }
        

    }
}
