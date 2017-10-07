using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Bono
    {

        public int IdBono { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public bool Calculado { get; set; }
        public double Monto { get; set; }
    }
}
