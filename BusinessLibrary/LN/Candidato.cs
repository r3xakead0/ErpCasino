using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Candidato
    {

        public bool Insertar(ref BE.Candidato beCandidato)
        {
            try
            {
                this.Validar(beCandidato);

                return new DA.ClsDaTbCandidato().Insertar(ref beCandidato);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Candidato beCandidato)
        {
            try
            {

                this.Validar(beCandidato);

                if (beCandidato.IdCandidato == 0)
                    throw new Exception("No existe el Candidato");

                return new DA.ClsDaTbCandidato().Actualizar(beCandidato);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(BE.Candidato beCandidato)
        {
            try
            {

                if (beCandidato.IdCandidato == 0)
                    throw new Exception("No existe el Candidato");

                return new DA.ClsDaTbCandidato().Eliminar(beCandidato);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Valida si existe el codigo de candidato
        /// </summary>
        /// <param name="beCandidato">Objeto candidato</param>
        /// <returns></returns>
        public bool ValidarCodigo(BE.Candidato beCandidato)
        {
            try
            {
                return new DA.ClsDaTbCandidato().ValidarCodigo(beCandidato.IdCandidato, beCandidato.Codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Valida si existe el codigo de candidato
        /// </summary>
        /// <param name="codigo">Codigo de candidato</param>
        /// <param name="idCandidato">Id de candidato opcional</param>
        /// <returns></returns>
        public bool ValidarCodigo(string codigo, int idCandidato = 0)
        {
            try
            {
                return new DA.ClsDaTbCandidato().ValidarCodigo(idCandidato, codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Listado de Candidatos para el formulario
        /// </summary>
        /// <returns></returns>
        public List<BE.UI.Candidato> Listar()
        {

            var lstUiCandidatos = new List<BE.UI.Candidato>();

            try
            {

                var daCandidato = new DA.ClsDaTbCandidato();
                DataTable dt = daCandidato.Listar();

                foreach (DataRow dr in dt.Rows)
                {

                    int id = int.Parse(dr["IdCandidato"].ToString());
                    string codigo = dr["Codigo"].ToString();

                    string nombres = dr["Nombres"].ToString();

                    string apellidos = dr["ApellidoPaterno"].ToString()
                                     + " "
                                     + dr["ApellidoMaterno"].ToString();

                    string codSexo = dr["CodSexo"].ToString();
                    string nomSexo = "";
                    var beSexo = new LN.Record().ObtenerSexo(codSexo);
                    if (beSexo != null)
                        nomSexo = beSexo.Nombre;
                    beSexo = null;

                    bool codActivo = bool.Parse(dr["Activo"].ToString());
                    string nomActivo = codActivo == true ? "Si" : "No";

                    bool codInduccion = bool.Parse(dr["Induccion"].ToString());
                    string nomInduccion = codInduccion == true ? "Si" : "No";

                    bool codDisciplina = bool.Parse(dr["Disciplina"].ToString());
                    string nomDisciplina = codDisciplina == true ? "Si" : "No";

                    bool codInforme = bool.Parse(dr["Informe"].ToString());
                    string nomInforme = codInforme == true ? "Si" : "No";

                    bool codDocumentacion = bool.Parse(dr["Documentacion"].ToString());
                    string nomDocumentacion = codDocumentacion == true ? "Si" : "No";

                    bool codContratado = bool.Parse(dr["Contratado"].ToString());
                    string nomContratado = codContratado == true ? "Si" : "No";

                    var uiCandidato = new BE.UI.Candidato();

                    uiCandidato.Id = id;
                    uiCandidato.Codigo = codigo;
                    uiCandidato.Nombres = nombres;
                    uiCandidato.Apellidos = apellidos;
                    uiCandidato.SexoCodigo = codSexo;
                    uiCandidato.SexoNombre = nomSexo;
                    uiCandidato.Activo = nomActivo;
                    uiCandidato.Induccion = nomInduccion;
                    uiCandidato.Disciplina = nomDisciplina;
                    uiCandidato.Informe = nomInforme;
                    uiCandidato.Documentacion = nomDocumentacion;
                    uiCandidato.Contratado = nomContratado;

                    lstUiCandidatos.Add(uiCandidato);
                }

                return lstUiCandidatos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Candidato Obtener(int idCandidato)
        {
            BE.Candidato beCandidato = null;
            try
            {


                //General
                beCandidato = new DA.ClsDaTbCandidato().Obtener(idCandidato);
                if (beCandidato == null)
                    return beCandidato;


                //Contacto
                beCandidato.Contacto = new DA.ClsDaTbCandidatoContacto().Obtener(idCandidato);
                if (beCandidato.Contacto == null)
                {
                    beCandidato = null;
                    return beCandidato;
                }
                else
                {

                    //Telefonos
                    var lstBeCandidatoTelefonos = new DA.ClsDaTbCandidatoTelefono().Listar(idCandidato);
                    foreach (BE.ClsBeTbCandidatoTelefono beCandidatoTelefono in lstBeCandidatoTelefonos)
                    {
                        beCandidato.Telefonos.Add(beCandidatoTelefono);
                    }

                }
                

                //Contratacion
                beCandidato.Contratacion = new DA.ClsDaTbCandidatoContratacion().Obtener(idCandidato);
                if (beCandidato.Contratacion == null)
                {
                    beCandidato = null;
                    return beCandidato;
                }

                return beCandidato;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Candidato Obtener(string codigo)
        {
            BE.Candidato beCandidato = null;
            try
            {
                //General
                beCandidato = new DA.ClsDaTbCandidato().Obtener(codigo);
                if (beCandidato == null)
                    return beCandidato;


                //Contacto
                beCandidato.Contacto = new DA.ClsDaTbCandidatoContacto().Obtener(beCandidato.IdCandidato);
                if (beCandidato.Contacto == null)
                {
                    beCandidato = null;
                    return beCandidato;
                }
                else
                {

                    //Telefonos
                    var lstBeCandidatoTelefonos = new DA.ClsDaTbCandidatoTelefono().Listar(beCandidato.IdCandidato);
                    foreach (BE.ClsBeTbCandidatoTelefono beCandidatoTelefono in lstBeCandidatoTelefonos)
                    {
                        beCandidato.Telefonos.Add(beCandidatoTelefono);
                    }

                }


                //Contratacion
                beCandidato.Contratacion = new DA.ClsDaTbCandidatoContratacion().Obtener(beCandidato.IdCandidato);
                if (beCandidato.Contratacion == null)
                {
                    beCandidato = null;
                    return beCandidato;
                }


                return beCandidato;
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

                var daCandidato = new DA.ClsDaTbCandidato();

                DataTable dt = daCandidato.ComboNombres();

                foreach (DataRow dr in dt.Rows)
                {
                    var result = new BE.Record()
                    {
                        Codigo = dr["Codigo"].ToString(),
                        Nombre = dr["Candidato"].ToString()
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

        public void Validar(BE.Candidato beCandidato)
        {
            try
            {
                #region General

                #region Validar Documento de Identidad

                bool existeDocumento = false;
                existeDocumento = new DA.ClsDaTbCandidato().ValidarDocumento(beCandidato.TipoDocumento.Codigo,
                                                                            beCandidato.NumeroDocumento,
                                                                            beCandidato.IdCandidato);
                if (existeDocumento == true)
                    throw new Exception("El documento ingresado ya está registrado");

                #endregion

                if (beCandidato.Nombres.Trim().Length == 0)
                {
                    throw new Exception("No ingreso los nombres");
                }
                if (beCandidato.ApellidoPaterno.Trim().Length == 0)
                {
                    throw new Exception("No ingreso el apellido paterno");
                }
                if (beCandidato.ApellidoMaterno.Trim().Length == 0)
                {
                    throw new Exception("No ingreso el apellido materno");
                }
                if (beCandidato.Sexo == null || beCandidato.Sexo.Codigo.Trim().Length == 0)
                {
                    throw new Exception("No selecciono el sexo");
                }
                if (beCandidato.TipoDocumento == null || beCandidato.TipoDocumento.Codigo.Trim().Length == 0)
                {
                    throw new Exception("No selecciono el tipo de documento");
                }
                if (beCandidato.NumeroDocumento.Trim().Length == 0)
                {
                    throw new Exception("No ingreso el numero de documento");
                }
                if (beCandidato.EstadoCivil == null || beCandidato.EstadoCivil.Codigo.Trim().Length == 0)
                {
                    throw new Exception("No selecciono el estado civil");
                }
                if (beCandidato.PaisNacimiento == null || beCandidato.PaisNacimiento.Codigo.Trim().Length == 0)
                {
                    throw new Exception("No selecciono el pais de nacimiento");
                }
                else if (beCandidato.PaisNacimiento.Codigo.Equals("PER"))
                {
                    if (beCandidato.UbigeoNacimiento == null || beCandidato.UbigeoNacimiento.Codigo.Trim().Length == 0)
                    {
                        throw new Exception("No selecciono la ubicación de nacimiento");
                    }
                }

                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public bool Contratar(int idCandidato)
        {
            try
            {
                int rowsAffected = new DA.ClsDaTbCandidato().Contratar(idCandidato);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}