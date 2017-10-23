using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Horario
    {

        private string GetNameOfMonth(int month)
        {
            string nameMonth = "";

            switch (month)
            {
                case 1:
                    nameMonth = "Enero";
                    break;
                case 2:
                    nameMonth = "Febrero";
                    break;
                case 3:
                    nameMonth = "Marzo";
                    break;
                case 4:
                    nameMonth = "Abril";
                    break;
                case 5:
                    nameMonth = "Mayo";
                    break;
                case 6:
                    nameMonth = "Junio";
                    break;
                case 7:
                    nameMonth = "Julio";
                    break;
                case 8:
                    nameMonth = "Agosto";
                    break;
                case 9:
                    nameMonth = "Septiembre";
                    break;
                case 10:
                    nameMonth = "Octubre";
                    break;
                case 11:
                    nameMonth = "Noviembre";
                    break;
                default:
                    nameMonth = "Diciembre";
                    break;
            }

            return nameMonth;
        }

        private BE.Horario HorarioUItoBE(BE.UI.Horario uiHorario)
        {
            var beHorario = new BE.Horario();
            beHorario.IdHorario = uiHorario.IdHorario;
            beHorario.Anho = uiHorario.Anho;
            beHorario.Semana = uiHorario.Semana;
            beHorario.FechaInicio = uiHorario.FechaHoraInicio.Date;
            beHorario.FechaFinal = uiHorario.FechaHoraFinal.Date;
            beHorario.HoraInicio = uiHorario.FechaHoraInicio.TimeOfDay;
            beHorario.HoraFinal = uiHorario.FechaHoraFinal.TimeOfDay;
            beHorario.IdSala = uiHorario.SalaId;
            beHorario.IdCargo = uiHorario.CargoId;
            beHorario.Fecha = uiHorario.Fecha;
            beHorario.Codigo = uiHorario.EmpleadoCodigo;
            beHorario.Dia = uiHorario.DiaNumero;
            beHorario.Turno = uiHorario.Turno;
            beHorario.Horas = uiHorario.Horas;
            return beHorario;
        }

        private BE.UI.Horario HorarioBEtoUI(BE.Horario beHorario)
        {

            string nombreCargo = "";
            var beCargo = new DA.Cargo().Obtener(beHorario.IdCargo);
            if (beCargo != null)
                nombreCargo = beCargo.Nombre;

            var uiHorario = new BE.UI.Horario();
            uiHorario.IdHorario = beHorario.IdHorario;
            uiHorario.Anho = beHorario.Anho;
            uiHorario.Semana = beHorario.Semana;
            uiHorario.FechaHoraInicio = beHorario.FechaInicio.Add(beHorario.HoraInicio);
            uiHorario.FechaHoraFinal = beHorario.FechaFinal.Add(beHorario.HoraFinal);
            uiHorario.SalaId = beHorario.IdSala;
            uiHorario.CargoId = beHorario.IdCargo;
            uiHorario.CargoNombre = nombreCargo;
            uiHorario.Fecha = beHorario.Fecha;
            uiHorario.EmpleadoCodigo = beHorario.Codigo;

            if (uiHorario.EmpleadoCodigo.Length > 0)
            {
                string nombreEmpleado = new DA.ClsDaTbEmpleado().ObtenerNombreCompleto(beHorario.Codigo);
                uiHorario.EmpleadoNombreCompleto = nombreEmpleado.Length == 0 ? "NO DEFINIDO" : nombreEmpleado;
            }
            else
            {
                uiHorario.EmpleadoNombreCompleto = "";
            }

            uiHorario.DiaNumero = beHorario.Dia;
            uiHorario.DiaNombre = this.ObtenerDia(beHorario.Dia);
            uiHorario.Turno = beHorario.Turno;
            uiHorario.Horas = beHorario.Horas;
            return uiHorario;
        }

        private BE.UI.HorarioSemanal HorarioSemanalBEtoUI(BE.HorarioSemanal beHorarioSemanal)
        {
            var uiHorarioSemanal = new BE.UI.HorarioSemanal();
            uiHorarioSemanal.Anho = beHorarioSemanal.Anho;
            uiHorarioSemanal.Semana = beHorarioSemanal.Semana;
            uiHorarioSemanal.FechaInicio = beHorarioSemanal.FechaInicio;
            uiHorarioSemanal.FechaFinal = beHorarioSemanal.FechaFinal;
            uiHorarioSemanal.SalaId = beHorarioSemanal.SalaId;
            uiHorarioSemanal.SalaNombre = beHorarioSemanal.SalaNombre;
            return uiHorarioSemanal;
        }

        private BE.UI.HorarioMensual HorarioMensualBEtoUI(BE.HorarioMensual beHorarioMensual)
        {
            var uiHorarioMensual = new BE.UI.HorarioMensual();
            uiHorarioMensual.Anho = beHorarioMensual.Anho;
            uiHorarioMensual.MesNumero = beHorarioMensual.Mes;
            uiHorarioMensual.MesNombre = this.GetNameOfMonth(beHorarioMensual.Mes);
            uiHorarioMensual.SalaId = beHorarioMensual.SalaId;
            uiHorarioMensual.SalaNombre = beHorarioMensual.SalaNombre;
            return uiHorarioMensual;
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

        public bool Insertar(ref BE.UI.Horario uiHorario)
        {
            try
            {
                var beHorario = this.HorarioUItoBE(uiHorario);
                return new DA.Horario().Insertar(ref beHorario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref List<BE.UI.Horario> lstUiHorarios)
        {
           
            try
            {
                var lstBeHorarios = new List<BE.Horario>();

                for (int i = 0; i < lstUiHorarios.Count; i++)
                {
                    var beHorario = this.HorarioUItoBE(lstUiHorarios[i]);
                    lstBeHorarios.Add(beHorario);
                }

                int rpta = new DA.Horario().Insertar(ref lstBeHorarios);

                return rpta > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Horario uiHorario)
        {
            try
            {
                var beHorario = this.HorarioUItoBE(uiHorario);
                return new DA.Horario().Actualizar(beHorario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idHorario)
        {
            try
            {
                return new DA.Horario().Eliminar(idHorario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarSemana(int anho, byte semana, int idSala)
        {
            try
            {
                return new DA.Horario().EliminarSemana(anho, semana, idSala);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarMes(BE.UI.HorarioSemanal uiHorarioSemanal)
        {
            try
            {
                int anho = uiHorarioSemanal.Anho;
                byte semana = uiHorarioSemanal.Semana;
                int idSala = uiHorarioSemanal.SalaId;
                return new DA.Horario().EliminarSemana(anho, semana, idSala);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarMes(int anho, byte mes, int idSala)
        {
            try
            {
                return new DA.Horario().EliminarMes(anho, mes, idSala);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarMes(BE.UI.HorarioMensual uiHorarioMensual)
        {
            try
            {
                int anho = uiHorarioMensual.Anho;
                byte mes = uiHorarioMensual.MesNumero;
                int idSala = uiHorarioMensual.SalaId;
                return new DA.Horario().EliminarMes(anho, mes, idSala);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Horario> ListarSemana(BE.UI.HorarioSemanal uiHorarioSemanal)
        {
            try
            {
                int anho = uiHorarioSemanal.Anho;
                byte semana = uiHorarioSemanal.Semana;
                int idSala = uiHorarioSemanal.SalaId;
                return this.ListarSemana(anho, semana, idSala);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Horario> ListarSemana(int anho, byte semana, int idSala)
        {
            try
            {
                List<BE.Horario> lstBeHorario = new DA.Horario().ListarSemana(anho, semana, idSala);

                var lstUiHorario = new List<BE.UI.Horario>();
                foreach (BE.Horario beHorario in lstBeHorario)
                {
                    BE.UI.Horario uiHorario = this.HorarioBEtoUI(beHorario);
                    lstUiHorario.Add(uiHorario);
                }
                
                return lstUiHorario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.HorarioMensual> ListarResumenMensual(int idSala = 0)
        {
            try
            {

                List<BE.HorarioMensual> lstBeHorarioMensual = new DA.Horario().ListarResumenMensual(idSala);

                var lstUiHorarioMensual = new List<BE.UI.HorarioMensual>();
                foreach (BE.HorarioMensual beHorarioMensual in lstBeHorarioMensual)
                {
                    BE.UI.HorarioMensual uiHorarioMensual = this.HorarioMensualBEtoUI(beHorarioMensual);
                    lstUiHorarioMensual.Add(uiHorarioMensual);
                }

                return lstUiHorarioMensual;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.HorarioSemanal> ListarResumenSemanal(int idSala = 0)
        {
            try
            {
                List<BE.HorarioSemanal> lstBeHorarioSemanal = new DA.Horario().ListarResumenSemanal(idSala);

                var lstUiHorarioSemanal = new List<BE.UI.HorarioSemanal>();
                foreach (BE.HorarioSemanal beHorarioSemanal in lstBeHorarioSemanal)
                {
                    BE.UI.HorarioSemanal uiHorarioSemanal = this.HorarioSemanalBEtoUI(beHorarioSemanal);
                    lstUiHorarioSemanal.Add(uiHorarioSemanal);
                }

                return lstUiHorarioSemanal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Listar los Empleados y Candidatos que estan asignado en el horario
        /// por Sala, Mes y Año
        /// </summary>
        /// <param name="anho">Numero de año. Ejm: 2017</param>
        /// <param name="semana">Numero de mes. Ejm: 1 (enero) o 12 (Diciembre)</param>
        /// <param name="idSala">ID sala</param>
        /// <returns></returns>
        public List<BE.Record> ListarColaborados(int anho, int semana, int idSala)
        {
            var lstColaborados = new List<BE.Record>();
            try
            {
                var lstEmpleados = new LN.Empleado().Combo();
                var lstCandidatos = new LN.Candidato().Combo();
                lstEmpleados.AddRange(lstCandidatos);
                var lstColaboradores = lstEmpleados.OrderBy(o => o.Nombre).Distinct().ToList();
            
                var lstCodigos = new DA.Horario().ListarColaborados(anho, semana, idSala);
                foreach (string codigo in lstCodigos)
                {
                    var colaborador = lstColaboradores.Where(x => x.Codigo.Equals(codigo)).FirstOrDefault();
                    if (colaborador != null)
                    {
                        lstColaborados.Add(colaborador);
                    }  
                }

                return lstColaborados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}