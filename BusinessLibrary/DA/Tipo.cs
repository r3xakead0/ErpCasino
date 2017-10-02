using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{

    public class Tipo
    {

        public void Cargar(ref BE.Tipo beTipo, ref DataRow dr)
        {
            try
            {
                if (dr["IdTipo"] == DBNull.Value)
                {
                    beTipo.IdTipo = 0;
                }
                else
                {
                    beTipo.IdTipo = int.Parse(dr["IdTipo"].ToString());
                }
                beTipo.IdTipo = dr["IdTipo"] == DBNull.Value ? 0 : int.Parse(dr["IdTipo"].ToString());
                beTipo.Nombre = dr["Nombre"] == DBNull.Value ? "" : dr["Nombre"].ToString();
                beTipo.Descripcion = dr["Descripcion"] == DBNull.Value ? "" : dr["Descripcion"].ToString();
                beTipo.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insertar(ref BE.Tipo beTipo)
        {
            try
            {
                string sp = "SpTbTipoInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDTIPO", beTipo.IdTipo));
                cmd.Parameters["@IDTIPO"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", beTipo.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beTipo.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beTipo.Activo));

                rowsAffected = cmd.ExecuteNonQuery();
                beTipo.IdTipo = int.Parse(cmd.Parameters["@IDTIPO"].Value.ToString());

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(ref BE.Tipo beTipo)
        {
            try
            {
                string sp = "SpTbTipoActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDTIPO", beTipo.IdTipo));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", beTipo.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beTipo.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beTipo.Activo));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(ref BE.Tipo beTipo)
        {
            try
            {
                string sp = "SpTbTipoEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDTIPO", beTipo.IdTipo));

                rowsAffected = cmd.ExecuteNonQuery();

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
                string sp = "SpTbTipoListar";

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

        public bool Obtener(ref BE.Tipo beTipo)
        {
            try
            {
                string sp = "SpTbTipoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDTIPO", beTipo.IdTipo));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref beTipo, ref dr);
                }
                else
                {
                    throw new Exception("No se pudo obtener el registro");
                }

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
