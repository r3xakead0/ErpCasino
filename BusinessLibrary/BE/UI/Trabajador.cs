using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class Trabajador
    {
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ApellidosNombres {
            get
            {
                return $"{ApellidoPaterno} {ApellidoMaterno}, {Nombres}";
            }
        }
        public string NombresApellidos
        {
            get
            {
                return $"{Nombres} {ApellidoPaterno} {ApellidoMaterno}";
            }
        }
        public TipoTrabajadorEnum Tipo { get; set; } = TipoTrabajadorEnum.Ninguno;
        public ActivoEnum Activo { get; set; }
    }
}
