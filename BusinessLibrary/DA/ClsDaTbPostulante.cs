using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{

    public class ClsDaTbPostulante
    {

        public BE.ClsBeTbPostulante Cargar(DataRow dr)
        {
            try
            {
                var bePostulante = new BE.ClsBeTbPostulante();

                bePostulante.IdPostulante = dr["IdPostulante"] == DBNull.Value ? 0 : int.Parse(dr["IdPostulante"].ToString());
                bePostulante.Nombres = dr["Nombres"] == DBNull.Value ? "" : dr["Nombres"].ToString();
                bePostulante.ApellidoPaterno = dr["ApellidoPaterno"] == DBNull.Value ? "" : dr["ApellidoPaterno"].ToString();
                bePostulante.ApellidoMaterno = dr["ApellidoMaterno"] == DBNull.Value ? "" : dr["ApellidoMaterno"].ToString();
                bePostulante.FechaNacimiento = dr["FechaNacimiento"] == DBNull.Value ? DateTime.Now.AddYears(-18) : DateTime.Parse(dr["FechaNacimiento"].ToString());
                bePostulante.NumeroDocumento = dr["NumeroDocumento"] == DBNull.Value ? "" : dr["NumeroDocumento"].ToString();
                bePostulante.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
                bePostulante.Candidato = dr["Candidato"] == DBNull.Value ? false : bool.Parse(dr["Candidato"].ToString());

                if (dr["CodNacimiento"] != DBNull.Value)
                {
                    bePostulante.UbigeoNacimiento = new BE.Ubigeo()
                    {
                        Codigo = dr["CodNacimiento"].ToString()
                    };
                }

                if (dr["CodPais"] != DBNull.Value)
                {
                    bePostulante.PaisNacimiento = new BE.Pais()
                    {
                        Codigo = dr["CodPais"].ToString(),
                        Nombre = dr["DscPais"].ToString()
                    };
                }

                if (dr["CodSexo"] != DBNull.Value)
                {
                    bePostulante.Sexo = new BE.Record()
                    {
                        Codigo = dr["CodSexo"].ToString(),
                        Nombre = dr["DscSexo"].ToString()
                    };
                }

                if (dr["CodEstadoCivil"] != DBNull.Value)
                {
                    bePostulante.EstadoCivil = new BE.Record()
                    {
                        Codigo = dr["CodEstadoCivil"].ToString(),
                        Nombre = dr["DscEstadoCivil"].ToString()
                    };
                }

                if (dr["CodDocumentoIdentidad"] != DBNull.Value)
                {
                    bePostulante.TipoDocumento = new BE.Record()
                    {
                        Codigo = dr["CodDocumentoIdentidad"].ToString(),
                        Nombre = dr["DscDocumentoIdentidad"].ToString()
                    };
                }

                return bePostulante;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insertar(ref BE.ClsBeTbPostulante bePostulante)
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
                sp = "SpTbPostulanteGeneralInsertar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", bePostulante.IdPostulante));
                cmd.Parameters["@IDPOSTULANTE"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@NOMBRES", bePostulante.Nombres));
                cmd.Parameters.Add(new SqlParameter("@APELLIDOPATERNO", bePostulante.ApellidoPaterno));
                cmd.Parameters.Add(new SqlParameter("@APELLIDOMATERNO", bePostulante.ApellidoMaterno));
                cmd.Parameters.Add(new SqlParameter("@FECHANACIMIENTO", bePostulante.FechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@CODSEXO", bePostulante.Sexo.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODDOCUMENTOIDENTIDAD", bePostulante.TipoDocumento.Codigo));
                cmd.Parameters.Add(new SqlParameter("@NUMERODOCUMENTO", bePostulante.NumeroDocumento));
                cmd.Parameters.Add(new SqlParameter("@CODPAIS", bePostulante.PaisNacimiento.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODESTADOCIVIL", bePostulante.EstadoCivil.Codigo));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", bePostulante.Activo));
                cmd.Parameters.Add(new SqlParameter("@CANDIDATO", bePostulante.Candidato));
                if (bePostulante.UbigeoNacimiento != null)
                {
                    cmd.Parameters.Add(new SqlParameter("@CODNACIMIENTO", bePostulante.UbigeoNacimiento.Codigo));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@CODNACIMIENTO", DBNull.Value));
                }

                rowsAffected += cmd.ExecuteNonQuery();
                bePostulante.IdPostulante = int.Parse(cmd.Parameters["@IDPOSTULANTE"].Value.ToString());

                //Contacto
                sp = "SpTbPostulanteContactoInsertar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", bePostulante.Contacto.IdPostulante));
                cmd.Parameters.Add(new SqlParameter("@CODUBIGEO", bePostulante.Contacto.Ubigeo.Codigo));
                cmd.Parameters.Add(new SqlParameter("@ZONA", bePostulante.Contacto.Zona));
                cmd.Parameters.Add(new SqlParameter("@DIRECCION", bePostulante.Contacto.Direccion));
                cmd.Parameters.Add(new SqlParameter("@REFERENCIA", bePostulante.Contacto.Referencia));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", bePostulante.Contacto.Email));

                rowsAffected += cmd.ExecuteNonQuery();

                //Telefonos
                sp = "SpTbPostulanteTelefonoInsertar";
                foreach (var telefono in bePostulante.Telefonos)
                {

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTETELEFONO", telefono.IdPostulanteTelefono));
                    cmd.Parameters["@IDPOSTULANTETELEFONO"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", telefono.IdPostulante));
                    cmd.Parameters.Add(new SqlParameter("@CODTIPOTELEFONO", telefono.CodTipoTelefono));
                    cmd.Parameters.Add(new SqlParameter("@NUMERO", telefono.Numero));

                    rowsAffected += cmd.ExecuteNonQuery();
                    telefono.IdPostulanteTelefono = int.Parse(cmd.Parameters["@IDPostulanteTELEFONO"].Value.ToString());

                }

                //Reclutamiento
                sp = "SpTbPostulanteReclutamientoInsertar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", bePostulante.Reclutamiento.IdPostulante));
                cmd.Parameters.Add(new SqlParameter("@CARGOCURRICULUM", bePostulante.Reclutamiento.CargoCurriculum));
                cmd.Parameters.Add(new SqlParameter("@FECHARECEPCION", bePostulante.Reclutamiento.FechaRecepcion));
                cmd.Parameters.Add(new SqlParameter("@OBSERVACION", bePostulante.Reclutamiento.Observacion));

                rowsAffected += cmd.ExecuteNonQuery();

                //Detalle Reclutamiento
                if (bePostulante.Reclutamiento.Historial.Count == 1)
                {
                    sp = "SpTbPostulanteHistorialInsertar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    int ultima = bePostulante.Reclutamiento.Historial.Count - 1;
                    var historial = bePostulante.Reclutamiento.Historial[ultima];
                    cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", historial.IdPostulante));
                    cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTEESTADO", historial.Estado.IdPostulanteEstado));
                    cmd.Parameters.Add(new SqlParameter("@ACEPTO", historial.Acepto));
                    cmd.Parameters.Add(new SqlParameter("@NOTA", historial.Nota));

                    rowsAffected += cmd.ExecuteNonQuery();
                }


                if (tns != null)
                    tns.Commit();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                if(tns != null)
                    tns.Rollback();

                throw ex;
            }
        }

        public int Actualizar(BE.ClsBeTbPostulante bePostulante)
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
                sp = "SpTbPostulanteGeneralActualizar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", bePostulante.IdPostulante));
                cmd.Parameters.Add(new SqlParameter("@NOMBRES", bePostulante.Nombres));
                cmd.Parameters.Add(new SqlParameter("@APELLIDOPATERNO", bePostulante.ApellidoPaterno));
                cmd.Parameters.Add(new SqlParameter("@APELLIDOMATERNO", bePostulante.ApellidoMaterno));
                cmd.Parameters.Add(new SqlParameter("@FECHANACIMIENTO", bePostulante.FechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@CODSEXO", bePostulante.Sexo.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODDOCUMENTOIDENTIDAD", bePostulante.TipoDocumento.Codigo));
                cmd.Parameters.Add(new SqlParameter("@NUMERODOCUMENTO", bePostulante.NumeroDocumento));
                cmd.Parameters.Add(new SqlParameter("@CODPAIS", bePostulante.PaisNacimiento.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODESTADOCIVIL", bePostulante.EstadoCivil.Codigo));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", bePostulante.Activo));
                cmd.Parameters.Add(new SqlParameter("@CANDIDATO", bePostulante.Candidato));
                if (bePostulante.UbigeoNacimiento != null)
                {
                    cmd.Parameters.Add(new SqlParameter("@CODNACIMIENTO", bePostulante.UbigeoNacimiento.Codigo));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@CODNACIMIENTO", DBNull.Value));
                }

                rowsAffected += cmd.ExecuteNonQuery();
                
                //Contacto
                sp = "SpTbPostulanteContactoActualizar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", bePostulante.Contacto.IdPostulante));
                cmd.Parameters.Add(new SqlParameter("@CODUBIGEO", bePostulante.Contacto.Ubigeo.Codigo));
                cmd.Parameters.Add(new SqlParameter("@ZONA", bePostulante.Contacto.Zona));
                cmd.Parameters.Add(new SqlParameter("@DIRECCION", bePostulante.Contacto.Direccion));
                cmd.Parameters.Add(new SqlParameter("@REFERENCIA", bePostulante.Contacto.Referencia));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", bePostulante.Contacto.Email));

                rowsAffected += cmd.ExecuteNonQuery();

                //Telefonos
                sp = "SpTbPostulanteTelefonoActualizar";
                foreach (var telefono in bePostulante.Telefonos)
                {

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTETELEFONO", telefono.IdPostulanteTelefono));
                    cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", telefono.IdPostulante));
                    cmd.Parameters.Add(new SqlParameter("@CODTIPOTELEFONO", telefono.CodTipoTelefono));
                    cmd.Parameters.Add(new SqlParameter("@NUMERO", telefono.Numero));

                    rowsAffected += cmd.ExecuteNonQuery();
                    
                }

                //Reclutamiento
                sp = "SpTbPostulanteReclutamientoActualizar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", bePostulante.Reclutamiento.IdPostulante));
                cmd.Parameters.Add(new SqlParameter("@CARGOCURRICULUM", bePostulante.Reclutamiento.CargoCurriculum));
                cmd.Parameters.Add(new SqlParameter("@FECHARECEPCION", bePostulante.Reclutamiento.FechaRecepcion));
                cmd.Parameters.Add(new SqlParameter("@OBSERVACION", bePostulante.Reclutamiento.Observacion));

                rowsAffected += cmd.ExecuteNonQuery();

                //Detalle Reclutamiento
                if (bePostulante.Reclutamiento.Historial.Count == 1)
                {
                    sp = "SpTbPostulanteHistorialInsertar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    int ultima = bePostulante.Reclutamiento.Historial.Count - 1;
                    var historial = bePostulante.Reclutamiento.Historial[ultima];
                    cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", historial.IdPostulante));
                    cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTEESTADO", historial.Estado.IdPostulanteEstado));
                    cmd.Parameters.Add(new SqlParameter("@ACEPTO", historial.Acepto));
                    cmd.Parameters.Add(new SqlParameter("@NOTA", historial.Nota));

                    rowsAffected += cmd.ExecuteNonQuery();
                }
                
               
                if (tns != null)
                    tns.Commit();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                if (tns != null)
                    tns.Rollback();

                throw ex;
            }

        }

        public int Eliminar( BE.ClsBeTbPostulante bePostulante)
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

                //Contacto
                sp = "SpTbPostulanteContactoEliminar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", bePostulante.IdPostulante));
                
                rowsAffected += cmd.ExecuteNonQuery();

                //Telefonos
                sp = "SpTbPostulanteTelefonoEliminar";

                foreach (var telefono in bePostulante.Telefonos)
                {

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTETELEFONO", telefono.IdPostulanteTelefono));

                    rowsAffected += cmd.ExecuteNonQuery();

                }

                //Reclutamiento
                sp = "SpTbPostulanteReclutamientoEliminar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", bePostulante.IdPostulante));

                rowsAffected += cmd.ExecuteNonQuery();

                //Historial
                sp = "SpTbPostulanteHistorialEliminar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", bePostulante.IdPostulante));

                rowsAffected += cmd.ExecuteNonQuery();

                //General
                sp = "SpTbPostulanteGeneralEliminar";

                cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tns;

                cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", bePostulante.IdPostulante));

                rowsAffected += cmd.ExecuteNonQuery();

                if (tns != null)
                    tns.Commit();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                if (tns != null)
                    tns.Rollback();

                throw ex;
            }
        }

        public int Contratar(int idPostulante)
        {

            int rowsAffected = 0;

            try
            {
                string sp = "SpTbPostulanteContratar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", idPostulante));

                    rowsAffected += cmd.ExecuteNonQuery();
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
                string sp = "SpTbPostulanteListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dad.Fill(dt);

                return dt;

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
                string sp = "SpTbPostulanteGeneralObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDPOSTULANTE", idPostulante));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];

                    bePostulante = this.Cargar(dr);

                    var beUbigeoNacimiento = bePostulante.UbigeoNacimiento;
                    if (new Ubigeo().Obtener(ref beUbigeoNacimiento))
                        bePostulante.UbigeoNacimiento = beUbigeoNacimiento;
                    else
                        bePostulante.UbigeoNacimiento = null;

                }

                return bePostulante;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidarDocumento(string codDocumento, string numDocumento, int idPostulante = 0)
        {
            try
            {
                string sp = "SpTbPostulanteGeneralValidarDocumento";
                bool exists = false;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (idPostulante  > 0)
                        cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", idPostulante));
                    else
                        cmd.Parameters.Add(new SqlParameter("@IDPOSTULANTE", DBNull.Value));

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

