using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class MetaSala
    {
        public int IdMetaSala { get; set; }
        public Sala Sala { get; set; }
        public int Anho { get; set; }
        public int Mes { get; set; }
        public int CantidadPersonal { get; set; }
        public double MontoPersonal { get; set; }
        public double MontoGrupal { get; set; }
        public bool Cumplido { get; set; }

    }

}
