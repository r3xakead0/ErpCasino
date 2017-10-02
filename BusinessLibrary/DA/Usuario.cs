using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.DA
{

    public class Usuario
    {


        public bool Validar(ref BE.Usuario beUsuario)
        {
            bool flag = false;
            try
            {
                string sp = "SpTbUsuarioValidar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@USUARIO", beUsuario.Username));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@CONTRASENHA", beUsuario.Password));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref beUsuario, dr);
                    flag = true;
                }

                return flag;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cargar(ref BE.Usuario beUsuario, DataRow dr)
        {

            try
            {

                beUsuario.IdUsuario = dr["IdUsuario"] == DBNull.Value ? 0 : int.Parse(dr["IdUsuario"].ToString());
                beUsuario.Username = dr["Usuario"] == DBNull.Value ? "" : dr["Usuario"].ToString();
                beUsuario.Nombre = dr["Nombre"] == DBNull.Value ? "" : dr["Nombre"].ToString();
                beUsuario.Email = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString();
                beUsuario.Password = dr["Contrasenha"] == DBNull.Value ? "" : dr["Contrasenha"].ToString();
                beUsuario.Bloqueado = dr["Bloqueado"] == DBNull.Value ? false : bool.Parse(dr["Bloqueado"].ToString());
                beUsuario.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
                beUsuario.IdUsuarioCreador = dr["IdUsuarioCreador"] == DBNull.Value ? 0 : int.Parse(dr["IdUsuarioCreador"].ToString());
                beUsuario.FechaCreacion = dr["FechaCreacion"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["FechaCreacion"].ToString());
                beUsuario.IdUsuarioModificador = dr["IdUsuarioModificador"] == DBNull.Value ? 0 : int.Parse(dr["IdUsuarioModificador"].ToString());
                beUsuario.FechaModificacion = dr["FechaModificacion"] == DBNull.Value ? null : (DateTime?)DateTime.Parse(dr["FechaModificacion"].ToString());

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

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

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

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(ref BE.Usuario beUsuario)
        {
            try
            {
                string sp = "SpTbUsuarioActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", beUsuario.IdUsuario));
                cmd.Parameters.Add(new SqlParameter("@USUARIO", beUsuario.Username));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", beUsuario.Nombre));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", beUsuario.Email));
                cmd.Parameters.Add(new SqlParameter("@CONTRASENHA", beUsuario.Password));
                cmd.Parameters.Add(new SqlParameter("@BLOQUEADO", beUsuario.Bloqueado));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beUsuario.Activo));
                cmd.Parameters.Add(new SqlParameter("@IDUSUARIOMODIFICADOR", beUsuario.IdUsuarioModificador));

                rowsAffected = cmd.ExecuteNonQuery();

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

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", idUsuario));

                rowsAffected = cmd.ExecuteNonQuery();

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

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dad.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    var beUsuario = new BE.Usuario();
                    this.Cargar(ref beUsuario, dr);
                    lstBeUsuarios.Add(beUsuario);
                }

                return lstBeUsuarios;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Obtener(ref BE.Usuario beUsuario)
        {
            bool flag = false;
            try
            {
                string sp = "SpTbUsuarioObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDUSUARIO", beUsuario.IdUsuario));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref beUsuario, dr);
                    flag = true;
                }

                return flag;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}