using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class SueldoCandidato
    {

        public int Insertar(ref BE.SueldoCandidato beSueldoCandidato)
        {
            try
            {
                string sp = "SpTbSueldoCandidatoInsertar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDSUELDOCANDIDATO", beSueldoCandidato.IdSueldoCandidato));
                    cmd.Parameters["@IDSUELDOCANDIDATO"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@FECHA", beSueldoCandidato.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOCANDIDATO", beSueldoCandidato.CodigoCandidato));
                    cmd.Parameters.Add(new SqlParameter("@SUELDO", beSueldoCandidato.Sueldo));
                    cmd.Parameters.Add(new SqlParameter("@BONONOCTURNOMINUTOS", beSueldoCandidato.BonoNocturnoMinutos));
                    cmd.Parameters.Add(new SqlParameter("@BONONOCTURNOTOTAL", beSueldoCandidato.BonoNocturnoTotal));
                    cmd.Parameters.Add(new SqlParameter("@BONOHORASEXTRASMINUTOS", beSueldoCandidato.BonoHorasExtrasMinutos));
                    cmd.Parameters.Add(new SqlParameter("@BONOHORASEXTRASTOTAL", beSueldoCandidato.BonoHorasExtrasTotal));
                    cmd.Parameters.Add(new SqlParameter("@BONOFERIADOMINUTOS", beSueldoCandidato.BonoFeriadoMinutos));
                    cmd.Parameters.Add(new SqlParameter("@BONOFERIADOTOTAL", beSueldoCandidato.BonoFeriadoTotal));
                    cmd.Parameters.Add(new SqlParameter("@DESCUENTOTARDANZAMINUTOS", beSueldoCandidato.DescuentoTardanzaMinutos));
                    cmd.Parameters.Add(new SqlParameter("@DESCUENTOTARDANZATOTAL", beSueldoCandidato.DescuentoTardanzaTotal));
                    cmd.Parameters.Add(new SqlParameter("@DESCUENTOINASISTENCIAMINUTOS", beSueldoCandidato.DescuentoInasistenciaMinutos));
                    cmd.Parameters.Add(new SqlParameter("@DESCUENTOINASISTENCIATOTAL", beSueldoCandidato.DescuentoInasistenciaTotal));

                    rowsAffected = cmd.ExecuteNonQuery();
                    beSueldoCandidato.IdSueldoCandidato = int.Parse(cmd.Parameters["@IDSUELDOCANDIDATO"].Value.ToString());

                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.SueldoCandidato beSueldoCandidato)
        {
            try
            {
                string sp = "SpTbSueldoCandidatoActualizar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDSUELDOCANDIDATO", beSueldoCandidato.IdSueldoCandidato));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", beSueldoCandidato.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@CODIGOCANDIDATO", beSueldoCandidato.CodigoCandidato));
                    cmd.Parameters.Add(new SqlParameter("@SUELDO", beSueldoCandidato.Sueldo));
                    cmd.Parameters.Add(new SqlParameter("@BONONOCTURNOMINUTOS", beSueldoCandidato.BonoNocturnoMinutos));
                    cmd.Parameters.Add(new SqlParameter("@BONONOCTURNOTOTAL", beSueldoCandidato.BonoNocturnoTotal));
                    cmd.Parameters.Add(new SqlParameter("@BONOHORASEXTRASMINUTOS", beSueldoCandidato.BonoHorasExtrasMinutos));
                    cmd.Parameters.Add(new SqlParameter("@BONOHORASEXTRASTOTAL", beSueldoCandidato.BonoHorasExtrasTotal));
                    cmd.Parameters.Add(new SqlParameter("@BONOFERIADOMINUTOS", beSueldoCandidato.BonoFeriadoMinutos));
                    cmd.Parameters.Add(new SqlParameter("@BONOFERIADOTOTAL", beSueldoCandidato.BonoFeriadoTotal));
                    cmd.Parameters.Add(new SqlParameter("@DESCUENTOTARDANZAMINUTOS", beSueldoCandidato.DescuentoTardanzaMinutos));
                    cmd.Parameters.Add(new SqlParameter("@DESCUENTOTARDANZATOTAL", beSueldoCandidato.DescuentoTardanzaTotal));
                    cmd.Parameters.Add(new SqlParameter("@DESCUENTOINASISTENCIAMINUTOS", beSueldoCandidato.DescuentoInasistenciaMinutos));
                    cmd.Parameters.Add(new SqlParameter("@DESCUENTOINASISTENCIATOTAL", beSueldoCandidato.DescuentoInasistenciaTotal));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idSueldoCandidato)
        {
            try
            {
                string sp = "SpTbSueldoCandidatoEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add(new SqlParameter("@IDSUELDOCANDIDATO", idSueldoCandidato));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.SueldoCandidato> Listar(int anho, int mes)
        {
            var lstBeObservaciones = new List<BE.SueldoCandidato>();

            try
            {
                string sp = "SpTbSueldoCandidatoListar";

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
                        var beSueldoCandidato = new BE.SueldoCandidato();

                        beSueldoCandidato.IdSueldoCandidato = reader["IdSueldoCandidato"] == DBNull.Value ? 0 : int.Parse(reader["IdSueldoCandidato"].ToString());
                        beSueldoCandidato.Fecha = reader["Fecha"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["Fecha"].ToString());
                        beSueldoCandidato.CodigoCandidato = reader["CodigoCandidato"] == DBNull.Value ? "" : reader["CodigoCandidato"].ToString();
                        beSueldoCandidato.Sueldo = reader["Sueldo"] == DBNull.Value ? 0.0 : double.Parse(reader["Sueldo"].ToString());
                        beSueldoCandidato.BonoNocturnoMinutos = reader["BonoNocturnoMinutos"] == DBNull.Value ? 0 : int.Parse(reader["BonoNocturnoMinutos"].ToString());
                        beSueldoCandidato.BonoNocturnoTotal = reader["BonoNocturnoTotal"] == DBNull.Value ? 0.0 : double.Parse(reader["BonoNocturnoTotal"].ToString());
                        beSueldoCandidato.BonoHorasExtrasMinutos = reader["BonoHorasExtrasMinutos"] == DBNull.Value ? 0 : int.Parse(reader["BonoHorasExtrasMinutos"].ToString());
                        beSueldoCandidato.BonoHorasExtrasTotal = reader["BonoHorasExtrasTotal"] == DBNull.Value ? 0.0 : double.Parse(reader["BonoHorasExtrasTotal"].ToString());
                        beSueldoCandidato.BonoFeriadoMinutos = reader["BonoFeriadoMinutos"] == DBNull.Value ? 0 : int.Parse(reader["BonoFeriadoMinutos"].ToString());
                        beSueldoCandidato.BonoFeriadoTotal = reader["BonoFeriadoTotal"] == DBNull.Value ? 0.0 : double.Parse(reader["BonoFeriadoTotal"].ToString());
                        beSueldoCandidato.DescuentoTardanzaMinutos = reader["DescuentoTardanzaMinutos"] == DBNull.Value ? 0 : int.Parse(reader["DescuentoTardanzaMinutos"].ToString());
                        beSueldoCandidato.DescuentoTardanzaTotal = reader["DescuentoTardanzaTotal"] == DBNull.Value ? 0.0 : double.Parse(reader["DescuentoTardanzaTotal"].ToString());
                        beSueldoCandidato.DescuentoInasistenciaMinutos = reader["DescuentoInasistenciaMinutos"] == DBNull.Value ? 0 : int.Parse(reader["DescuentoInasistenciaMinutos"].ToString());
                        beSueldoCandidato.DescuentoInasistenciaTotal = reader["DescuentoInasistenciaTotal"] == DBNull.Value ? 0.0 : double.Parse(reader["DescuentoInasistenciaTotal"].ToString());

                        lstBeObservaciones.Add(beSueldoCandidato);
                    }

                }

                return lstBeObservaciones;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Validar si existe sueldos calculados para el periodo (año y mes) y tipo de sueldo
        /// </summary>
        /// <param name="anho">Año de consulta en formato yyyy. Ejm: 2017</param>
        /// <param name="mes">Mes de consulta en rango del 1 al 12. Ejm: 1</param>
        /// <returns></returns>
        public bool ExisteCalculo(int anho, int mes)
        {
            int cantidad = 0;

            try
            {
                string sp = "SpTbSueldoCandidatoExisteCalculo";

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
                        cantidad = reader["Cantidad"] == DBNull.Value ? 0 : int.Parse(reader["Cantidad"].ToString());
                    }

                }

                return cantidad > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}
