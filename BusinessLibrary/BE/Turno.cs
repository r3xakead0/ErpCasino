using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class Turno 
    {

        public int IdTurno { get; set; }
        public int Numero { get; set; }
        public string HoraInicial { get; set; }
        public string HoraFinal { get; set; }
        public bool Activo { get; set; }

    }
}