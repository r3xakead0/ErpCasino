using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{

    public class Afp
    {

        public void Cargar(ref BE.Afp beAfp, ref DataRow dr)
        {
            try
            {
                beAfp.IdAfp = dr["IdAfp"] == DBNull.Value ? 0 : int.Parse(dr["IdAfp"].ToString());
                beAfp.Codigo = dr["Codigo"] == DBNull.Value ? "" : dr["Codigo"].ToString();
                beAfp.Nombre = dr["Nombre"] == DBNull.Value ? "" : dr["Nombre"].ToString();
                beAfp.Descripcion = dr["Descripcion"] == DBNull.Value ? "" : dr["Descripcion"].ToString();
                beAfp.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insertar(ref BE.Afp beAfp)
        {
            try
            {
                int rowsAffected = 0;
                string sp = "SpTbAfpInsertar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDAFP", beAfp.IdAfp));
                    cmd.Parameters["@IDAFP"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", beAfp.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", beAfp.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beAfp.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@ACTIVO", beAfp.Activo));

                    rowsAffected = cmd.ExecuteNonQuery();
                    beAfp.IdAfp = int.Parse(cmd.Parameters["@IDAFP"].Value.ToString());
                }
                    
                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(ref BE.Afp beAfp)
        {
            try
            {
                string sp = "SpTbAfpActualizar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDAFP", beAfp.IdAfp));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", beAfp.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", beAfp.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beAfp.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@ACTIVO", beAfp.Activo));

                    rowsAffected = cmd.ExecuteNonQuery();
                }
                    
                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idAfp)
        {
            try
            {
                int rowsAffected = 0;
                string sp = "SpTbAfpEliminar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDAFP", idAfp));

                    rowsAffected = cmd.ExecuteNonQuery();
           
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar(BE.Afp beAfp)
        {
            try
            {
                string sp = "SpTbAfpListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@CODIGO", beAfp.Codigo));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@NOMBRE", beAfp.Nombre));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@DESCRIPCION", beAfp.Descripcion));
                dad.SelectCommand.Parameters.Add(new SqlParameter("@ACTIVO", beAfp.Activo));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Obtener(ref BE.Afp beAfp)
        {
            bool flag = false;
            try
            {
                string sp = "SpTbAfpObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDAFP", beAfp.IdAfp));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref beAfp, ref dr);
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
