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
}
