using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Asistencia
    {

        public bool Insertar(ref BE.UI.Asistencia uiAsistencia, int idSession = 0)
        {
            int rowsAffected = 0;

            try
            {
                var beAsistencia = new BE.Asistencia();

                beAsistencia.IdUsuarioCreador = idSession;
                beAsistencia.FechaCreacion = DateTime.Now;

                beAsistencia.IdAsistencia = 0;
                beAsistencia.Codigo = uiAsistencia.EmpleadoCodigo;
                beAsistencia.FechaHoraEntrada = uiAsistencia.FechaHoraEntrada;
                beAsistencia.FechaHoraSalida = uiAsistencia.FechaHoraSalida;
                beAsistencia.Turno = uiAsistencia.Turno;
                beAsistencia.Origen = uiAsistencia.Origen;
                beAsistencia.FechaRegistro = uiAsistencia.Fecha;

                rowsAffected = new DA.Asistencia().Insertar(ref beAsistencia);

                uiAsistencia.ID = beAsistencia.IdAsistencia;

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idAsistencia)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = new DA.Asistencia().Eliminar(idAsistencia);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Asistencia> Listar(DateTime fecha)
        {

            var lstUiAsistencias = new List<BE.UI.Asistencia>();

            try
            {

                var daAsistencia = new DA.Asistencia();

                DataTable dt = daAsistencia.Listar(fecha);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var beAsistencia = new BE.Asistencia();

                    DataRow dr = dt.Rows[i];
                    daAsistencia.Cargar(ref beAsistencia, ref dr);

                    var uiAsistencia = new BE.UI.Asistencia();
                    uiAsistencia.ID = beAsistencia.IdAsistencia;
                    uiAsistencia.EmpleadoCodigo = beAsistencia.Codigo;
                    uiAsistencia.EmpleadoNombreCompleto = new LN.Empleado().ObtenerNombreCompleto(beAsistencia.Codigo);
                    uiAsistencia.FechaHoraEntrada = beAsistencia.FechaHoraEntrada;
                    uiAsistencia.FechaHoraSalida = beAsistencia.FechaHoraSalida;
                    uiAsistencia.Tiempo = beAsistencia.FechaHoraSalida.Subtract(beAsistencia.FechaHoraEntrada);
                    uiAsistencia.Turno = beAsistencia.Turno;
                    uiAsistencia.Origen = beAsistencia.Origen;
                    uiAsistencia.Fecha = beAsistencia.FechaRegistro;

                    lstUiAsistencias.Add(uiAsistencia);
                }


                return lstUiAsistencias;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarResumen(DateTime fecha)
        {
            try
            {

                int rowsAffected = new DA.Asistencia().EliminarResumen(fecha);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.AsistenciaResumen> ListarResumen(int anho, int mes)
        {

            var lstUiAsistenciaResumen = new List<BE.UI.AsistenciaResumen>();

            try
            {

                var daAsistencia = new DA.Asistencia();
                DataTable dt = daAsistencia.ListarResumen(anho, mes);

                foreach (DataRow dr in dt.Rows)
                {
                    var uiAsistenciaResumen = new BE.UI.AsistenciaResumen();
                    uiAsistenciaResumen.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                    uiAsistenciaResumen.Cantidad = int.Parse(dr["Cantidad"].ToString());
                    lstUiAsistenciaResumen.Add(uiAsistenciaResumen);
                }

                return lstUiAsistenciaResumen;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}