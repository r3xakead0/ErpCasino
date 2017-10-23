using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class Sala
    {

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Zona { get; set; }
        public string Direccion { get; set; }
        public string Referencia { get; set; }
        public string Activo { get; set; }  //SI|NO

    }
}
