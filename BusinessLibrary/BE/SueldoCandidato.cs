using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class SueldoCandidato
    {

        public int IdSueldoCandidato { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoCandidato { get; set; }

        #region Base
        public double Sueldo { get; set; }
        #endregion

        #region Bonos
        public int BonoNocturnoMinutos { get; set; }
        public double BonoNocturnoTotal { get; set; }

        public int BonoHorasExtrasMinutos { get; set; }
        public double BonoHorasExtrasTotal { get; set; }

        public int BonoFeriadoMinutos { get; set; }
        public double BonoFeriadoTotal { get; set; }
        #endregion

        #region Descuentos 
        public int DescuentoTardanzaMinutos { get; set; }
        public double DescuentoTardanzaTotal { get; set; }

        public int DescuentoInasistenciaMinutos { get; set; }
        public double DescuentoInasistenciaTotal { get; set; }
        #endregion


    }

}
