using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Inasistencia : Audit
    {
        public int IdInasistencia { get; set; }
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaHoraEntrada { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public string Tipo { get; set; }
        public string Asunto { get; set; }
        public string Detalle { get; set; }
        public string Certificado { get; set; }

    }
}