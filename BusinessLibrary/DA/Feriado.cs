using ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{

    public class Feriado
    {

        public int Insertar(BE.Feriado beFeriado)
        {
            try
            {
                int rowsAffected = 0;
                string sp = "SpTbFeriadoInsertar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Fecha", beFeriado.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@Festivo", beFeriado.Festivo));
                    cmd.Parameters.Add(new SqlParameter("@Motivo", beFeriado.Motivo));
                    cmd.Parameters.Add(new SqlParameter("@Activo", beFeriado.Activo));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.Feriado beFeriado)
        {
            try
            {
                int rowsAffected = 0;
                string sp = "SpTbFeriadoActualizar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Fecha", beFeriado.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@Festivo", beFeriado.Festivo));
                    cmd.Parameters.Add(new SqlParameter("@Motivo", beFeriado.Motivo));
                    cmd.Parameters.Add(new SqlParameter("@Activo", beFeriado.Activo));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(DateTime fecha)
        {
            try
            {
                int rowsAffected = 0;
                string sp = "SpTbFeriadoObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Fecha", fecha));

                    rowsAffected = cmd.ExecuteNonQuery();
                }
                    
                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Feriado> ListarAnho(int anho)
        {
            List<BE.Feriado> lstFeriado = new List<BE.Feriado>();
            try
            {
                string sp = "SpTbFeriadoListarAnho";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {

                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beFeriado = new BE.Feriado();

                        beFeriado.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        beFeriado.Motivo = reader["Motivo"].ToString();
                        beFeriado.Festivo = bool.Parse(reader["Festivo"].ToString());
                        beFeriado.Activo = bool.Parse(reader["Activo"].ToString());

                        lstFeriado.Add(beFeriado);
                    }

                }

                return lstFeriado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Feriado> ListarMes(int anho, int mes)
        {
            List<BE.Feriado> lstFeriado = new List<BE.Feriado>();
            try
            {
                string sp = "SpTbFeriadoListarMes";

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
                        var beFeriado = new BE.Feriado();

                        beFeriado.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        beFeriado.Motivo = reader["Motivo"].ToString();
                        beFeriado.Festivo = bool.Parse(reader["Festivo"].ToString());
                        beFeriado.Activo = bool.Parse(reader["Activo"].ToString());

                        lstFeriado.Add(beFeriado);
                    }

                }
                    
                return lstFeriado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Feriado Obtener(DateTime fecha)
        {
            BE.Feriado beFeriado = null;
            try
            {
                string sp = "SpTbFeriadoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Fecha", fecha));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    beFeriado = new BE.Feriado();

                    beFeriado.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                    beFeriado.Motivo = reader["Motivo"].ToString();
                    beFeriado.Festivo = bool.Parse(reader["Festivo"].ToString());
                    beFeriado.Activo = bool.Parse(reader["Activo"].ToString());
                }

                return beFeriado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
