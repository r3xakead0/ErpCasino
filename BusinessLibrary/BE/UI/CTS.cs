using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class CTS
    {

        public int IdCts { get; set; }
        public DateTime FechaDeposito { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoNombre { get; set; }
        public double Monto { get; set; }
        public DateTime FechaPeriodoInicial { get; set; }
        public DateTime FechaPeriodoFinal { get; set; }

    }
}
