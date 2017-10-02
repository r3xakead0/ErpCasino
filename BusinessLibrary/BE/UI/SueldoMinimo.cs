using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class SueldoMinimo
    {

        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public double Monto { get; set; }
        public string Activo { get; set; } //SI|NO

    }
}
