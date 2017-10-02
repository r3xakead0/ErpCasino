using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class DescuentoEmpleado
    {

        public int IdDescuentoEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoEmpleado { get; set; }
        public Descuento Descuento { get; set; }
        public string Motivo { get; set; }
        public double Monto { get; set; }

    }
    
}
