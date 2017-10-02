using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class Postulante
    {
        public int Id { get; set; }
        public string DocumentoCodigo { get; set; }
        public string DocumentoNombre { get; set; }
        public string DocumentoNumero { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string SexoCodigo { get; set; }
        public string SexoNombre { get; set; }
        public string Activo { get; set; } //SI|NO
        public string Candidato { get; set; } //SI|NO
        public string EstadoDescipcion { get; set; } 
    }

}