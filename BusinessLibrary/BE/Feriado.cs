using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class Feriado
    {

        public DateTime Fecha { get; set; }
        public bool Festivo { get; set; }
        public string Motivo { get; set; }
        public bool Activo { get; set; }
    }
    

}
