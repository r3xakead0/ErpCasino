using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class Cuota
    {
        public int IdCuota { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public double Importe { get; set; }
        public bool Pagado { get; set; }
    }

}