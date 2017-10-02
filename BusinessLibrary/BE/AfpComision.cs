using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class AfpComision
    {

        public int IdAfpComision { get; set; }
        public int Anho { get; set; }
        public int Mes { get; set; }
        public Afp Afp { get; set; }
        public double PorcentajeFondo { get; set; }
        public double PorcentajeSeguro { get; set; }
        public double PorcentajeComisionFlujo { get; set; }
        public double PorcentajeComisionMixta { get; set; }

    }

}
