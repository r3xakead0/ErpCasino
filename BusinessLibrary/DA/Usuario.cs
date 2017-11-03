using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.DA
{

    public class Usuario
    {


        public BE.Usuario Validar(string username, string password)
        {
            BE.Usuario beUsuario = null;
            try
            {
                string sp = "SpTbUsuarioValidar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@USUARIO", username));
                    cmd.Parameters.Add(new SqlParameter("@CONTRASENHA", password));
    
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beUsuario = new BE.Usuario();

                        beUsuario.IdUsuario = reader["IdUsuario"] == DBNull.Value ? 0 : int.Parse(reader["IdUsuario"].ToString());
                        beUsuario.Username = reader["Usuario"] == DBNull.Value ? "" : reader["Usuario"].ToString();
                        beUsuario.Nombre = reader["Nombre"] == DBNull.Value ? "" : reader["Nombre"].ToString();
                        beUsuario.Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();
                        beUsuario.Password = reader["Contrasenha"] == DBNull.Value ? "" : reader["Contrasenha"].ToString();
                        beUsuario.Bloqueado = reader["Bloqueado"] == DBNull.Value ? false : bool.Parse(reader["Bloqueado"].ToString());
                        beUsuario.Activo = reader["Activo"] == DBNull.Value ? false : bool.Parse(reader["Activo"].ToString());
                        beUsuario.IdUsuarioCreador = reader["IdUsuarioCreador"] == DBNull.Value ? 0 : int.Parse(reader["IdUsuarioCreador"].ToString());
                        beUsuario.FechaCreacion = reader["FechaCreacion"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["FechaCreacion"].ToString());
                        beUsuario.IdUsuarioModificador = reader["IdUsuarioModificador"] == DBNull.Value ? 0 : int.Parse(reader["IdUsuarioModificador"].ToString());
                        beUsuario.FechaModificacion = reader["FechaModificacion"] == DBNull.Value ? null : (DateTime?)DateTime.Parse(reader["FechaModificacion"].ToString());
                        
                    }
                }
                  
                return beUsuario;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int Insertar(ref BE.Usuario beUsuario)
        {
            try
            {
                string sp = "SpTbUsuarioInsertar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", beUsuario.IdUsuario));
                    cmd.Parameters["@IDUSUARIO"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@USUARIO", beUsuario.Username));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", beUsuario.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@EMAIL", beUsuario.Email));
                    cmd.Parameters.Add(new SqlParameter("@CONTRASENHA", beUsuario.Password));
                    cmd.Parameters.Add(new SqlParameter("@BLOQUEADO", beUsuario.Bloqueado));
                    cmd.Parameters.Add(new SqlParameter("@ACTIVO", beUsuario.Activo));
                    cmd.Parameters.Add(new SqlParameter("@IDUSUARIOCREADOR", beUsuario.IdUsuarioCreador));

                    rowsAffected = cmd.ExecuteNonQuery();
                    beUsuario.IdUsuario = int.Parse(cmd.Parameters["@IDUSUARIO"].Value.ToString());

                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.Usuario beUsuario)
        {
            try
            {
                string sp = "SpTbUsuarioActualizar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", beUsuario.IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@USUARIO", beUsuario.Username));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", beUsuario.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@EMAIL", beUsuario.Email));
                    cmd.Parameters.Add(new SqlParameter("@CONTRASENHA", beUsuario.Password));
                    cmd.Parameters.Add(new SqlParameter("@BLOQUEADO", beUsuario.Bloqueado));
                    cmd.Parameters.Add(new SqlParameter("@ACTIVO", beUsuario.Activo));
                    cmd.Parameters.Add(new SqlParameter("@IDUSUARIOMODIFICADOR", beUsuario.IdUsuarioModificador));

                    rowsAffected += cmd.ExecuteNonQuery();
                }
                   
                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idUsuario)
        {
            try
            {
                string sp = "SpTbUsuarioEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", idUsuario));

                    rowsAffected = cmd.ExecuteNonQuery();
                }
                   
                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Usuario> Listar()
        {

            var lstBeUsuarios = new List<BE.Usuario>();

            try
            {
                string sp = "SpTbUsuarioListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beUsuario = new BE.Usuario();

                        beUsuario.IdUsuario = reader["IdUsuario"] == DBNull.Value ? 0 : int.Parse(reader["IdUsuario"].ToString());
                        beUsuario.Username = reader["Usuario"] == DBNull.Value ? "" : reader["Usuario"].ToString();
                        beUsuario.Nombre = reader["Nombre"] == DBNull.Value ? "" : reader["Nombre"].ToString();
                        beUsuario.Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();
                        beUsuario.Password = reader["Contrasenha"] == DBNull.Value ? "" : reader["Contrasenha"].ToString();
                        beUsuario.Bloqueado = reader["Bloqueado"] == DBNull.Value ? false : bool.Parse(reader["Bloqueado"].ToString());
                        beUsuario.Activo = reader["Activo"] == DBNull.Value ? false : bool.Parse(reader["Activo"].ToString());
                        beUsuario.IdUsuarioCreador = reader["IdUsuarioCreador"] == DBNull.Value ? 0 : int.Parse(reader["IdUsuarioCreador"].ToString());
                        beUsuario.FechaCreacion = reader["FechaCreacion"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["FechaCreacion"].ToString());
                        beUsuario.IdUsuarioModificador = reader["IdUsuarioModificador"] == DBNull.Value ? 0 : int.Parse(reader["IdUsuarioModificador"].ToString());
                        beUsuario.FechaModificacion = reader["FechaModificacion"] == DBNull.Value ? null : (DateTime?)DateTime.Parse(reader["FechaModificacion"].ToString());

                        lstBeUsuarios.Add(beUsuario);
                    }

                }

                return lstBeUsuarios;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Usuario Obtener(int idUsuario)
        {
            BE.Usuario beUsuario = null;
            try
            {
                string sp = "SpTbUsuarioObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", idUsuario));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beUsuario = new BE.Usuario();

                        beUsuario.IdUsuario = reader["IdUsuario"] == DBNull.Value ? 0 : int.Parse(reader["IdUsuario"].ToString());
                        beUsuario.Username = reader["Usuario"] == DBNull.Value ? "" : reader["Usuario"].ToString();
                        beUsuario.Nombre = reader["Nombre"] == DBNull.Value ? "" : reader["Nombre"].ToString();
                        beUsuario.Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();
                        beUsuario.Password = reader["Contrasenha"] == DBNull.Value ? "" : reader["Contrasenha"].ToString();
                        beUsuario.Bloqueado = reader["Bloqueado"] == DBNull.Value ? false : bool.Parse(reader["Bloqueado"].ToString());
                        beUsuario.Activo = reader["Activo"] == DBNull.Value ? false : bool.Parse(reader["Activo"].ToString());
                        beUsuario.IdUsuarioCreador = reader["IdUsuarioCreador"] == DBNull.Value ? 0 : int.Parse(reader["IdUsuarioCreador"].ToString());
                        beUsuario.FechaCreacion = reader["FechaCreacion"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["FechaCreacion"].ToString());
                        beUsuario.IdUsuarioModificador = reader["IdUsuarioModificador"] == DBNull.Value ? 0 : int.Parse(reader["IdUsuarioModificador"].ToString());
                        beUsuario.FechaModificacion = reader["FechaModificacion"] == DBNull.Value ? null : (DateTime?)DateTime.Parse(reader["FechaModificacion"].ToString());

                    }
                }

                return beUsuario;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}