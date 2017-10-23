using BE = ErpCasino.BusinessLibrary.BE;
using System.Data.SqlClient;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.DA
{

    public class ClsDaTbEmpleadoRecurso
    {

        private BE.ClsBeTbEmpleadoRecurso Cargar(DataRow dr)
        {
            try
            {
                var beEmpleadoRecurso = new BE.ClsBeTbEmpleadoRecurso();

                beEmpleadoRecurso.IdEmpleado = dr["IdEmpleado"] == DBNull.Value ? 0 : int.Parse(dr["IdEmpleado"].ToString());
                beEmpleadoRecurso.FechaInicio = dr["FechaInicio"] == DBNull.Value ? DateTime.Now  : (DateTime)dr["FechaInicio"];
                beEmpleadoRecurso.FechaCese = dr["FechaCese"] == DBNull.Value ? null : (DateTime?)dr["FechaCese"];
                beEmpleadoRecurso.Cesado = dr["Cesado"] == DBNull.Value ? false : bool.Parse(dr["Cesado"].ToString());
                beEmpleadoRecurso.NumeroHijos = dr["NumeroHijos"] == DBNull.Value ? 0 : int.Parse(dr["NumeroHijos"].ToString());
                beEmpleadoRecurso.CuentaBanco = dr["CuentaBanco"] == DBNull.Value ? "" : dr["CuentaBanco"].ToString();
                beEmpleadoRecurso.CCI = dr["CCI"] == DBNull.Value ? "" : dr["CCI"].ToString();
                beEmpleadoRecurso.ONP = dr["ONP"] == DBNull.Value ? false : bool.Parse(dr["ONP"].ToString());
                beEmpleadoRecurso.CUSPP = dr["CUSPP"] == DBNull.Value ? "" : dr["CUSPP"].ToString();
                beEmpleadoRecurso.CodComision = dr["CodComision"] == DBNull.Value ? "" : dr["CodComision"].ToString();
                beEmpleadoRecurso.CuentaCTS = dr["CuentaCTS"] == DBNull.Value ? "" : dr["CuentaCTS"].ToString();
                beEmpleadoRecurso.Sueldo = dr["Sueldo"] == DBNull.Value ? 0.0 : Double.Parse(dr["Sueldo"].ToString());
                beEmpleadoRecurso.RetencionJudicialNominal = dr["RetencionJudicialNominal"] == DBNull.Value ? 0.0 : Double.Parse(dr["RetencionJudicialNominal"].ToString());
                beEmpleadoRecurso.RetencionJudicialPorcentual = dr["RetencionJudicialPorcentual"] == DBNull.Value ? 0.0 : Double.Parse(dr["RetencionJudicialPorcentual"].ToString());

                if (dr["IdArea"] != DBNull.Value)
                {
                    beEmpleadoRecurso.Area = new BE.Area()
                    {
                        IdArea = (int)dr["IdArea"],
                        Nombre = dr["NombreArea"].ToString()
                    };
                }

                if (dr["IdCargo"] != DBNull.Value)
                {
                    beEmpleadoRecurso.Cargo = new BE.Cargo()
                    {
                        IdCargo = (int)dr["IdCargo"],
                        Nombre = dr["NombreCargo"].ToString()
                    };
                }

                if (dr["IdSala"] != DBNull.Value)
                {
                    beEmpleadoRecurso.Sala = new BE.Sala()
                    {
                        IdSala = (int)dr["IdSala"],
                        Nombre = dr["NombreSala"].ToString()
                    };
                }

                if (dr["IdBanco"] != DBNull.Value)
                {
                    beEmpleadoRecurso.Banco = new BE.Banco()
                    {
                        IdBanco = (int)dr["IdBanco"],
                        Nombre = dr["NombreBanco"].ToString()
                    };
                }

                if (dr["IdAfp"] != DBNull.Value)
                {
                    beEmpleadoRecurso.Afp = new BE.Afp()
                    {
                        IdAfp = (int)dr["IdAfp"],
                        Nombre = dr["NombreAfp"].ToString()
                    };
                }

                if (dr["IdBancoCTS"] != DBNull.Value)
                {
                    beEmpleadoRecurso.BancoCTS = new BE.Banco()
                    {
                        IdBanco = (int)dr["IdBancoCTS"],
                        Nombre = dr["NombreBancoCTS"].ToString()
                    };
                }

                return beEmpleadoRecurso;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtene los datos completo del recurso 
        /// </summary>
        /// <param name="idEmpleado">UD de empleado</param>
        /// <returns></returns>
        public BE.ClsBeTbEmpleadoRecurso Obtener(int idEmpleado)
        {
            BE.ClsBeTbEmpleadoRecurso beEmpleadoRecurso = null;

            try
            {
                string sp = "SpTbEmpleadoRecursoObtener";

                using (SqlConnection cnn = new SqlConnection(ConnectionManager.ConexionLocal))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dad = new SqlDataAdapter(cmd);
                    dad.SelectCommand.Parameters.Add(new SqlParameter("@IDEMPLEADO", idEmpleado));

                    DataTable dt = new DataTable();
                    dad.Fill(dt);

                    if ((dt.Rows.Count == 1))
                    {
                        DataRow dr = dt.Rows[0];
                        beEmpleadoRecurso = this.Cargar(dr);
                    }

                    cnn.Close();
                }

                return beEmpleadoRecurso;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }

}