using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class Asistencia
    {

        public int ID { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoNombreCompleto { get; set; }
        public int Turno { get; set; }
        public DateTime FechaHoraEntrada { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public TimeSpan Tiempo { get; set; }
        public string Origen { get; set; }
        public DateTime Fecha { get; set; }


    }

    public class AsistenciaResumen
    {
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        
    }

    /// <summary>
    /// Calculo de Asistencia en Minutos
    /// </summary>
    public class AsistenciaCalculo : ICloneable
    {

        #region Datos Generales 

        /// <summary>
        /// Codigo Unico del Trabajador (Candidato o Empleado)
        /// </summary>
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public int Semana { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFinal { get; set; }

        #endregion

        #region Valores de calculo en Minutos

        public int AsistenciaNormalTotal { get; set; }
        public int AsistenciaNormalDiurna { get; set; }
        public int AsistenciaNormalNocturna { get; set; }
        public int AsistenciaNormalDiurnaExtra1 { get; set; }
        public int AsistenciaNormalNocturnaExtra1 { get; set; }
        public int AsistenciaNormalDiurnaExtra2 { get; set; }
        public int AsistenciaNormalNocturnaExtra2 { get; set; }
        public int TardanzaNormalTotal { get; set; }
        public int TardanzaNormalDiurna { get; set; }
        public int TardanzaNormalNocturna { get; set; }
        public int AsistenciaFeriadoTotal { get; set; }
        public int AsistenciaFeriadoDiurna { get; set; }
        public int AsistenciaFeriadoNocturna { get; set; }
        public int AsistenciaFeriadoDiurnaExtra1 { get; set; }
        public int AsistenciaFeriadoNocturnaExtra1 { get; set; }
        public int AsistenciaFeriadoDiurnaExtra2 { get; set; }
        public int AsistenciaFeriadoNocturnaExtra2 { get; set; }
        public int TardanzaFeriadoTotal { get; set; }
        public int TardanzaFeriadoDiurna { get; set; }
        public int TardanzaFeriadoNocturna { get; set; }
        public int InasistenciaTotal { get; set; }
        public int InasistenciaNormal { get; set; }
        public int InasistenciaFeriado { get; set; }

        #endregion

        #region Devuelve valores en formato de calculo

        public string FormateadoCalculo { get; set; } = "M"; //H = Hora | M = Minuto (Defecto)
        public string FormateadoAsistenciaNormalTotal { get { return AplicarFormato(AsistenciaNormalTotal); } }
        public string FormateadoAsistenciaNormalDiurna { get { return AplicarFormato(AsistenciaNormalDiurna); } }
        public string FormateadoAsistenciaNormalNocturna { get { return AplicarFormato(AsistenciaNormalNocturna); } }
        public string FormateadoAsistenciaNormalDiurnaExtra1 { get { return AplicarFormato(AsistenciaNormalDiurnaExtra1); } }
        public string FormateadoAsistenciaNormalNocturnaExtra1 { get { return AplicarFormato(AsistenciaNormalNocturnaExtra1); } }
        public string FormateadoAsistenciaNormalDiurnaExtra2 { get { return AplicarFormato(AsistenciaNormalDiurnaExtra2); } }
        public string FormateadoAsistenciaNormalNocturnaExtra2 { get { return AplicarFormato(AsistenciaNormalNocturnaExtra2); } }
        public string FormateadoTardanzaNormalTotal { get { return AplicarFormato(TardanzaNormalTotal); } }
        public string FormateadoTardanzaNormalDiurna { get { return AplicarFormato(TardanzaNormalDiurna); } }
        public string FormateadoTardanzaNormalNocturna { get { return AplicarFormato(TardanzaNormalNocturna); } }
        public string FormateadoAsistenciaFeriadoTotal { get { return AplicarFormato(AsistenciaFeriadoTotal); } }
        public string FormateadoAsistenciaFeriadoDiurna { get { return AplicarFormato(AsistenciaFeriadoDiurna); } }
        public string FormateadoAsistenciaFeriadoNocturna { get { return AplicarFormato(AsistenciaFeriadoNocturna); } }
        public string FormateadoAsistenciaFeriadoDiurnaExtra1 { get { return AplicarFormato(AsistenciaFeriadoDiurnaExtra1); } }
        public string FormateadoAsistenciaFeriadoNocturnaExtra1 { get { return AplicarFormato(AsistenciaFeriadoNocturnaExtra1); } }
        public string FormateadoAsistenciaFeriadoDiurnaExtra2 { get { return AplicarFormato(AsistenciaFeriadoDiurnaExtra2); } }
        public string FormateadoAsistenciaFeriadoNocturnaExtra2 { get { return AplicarFormato(AsistenciaFeriadoNocturnaExtra2); } }
        public string FormateadoTardanzaFeriadoTotal { get { return AplicarFormato(TardanzaFeriadoTotal); } }
        public string FormateadoTardanzaFeriadoDiurna { get { return AplicarFormato(TardanzaFeriadoDiurna); } }
        public string FormateadoTardanzaFeriadoNocturna { get { return AplicarFormato(TardanzaFeriadoNocturna); } }
        public string FormateadoInasistenciaTotal { get { return AplicarFormato(InasistenciaTotal); } }
        public string FormateadoInasistenciaNormal { get { return AplicarFormato(InasistenciaNormal); } }
        public string FormateadoInasistenciaFeriado { get { return AplicarFormato(InasistenciaFeriado); } }

        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        private string AplicarFormato(int valor)
        {
            string strValor = "";

            if (FormateadoCalculo == "H") //Hora
            {
                var span = TimeSpan.FromMinutes(valor);
                strValor = string.Format("{0:00}:{1:00}", (int)span.TotalHours, span.Minutes);
            }
            else if (FormateadoCalculo == "M") //Minuto
            {
                strValor = valor.ToString();
            }

            return strValor;
        }

    }
}
