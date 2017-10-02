using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Banco
    {

        public void Cargar(ref BE.Banco oBeTbBanco, ref DataRow dr)
        {
            try
            {
                oBeTbBanco.IdBanco = dr["IdBanco"] == DBNull.Value ? 0 : int.Parse(dr["IdBanco"].ToString());
                oBeTbBanco.Codigo = dr["Codigo"] == DBNull.Value ? "" : dr["Codigo"].ToString();
                oBeTbBanco.Nombre = dr["Nombre"] == DBNull.Value ? "" : dr["Nombre"].ToString();
                oBeTbBanco.Descripcion = dr["Descripcion"] == DBNull.Value ? "" : dr["Descripcion"].ToString();
                oBeTbBanco.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insertar(ref BE.Banco oBeTbBanco)
        {
            try
            {
                string sp = "SpTbBancoInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDBANCO", oBeTbBanco.IdBanco));
                cmd.Parameters["@IDBANCO"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@CODIGO", oBeTbBanco.Codigo));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", oBeTbBanco.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeTbBanco.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", oBeTbBanco.Activo));

                rowsAffected = cmd.ExecuteNonQuery();
                oBeTbBanco.IdBanco = int.Parse(cmd.Parameters["@IDBANCO"].Value.ToString());

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(ref BE.Banco oBeTbBanco)
        {
            try
            {
                string sp = "SpTbBancoActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDBANCO", oBeTbBanco.IdBanco));
                cmd.Parameters.Add(new SqlParameter("@CODIGO", oBeTbBanco.Codigo));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", oBeTbBanco.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeTbBanco.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", oBeTbBanco.Activo));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(BE.Banco oBeTbBanco)
        {
            try
            {
                string sp = "SpTbBancoEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDBANCO", oBeTbBanco.IdBanco));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar(BE.Banco oBeTbBanco)
        {
            try
            {
                string sp = "SpTbBancoListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@CODIGO", oBeTbBanco.Codigo));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@NOMBRE", oBeTbBanco.Nombre));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeTbBanco.Descripcion));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@ACTIVO", oBeTbBanco.Activo));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Obtener(ref BE.Banco oBeTbBanco)
        {
            try
            {
                string sp = "SpTbBancoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDBANCO", oBeTbBanco.IdBanco));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref oBeTbBanco, ref dr);
                }
                else
                {
                    return false;
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
