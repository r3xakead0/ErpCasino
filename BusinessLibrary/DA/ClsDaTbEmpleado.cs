using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{

    public class ClsDaTbEmpleado
    {

        private BE.ClsBeTbEmpleado Cargar(DataRow dr)
        {
            try
            {
                var beEmpleado = new BE.ClsBeTbEmpleado();

                beEmpleado.IdEmpleado = dr["IdEmpleado"] == DBNull.Value ? 0 : int.Parse(dr["IdEmpleado"].ToString());
                beEmpleado.Codigo = dr["Codigo"] == DBNull.Value ? "" : dr["Codigo"].ToString();
                beEmpleado.Nombres = dr["Nombres"] == DBNull.Value ? "" : dr["Nombres"].ToString();
                beEmpleado.ApellidoPaterno = dr["ApellidoPaterno"] == DBNull.Value ? "" : dr["ApellidoPaterno"].ToString();
                beEmpleado.ApellidoMaterno = dr["ApellidoMaterno"] == DBNull.Value ? "" : dr["ApellidoMaterno"].ToString();
                beEmpleado.FechaNacimiento = dr["FechaNacimiento"] == DBNull.Value ? DateTime.Now.AddYears(-18) : DateTime.Parse(dr["FechaNacimiento"].ToString());
                beEmpleado.NumeroDocumento = dr["NumeroDocumento"] == DBNull.Value ? "" : dr["NumeroDocumento"].ToString();
                beEmpleado.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
                beEmpleado.IdCandidato = dr["IdCandidato"] == DBNull.Value ? 0 : int.Parse(dr["IdCandidato"].ToString());

                if (dr["CodNacimiento"] != DBNull.Value)
                {
                    beEmpleado.UbigeoNacimiento = new BE.Ubigeo()
                    {
                        Codigo = dr["CodNacimiento"].ToString()
                    };
                }

                if (dr["CodPais"] != DBNull.Value)
                {
                    beEmpleado.PaisNacimiento = new BE.Pais()
                    {
                        Codigo = dr["CodPais"].ToString(),
                        Nombre = dr["DscPais"].ToString()
                    };
                }

                if (dr["CodSexo"] != DBNull.Value)
                {
                    beEmpleado.Sexo = new BE.Record()
                    {
                        Codigo = dr["CodSexo"].ToString(),
                        Nombre = dr["DscSexo"].ToString()
                    };
                }

                if (dr["CodEstadoCivil"] != DBNull.Value)
                {
                    beEmpleado.EstadoCivil = new BE.Record()
                    {
                        Codigo = dr["CodEstadoCivil"].ToString(),
                        Nombre = dr["DscEstadoCivil"].ToString()
                    };
                }

                if (dr["CodDocumentoIdentidad"] != DBNull.Value)
                {
                    beEmpleado.TipoDocumento = new BE.Record()
                    {
                        Codigo = dr["CodDocumentoIdentidad"].ToString(),
                        Nombre = dr["DscDocumentoIdentidad"].ToString()
                    };
                }

                return beEmpleado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insertar(ref BE.ClsBeTbEmpleado beEmpleado)
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

                    //General
                    sp = "SpTbEmpleadoGeneralInsertar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", beEmpleado.IdEmpleado));
                    cmd.Parameters["@IDEMPLEADO"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", beEmpleado.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRES", beEmpleado.Nombres));
                    cmd.Parameters.Add(new SqlParameter("@APELLIDOPATERNO", beEmpleado.ApellidoPaterno));
                    cmd.Parameters.Add(new SqlParameter("@APELLIDOMATERNO", beEmpleado.ApellidoMaterno));
                    cmd.Parameters.Add(new SqlParameter("@FECHANACIMIENTO", beEmpleado.FechaNacimiento));
                    cmd.Parameters.Add(new SqlParameter("@CODSEXO", beEmpleado.Sexo.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@CODDOCUMENTOIDENTIDAD", beEmpleado.TipoDocumento.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@NUMERODOCUMENTO", beEmpleado.NumeroDocumento));
                    cmd.Parameters.Add(new SqlParameter("@CODPAIS", beEmpleado.PaisNacimiento.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@CODESTADOCIVIL", beEmpleado.EstadoCivil.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@ACTIVO", beEmpleado.Activo));
                    cmd.Parameters.Add(new SqlParameter("@CODNACIMIENTO", beEmpleado.UbigeoNacimiento.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", beEmpleado.IdCandidato));

                    rowsAffected += cmd.ExecuteNonQuery();
                    beEmpleado.IdEmpleado = int.Parse(cmd.Parameters["@IDEMPLEADO"].Value.ToString());

                    //Contacto
                    sp = "SpTbEmpleadoContactoInsertar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", beEmpleado.Contacto.IdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@CODUBIGEO", beEmpleado.Contacto.Ubigeo.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@ZONA", beEmpleado.Contacto.Zona));
                    cmd.Parameters.Add(new SqlParameter("@DIRECCION", beEmpleado.Contacto.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@REFERENCIA", beEmpleado.Contacto.Referencia));
                    cmd.Parameters.Add(new SqlParameter("@EMAIL", beEmpleado.Contacto.Email));

                    rowsAffected += cmd.ExecuteNonQuery();

                    //Telefonos
                    sp = "SpTbEmpleadoTelefonoInsertar";
                    foreach (var telefono in beEmpleado.Telefonos)
                    {

                        cmd = new SqlCommand(sp, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDEMPLEADOTELEFONO", telefono.IdEmpleadoTelefono));
                        cmd.Parameters["@IDEMPLEADOTELEFONO"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", telefono.IdEmpleado));
                        cmd.Parameters.Add(new SqlParameter("@CODTIPOTELEFONO", telefono.CodTipoTelefono));
                        cmd.Parameters.Add(new SqlParameter("@NUMERO", telefono.Numero));

                        rowsAffected += cmd.ExecuteNonQuery();
                        telefono.IdEmpleadoTelefono = Convert.ToInt32(cmd.Parameters["@IDEMPLEADOTELEFONO"].Value.ToString());

                    }

                    //Recurso
                    sp = "SpTbEmpleadoRecursoInsertar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", beEmpleado.Recurso.IdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@IDAREA", beEmpleado.Recurso.Area.IdArea));
                    cmd.Parameters.Add(new SqlParameter("@IDCARGO", beEmpleado.Recurso.Cargo.IdCargo));
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", beEmpleado.Recurso.Sala.IdSala));
                    cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", beEmpleado.Recurso.FechaInicio));

                    cmd.Parameters.Add(new SqlParameter("@CESADO", beEmpleado.Recurso.Cesado));
                    if (beEmpleado.Recurso.Cesado == true)
                        cmd.Parameters.Add(new SqlParameter("@FECHACESE", beEmpleado.Recurso.FechaCese));
                    else
                        cmd.Parameters.Add(new SqlParameter("@FECHACESE", DBNull.Value));

                    cmd.Parameters.Add(new SqlParameter("@NUMEROHIJOS", beEmpleado.Recurso.NumeroHijos));
                    cmd.Parameters.Add(new SqlParameter("@IDBANCO", beEmpleado.Recurso.Banco.IdBanco));
                    cmd.Parameters.Add(new SqlParameter("@CUENTABANCO", beEmpleado.Recurso.CuentaBanco));
                    cmd.Parameters.Add(new SqlParameter("@CCI", beEmpleado.Recurso.CCI));
                    cmd.Parameters.Add(new SqlParameter("@ONP", beEmpleado.Recurso.ONP));

                    if (beEmpleado.Recurso.Afp != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@IDAFP", beEmpleado.Recurso.Afp.IdAfp));
                        cmd.Parameters.Add(new SqlParameter("@CUSPP", beEmpleado.Recurso.CUSPP));
                        cmd.Parameters.Add(new SqlParameter("@CODCOMISION", beEmpleado.Recurso.CodComision));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@IDAFP", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@CUSPP", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@CODCOMISION", DBNull.Value));
                    }

                    cmd.Parameters.Add(new SqlParameter("@IDBANCOCTS", beEmpleado.Recurso.BancoCTS.IdBanco));
                    cmd.Parameters.Add(new SqlParameter("@CUENTACTS", beEmpleado.Recurso.CuentaCTS));
                    cmd.Parameters.Add(new SqlParameter("@SUELDO", beEmpleado.Recurso.Sueldo));
                    cmd.Parameters.Add(new SqlParameter("@RETENCIONJUDICIALNOMINAL", beEmpleado.Recurso.RetencionJudicialNominal));
                    cmd.Parameters.Add(new SqlParameter("@RETENCIONJUDICIALPORCENTUAL", beEmpleado.Recurso.RetencionJudicialPorcentual));

                    if (beEmpleado.Recurso.FechaUltimaVacacion != null)
                        cmd.Parameters.Add(new SqlParameter("@FECHAULTIMAVACACION", beEmpleado.Recurso.FechaUltimaVacacion));
                    else
                        cmd.Parameters.Add(new SqlParameter("@FECHAULTIMAVACACION", DBNull.Value));

                    cmd.Parameters.Add(new SqlParameter("@AUTOGENERADO", beEmpleado.Recurso.Autogenerado));

                    rowsAffected += cmd.ExecuteNonQuery();

                    if (tns != null)
                        tns.Commit();
                }   

                return rowsAffected;

            }
            catch (Exception ex)
            {
                if(tns != null)
                    tns.Rollback();

                throw ex;
            }
        }

        /// <summary>
        /// Actualiza solo datos generales
        /// </summary>
        /// <param name="beEmpleado">Objeto Empleado</param>
        /// <returns></returns>
        public int Actualizar(BE.ClsBeTbEmpleado beEmpleado)
        {
            SqlConnection cnn = null;
            SqlTransaction tns = null;
            SqlCommand cmd = null;

            try
            {

                int rowsAffected = 0;
                string sp = "";

                using (cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    tns = cnn.BeginTransaction();

                    //GENERAL

                    sp = "SpTbEmpleadoGeneralActualizar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", beEmpleado.IdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", beEmpleado.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRES", beEmpleado.Nombres));
                    cmd.Parameters.Add(new SqlParameter("@APELLIDOPATERNO", beEmpleado.ApellidoPaterno));
                    cmd.Parameters.Add(new SqlParameter("@APELLIDOMATERNO", beEmpleado.ApellidoMaterno));
                    cmd.Parameters.Add(new SqlParameter("@FECHANACIMIENTO", beEmpleado.FechaNacimiento));
                    cmd.Parameters.Add(new SqlParameter("@CODSEXO", beEmpleado.Sexo.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@CODDOCUMENTOIDENTIDAD", beEmpleado.TipoDocumento.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@NUMERODOCUMENTO", beEmpleado.NumeroDocumento));
                    cmd.Parameters.Add(new SqlParameter("@CODPAIS", beEmpleado.PaisNacimiento.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@CODESTADOCIVIL", beEmpleado.EstadoCivil.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@ACTIVO", beEmpleado.Activo));
                    cmd.Parameters.Add(new SqlParameter("@CODNACIMIENTO", beEmpleado.UbigeoNacimiento.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@IDCANDIDATO", beEmpleado.IdCandidato));

                    rowsAffected += cmd.ExecuteNonQuery();

                    //CONTACTO

                    sp = "SpTbEmpleadoContactoActualizar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", beEmpleado.Contacto.IdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@CODUBIGEO", beEmpleado.Contacto.Ubigeo.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@ZONA", beEmpleado.Contacto.Zona));
                    cmd.Parameters.Add(new SqlParameter("@DIRECCION", beEmpleado.Contacto.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@REFERENCIA", beEmpleado.Contacto.Referencia));
                    cmd.Parameters.Add(new SqlParameter("@EMAIL", beEmpleado.Contacto.Email));

                    rowsAffected += cmd.ExecuteNonQuery();

                    //TELEFONOS

                    sp = "SpTbEmpleadoTelefonoActualizar";
                    foreach (var telefono in beEmpleado.Telefonos)
                    {

                        cmd = new SqlCommand(sp, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDEMPLEADOTELEFONO", telefono.IdEmpleadoTelefono));
                        cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", telefono.IdEmpleado));
                        cmd.Parameters.Add(new SqlParameter("@CODTIPOTELEFONO", telefono.CodTipoTelefono));
                        cmd.Parameters.Add(new SqlParameter("@NUMERO", telefono.Numero));

                        rowsAffected += cmd.ExecuteNonQuery();
                        telefono.IdEmpleadoTelefono = Convert.ToInt32(cmd.Parameters["@IDEMPLEADOTELEFONO"].Value.ToString());

                    }

                    //RECURSO

                    sp = "SpTbEmpleadoRecursoActualizar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", beEmpleado.Recurso.IdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@IDAREA", beEmpleado.Recurso.Area.IdArea));
                    cmd.Parameters.Add(new SqlParameter("@IDCARGO", beEmpleado.Recurso.Cargo.IdCargo));
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", beEmpleado.Recurso.Sala.IdSala));
                    cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", beEmpleado.Recurso.FechaInicio));

                    cmd.Parameters.Add(new SqlParameter("@CESADO", beEmpleado.Recurso.Cesado));
                    if (beEmpleado.Recurso.Cesado == true)
                        cmd.Parameters.Add(new SqlParameter("@FECHACESE", beEmpleado.Recurso.FechaCese));
                    else
                        cmd.Parameters.Add(new SqlParameter("@FECHACESE", DBNull.Value));

                    cmd.Parameters.Add(new SqlParameter("@NUMEROHIJOS", beEmpleado.Recurso.NumeroHijos));
                    cmd.Parameters.Add(new SqlParameter("@IDBANCO", beEmpleado.Recurso.Banco.IdBanco));
                    cmd.Parameters.Add(new SqlParameter("@CUENTABANCO", beEmpleado.Recurso.CuentaBanco));
                    cmd.Parameters.Add(new SqlParameter("@CCI", beEmpleado.Recurso.CCI));
                    cmd.Parameters.Add(new SqlParameter("@ONP", beEmpleado.Recurso.ONP));

                    if (beEmpleado.Recurso.Afp != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@IDAFP", beEmpleado.Recurso.Afp.IdAfp));
                        cmd.Parameters.Add(new SqlParameter("@CUSPP", beEmpleado.Recurso.CUSPP));
                        cmd.Parameters.Add(new SqlParameter("@CODCOMISION", beEmpleado.Recurso.CodComision));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@IDAFP", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@CUSPP", DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@CODCOMISION", DBNull.Value));
                    }

                    cmd.Parameters.Add(new SqlParameter("@IDBANCOCTS", beEmpleado.Recurso.BancoCTS.IdBanco));
                    cmd.Parameters.Add(new SqlParameter("@CUENTACTS", beEmpleado.Recurso.CuentaCTS));
                    cmd.Parameters.Add(new SqlParameter("@SUELDO", beEmpleado.Recurso.Sueldo));
                    cmd.Parameters.Add(new SqlParameter("@RETENCIONJUDICIALNOMINAL", beEmpleado.Recurso.RetencionJudicialNominal));
                    cmd.Parameters.Add(new SqlParameter("@RETENCIONJUDICIALPORCENTUAL", beEmpleado.Recurso.RetencionJudicialPorcentual));

                    if (beEmpleado.Recurso.FechaUltimaVacacion != null)
                        cmd.Parameters.Add(new SqlParameter("@FECHAULTIMAVACACION", beEmpleado.Recurso.FechaUltimaVacacion));
                    else
                        cmd.Parameters.Add(new SqlParameter("@FECHAULTIMAVACACION", DBNull.Value));

                    cmd.Parameters.Add(new SqlParameter("@AUTOGENERADO", beEmpleado.Recurso.Autogenerado));

                    rowsAffected += cmd.ExecuteNonQuery();

                    if (tns != null)
                        tns.Commit();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                if (tns != null)
                    tns.Rollback();

                throw ex;
            }
        }
        
        public int Eliminar( BE.ClsBeTbEmpleado beEmpleado)
        {

            SqlConnection cnn = null;
            SqlTransaction tns = null;
            SqlCommand cmd = null;

            try
            {

                int rowsAffected = 0;
                string sp = "";

                using (cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    tns = cnn.BeginTransaction();

                    //Contacto
                    sp = "SpTbEmpleadoContactoEliminar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", beEmpleado.IdEmpleado));

                    rowsAffected += cmd.ExecuteNonQuery();

                    //Recurso
                    sp = "SpTbEmpleadoRecursoEliminar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", beEmpleado.IdEmpleado));

                    rowsAffected += cmd.ExecuteNonQuery();

                    //Telefonos
                    sp = "SpTbEmpleadoTelefonoEliminar";

                    foreach (var telefono in beEmpleado.Telefonos)
                    {

                        cmd = new SqlCommand(sp, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDEMPLEADOTELEFONO", telefono.IdEmpleadoTelefono));

                        rowsAffected += cmd.ExecuteNonQuery();

                    }

                    //General
                    sp = "SpTbEmpleadoGeneralEliminar";

                    cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = tns;

                    cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", beEmpleado.IdEmpleado));

                    rowsAffected += cmd.ExecuteNonQuery();

                    if (tns != null)
                        tns.Commit();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                if (tns != null)
                    tns.Rollback();

                throw ex;
            }
        }

        public DataTable ListarVacaciones(DateTime fecha)
        {
            try
            {
                string sp = "SpTbEmpleadoListarVacaciones";
                DataTable dt = new DataTable();

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@FECHA", fecha));

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

        public DataTable ListaSimple()
        {
            try
            {
                string sp = "SpTbEmpleadoListaSimple";
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

        public DataTable Listar()
        {
            try
            {
                string sp = "SpTbEmpleadoListar";
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
                string sp = "SpTbEmpleadoComboNombres";
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

        public string ObtenerNombreCompleto(string codigo, bool? activo = null)
        {
            string nombreCompleto = "";

            try
            {
                string sp = "SpObtenerNombreCompleto";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    if (activo != null)
                        cmd.Parameters.Add(new SqlParameter("@ACTIVO", activo));

                    nombreCompleto = cmd.ExecuteScalar().ToString();

                    cnn.Close();
                }

                return nombreCompleto;
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
                string sp = "SpTbEmpleadoGeneralObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@IDEMPLEADO", idEmpleado));

                    DataTable dt = new DataTable();
                    dad.Fill(dt);

                    if ((dt.Rows.Count == 1))
                    {
                        DataRow dr = dt.Rows[0];

                        beEmpleado = this.Cargar(dr);

                        var oBeUbigeoNacimiento = beEmpleado.UbigeoNacimiento;
                        new Ubigeo().Obtener(ref oBeUbigeoNacimiento);
                        beEmpleado.UbigeoNacimiento = oBeUbigeoNacimiento;

                    }

                    cnn.Close();
                }

                return beEmpleado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtener los datos del empleados sin detalle de Recurso o Contacto
        /// Tampoco obtiene la descripción de los tipos (Pais, Tipo Documento, Estado Civil, etc)
        /// </summary>
        /// <param name="codigo">Codigo de Empleado</param>
        /// <returns></returns>
        public BE.ClsBeTbEmpleado Obtener(string codigo)
        {
            BE.ClsBeTbEmpleado beEmpleado = null;
            SqlConnection cnn = null;
            try
            {
                string sp = "SpTbEmpleadoGeneralObtenerCodigo";

                using (cnn = new SqlConnection(ConnectionManager.ConexionLocal))
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

                        beEmpleado = new BE.ClsBeTbEmpleado();
                        beEmpleado.IdEmpleado = dr["IdEmpleado"] == DBNull.Value ? 0 : int.Parse(dr["IdEmpleado"].ToString());
                        beEmpleado.Codigo = dr["Codigo"] == DBNull.Value ? "" : dr["Codigo"].ToString();
                        beEmpleado.Nombres = dr["Nombres"] == DBNull.Value ? "" : dr["Nombres"].ToString();
                        beEmpleado.ApellidoPaterno = dr["ApellidoPaterno"] == DBNull.Value ? "" : dr["ApellidoPaterno"].ToString();
                        beEmpleado.ApellidoMaterno = dr["ApellidoMaterno"] == DBNull.Value ? "" : dr["ApellidoMaterno"].ToString();
                        beEmpleado.FechaNacimiento = dr["FechaNacimiento"] == DBNull.Value ? DateTime.Now.AddYears(-18) : DateTime.Parse(dr["FechaNacimiento"].ToString());
                        beEmpleado.NumeroDocumento = dr["NumeroDocumento"] == DBNull.Value ? "" : dr["NumeroDocumento"].ToString();
                        beEmpleado.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
                        beEmpleado.UbigeoNacimiento = new BE.Ubigeo()
                        {
                            Codigo = dr["CodNacimiento"] == DBNull.Value ? "" : dr["CodNacimiento"].ToString()
                        };
                        beEmpleado.PaisNacimiento = new BE.Pais()
                        {
                            Codigo = dr["CodPais"] == DBNull.Value ? "" : dr["CodPais"].ToString()
                        };
                        beEmpleado.Sexo = new BE.Record()
                        {
                            Codigo = dr["CodSexo"] == DBNull.Value ? "" : dr["CodSexo"].ToString()
                        };
                        beEmpleado.EstadoCivil = new BE.Record()
                        {
                            Codigo = dr["CodEstadoCivil"] == DBNull.Value ? "" : dr["CodEstadoCivil"].ToString()
                        };
                        beEmpleado.TipoDocumento = new BE.Record()
                        {
                            Codigo = dr["CodDocumentoIdentidad"] == DBNull.Value ? "" : dr["CodDocumentoIdentidad"].ToString()
                        };
                    }
                }

                return beEmpleado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn != null)
                    cnn.Close();
            }
        }

        public bool ValidarCodigo(int idEmpleado, string codigo)
        {
            bool rpta = false;
            try
            {
                string sp = "SpTbEmpleadoGeneralValidarCodigo";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (idEmpleado > 0)
                        cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", idEmpleado));
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

        public bool ValidarDocumento(string codDocumento, string numDocumento, int idEmpleado = 0)
        {
            bool rpta = false;
            try
            {
                string sp = "SpTbEmpleadoGeneralValidarDocumento";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (idEmpleado > 0)
                        cmd.Parameters.Add(new SqlParameter("@IDEMPLEADO", idEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@CODDOCUMENTOIDENTIDAD", codDocumento));
                    cmd.Parameters.Add(new SqlParameter("@NUMERODOCUMENTO", numDocumento));

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


        internal int Vacacion(string codigo, DateTime? fecha = null)
        {
            try
            {
                string sp = "SpTbEmpleadoRecursoVacacion";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));

                    if (fecha != null)
                        cmd.Parameters.Add(new SqlParameter("@FECHAVACACION", (DateTime)fecha));
                    else
                        cmd.Parameters.Add(new SqlParameter("@FECHAVACACION", DBNull.Value));

                    rowsAffected = cmd.ExecuteNonQuery();

                    cnn.Close();
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

