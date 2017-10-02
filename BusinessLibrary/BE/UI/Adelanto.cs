using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class Adelanto
    {

        public int IdAdelanto { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoEmpleado { get; set; }
        public string NombreCompletoEmpleado { get; set; }
        public string CodigoTipo { get; set; }
        public string NombreTipo { get; set; }
        public int IdBanco { get; set; }
        public string NombreBanco { get; set; }
        public string Numero { get; set; }
        public double Monto { get; set; }
        
    }
}
