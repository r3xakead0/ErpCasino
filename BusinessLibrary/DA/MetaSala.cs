using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class MetaSala
    {

        public bool Insertar(ref BE.MetaSala beMetaSala)
        {
            try
            {
                string sp = "SpTbMetaSalaInsertar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDMETASALA", beMetaSala.IdMetaSala));
                    cmd.Parameters["@IDMETASALA"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", beMetaSala.Sala.IdSala));
                    cmd.Parameters.Add(new SqlParameter("@ANHO", beMetaSala.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", beMetaSala.Mes));
                    cmd.Parameters.Add(new SqlParameter("@CANTIDADPERSONAL", beMetaSala.CantidadPersonal));
                    cmd.Parameters.Add(new SqlParameter("@MONTOPERSONAL", beMetaSala.MontoPersonal));
                    cmd.Parameters.Add(new SqlParameter("@MONTOGRUPAL", beMetaSala.MontoGrupal));
                    cmd.Parameters.Add(new SqlParameter("@CUMPLIDO", beMetaSala.Cumplido));

                    rowsAffected = cmd.ExecuteNonQuery();
                    beMetaSala.IdMetaSala = int.Parse(cmd.Parameters["@IDMETASALA"].Value.ToString());

                    cnn.Close();
                }

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.MetaSala beMetaSala)
        {
            try
            {
                string sp = "SpTbMetaSalaActualizar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDMETASALA", beMetaSala.IdMetaSala));
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", beMetaSala.Sala.IdSala));
                    cmd.Parameters.Add(new SqlParameter("@ANHO", beMetaSala.Anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", beMetaSala.Mes));
                    cmd.Parameters.Add(new SqlParameter("@CANTIDADPERSONAL", beMetaSala.CantidadPersonal));
                    cmd.Parameters.Add(new SqlParameter("@MONTOPERSONAL", beMetaSala.MontoPersonal));
                    cmd.Parameters.Add(new SqlParameter("@MONTOGRUPAL", beMetaSala.MontoGrupal));
                    cmd.Parameters.Add(new SqlParameter("@CUMPLIDO", beMetaSala.Cumplido));

                    rowsAffected = cmd.ExecuteNonQuery();

                    cnn.Close();
                }

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idMetaSala)
        {
            try
            {
                string sp = "SpTbMetaSalaEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDMETASALA", idMetaSala));

                    rowsAffected = cmd.ExecuteNonQuery();

                    cnn.Close();
                }

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.MetaSala> Listar()
        {
            var lstMetaSala = new List<BE.MetaSala>();
            try
            {
                string sp = "SpTbMetaSalaListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beMetaSala = new BE.MetaSala();

                        beMetaSala.IdMetaSala = reader["IdMetaSala"] == DBNull.Value ? 0 : int.Parse(reader["IdMetaSala"].ToString());
                        beMetaSala.Anho = reader["Anho"] == DBNull.Value ? 0 : int.Parse(reader["Anho"].ToString());
                        beMetaSala.Mes = reader["Mes"] == DBNull.Value ? 0 : int.Parse(reader["Mes"].ToString());
                        beMetaSala.CantidadPersonal = reader["CantidadPersonal"] == DBNull.Value ? 0 : int.Parse(reader["CantidadPersonal"].ToString());
                        beMetaSala.MontoPersonal = reader["MontoPersonal"] == DBNull.Value ? 0.0 : double.Parse(reader["MontoPersonal"].ToString());
                        beMetaSala.MontoGrupal = reader["MontoGrupal"] == DBNull.Value ? 0.0 : double.Parse(reader["MontoGrupal"].ToString());
                        beMetaSala.Cumplido = reader["Cumplido"] == DBNull.Value ? false : bool.Parse(reader["Cumplido"].ToString());

                        beMetaSala.Sala = new BE.Sala()
                        {
                            IdSala = reader["IdSala"] == DBNull.Value ? 0 : int.Parse(reader["IdSala"].ToString())
                        };

                        lstMetaSala.Add(beMetaSala);
                    }

                    cnn.Close();
                }

                return lstMetaSala;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.MetaSala Obtener(int idSala, int anho, int mes)
        {
            BE.MetaSala beMetaSala = null;

            try
            {
                string sp = "SpTbMetaSalaObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDSALA", idSala));
                    cmd.Parameters.Add(new SqlParameter("@ANHO", anho));
                    cmd.Parameters.Add(new SqlParameter("@MES", mes));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        beMetaSala = new BE.MetaSala();

                        beMetaSala.IdMetaSala = reader["IdMetaSala"] == DBNull.Value ? 0 : int.Parse(reader["IdMetaSala"].ToString());
                        beMetaSala.Anho = reader["Anho"] == DBNull.Value ? 0 : int.Parse(reader["Anho"].ToString());
                        beMetaSala.Mes = reader["Mes"] == DBNull.Value ? 0 : int.Parse(reader["Mes"].ToString());
                        beMetaSala.CantidadPersonal = reader["CantidadPersonal"] == DBNull.Value ? 0 : int.Parse(reader["CantidadPersonal"].ToString());
                        beMetaSala.MontoPersonal = reader["MontoPersonal"] == DBNull.Value ? 0.0 : double.Parse(reader["MontoPersonal"].ToString());
                        beMetaSala.MontoGrupal = reader["MontoGrupal"] == DBNull.Value ? 0.0 : double.Parse(reader["MontoGrupal"].ToString());
                        beMetaSala.Cumplido = reader["Cumplido"] == DBNull.Value ? false : bool.Parse(reader["Cumplido"].ToString());

                        beMetaSala.Sala = new BE.Sala()
                        {
                            IdSala = reader["IdSala"] == DBNull.Value ? 0 : int.Parse(reader["IdSala"].ToString())
                        };
                    }

                    cnn.Close();
                }

                return beMetaSala;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
