using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Postulante
    {

        public bool Insertar(ref BE.ClsBeTbPostulante bePostulante)
        {
            int rowsAffected = 0;

            try
            {

                this.Validar(bePostulante);

                rowsAffected = new DA.ClsDaTbPostulante().Insertar(ref bePostulante);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.ClsBeTbPostulante bePostulante)
        {
            int rowsAffected = 0;

            try
            {

                if (bePostulante.IdPostulante == 0)
                    throw new Exception("No existe el Postulante");

                this.Validar(bePostulante);

                rowsAffected = new DA.ClsDaTbPostulante().Actualizar(bePostulante);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(BE.ClsBeTbPostulante bePostulante)
        {
            int rowsAffected = 0;

            try
            {

                if (bePostulante.IdPostulante == 0)
                    throw new Exception("No existe el Postulante");

                var daPostulante = new DA.ClsDaTbPostulante();

                rowsAffected = daPostulante.Eliminar(bePostulante);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Contratar(int idPostulante)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = new DA.ClsDaTbPostulante().Contratar(idPostulante);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Postulante> Listar()
        {

            var lstUiPostulantes = new List<BE.UI.Postulante>();

            try
            {

                var daPostulante = new DA.ClsDaTbPostulante();
                DataTable dt = daPostulante.Listar();

                foreach (DataRow dr in dt.Rows)
                {
                    string codSexo = dr["CodSexo"].ToString();
                    string nomSexo = "";
                    var beSexo = new LN.Record().ObtenerSexo(codSexo);
                    if (beSexo != null)
                        nomSexo = beSexo.Nombre;

                    bool codActivo = bool.Parse(dr["Activo"].ToString());
                    string nomActivo = codActivo == true ? "Si" : "No";

                    string apellidos = dr["ApellidoPaterno"].ToString()
                                     + " "
                                     + dr["ApellidoMaterno"].ToString();

                    bool codCandidato = bool.Parse(dr["Candidato"].ToString());
                    string nomCandidato = codCandidato == true ? "Si" : "No";

                    var uiPostulante = new BE.UI.Postulante();

                    uiPostulante.Id = int.Parse(dr["IdPostulante"].ToString());
                    uiPostulante.DocumentoCodigo = dr["CodDocumentoIdentidad"].ToString();
                    uiPostulante.DocumentoNumero = dr["NumeroDocumento"].ToString();
                    uiPostulante.Nombres = dr["Nombres"].ToString();
                    uiPostulante.Apellidos = apellidos;
                    uiPostulante.SexoCodigo = codSexo;
                    uiPostulante.SexoNombre = nomSexo;
                    uiPostulante.Activo = nomActivo;
                    uiPostulante.Candidato = nomCandidato;
                    uiPostulante.EstadoDescipcion = dr["Estado"].ToString();

                    lstUiPostulantes.Add(uiPostulante);
                }

                return lstUiPostulantes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.ClsBeTbPostulante Obtener(int idPostulante)
        {
            BE.ClsBeTbPostulante bePostulante = null;
            try
            {

                //General
                bePostulante = new DA.ClsDaTbPostulante().Obtener(idPostulante);
                if (bePostulante == null)
                    return bePostulante;


                //Contacto
                bePostulante.Contacto = new DA.ClsDaTbPostulanteContacto().Obtener(idPostulante);
                if (bePostulante.Contacto == null)
                {
                    bePostulante = null;
                    return bePostulante;
                }
                else
                {

                    //Telefonos
                    var lstBePostulanteTelefonos = new DA.ClsDaTbPostulanteTelefono().Listar(idPostulante);
                    foreach (BE.ClsBeTbPostulanteTelefono bePostulanteTelefono in lstBePostulanteTelefonos)
                    {
                        bePostulante.Telefonos.Add(bePostulanteTelefono);
                    }

                }


                //Contratacion
                bePostulante.Reclutamiento = new DA.ClsDaTbPostulanteReclutamiento().Obtener(idPostulante);
                if (bePostulante.Reclutamiento == null)
                {
                    bePostulante = null;
                    return bePostulante;
                }
                else
                {
                    var lstBePostulanteHistorial = new DA.ClsDaTbPostulanteHistorial().Listar(idPostulante);

                    for (int i = 0; i < lstBePostulanteHistorial.Count; i++)
                    {
                        var beEstado = new BE.ClsBeTbPostulanteEstado() { IdPostulanteEstado = lstBePostulanteHistorial[i].Estado.IdPostulanteEstado };
                        if (new DA.ClsDaTbPostulanteEstado().Obtener(ref beEstado))
                            lstBePostulanteHistorial[i].Estado = beEstado;
                    }

                    bePostulante.Reclutamiento.Historial = lstBePostulanteHistorial;
                }

                return bePostulante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Validar(BE.ClsBeTbPostulante bePostulante)
        {
            try
            {

                #region Validar Documento de Identidad

                bool existeDocumento = false;
                existeDocumento = new DA.ClsDaTbPostulante().ValidarDocumento(bePostulante.TipoDocumento.Codigo,
                                                                            bePostulante.NumeroDocumento,
                                                                            bePostulante.IdPostulante);
                if (existeDocumento == true)
                    throw new Exception("El documento ingresado ya está registrado");

                #endregion

                if (bePostulante.Nombres.Trim().Length == 0)
                {
                    throw new Exception("No ingreso los nombres");
                }
                if (bePostulante.ApellidoPaterno.Trim().Length == 0)
                {
                    throw new Exception("No ingreso el apellido paterno");
                }
                if (bePostulante.ApellidoMaterno.Trim().Length == 0)
                {
                    throw new Exception("No ingreso el apellido materno");
                }
                if (bePostulante.Sexo.Codigo.Trim().Length == 0)
                {
                    throw new Exception("No selecciono el sexo");
                }
                if (bePostulante.TipoDocumento == null)
                {
                    throw new Exception("No selecciono el tipo de documento");
                }
                if (bePostulante.NumeroDocumento.Trim().Length == 0)
                {
                    throw new Exception("No ingreso el numero de documento");
                }
                if (bePostulante.PaisNacimiento == null)
                {
                    throw new Exception("No selecciono el pais de nacimiento");
                }
                if (bePostulante.EstadoCivil == null)
                {
                    throw new Exception("No selecciono el estado civil");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<BE.ClsBeTbPostulanteEstado> ListarEstadosReclutamiento(int? IdPostulante = null)
        {

            List<BE.ClsBeTbPostulanteEstado> lst = new List<BE.ClsBeTbPostulanteEstado>();

            try
            {

                var daEstado = new DA.ClsDaTbPostulanteEstado();

                DataTable dt = daEstado.Listar(IdPostulante, true);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var beEstado = new BE.ClsBeTbPostulanteEstado();

                    DataRow dr = dt.Rows[i];
                    daEstado.Cargar(ref beEstado, dr);

                    lst.Add(beEstado);
                }


                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}