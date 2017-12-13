using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class CostoCalculo : ICloneable
    {

        /// <summary>
        /// Codigo Unico del Trabajador (Candidato o Empleado)
        /// </summary>
        public string Codigo { get; set; }

        #region Sueldo
        public double Sueldo { get; set; }
        public double AsignacionFamiliar { get; set; }
        #endregion

        public string CostosPor { get; set; } = "M"; //Minutos, Hora y Dia

        #region Costo Normal
        public double NormalDiurno { get; set; }
        public double NormalDiurnoExtra1 { get; set; }
        public double NormalDiurnoExtra2 { get; set; }
        public double NormalNocturno { get; set; }
        public double NormalNocturnoExtra1 { get; set; }
        public double NormalNocturnoExtra2 { get; set; }
        #endregion

        #region Costo Feriado
        public double FeriadoDiurno { get; set; }
        public double FeriadoDiurnoExtra1 { get; set; }
        public double FeriadoDiurnoExtra2 { get; set; }
        public double FeriadoNocturno { get; set; }
        public double FeriadoNocturnoExtra1 { get; set; }
        public double FeriadoNocturnoExtra2 { get; set; }
        #endregion

        #region Descuento Tardanza
        public double TardanzaNormalDiurno { get; set; }
        public double TardanzaNormalNocturno { get; set; }
        public double TardanzaFeriadoDiurno { get; set; }
        public double TardanzaFeriadoNocturno { get; set; }
        #endregion

        #region Descuento Inasistencia
        public double Dominical { get; set; }
        public double Inasistencia { get; set; }
        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

}
