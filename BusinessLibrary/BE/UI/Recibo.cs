using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    /// <summary>
    /// Calculo de Asistencia de Candidatos para Recibo
    /// </summary>
    public class ReciboAsistencia : AsistenciaCalculo
    {

    }

    public class ReciboResumen
    {
        public int Anho { get; set; }
        public int Mes { get; set; }
        public string TrabajadorCodigo { get; set; }
        public string TrabajadorNombreCompleto { get; set; }
        public TipoTrabajadorEnum TrabajadorTipo { get; set; } = TipoTrabajadorEnum.Ninguno;
        public double TotalSueldo { get; set; } = 0.0; //Solo para Candidatos
        public double TotalBonos { get; set; } = 0.0;
        public double TotalDescuentos { get; set; } = 0.0;
        public double Total
        {
            get
            {
                return TotalSueldo + TotalBonos - TotalDescuentos;
            }
        }
    }

    public class Recibo 
    {
        public int ID { get; set; }
        public int Anho { get; set; }
        public int Mes { get; set; }
        public string TrabajadorCodigo { get; set; }
        public string TrabajadorNombreCompleto { get; set; }
        public TipoReciboEnum Tipo { get; set; } = TipoReciboEnum.Ninguno;
        public int OrigenID { get; set; } //ID de origen de referencia
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double Total { get; set; } = 0.0;
    }

}
