using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class BonoEmpleado
    {

        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoNombreCompleto { get; set; }
        public int BonoID { get; set; }
        public string BonoNombre { get; set; }
        public double Monto { get; set; }

    }
    
}
