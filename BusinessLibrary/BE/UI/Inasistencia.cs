using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class Inasistencia
    {
        public int Id { get; set; }
        public int Anho { get; set; }
        public byte MesId { get; set; }
        public string MesNombre { get; set; }
        public byte Semana { get; set; }
        public int SalaId { get; set; }
        public string SalaNombre { get; set; }
        public int CargoId { get; set; }
        public string CargoNombre { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoNombreCompleto { get; set; }
        public DateTime Fecha { get; set; }
        public byte DiaNumero { get; set; }
        public string DiaNombre { get; set; }
        public byte Turno { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFinal { get; set; }
        public byte Horas { get; set; }
        public string TipoCodigo { get; set; }
        public string TipoNombre { get; set; }
        public string Asunto { get; set; }
        public string Detalle { get; set; }
        public string Certificado { get; set; }

    }
}
