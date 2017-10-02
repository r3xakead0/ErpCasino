using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class AfpComision
    {

        public int IdAfpComision { get; set; }
        public int AfpID { get; set; }
        public string AfpNombre { get; set; }
        public double PorcentajeFondo { get; set; }
        public double PorcentajeSeguro { get; set; }
        public double PorcentajeComisionFlujo { get; set; }
        public double PorcentajeComisionMixta { get; set; }

    }

}
