using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class ClsBeTbPlantillaHorario
    {

        public int IdPlantillaHorario = 0;
        public Sala Sala = null;
        public Cargo Cargo = null;
        public int Dia = 0;
        public int Turno = 0;
        public string HoraInicio = "00:00:00";
        public string HoraFin = "00:00:00";
        public int Horas = 0;
        
        public ClsBeTbPlantillaHorario()
        {
            Sala = new Sala();
            Cargo = new Cargo();
        }
    }
}
