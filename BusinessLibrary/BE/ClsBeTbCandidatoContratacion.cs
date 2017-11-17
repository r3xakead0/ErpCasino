using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbCandidatoContratacion : ICloneable
    {

        public int IdCandidato { get; set; } = 0;
        public DateTime InduccionFechaInicio { get; set; } = DateTime.Now;
        public DateTime? InduccionFechaFin { get; set; } = null;
        public bool Induccion { get; set; } = false;
        public bool Disciplina { get; set; } = false;
        public bool Informe { get; set; } = false;
        public bool Documentacion { get; set; } = false;
        public string Observacion { get; set; } = "";
        public double Sueldo { get; set; } = 0.0;
        
        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }

}
