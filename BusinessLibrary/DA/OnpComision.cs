using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class OnpComision
    {

        public bool Insertar(ref BE.OnpComision BeOnpComision)
        {
            try
            {
                string sp = "SpTbOnpComisionInsertar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDONPCOMISION", BeOnpComision.IdOnpComision));
                    cmd.Parameters["@IDONPCOMISION"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", BeOnpComision.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", BeOnpComision.Mes));
                    cmd.Parameters.Add(new SqlParameter("@PORCENTAJEAPORTE", BeOnpComision.PorcentajeAporte));

                    rowsAffected = cmd.ExecuteNonQuery();
                    BeOnpComision.IdOnpComision = int.Parse(cmd.Parameters["@IDONPCOMISION"].Value.ToString());

                }

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idOnpComision)
        {
            try
            {
                string sp = "SpTbOnpComisionEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDONPCOMISION", idOnpComision));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return (rowsAffected > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.OnpComision> Listar()
        {
            var lstOnpComision = new List<BE.OnpComision>();
            try
            {
                string sp = "SpTbOnpComisionListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {

                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beOnpComision = new BE.OnpComision();

                        beOnpComision.IdOnpComision = int.Parse(reader["IdOnpComision"].ToString());
                        beOnpComision.Anho = int.Parse(reader["Anho"].ToString());
                        beOnpComision.Mes = int.Parse(reader["Mes"].ToString());
                        beOnpComision.PorcentajeAporte = double.Parse(reader["PorcentajeAporte"].ToString());

                        lstOnpComision.Add(beOnpComision);
                    }

                }                    

                return lstOnpComision;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.OnpComision Obtener(int anho, int mes)
        {
            BE.OnpComision beOnpComision = null;
            try
            {
                string sp = "SpTbOnpComisionObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        beOnpComision = new BE.OnpComision();

                        beOnpComision.IdOnpComision = int.Parse(reader["IdOnpComision"].ToString());
                        beOnpComision.Anho = int.Parse(reader["Anho"].ToString());
                        beOnpComision.Mes = int.Parse(reader["Mes"].ToString());
                        beOnpComision.PorcentajeAporte = double.Parse(reader["PorcentajeAporte"].ToString());

                    }

                }

                return beOnpComision;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}