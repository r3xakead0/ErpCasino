using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Sala
    {

        public void Cargar(ref BE.Sala beSala, ref DataRow dr)
        {
            try
            {
                beSala.IdSala = dr["IdSala"] == DBNull.Value ? 0 : int.Parse(dr["IdSala"].ToString());
                beSala.Nombre = dr["Nombre"] == DBNull.Value ? "" : dr["Nombre"].ToString();
                beSala.Descripcion = dr["Descripcion"] == DBNull.Value ? "" : dr["Descripcion"].ToString();
                beSala.Zona = dr["Zona"] == DBNull.Value ? "" : dr["Zona"].ToString();
                beSala.Direccion = dr["Direccion"] == DBNull.Value ? "" : dr["Direccion"].ToString();
                beSala.Referencia = dr["Referencia"] == DBNull.Value ? "" : dr["Referencia"].ToString();
                beSala.Activo = dr["Activo"] == DBNull.Value ? false : bool.Parse(dr["Activo"].ToString());

                if (dr["CodUbigeo"] != DBNull.Value)
                {
                    beSala.Ubigeo = new BE.Ubigeo()
                    {
                        Codigo = dr["CodUbigeo"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insertar(ref BE.Sala beSala)
        {
            try
            {
                string sp = "SpTbSalaInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDSALA", beSala.IdSala));
                cmd.Parameters["@IDSALA"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", beSala.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beSala.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@CODUBIGEO", beSala.Ubigeo.Codigo));
                cmd.Parameters.Add(new SqlParameter("@ZONA", beSala.Zona));
                cmd.Parameters.Add(new SqlParameter("@DIRECCION", beSala.Direccion));
                cmd.Parameters.Add(new SqlParameter("@REFERENCIA", beSala.Referencia));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beSala.Activo));

                rowsAffected = cmd.ExecuteNonQuery();
                beSala.IdSala = int.Parse(cmd.Parameters["@IDSALA"].Value.ToString());

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Actualizar(BE.Sala beSala)
        {
            try
            {
                string sp = "SpTbSalaActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDSALA", beSala.IdSala));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", beSala.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beSala.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@CODUBIGEO", beSala.Ubigeo.Codigo));
                cmd.Parameters.Add(new SqlParameter("@ZONA", beSala.Zona));
                cmd.Parameters.Add(new SqlParameter("@DIRECCION", beSala.Direccion));
                cmd.Parameters.Add(new SqlParameter("@REFERENCIA", beSala.Referencia));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beSala.Activo));

                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Eliminar(int idSala)
        {
            try
            {
                string sp = "SpTbSalaEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDSALA", idSala));

                int rowsAffected = 0;
                rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Sala> Listar()
        {
            var lstBeSalas = new List<BE.Sala>();

            try
            {
                string sp = "SpTbSalaListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    var beSala = new BE.Sala();

                    beSala.IdSala = int.Parse(reader["IdSala"].ToString());
                    beSala.Nombre = reader["Nombre"].ToString();
                    beSala.Descripcion = reader["Descripcion"].ToString();
                    beSala.Zona = reader["Zona"].ToString();
                    beSala.Direccion = reader["Direccion"].ToString();
                    beSala.Referencia = reader["Referencia"].ToString();
                    beSala.Activo = bool.Parse(reader["Activo"].ToString());

                    if (reader["CodUbigeo"] != DBNull.Value)
                    {
                        var beUbigeo = new BE.Ubigeo();
                        beUbigeo.Codigo = reader["CodUbigeo"].ToString();

                        if (new DA.Ubigeo().Obtener(ref beUbigeo))
                        {
                            beSala.Ubigeo = beUbigeo;
                        } 
                    }

                    lstBeSalas.Add(beSala);
                }

                return lstBeSalas;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Obtener(ref BE.Sala beSala)
        {
            bool rpta = false;
            try
            {
                string sp = "SpTbSalaObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDSALA", beSala.IdSala));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    Cargar(ref beSala, ref dr);
                    rpta = true;
                }

                return rpta;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}