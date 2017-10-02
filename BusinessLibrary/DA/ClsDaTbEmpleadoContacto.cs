using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{
    public class ClsDaTbEmpleadoContacto
    {

        public BE.ClsBeTbEmpleadoContacto Cargar(DataRow dr)
        {
            try
            {
                var beEmpleadoContacto = new BE.ClsBeTbEmpleadoContacto();

                beEmpleadoContacto.IdEmpleado = dr["IdEmpleado"] == DBNull.Value ? 0 : int.Parse(dr["IdEmpleado"].ToString());
                beEmpleadoContacto.Zona = dr["Zona"] == DBNull.Value ? "" : dr["Zona"].ToString();
                beEmpleadoContacto.Direccion = dr["Direccion"] == DBNull.Value ? "" : dr["Direccion"].ToString();
                beEmpleadoContacto.Referencia = dr["Referencia"] == DBNull.Value ? "" : dr["Referencia"].ToString();
                beEmpleadoContacto.Email = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString();

                if (dr["CodUbigeo"] != DBNull.Value)
                {
                    beEmpleadoContacto.Ubigeo = new BE.Ubigeo()
                    {
                        Codigo = dr["CodUbigeo"].ToString()
                    };
                }

                return beEmpleadoContacto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtener datos completos del Contacto
        /// </summary>
        /// <param name="idEmpleado">ID de empleado</param>
        /// <returns></returns>
        public BE.ClsBeTbEmpleadoContacto Obtener(int idEmpleado)
        {
            BE.ClsBeTbEmpleadoContacto beEmpleadoContacto = null;
            try
            {
                string sp = "SpTbEmpleadoContactoObtener";

                SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal);
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.SelectCommand.Parameters.Add(new SqlParameter("@IDEMPLEADO", idEmpleado));

                DataTable dt = new DataTable();
                dad.Fill(dt);

                if ((dt.Rows.Count == 1))
                {
                    DataRow dr = dt.Rows[0];
                    beEmpleadoContacto = this.Cargar(dr);

                    var oBeUbigeo = beEmpleadoContacto.Ubigeo;
                    new Ubigeo().Obtener(ref oBeUbigeo);
                    beEmpleadoContacto.Ubigeo = oBeUbigeo;

                }
               
                return beEmpleadoContacto;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
