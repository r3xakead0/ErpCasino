using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class SueldoCandidato
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }

        #region Candidato

        public string CandidatoCodigo { get; set; }
        public string CandidatoNombreCompleto { get; set; }

        #endregion

        #region Base
        public double Sueldo { get; set; }
        public double AsignacionFamiliar  { get; set; }
        #endregion

        #region Bonos
        public int BonoNocturnoMinutos { get; set; }
        public string BonoNocturnoFormato { get { return FormatoHoraMinuto(BonoNocturnoMinutos); } }
        public double BonoNocturnoTotal { get; set; }

        public int BonoHorasExtrasMinutos { get; set; }
        public string BonoHorasExtrasFormato { get { return FormatoHoraMinuto(BonoHorasExtrasMinutos); } }
        public double BonoHorasExtrasTotal { get; set; }

        public int BonoFeriadoMinutos { get; set; }
        public string BonoFeriadoFormato { get { return FormatoHoraMinuto(BonoFeriadoMinutos); } }
        public double BonoFeriadoTotal { get; set; }
        #endregion

        #region Descuentos 
        public int DescuentoTardanzaMinutos { get; set; }
        public string DescuentoTardanzaFormato { get { return FormatoHoraMinuto(DescuentoTardanzaMinutos); } }
        public double DescuentoTardanzaTotal { get; set; }

        public int DescuentoInasistenciaMinutos { get; set; }
        public string DescuentoInasistenciaFormato { get { return FormatoHoraMinuto(DescuentoInasistenciaMinutos); } }
        public double DescuentoInasistenciaTotal { get; set; }
        #endregion

        #region Totales
        public double TotalBase
        {
            get
            {
                return Sueldo + AsignacionFamiliar;
            }
        }

        public double TotalBonos
        {
            get
            {
                return BonoNocturnoTotal + BonoHorasExtrasTotal + BonoFeriadoTotal;
            }
        }

        public double TotalDescuentos
        {
            get
            {
                return DescuentoTardanzaTotal + DescuentoInasistenciaTotal;
            }
        }

        public double TotalNeto
        {
            get
            {
                double totalBase = Sueldo + AsignacionFamiliar;
                double totalBono = BonoNocturnoTotal + BonoHorasExtrasTotal + BonoFeriadoTotal;
                double totalDescuento = DescuentoTardanzaTotal + DescuentoInasistenciaTotal;

                return totalBase + totalBono + totalDescuento;
            }
        }

        #endregion

        /// <summary>
        /// Retornar en formato horas y minutos (HH:ss) 
        /// </summary>
        /// <param name="minutos">Cantidad de minutos</param>
        /// <returns></returns>
        private string FormatoHoraMinuto(int minutos)
        {
            var span = TimeSpan.FromMinutes(minutos);
            string strValor = string.Format("{0:00}:{1:00}", (int)span.TotalHours, span.Minutes);
            return strValor;
        }
    }

}