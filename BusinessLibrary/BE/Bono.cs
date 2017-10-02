using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Bono: Audit
    {

        public int IdBono { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public bool Activo { get; set; }

    }
}
