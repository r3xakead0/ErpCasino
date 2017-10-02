using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class ObservacionEmpleado
    {

        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public int SalaID { get; set; }
        public string SalaNombre { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoNombreCompleto { get; set; }
        public int ObservacionID { get; set; }
        public string ObservacionNombre { get; set; }
        public string ObservacionDescripcion { get; set; }

    }
    
}
