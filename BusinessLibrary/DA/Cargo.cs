using BE = ErpCasino.BusinessLibrary.BE;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class Cargo
    {

        public bool Insertar(ref BE.Cargo beCargo)
        {
            try
            {
                string sp = "SpTbCargoInsertar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDCARGO", beCargo.IdCargo));
                cmd.Parameters["@IDCARGO"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", beCargo.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beCargo.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beCargo.Activo));
                cmd.Parameters.Add(new SqlParameter("@BONO", beCargo.Bono));

                rowsAffected = cmd.ExecuteNonQuery();
                beCargo.IdCargo = int.Parse(cmd.Parameters["@IDCARGO"].Value.ToString());

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.Cargo beCargo)
        {
            try
            {
                string sp = "SpTbCargoActualizar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDCARGO", beCargo.IdCargo));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", beCargo.Nombre));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", beCargo.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@ACTIVO", beCargo.Activo));
                cmd.Parameters.Add(new SqlParameter("@BONO", beCargo.Bono));

                rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idCargo)
        {
            try
            {
                string sp = "SpTbCargoEliminar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                int rowsAffected = 0;
                cnn.Open();

                cmd.Parameters.Add(new SqlParameter("@IDCARGO", idCargo));

                rowsAffected = cmd.ExecuteNonQuery();

                return (rowsAffected > 0 ? true : false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Cargo> Listar()
        {
            var lstCargos = new List<BE.Cargo>();
            try
            {
                string sp = "SpTbCargoListar";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                cnn.Open();

                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var beCargo = new BE.Cargo();

                    beCargo.IdCargo = int.Parse(reader["IdCargo"].ToString());
                    beCargo.Nombre = reader["Nombre"].ToString();
                    beCargo.Descripcion = reader["Descripcion"].ToString();
                    beCargo.Activo = bool.Parse(reader["Activo"].ToString());
                    beCargo.Bono = double.Parse(reader["Bono"].ToString());

                    lstCargos.Add(beCargo);
                }

                return lstCargos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Cargo Obtener(int idCargo)
        {
            BE.Cargo beCargo = null;
            try
            {
                string sp = "SpTbCargoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);

                cnn.Open();
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDCARGO", idCargo));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    beCargo = new BE.Cargo();

                    beCargo.IdCargo = int.Parse(reader["IdCargo"].ToString());
                    beCargo.Nombre = reader["Nombre"].ToString();
                    beCargo.Descripcion = reader["Descripcion"].ToString();
                    beCargo.Activo = bool.Parse(reader["Activo"].ToString());
                    beCargo.Bono = double.Parse(reader["Bono"].ToString());

                }

                return beCargo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }

}
