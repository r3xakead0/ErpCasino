using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Adelanto
    {

        public int Insertar(ref List<BE.Adelanto> lstBeAdelantos)
        {
            SqlConnection cnn = null;
            SqlTransaction tns = null;
            SqlCommand cmd = null;

            try
            {
                int rowsAffected = 0;
                string sp = "SpTbAdelantoInsertar";
               
                using (cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();
                    tns = cnn.BeginTransaction();

                    for (int i = 0; i < lstBeAdelantos.Count; i++)
                    {
                        var beAdelanto = lstBeAdelantos[i];

                        cmd = new SqlCommand(sp, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tns;

                        cmd.Parameters.Add(new SqlParameter("@IDADELANTO", beAdelanto.IdAdelanto));
                        cmd.Parameters["@IDADELANTO"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@FECHA", beAdelanto.Fecha));
                        cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beAdelanto.CodigoEmpleado));
                        cmd.Parameters.Add(new SqlParameter("@TIPO", beAdelanto.Tipo));
                        if (beAdelanto.IdBanco == 0)
                            cmd.Parameters.Add(new SqlParameter("@IDBANCO", DBNull.Value));
                        else
                            cmd.Parameters.Add(new SqlParameter("@IDBANCO", beAdelanto.IdBanco));
                        cmd.Parameters.Add(new SqlParameter("@NUMERO", beAdelanto.Numero));
                        cmd.Parameters.Add(new SqlParameter("@MONTO", beAdelanto.Monto));

                        rowsAffected += cmd.ExecuteNonQuery();
                        lstBeAdelantos[i].IdAdelanto = int.Parse(cmd.Parameters["@IDADELANTO"].Value.ToString());

                    }

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

        public int Insertar(ref BE.Adelanto beAdelanto)
        {
            try
            {
                int rowsAffected = 0;
                string sp = "SpTbAdelantoInsertar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDADELANTO", beAdelanto.IdAdelanto));
                    cmd.Parameters["@IDADELANTO"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@FECHA", beAdelanto.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beAdelanto.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@TIPO", beAdelanto.Tipo));
                    if (beAdelanto.IdBanco == 0)
                        cmd.Parameters.Add(new SqlParameter("@IDBANCO", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@IDBANCO", beAdelanto.IdBanco));
                    cmd.Parameters.Add(new SqlParameter("@NUMERO", beAdelanto.Numero));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", beAdelanto.Monto));

                    rowsAffected += cmd.ExecuteNonQuery();
                    beAdelanto.IdAdelanto = int.Parse(cmd.Parameters["@IDADELANTO"].Value.ToString());

                }

                return rowsAffected ;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.Adelanto beAdelanto)
        {
            try
            {
                int rowsAffected = 0;
                string sp = "SpTbAdelantoActualizar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDADELANTO", beAdelanto.IdAdelanto));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", beAdelanto.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beAdelanto.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@TIPO", beAdelanto.Tipo));
                    if (beAdelanto.IdBanco == 0)
                        cmd.Parameters.Add(new SqlParameter("@IDBANCO", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@IDBANCO", beAdelanto.IdBanco));
                    cmd.Parameters.Add(new SqlParameter("@NUMERO", beAdelanto.Numero));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", beAdelanto.Monto));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idAdelanto)
        {
            try
            {
                string sp = "SpTbAdelantoEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDADELANTO", idAdelanto));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Adelanto> Listar(int anho, int mes)
        {
            var lstAdelanto = new List<BE.Adelanto>();
            try
            {
                string sp = "SpTbAdelantoListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beAdelanto = new BE.Adelanto();

                        beAdelanto.IdAdelanto = int.Parse(reader["IdAdelanto"].ToString());
                        beAdelanto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        beAdelanto.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                        beAdelanto.Tipo = reader["Tipo"].ToString();
                        beAdelanto.Numero = reader["Numero"].ToString();
                        beAdelanto.Monto = double.Parse(reader["Monto"].ToString());

                        string idBanco = reader["IdBanco"].ToString();
                        beAdelanto.IdBanco = idBanco == "" ? 0 : int.Parse(idBanco);

                        lstAdelanto.Add(beAdelanto);
                    }
                }
  
                return lstAdelanto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Adelanto Obtener(int idAdelanto)
        {
            BE.Adelanto beAdelanto = null;

            try
            {
                string sp = "SpTbAdelantoObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDADELANTO", idAdelanto));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beAdelanto = new BE.Adelanto();

                        beAdelanto.IdAdelanto = int.Parse(reader["IdAdelanto"].ToString());
                        beAdelanto.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        beAdelanto.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                        beAdelanto.Tipo = reader["Tipo"].ToString();
                        beAdelanto.Numero = reader["Numero"].ToString();
                        beAdelanto.Monto = double.Parse(reader["Monto"].ToString());

                        string idBanco = reader["IdBanco"].ToString();
                        beAdelanto.IdBanco = idBanco == "" ? 0 : int.Parse(idBanco);
                    }

                }

                return beAdelanto;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
