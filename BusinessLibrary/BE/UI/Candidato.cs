using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class Candidato
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string SexoCodigo { get; set; }
        public string SexoNombre { get; set; }
        public string Activo { get; set; } //SI|NO
        public string Induccion { get; set; } //SI|NO
        public string Disciplina { get; set; } //SI|NO
        public string Informe { get; set; } //SI|NO
        public string Documentacion { get; set; } //SI|NO
        public string Contratado { get; set; } //SI|NO

    }

}