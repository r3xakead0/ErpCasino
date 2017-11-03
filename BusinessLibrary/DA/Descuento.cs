using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Descuento
    {

        public bool Insertar(ref BE.Descuento oBeDescuento)
        {
            try
            {
                string sp = "SpTbDescuentoInsertar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDDESCUENTO", oBeDescuento.IdDescuento));
                    cmd.Parameters["@IDDESCUENTO"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", oBeDescuento.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeDescuento.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", oBeDescuento.Monto));
                    cmd.Parameters.Add(new SqlParameter("@ACTIVO", oBeDescuento.Activo));

                    rowsAffected = cmd.ExecuteNonQuery();
                    oBeDescuento.IdDescuento = int.Parse(cmd.Parameters["@IDDESCUENTO"].Value.ToString());

                }

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Descuento oBeDescuento)
        {
            try
            {
                string sp = "SpTbDescuentoActualizar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDDESCUENTO", oBeDescuento.IdDescuento));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", oBeDescuento.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", oBeDescuento.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@MONTO", oBeDescuento.Monto));
                    cmd.Parameters.Add(new SqlParameter("@ACTIVO", oBeDescuento.Activo));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idDescuento)
        {
            try
            {
                string sp = "SpTbDescuentoEliminar";
                int rowsAffected = 0;

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDDESCUENTO", idDescuento));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Descuento> Listar()
        {
            var lstDescuentos = new List<BE.Descuento>();
            try
            {
                string sp = "SpTbDescuentoListar";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var beDescuento = new BE.Descuento();

                        beDescuento.IdDescuento = int.Parse(reader["IdDescuento"].ToString());
                        beDescuento.Nombre = reader["Nombre"].ToString();
                        beDescuento.Descripcion = reader["Descripcion"].ToString();
                        beDescuento.Monto = double.Parse(reader["Monto"].ToString());
                        beDescuento.Activo = bool.Parse(reader["Activo"].ToString());

                        lstDescuentos.Add(beDescuento);
                    }
                }

                return lstDescuentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Descuento Obtener(int idDescuento)
        {
            BE.Descuento beDescuento = null;
            try
            {
                string sp = "SpTbDescuentoObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDDESCUENTO", idDescuento));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        beDescuento = new BE.Descuento();

                        beDescuento.IdDescuento = int.Parse(reader["IdDescuento"].ToString());
                        beDescuento.Nombre = reader["Nombre"].ToString();
                        beDescuento.Descripcion = reader["Descripcion"].ToString();
                        beDescuento.Monto = double.Parse(reader["Monto"].ToString());
                        beDescuento.Activo = bool.Parse(reader["Activo"].ToString());
                    }
                }

                return beDescuento;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
