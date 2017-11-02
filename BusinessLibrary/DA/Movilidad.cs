using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Movilidad
    {

        public int Insertar(ref BE.Movilidad beMovilidad)
        {
            try
            {
                int rowsAffected = 0;
                string sp = "SpTbMovilidadInsertar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDMOVILIDAD", beMovilidad.IdMovilidad));
                    cmd.Parameters["@IDMOVILIDAD"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", beMovilidad.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", beMovilidad.Mes));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beMovilidad.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", beMovilidad.Monto));
                    cmd.Parameters.Add(new SqlParameter("@IDUSUARIOCREADOR", 1));
                    cmd.Parameters.Add(new SqlParameter("@FECHACREACION", DateTime.Now));

                    rowsAffected += cmd.ExecuteNonQuery();
                    beMovilidad.IdMovilidad = int.Parse(cmd.Parameters["@IDMOVILIDAD"].Value.ToString());
                }

                return rowsAffected ;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.Movilidad beMovilidad)
        {
            try
            {
                int rowsAffected = 0;
                string sp = "SpTbMovilidadActualizar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDMOVILIDAD", beMovilidad.IdMovilidad));
                    cmd.Parameters.Add(new SqlParameter("@ANHO", beMovilidad.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", beMovilidad.Mes));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOEMPLEADO", beMovilidad.CodigoEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", beMovilidad.Monto));
                    cmd.Parameters.Add(new SqlParameter("@IDUSUARIOMODIFICADOR", 1));
                    cmd.Parameters.Add(new SqlParameter("@FECHAMODIFICACION",DateTime.Now));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idMovilidad)
        {
            try
            {
                string sp = "SpTbMovilidadEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDMOVILIDAD", idMovilidad));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Movilidad> Listar()
        {
            var lstMovilidad = new List<BE.Movilidad>();
            try
            {
                string sp = "SpTbMovilidadListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beMovilidad = new BE.Movilidad();

                        beMovilidad.IdMovilidad  = int.Parse(reader["IDMOVILIDAD"].ToString());
                        beMovilidad.Anho = int.Parse(reader["Anho"].ToString());
                        beMovilidad.Mes = int.Parse(reader["Mes"].ToString());
                        beMovilidad.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                        beMovilidad.Monto = double.Parse(reader["Monto"].ToString());
                        
                        lstMovilidad.Add(beMovilidad);
                    }
                }
  
                return lstMovilidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Movilidad Obtener(int idMovilidad)
        {
            BE.Movilidad beMovilidad = null;

            try
            {
                string sp = "SpTbMovilidadObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDMOVILIDAD", idMovilidad));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beMovilidad = new BE.Movilidad();

                        beMovilidad.IdMovilidad = int.Parse(reader["IDMOVILIDAD"].ToString());
                        beMovilidad.Anho = int.Parse(reader["Anho"].ToString());
                        beMovilidad.Mes = int.Parse(reader["Mes"].ToString());
                        beMovilidad.CodigoEmpleado = reader["CodigoEmpleado"].ToString();
                        beMovilidad.Monto = double.Parse(reader["Monto"].ToString());
                    }

                }

                return beMovilidad;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
