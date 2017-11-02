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

}