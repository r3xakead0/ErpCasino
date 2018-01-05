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

    /// <summary>
    /// Objeto de datos simples del Candidato (Codigo, Nombres y Apellidos) y Sueldo
    /// </summary>
    public class CandidatoSueldo
    {
        public string Codigo { get; set; } = "";
        public string Nombres { get; set; } = "";
        public string ApellidoPaterno { get; set; } = "";
        public string ApellidoMaterno { get; set; } = "";

        private double _Sueldo = 0.0;
        public double Sueldo
        {
            get
            {
                return Math.Round(_Sueldo, 2);
            }
            set 
            {
                _Sueldo = value;
            }
        }

    }

    public class CandidatoAsistencia : AsistenciaCalculo
    {
        public string NombleCompleto { get; set; } = "";
    }

    public class CandidatoCosto : CostoCalculo
    {
        public string NombleCompleto { get; set; } = "";
    }

    public class CandidatoAsistenciaResumen : AsistenciaResumenCalculo
    {
        public string NombleCompleto { get; set; } = "";
    }


}