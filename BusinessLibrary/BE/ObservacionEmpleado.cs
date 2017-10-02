using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class ObservacionEmpleado
    {

        public int IdObservacionEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public Sala Sala { get; set; }
        public string CodigoEmpleado { get; set; }
        public Observacion Observacion { get; set; }
        public string Descripcion { get; set; }

    }
    
}
