using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class DescuentoEmpleado
    {

        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoNombreCompleto { get; set; }
        public int DescuentoID { get; set; }
        public string DescuentoTipo { get; set; } //Manual o Calculado
        public string DescuentoNombre { get; set; }
        public string Motivo { get; set; }
        public double Monto { get; set; }
        
    }
    
}
