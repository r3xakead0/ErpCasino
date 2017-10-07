using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class BonoEmpleado
    {

        public int IdBonoEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoEmpleado { get; set; }
        public Bono Bono { get; set; }
        public string Motivo { get; set; }
        public double Monto { get; set; }

    }
    
}
