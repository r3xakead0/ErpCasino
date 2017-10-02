using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class Sala 
    {

        public int IdSala { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Ubigeo Ubigeo { get; set; }
        public string Zona { get; set; }
        public string Direccion { get; set; }
        public string Referencia { get; set; }
        public bool Activo { get; set; }
        
    }
}
