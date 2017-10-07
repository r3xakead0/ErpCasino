using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class Comprometido
    {
        public int IdComprometido { get; set; }
        public int Anho { get; set; }
        public int Mes { get; set; }
        public Sala Sala { get; set; }
        public string CodigoEmpleado { get; set; }
        public bool Estado { get; set; }

    }

}
