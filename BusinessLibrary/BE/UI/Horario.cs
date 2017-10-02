using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class Horario 
    {
        public int IdHorario { get; set; }
        public int Anho { get; set; }
        public byte Semana { get; set; }
        public int SalaId { get; set; }
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
    }

    public class HorarioSemanal
    {
        public int Anho { get; set; }
        public byte Semana { get; set; }
        public int SalaId { get; set; }
        public string SalaNombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
    }

    public class HorarioMensual
    {
        public int Anho { get; set; }
        public byte MesNumero { get; set; }
        public string MesNombre { get; set; }
        public int SalaId { get; set; }
        public string SalaNombre { get; set; }
    }
}
