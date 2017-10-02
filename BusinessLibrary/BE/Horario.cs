using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Horario 
    {
        public int IdHorario { get; set; }
        public int Anho { get; set; }
        public byte Semana { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdSala { get; set; }
        public int IdCargo { get; set; }
        public DateTime Fecha { get; set; }
        public string Codigo { get; set; }
        public byte Dia { get; set; }
        public byte Turno { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFinal { get; set; }
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
        public byte Mes { get; set; }
        public int SalaId { get; set; }
        public string SalaNombre { get; set; }
    }
}
