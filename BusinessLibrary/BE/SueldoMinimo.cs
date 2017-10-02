using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class SueldoMinimo
    {

        public int IdSueldoMinimo { get; set; }
        public DateTime FechaInicio { get; set; }
        public double Monto { get; set; }
        public bool Activo { get; set; }

    }
}
