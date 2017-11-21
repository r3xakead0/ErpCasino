using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    /// <summary>
    /// Registro de Empleado para el formulario de Listado de Empleados
    /// </summary>
    public class Empleado
    {
        public int Id { get; set; }
        public string DocumentoCodigo { get; set; }
        public string DocumentoNombre { get; set; }
        public string DocumentoNumero { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int SalaId { get; set; }
        public string SalaNombre { get; set; }
        public int CargoId { get; set; }
        public string CargoNombre { get; set; }
        public string SexoCodigo { get; set; }
        public string SexoNombre { get; set; }
        public string Activo { get; set; } //Si|No
    }

    public class EmpleadoHijo
    {
        public int Id { get; set; }
        public string HijoNombre { get; set; }
        public string HijoApellidoPaterno { get; set; }
        public string HijoApellidoMaterno { get; set; }
        public DateTime HijoFechaNacimiento { get; set; }
        public int HijoEdad { get; set; }
        public bool HijoEstudia { get; set; } 
    }

    public class EmpleadoVacacion
    {
        public int Id { get; set; }
        public string EmpleadoCodigo { get; set; }
        public string EmpleadoApellidosNombres { get; set; }
        public DateTime EmpleadoFechaIngreso { get; set; }
        public DateTime? EmpleadoFechaVacacion { get; set; }
    }

    

    public class EmpleadoCompleto : Empleado
    {

        private int Anho { get; set; }
        private int Mes { get; set; }

        public int AreaId { get; set; }
        public string AreaNombre { get; set; }
        
        public DateTime FechaIngreso { get; set; } 
        public DateTime? FechaCese { get; set; }
        public DateTime? FechaVacacion { get; set; }

        public double Sueldo { get; set; }
        public double AsignacionFamiliar { get; set; }

        #region Banco (Sueldo)

        public int BancoId { get; set; }
        public string BancoNombre { get; set; }
        public string BancoCuenta { get; set; }
        public string BancoCci { get; set; }

        #endregion

        #region Banco (CTS)

        public int CtsId { get; set; }
        public string CtsNombre { get; set; }
        public string CtsCuenta { get; set; }

        #endregion

        #region Pension

        public TipoPensionEnum PensionTipo { get; set; }
        public double PensionMonto
        {
            get
            {
                return OnpMonto + AfpMonto;
            }
        }

        public double PensionPorcentaje
        {
            get
            {
                return OnpComisionPorcentaje + AfpComisionPorcentaje;
            }
        }

        public double OnpComisionPorcentaje { get; set; } = 0.0;
        public double OnpMonto { get; set; } = 0.0;

        public int AfpId { get; set; }
        public string AfpNombre { get; set; }
        public string AfpCuspp { get; set; }
        public string AfpComisionCodigo { get; set; }
        public string AfpComisionNombre { get; set; } 
        public double AfpComisionPorcentaje { get; set; } = 0.0;
        public double AfpMonto { get; set; } = 0.0;

        #endregion

        #region Retencion Judicial

        public TipoRetencionJudicialEnum RetencionJudicialTipo { get; set; } 
        public double RetencionJudicialNominal { get; set; } = 0.0;
        public double RetencionJudicialPorcentual { get; set; } = 0.0;

        #endregion

        public string EsSaludAutogenerado { get; set; } = "";

    }

}