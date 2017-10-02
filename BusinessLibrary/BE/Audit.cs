using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class Audit
    {
        public int IdUsuarioCreador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuarioModificador { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

}
