using BE = ErpCasino.BusinessLibrary.BE;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class SueldoMinimo
    {

        public int Insertar(ref BE.SueldoMinimo beSueldoMinimo)
        {
            try
            {
                string sp = "SpTbSueldoMinimoInsertar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDSUELDOMINIMO", beSueldoMinimo.IdSueldoMinimo));
                    cmd.Parameters["@IDSUELDOMINIMO"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", beSueldoMinimo.FechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", beSueldoMinimo.Monto));
                    cmd.Parameters.Add(new SqlParameter("@ACTIVO", beSueldoMinimo.Activo));

                    rowsAffected = cmd.ExecuteNonQuery();
                    beSueldoMinimo.IdSueldoMinimo = int.Parse(cmd.Parameters["@IDSUELDOMINIMO"].Value.ToString());

                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.SueldoMinimo beSueldoMinimo)
        {
            try
            {
                string sp = "SpTbSueldoMinimoActualizar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDSUELDOMINIMO", beSueldoMinimo.IdSueldoMinimo));
                    cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", beSueldoMinimo.FechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", beSueldoMinimo.Monto));
                    cmd.Parameters.Add(new SqlParameter("@ACTIVO", beSueldoMinimo.Activo));

                    rowsAffected = cmd.ExecuteNonQuery();
                }
                  
                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idSueldoMinimo)
        {
            try
            {
                string sp = "SpTbSueldoMinimoEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDSUELDOMINIMO", idSueldoMinimo));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.SueldoMinimo> Listar()
        {
            var lstSueldosMinimos = new List<BE.SueldoMinimo>();

            try
            {
                string sp = "SpTbSueldoMinimoListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beSueldoMinimo = new BE.SueldoMinimo();

                        beSueldoMinimo.IdSueldoMinimo = int.Parse(reader["IdSueldoMinimo"].ToString());
                        beSueldoMinimo.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                        beSueldoMinimo.Monto = double.Parse(reader["Monto"].ToString());
                        beSueldoMinimo.Activo = bool.Parse(reader["Activo"].ToString());

                        lstSueldosMinimos.Add(beSueldoMinimo);
                    }
                }

                return lstSueldosMinimos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}