using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class Categoria 
    {

        public int IdCategoria { get; set; }
        public int IdTipo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }

}
