using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Empleado
    {

        public bool Insertar(ref BE.ClsBeTbEmpleado beEmpleado)
        {
            
            try
            {

                this.Validar(beEmpleado);

                var daEmpleado = new DA.ClsDaTbEmpleado();

                int rowsAffected = daEmpleado.Insertar(ref beEmpleado);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.ClsBeTbEmpleado beEmpleado)
        {
            
            try
            {

                this.Validar(beEmpleado);
                if (beEmpleado.IdEmpleado == 0)
                    throw new Exception("No existe el empleado");

                int rowsAffected = new DA.ClsDaTbEmpleado().Actualizar(beEmpleado);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(BE.ClsBeTbEmpleado beEmpleado)
        {
            int rowsAffected = 0;

            try
            {

                if (beEmpleado.IdEmpleado == 0)
                    throw new Exception("No existe el empleado");
            
                var daEmpleado = new DA.ClsDaTbEmpleado();

                rowsAffected = daEmpleado.Eliminar(beEmpleado); 

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.EmpleadoVacacion> ListarVacaciones(DateTime fecha)
        {
            var lstUiEmpleadosVacaciones = new List<BE.UI.EmpleadoVacacion>();
            try
            {
                DataTable dtEmpleados = new DA.ClsDaTbEmpleado().ListarVacaciones(fecha);

                foreach (DataRow drEmpleado in dtEmpleados.Rows)
                {
                    var uiEmpleadoVacacion = new BE.UI.EmpleadoVacacion();

                    uiEmpleadoVacacion.Id = drEmpleado["IdEmpleado"] == DBNull.Value ? 0 : int.Parse(drEmpleado["IdEmpleado"].ToString());
                    uiEmpleadoVacacion.EmpleadoCodigo = drEmpleado["Codigo"] == DBNull.Value ? "" : drEmpleado["Codigo"].ToString();
                    uiEmpleadoVacacion.EmpleadoApellidosNombres = drEmpleado["ApellidosNombres"] == DBNull.Value ? "" : drEmpleado["ApellidosNombres"].ToString();
                    uiEmpleadoVacacion.EmpleadoFechaIngreso = drEmpleado["FechaIngreso"] == DBNull.Value ? DateTime.Now : DateTime.Parse(drEmpleado["FechaIngreso"].ToString());
                    uiEmpleadoVacacion.EmpleadoFechaVacacion = drEmpleado["FechaVacacion"] == DBNull.Value ? null : (DateTime?)DateTime.Parse(drEmpleado["FechaVacacion"].ToString());

                    lstUiEmpleadosVacaciones.Add(uiEmpleadoVacacion);
                }

                return lstUiEmpleadosVacaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<BE.UI.Empleado> Listar()
        {

            var lstUiEmpleados = new List<BE.UI.Empleado>();

            try
            {

                var daEmpleado = new DA.ClsDaTbEmpleado();

                DataTable dt = daEmpleado.Listar();

                foreach (DataRow dr in dt.Rows)
                {

                    int idEmpleado = int.Parse(dr["IdEmpleado"].ToString());

                    var uiEmpleado = new BE.UI.Empleado();

                    #region Obtener datos de Estado
                    string activo = bool.Parse(dr["Activo"].ToString()) == true ? "Si" : "No";
                    #endregion

                    #region Nombre Completo del Empleado
                    string apellidos = dr["ApellidoPaterno"].ToString()
                                     + " "
                                     + dr["ApellidoMaterno"].ToString();
                    #endregion

                    #region Obtener datos del Sexo
                    string codSexo = dr["CodSexo"].ToString();
                    string nomSexo = "";
                    var beSexo = new LN.Record().ObtenerSexo(codSexo);
                    if (beSexo != null)
                        nomSexo = beSexo.Nombre;
                    beSexo = null;
                    #endregion

                    uiEmpleado.Id = int.Parse(dr["IdEmpleado"].ToString());
                    uiEmpleado.DocumentoCodigo = dr["CodDocumentoIdentidad"].ToString();
                    uiEmpleado.DocumentoNumero = dr["NumeroDocumento"].ToString();
                    uiEmpleado.Codigo = dr["Codigo"].ToString();
                    uiEmpleado.Nombres = dr["Nombres"].ToString();
                    uiEmpleado.Apellidos = apellidos;
                    uiEmpleado.SexoCodigo = codSexo;
                    uiEmpleado.SexoNombre = nomSexo;
                    uiEmpleado.Activo = activo;

                    var beEmpleadoRecurso = new LN.Empleado().ObtenerRecurso(idEmpleado);
                    if (beEmpleadoRecurso != null)
                    {
                        uiEmpleado.SalaId = beEmpleadoRecurso.Sala.IdSala;
                        uiEmpleado.SalaNombre = beEmpleadoRecurso.Sala.Nombre;
                        uiEmpleado.CargoId = beEmpleadoRecurso.Cargo.IdCargo;
                        uiEmpleado.CargoNombre = beEmpleadoRecurso.Cargo.Nombre;
                    }

                    lstUiEmpleados.Add(uiEmpleado);

                }

                return lstUiEmpleados;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Record> Combo()
        {

            List<BE.Record> lst = new List<BE.Record>();

            try
            {

                var daEmpleado = new DA.ClsDaTbEmpleado();

                DataTable dt = daEmpleado.ComboNombres();

                foreach (DataRow dr in dt.Rows)
                {
                    var result = new BE.Record()
                    {
                        Codigo = dr["Codigo"].ToString(),
                        Nombre = dr["Empleado"].ToString()
                    };
                    lst.Add(result);
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.ClsBeTbEmpleadoRecurso ObtenerRecurso(int idEmpleado)
        {
            try
            {
                return new DA.ClsDaTbEmpleadoRecurso().Obtener(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.ClsBeTbEmpleadoRecurso ObtenerRecurso(string codigo)
        {
            try
            {
                BE.ClsBeTbEmpleadoRecurso beEmpleadoRecurso = null;

                var beEmpleado = new DA.ClsDaTbEmpleado().Obtener(codigo);
                if (beEmpleado != null)
                    beEmpleadoRecurso = new DA.ClsDaTbEmpleadoRecurso().Obtener(beEmpleado.IdEmpleado);

                return beEmpleadoRecurso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.ClsBeTbEmpleado Obtener(int idEmpleado)
        {
            BE.ClsBeTbEmpleado beEmpleado = null;
            try
            {

                #region Datos Generales

                beEmpleado = new DA.ClsDaTbEmpleado().Obtener(idEmpleado);

                if (beEmpleado == null)
                {
                    return beEmpleado;
                }

                #endregion

                #region Datos del Contacto

                var beContacto = new DA.ClsDaTbEmpleadoContacto().Obtener(idEmpleado);
                if (beContacto == null)
                {
                    beEmpleado = null;
                    return beEmpleado;
                }
                else
                    beEmpleado.Contacto = beContacto;

                var lstBeTelefonos = new DA.ClsDaTbEmpleadoTelefono().Listar(idEmpleado);
                beEmpleado.Telefonos = lstBeTelefonos;

                #endregion

                #region Datos de Recursos Humanos

                var beRecurso = new DA.ClsDaTbEmpleadoRecurso().Obtener(idEmpleado);
                if (beRecurso == null)
                {
                    beEmpleado = null;
                    return beEmpleado;
                }
                else
                    beEmpleado.Recurso = beRecurso;

                #endregion


                return beEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtener los datos del empleado mediante el codigo
        /// </summary>
        /// <param name="codigo">Codigo del Empleado</param>
        /// <param name="detalle">Opcion para regresar datos completos del Empleado</param>
        /// <returns></returns>
        public BE.ClsBeTbEmpleado Obtener(string codigo, bool detalle = false)
        {
            BE.ClsBeTbEmpleado beEmpleado = null;
            try
            {
                int idEmpleado = 0;

                beEmpleado = new DA.ClsDaTbEmpleado().Obtener(codigo);

                if (beEmpleado == null)
                    return beEmpleado;
                else
                {
                    if (detalle)
                    {
                        idEmpleado = beEmpleado.IdEmpleado;
                        beEmpleado = this.Obtener(idEmpleado);
                    }
                }

                return beEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtener el monto de Asignación Familiar
        /// </summary>
        /// <param name="codigo">Codigo de Empleado</param>
        /// <returns></returns>
        public double ObtenerAsignacionFamiliar(string codigo)
        {
            try
            {
                double asignacionFamiliar = 0.0;
                double porcentaje = 10.0;

                var beEmpleadoRecurso = this.ObtenerRecurso(codigo);
                if (beEmpleadoRecurso != null)
                {
                    if (beEmpleadoRecurso.NumeroHijos > 0)
                    {
                        var beSueldoMinimo = new LN.SueldoMinimo().Actual(DateTime.Now);
                        if (beSueldoMinimo != null)
                            asignacionFamiliar = beSueldoMinimo.Monto / porcentaje;
                    }
                }
               
                return asignacionFamiliar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ObtenerNombreCompleto(string codigo, bool? activo = null)
        {
            return new DA.ClsDaTbEmpleado().ObtenerNombreCompleto(codigo, activo);
        }

        public bool ValidarCodigo(BE.ClsBeTbEmpleado beEmpleado)
        {
            bool rpta = false;
            try
            {
                var daEmpleado = new DA.ClsDaTbEmpleado();
                rpta = daEmpleado.ValidarCodigo(beEmpleado.IdEmpleado, beEmpleado.Codigo);
                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidarDocumento(BE.ClsBeTbEmpleado beEmpleado)
        {
            bool rpta = false;
            try
            {
                if (beEmpleado.TipoDocumento != null)
                {
                    var daEmpleado = new DA.ClsDaTbEmpleado();
                    rpta = daEmpleado.ValidarDocumento(beEmpleado.TipoDocumento.Codigo, beEmpleado.NumeroDocumento, beEmpleado.IdEmpleado);
                }
                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Validar(BE.ClsBeTbEmpleado beEmpleado)
        {
            try
            {

                #region Validar Documento de Identidad

                bool existeDocumento = false;
                existeDocumento = new DA.ClsDaTbEmpleado().ValidarDocumento(beEmpleado.TipoDocumento.Codigo,
                                                                            beEmpleado.NumeroDocumento,
                                                                            beEmpleado.IdEmpleado);
                if (existeDocumento == true)
                    throw new Exception("El documento ingresado ya está registrado");

                #endregion

                if (beEmpleado.Codigo.Trim().Length == 0)
                {
                    throw new Exception("No ingreso el codigo");
                }
                if (beEmpleado.Nombres.Trim().Length == 0)
                {
                    throw new Exception("No ingreso los nombres");
                }
                if (beEmpleado.ApellidoPaterno.Trim().Length == 0)
                {
                    throw new Exception("No ingreso el apellido paterno");
                }
                if (beEmpleado.ApellidoMaterno.Trim().Length == 0)
                {
                    throw new Exception("No ingreso el apellido materno");
                }
                if (beEmpleado.Sexo.Codigo.Trim().Length == 0)
                {
                    throw new Exception("No selecciono el sexo");
                }
                if (beEmpleado.TipoDocumento == null)
                {
                    throw new Exception("No selecciono el tipo de documento");
                }
                if (beEmpleado.NumeroDocumento.Trim().Length == 0)
                {
                    throw new Exception("No ingreso el numero de documento");
                }
                if (beEmpleado.PaisNacimiento == null)
                {
                    throw new Exception("No selecciono el pais de nacimiento");
                }
                if (beEmpleado.EstadoCivil == null)
                {
                    throw new Exception("No selecciono el estado civil");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }

}