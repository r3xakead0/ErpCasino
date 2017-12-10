using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Inasistencia
    {

        private BE.Inasistencia InasistenciaUItoBE(BE.UI.Inasistencia uiInasistencia)
        {
            var beInasistencia = new BE.Inasistencia();
            beInasistencia.IdInasistencia = uiInasistencia.Id;
            beInasistencia.Codigo = uiInasistencia.EmpleadoCodigo;
            beInasistencia.Fecha = uiInasistencia.Fecha;
            beInasistencia.FechaHoraEntrada = uiInasistencia.FechaHoraInicio;
            beInasistencia.FechaHoraSalida = uiInasistencia.FechaHoraFinal;
            beInasistencia.Tipo = uiInasistencia.TipoCodigo;
            beInasistencia.Asunto = uiInasistencia.Asunto;
            beInasistencia.Detalle = uiInasistencia.Detalle;
            beInasistencia.Certificado = uiInasistencia.Certificado;
            return beInasistencia;
        }
       
        private string ObtenerDia(int dia)
        {
            string nombreDia = "";

            switch (dia)
            {
                case 1:
                    nombreDia = "Lunes";
                    break;
                case 2:
                    nombreDia = "Martes";
                    break;
                case 3:
                    nombreDia = "Miercoles";
                    break;
                case 4:
                    nombreDia = "Jueves";
                    break;
                case 5:
                    nombreDia = "Viernes";
                    break;
                case 6:
                    nombreDia = "Sabado";
                    break;
                default:
                    nombreDia = "Domingo";
                    break;
            }

            return nombreDia;
        }

        private string ObtenerMes(int mes)
        {
            string nombreMes = "";

            switch (mes)
            {
                case 1:
                    nombreMes = "Enero";
                    break;
                case 2:
                    nombreMes = "Febrero";
                    break;
                case 3:
                    nombreMes = "Marzo";
                    break;
                case 4:
                    nombreMes = "Abril";
                    break;
                case 5:
                    nombreMes = "Mayo";
                    break;
                case 6:
                    nombreMes = "Junio";
                    break;
                case 7:
                    nombreMes = "Julio";
                    break;
                case 8:
                    nombreMes = "Agosto";
                    break;
                case 9:
                    nombreMes = "Septiembre";
                    break;
                case 10:
                    nombreMes = "Octubre";
                    break;
                case 11:
                    nombreMes = "Noviembre";
                    break;
                default:
                    nombreMes = "Diciembre";
                    break;
            }

            return nombreMes;
        }

        public bool Insertar(ref BE.UI.Inasistencia uiInasistencia, int idUsuario)
        {
            try
            {
                var beInasistencia = this.InasistenciaUItoBE(uiInasistencia);
                beInasistencia.IdUsuarioCreador = idUsuario;
                beInasistencia.FechaCreacion = DateTime.Now;
                return new DA.Inasistencia().Insertar(ref beInasistencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Inasistencia uiInasistencia, int idUsuario)
        {
            try
            {
                var beInasistencia = this.InasistenciaUItoBE(uiInasistencia);
                beInasistencia.IdUsuarioModificador = idUsuario;
                beInasistencia.FechaModificacion = DateTime.Now;
                return new DA.Inasistencia().Actualizar(beInasistencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Inasistencia> Listar(int anho, int mes, int idSala = 0)
        {
            try
            {
                var lstUiInasistencias = new List<BE.UI.Inasistencia>();

                DataTable dtInasistencias = new DA.Inasistencia().Listar(anho, mes, idSala);
                foreach (DataRow drInasistencia in dtInasistencias.Rows)
                {
                    var uiInasistencia = new BE.UI.Inasistencia();
                    uiInasistencia.Id = int.Parse(drInasistencia["IdInasistencia"].ToString());
                    uiInasistencia.Anho = int.Parse(drInasistencia["Anho"].ToString());
                    uiInasistencia.MesId = byte.Parse(drInasistencia["Mes"].ToString());
                    uiInasistencia.MesNombre = this.ObtenerMes(uiInasistencia.MesId);
                    uiInasistencia.Semana = byte.Parse(drInasistencia["Semana"].ToString());

                    uiInasistencia.SalaId = int.Parse(drInasistencia["IdSala"].ToString());
                    if (uiInasistencia.SalaId > 0)
                    {
                        var beSala = new BE.Sala() { IdSala = uiInasistencia.SalaId };
                        bool exists = new DA.Sala().Obtener(ref beSala);
                        uiInasistencia.SalaNombre = (exists == true ? beSala.Nombre : "");
                    }

                    uiInasistencia.CargoId = int.Parse(drInasistencia["IdCargo"].ToString());
                    if (uiInasistencia.CargoId > 0)
                    {
                        int idCargo = uiInasistencia.CargoId;
                        string nombreCargo = "";

                        var beCargo = new DA.Cargo().Obtener(idCargo);
                        if (beCargo != null)
                            nombreCargo = beCargo.Nombre;
                        beCargo = null;

                        uiInasistencia.CargoNombre = nombreCargo;
                    }

                    uiInasistencia.EmpleadoCodigo = drInasistencia["Codigo"].ToString();
                    if (uiInasistencia.EmpleadoCodigo.Length > 0)
                    {
                        string nombreEmpleado = new DA.Trabajador().ObtenerNombreCompleto(uiInasistencia.EmpleadoCodigo);
                        uiInasistencia.EmpleadoNombreCompleto = nombreEmpleado.Length == 0 ? "NO DEFINIDO" : nombreEmpleado;
                    }

                    uiInasistencia.Fecha = DateTime.Parse(drInasistencia["Fecha"].ToString());
                    uiInasistencia.DiaNumero = byte.Parse(drInasistencia["Dia"].ToString());
                    uiInasistencia.DiaNombre = this.ObtenerDia(uiInasistencia.DiaNumero);

                    DateTime fechaInicio = DateTime.Parse(drInasistencia["FechaInicio"].ToString());
                    DateTime fechaFinal = DateTime.Parse(drInasistencia["FechaFinal"].ToString());
                    TimeSpan horaInicio = TimeSpan.Parse(drInasistencia["HoraInicio"].ToString());
                    TimeSpan horaFinal = TimeSpan.Parse(drInasistencia["HoraFinal"].ToString());
                    uiInasistencia.FechaHoraInicio = fechaInicio.Add(horaInicio);
                    uiInasistencia.FechaHoraFinal = fechaFinal.Add(horaFinal);

                    uiInasistencia.Horas = byte.Parse(drInasistencia["Horas"].ToString());

                    uiInasistencia.TipoCodigo = drInasistencia["Tipo"].ToString();
                    if (uiInasistencia.TipoCodigo.Length > 0)
                    {
                        var tipo = new LN.Record().ObtenerTipoInasistencia(uiInasistencia.TipoCodigo);
                        uiInasistencia.TipoNombre = tipo == null ? "No Definido" : tipo.Nombre;
                    }

                    uiInasistencia.Asunto = drInasistencia["Asunto"].ToString();
                    uiInasistencia.Detalle = drInasistencia["Detalle"].ToString();
                    uiInasistencia.Certificado = drInasistencia["CITT"].ToString();

                    lstUiInasistencias.Add(uiInasistencia);
                }

                return lstUiInasistencias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}