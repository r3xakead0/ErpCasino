using ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{

    public class ClsDaTbCandidato
    {

        /// <summary>
        /// Convertir registro a objeto Candidato
        /// </summary>
        /// <param name="dr">Registro candidato</param>
        public BE.Candidato Cargar(DataRow dr)
        {
            try
            {
                var beCandidato = new BE.Candidato();

                beCandidato.IdCandidato = dr["IdCandidato"] == DBNull.Value ? 0 : int.Parse(dr["IdCandidato"].ToString());
                beCandidato.Codigo = dr["Codigo"] == DBNull.Value ? "" : dr["Codigo"].ToString();
                beCandidato.Nombres = dr["Nombres"] == DBNull.Value ? "" : dr["Nombres"].ToString();
                beCandidato.ApellidoPaterno = dr["ApellidoPaterno"] == DBNull.Value ? "" : dr["ApellidoPaterno"].ToString();
                beCandidato.ApellidoMaterno = dr["ApellidoMaterno"] == DBNull.Value ? "" : dr["ApellidoMaterno"].ToString();
                beCandidato.FechaNacimiento = dr["FechaNacimiento"] == DBNull.Value ? DateTime.Now.AddYears(-18) : DateTime.Parse(dr["FechaNacimiento"].ToString());
                beCandidato.NumeroDocumento = dr["NumeroDocumento"] == DBNull.Value ? "" : dr["NumeroDocumento"].ToString();
                beCandidato.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
                beCandidato.Contratado = dr["Contratado"] == DBNull.Value ? false : bool.Parse(dr["Contratado"].ToString());

                if (dr["CodNacimiento"] != DBNull.Value)
                {
                    beCandidato.UbigeoNacimiento = new BE.Ubigeo()
                    {
                        Codigo = dr["CodNacimiento"].ToString()
                    };
                }

                if (dr["CodPais"] != DBNull.Value)
                {
                    beCandidato.PaisNacimiento = new BE.Pais()
                    {
                        Codigo = dr["CodPais"].ToString(),
                        Nombre = dr["DscPais"].ToString()
                    };
                }

                if (dr["CodSexo"] != DBNull.Value)
                {
                    beCandidato.Sexo = new Record()
                    {
                        Codigo = dr["CodSexo"].ToString(),
                        Nombre = dr["DscSexo"].ToString()
                    };
                }

                if (dr["CodEstadoCivil"] != DBNull.Value)
                {
                    beCandidato.EstadoCivil = new Record()
                    {
                        Codigo = dr["CodEstadoCivil"].ToString(),
                        Nombre = dr["DscEstadoCivil"].ToString()
                    };
                }

                if (dr["CodDocumentoIdentidad"] != DBNull.Value)
                {
                    beCandidato.TipoDocumento = new Record()
                    {
                        Codigo = dr["CodDocumentoIdentidad"].ToString(),
                        Nombre = dr["DscDocumentoIdentidad"].ToString()
                    };
                }

                return beCandidato;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.Candidato beCandidato)
        {

            SqlConnection cnn = null;
            SqlTransaction tns = null;
            SqlCommand cmd = null;

            try
            {

                int rowsAffected = 0;
                string sp = "";

                cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                tns = cnn.BeginTransaction();

                #region General

                sp = "SpTbCandidatoGeneralInsertar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", beCandidato.IdCandidato));
                cmd.Parameters["@IDCANDIDATO"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@CODIGO", beCandidato.Codigo));
                cmd.Parameters.Add(new SqlParameter("@NOMBRES", beCandidato.Nombres));
                cmd.Parameters.Add(new SqlParameter("@APELLIDOPATERNO", beCandidato.ApellidoPaterno));
                cmd.Parameters.Add(new SqlParameter("@APELLIDOMATERNO", beCandidato.ApellidoMaterno));
                cmd.Parameters.Add(new SqlParameter("@FECHANACIMIENTO", beCandidato.FechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@CODSEXO", beCandidato.Sexo.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODDOCUMENTOIDENTIDAD", beCandidato.TipoDocumento.Codigo));
                cmd.Parameters.Add(new SqlParameter("@NUMERODOCUMENTO", beCandidato.NumeroDocumento));
                cmd.Parameters.Add(new SqlParameter("@CODPAIS", beCandidato.PaisNacimiento.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODESTADOCIVIL", beCandidato.EstadoCivil.Codigo));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beCandidato.Activo));
                cmd.Parameters.Add(new SqlParameter("@CONTRATADO", beCandidato.Contratado));
                cmd.Parameters.Add(new SqlParameter("@CODNACIMIENTO", beCandidato.UbigeoNacimiento.Codigo));

                rowsAffected += cmd.ExecuteNonQuery();
                beCandidato.IdCandidato = int.Parse(cmd.Parameters["@IDCANDIDATO"].Value.ToString());

                #endregion

                #region Contacto

                sp = "SpTbCandidatoContactoInsertar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", beCandidato.Contacto.IdCandidato));
                cmd.Parameters.Add(new SqlParameter("@CODUBIGEO", beCandidato.Contacto.Ubigeo.Codigo));
                cmd.Parameters.Add(new SqlParameter("@ZONA", beCandidato.Contacto.Zona));
                cmd.Parameters.Add(new SqlParameter("@DIRECCION", beCandidato.Contacto.Direccion));
                cmd.Parameters.Add(new SqlParameter("@REFERENCIA", beCandidato.Contacto.Referencia));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", beCandidato.Contacto.Email));

                rowsAffected += cmd.ExecuteNonQuery();

                #region Telefonos

                sp = "SpTbCandidatoTelefonoInsertar";

                foreach (var telefono in beCandidato.Telefonos)
                {

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDCANDIDATOTELEFONO", telefono.IdCandidatoTelefono));
                    cmd.Parameters["@IDCANDIDATOTELEFONO"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", telefono.IdCandidato));
                    cmd.Parameters.Add(new SqlParameter("@CODTIPOTELEFONO", telefono.CodTipoTelefono));
                    cmd.Parameters.Add(new SqlParameter("@NUMERO", telefono.Numero));

                    rowsAffected += cmd.ExecuteNonQuery();
                    telefono.IdCandidatoTelefono = Convert.ToInt32(cmd.Parameters["@IDCANDIDATOTELEFONO"].Value.ToString());

                }

                #endregion

                #endregion

                #region Contratacion

                sp = "SpTbCandidatoContratacionInsertar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", beCandidato.Contratacion.IdCandidato));
                cmd.Parameters.Add(new SqlParameter("@INDUCCIONFECHAINICIO", beCandidato.Contratacion.InduccionFechaInicio));
                cmd.Parameters.Add(new SqlParameter("@INDUCCIONFECHAFIN", beCandidato.Contratacion.InduccionFechaFin));
                cmd.Parameters.Add(new SqlParameter("@INDUCCIONEstado", beCandidato.Contratacion.Induccion));
                cmd.Parameters.Add(new SqlParameter("@INFORMEDISCIPLINARIOESTADO", beCandidato.Contratacion.Disciplina));
                cmd.Parameters.Add(new SqlParameter("@INFORMEADMINISTRATIVOESTADO", beCandidato.Contratacion.Informe));
                cmd.Parameters.Add(new SqlParameter("@DOCUMENTACIONEstado", beCandidato.Contratacion.Documentacion));
                cmd.Parameters.Add(new SqlParameter("@OBSERVACION", beCandidato.Contratacion.Observacion));

                rowsAffected += cmd.ExecuteNonQuery();

                #endregion

                if (tns != null)
                    tns.Commit();

                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                if(tns != null)
                    tns.Rollback();

                beCandidato.IdCandidato = 0;

                throw ex;
            }
        }

        public bool Actualizar(BE.Candidato beCandidato)
        {
            SqlConnection cnn = null;
            SqlTransaction tns = null;

            try
            {

                int rowsAffected = 0;
                string sp = "";

                cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();
                tns = cnn.BeginTransaction();

                SqlCommand cmd = null;

                //General
                sp = "SpTbCandidatoGeneralActualizar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", beCandidato.IdCandidato));
                cmd.Parameters.Add(new SqlParameter("@CODIGO", beCandidato.Codigo));
                cmd.Parameters.Add(new SqlParameter("@NOMBRES", beCandidato.Nombres));
                cmd.Parameters.Add(new SqlParameter("@APELLIDOPATERNO", beCandidato.ApellidoPaterno));
                cmd.Parameters.Add(new SqlParameter("@APELLIDOMATERNO", beCandidato.ApellidoMaterno));
                cmd.Parameters.Add(new SqlParameter("@FECHANACIMIENTO", beCandidato.FechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@CODSEXO", beCandidato.Sexo.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODDOCUMENTOIDENTIDAD", beCandidato.TipoDocumento.Codigo));
                cmd.Parameters.Add(new SqlParameter("@NUMERODOCUMENTO", beCandidato.NumeroDocumento));
                cmd.Parameters.Add(new SqlParameter("@CODPAIS", beCandidato.PaisNacimiento.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODESTADOCIVIL", beCandidato.EstadoCivil.Codigo));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beCandidato.Activo));
                cmd.Parameters.Add(new SqlParameter("@CONTRATADO", beCandidato.Contratado));
                cmd.Parameters.Add(new SqlParameter("@CODNACIMIENTO", beCandidato.UbigeoNacimiento.Codigo));

                rowsAffected += cmd.ExecuteNonQuery();

                //Contacto
                sp = "SpTbCandidatoContactoActualizar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", beCandidato.Contacto.IdCandidato));
                cmd.Parameters.Add(new SqlParameter("@CODUBIGEO", beCandidato.Contacto.Ubigeo.Codigo));
                cmd.Parameters.Add(new SqlParameter("@ZONA", beCandidato.Contacto.Zona));
                cmd.Parameters.Add(new SqlParameter("@DIRECCION", beCandidato.Contacto.Direccion));
                cmd.Parameters.Add(new SqlParameter("@REFERENCIA", beCandidato.Contacto.Referencia));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", beCandidato.Contacto.Email));

                rowsAffected += cmd.ExecuteNonQuery();

                //Telefonos
                sp = "SpTbCandidatoTelefonoActualizar";
                foreach (var telefono in beCandidato.Telefonos)
                {

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDCANDIDATOTELEFONO", telefono.IdCandidatoTelefono));
                    cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", telefono.IdCandidato));
                    cmd.Parameters.Add(new SqlParameter("@CODTIPOTELEFONO", telefono.CodTipoTelefono));
                    cmd.Parameters.Add(new SqlParameter("@NUMERO", telefono.Numero));

                    rowsAffected += cmd.ExecuteNonQuery();
                    
                }

                //Contratacion
                sp = "SpTbCandidatoContratacionActualizar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", beCandidato.Contratacion.IdCandidato));
                cmd.Parameters.Add(new SqlParameter("@INDUCCIONFECHAINICIO", beCandidato.Contratacion.InduccionFechaInicio));
                if (beCandidato.Contratacion.InduccionFechaFin == null)
                    cmd.Parameters.Add(new SqlParameter("@INDUCCIONFECHAFIN", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@INDUCCIONFECHAFIN", beCandidato.Contratacion.InduccionFechaFin));
                cmd.Parameters.Add(new SqlParameter("@INDUCCIONESTADO", beCandidato.Contratacion.Induccion));
                cmd.Parameters.Add(new SqlParameter("@INFORMEDISCIPLINARIOESTADO", beCandidato.Contratacion.Disciplina));
                cmd.Parameters.Add(new SqlParameter("@INFORMEADMINISTRATIVOESTADO", beCandidato.Contratacion.Informe));
                cmd.Parameters.Add(new SqlParameter("@DOCUMENTACIONESTADO", beCandidato.Contratacion.Documentacion));
                cmd.Parameters.Add(new SqlParameter("@OBSERVACION", beCandidato.Contratacion.Observacion));

                rowsAffected += cmd.ExecuteNonQuery();


                if (tns != null)
                    tns.Commit();

                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                if (tns != null)
                    tns.Rollback();

                throw ex;
            }
           
        }

        public bool Eliminar(Candidato beCandidato)
        {

            SqlConnection cnn = null;
            SqlTransaction tns = null;

            try
            {

                int rowsAffected = 0;
                string sp = "";

                using (cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    tns = cnn.BeginTransaction();

                    SqlCommand cmd = null;

                    #region Contacto

                    sp = "SpTbCandidatoContactoEliminar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", beCandidato.IdCandidato));

                    rowsAffected += cmd.ExecuteNonQuery();

                    #region Telefonos

                    sp = "SpTbCandidatoTelefonoEliminar";

                    foreach (var telefono in beCandidato.Telefonos)
                    {

                        cmd = new SqlCommand(sp, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDCANDIDATOTELEFONO", telefono.IdCandidatoTelefono));

                        rowsAffected += cmd.ExecuteNonQuery();

                    }

                    #endregion

                    #endregion

                    #region Contratacion

                    sp = "SpTbCandidatoContratacionEliminar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", beCandidato.IdCandidato));

                    rowsAffected += cmd.ExecuteNonQuery();

                    #endregion

                    #region General

                    sp = "SpTbCandidatoGeneralEliminar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", beCandidato.IdCandidato));

                    rowsAffected += cmd.ExecuteNonQuery();

                    #endregion

                    cnn.Close();

                    if (tns != null)
                        tns.Commit();
                }

                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                if (tns != null)
                    tns.Rollback();

                throw ex;
            }
        }

        public int Contratar(int idCandidato)
        {

            int rowsAffected = 0;

            try
            {
                string sp = "SpTbCandidatoContratar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", idCandidato));

                    rowsAffected += cmd.ExecuteNonQuery();

                    cnn.Close();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar()
        {
            try
            {
                string sp = "SpTbCandidatoListar";
                DataTable dt = new DataTable();

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.Fill(dt);

                    cnn.Close();
                }
  
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ComboNombres()
        {
            try
            {
                string sp = "SpTbCandidatoComboNombres";
                DataTable dt = new DataTable();

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.Fill(dt);

                    cnn.Close();
                }
                    
                return dt;

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

                string sp = "SpTbCandidatoGeneralObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@IDCANDIDATO", idCandidato));

                    DataTable dt = new DataTable();
                    dad.Fill(dt);

                    if ((dt.Rows.Count == 1))
                    {
                        DataRow dr = dt.Rows[0];

                        beCandidato = this.Cargar(dr);

                        var beUbigeoNacimiento = beCandidato.UbigeoNacimiento;
                        if (new Ubigeo().Obtener(ref beUbigeoNacimiento))
                            beCandidato.UbigeoNacimiento = beUbigeoNacimiento;
                        else
                            beCandidato.UbigeoNacimiento = null;

                    }

                    cnn.Close();
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
            int idCandidato = 0;

            try
            {
                string sp = "SpTbCandidatoGeneralObtenerCodigo";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@CODIGO", codigo));

                    DataTable dt = new DataTable();
                    dad.Fill(dt);

                    if ((dt.Rows.Count == 1))
                    {
                        DataRow dr = dt.Rows[0];

                        beCandidato = new BE.Candidato();

                        #region General

                        idCandidato = dr["IdCandidato"] == DBNull.Value ? 0 : int.Parse(dr["IdCandidato"].ToString());

                        beCandidato.IdCandidato = idCandidato;
                        beCandidato.Codigo = dr["Codigo"] == DBNull.Value ? "" : dr["Codigo"].ToString();
                        beCandidato.Nombres = dr["Nombres"] == DBNull.Value ? "" : dr["Nombres"].ToString();
                        beCandidato.ApellidoPaterno = dr["ApellidoPaterno"] == DBNull.Value ? "" : dr["ApellidoPaterno"].ToString();
                        beCandidato.ApellidoMaterno = dr["ApellidoMaterno"] == DBNull.Value ? "" : dr["ApellidoMaterno"].ToString();
                        beCandidato.FechaNacimiento = dr["FechaNacimiento"] == DBNull.Value ? DateTime.Now.AddYears(-18) : DateTime.Parse(dr["FechaNacimiento"].ToString());
                        beCandidato.NumeroDocumento = dr["NumeroDocumento"] == DBNull.Value ? "" : dr["NumeroDocumento"].ToString();
                        beCandidato.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());

                        if (dr["CodNacimiento"] == DBNull.Value)
                            beCandidato.UbigeoNacimiento = null;
                        else
                        {
                            var beUbigeoNacimiento = new BE.Ubigeo();
                            beUbigeoNacimiento.Codigo = dr["CodNacimiento"].ToString();

                            if (new LN.Ubigeo().Obtener(ref beUbigeoNacimiento))
                                beCandidato.UbigeoNacimiento = beUbigeoNacimiento;
                            else
                                beCandidato.UbigeoNacimiento = null;
                        }

                        if (dr["CodPais"] == DBNull.Value)
                            beCandidato.PaisNacimiento = null;
                        else
                        {
                            var bePais = new BE.Pais();
                            bePais.Codigo = dr["CodPais"].ToString();

                            if (new LN.Pais().Obtener(ref bePais))
                                beCandidato.PaisNacimiento = bePais;
                            else
                                beCandidato.PaisNacimiento = null;
                        }

                        if (dr["CodSexo"] == DBNull.Value)
                            beCandidato.Sexo = null;
                        else
                        {
                            string codSexo = dr["CodSexo"].ToString();
                            var beSexo = new LN.Record().ObtenerSexo(codSexo);
                            beCandidato.Sexo = beSexo;
                        }

                        if (dr["CodEstadoCivil"] == DBNull.Value)
                            beCandidato.EstadoCivil = null;
                        else
                        {
                            string codEstadoCivil = dr["CodEstadoCivil"].ToString();
                            var beEstadoCivil = new LN.Record().ObtenerEstadoCivil(codEstadoCivil);
                            beCandidato.EstadoCivil = beEstadoCivil;
                        }

                        if (dr["CodDocumentoIdentidad"] == DBNull.Value)
                            beCandidato.TipoDocumento = null;
                        else
                        {
                            string codDocumentoIdentidad = dr["CodDocumentoIdentidad"].ToString();
                            var beDocumentoIdentidad = new LN.Record().ObtenerTipoDocumento(codDocumentoIdentidad);
                            beCandidato.TipoDocumento = beDocumentoIdentidad;
                        }

                        #endregion

                    }

                    cnn.Close();
                }

                return beCandidato;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidarCodigo(int idCandidato, string codigo)
        {
            bool rpta = false;
            try
            {
                string sp = "SpTbCandidatoGeneralValidarCodigo";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (idCandidato > 0)
                        cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", idCandidato));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));

                    rpta = (bool)cmd.ExecuteScalar();

                    cnn.Close();
                }   

                return rpta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidarDocumento(string codDocumento, string numDocumento, int idCandidato = 0)
        {
            try
            {
                string sp = "SpTbCandidatoGeneralValidarDocumento";
                bool exists = false;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (idCandidato > 0)
                        cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", idCandidato));
                    else
                        cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", DBNull.Value));

                    cmd.Parameters.Add(new SqlParameter("@CODDOCUMENTOIDENTIDAD", codDocumento));
                    cmd.Parameters.Add(new SqlParameter("@NUMERODOCUMENTO", numDocumento));

                    exists = (bool)cmd.ExecuteScalar();
                }

                return exists;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

