using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Comprometido
    {

        private BE.UI.Comprometido BeToUi(BE.Comprometido beComprometido)
        {
            var uiComprometido = new BE.UI.Comprometido();

            uiComprometido.Id = beComprometido.IdComprometido;
            uiComprometido.SalaId = beComprometido.Sala.IdSala;
            uiComprometido.SalaNombre = beComprometido.Sala.Nombre;
            uiComprometido.Anho = beComprometido.Anho;
            uiComprometido.Mes = beComprometido.Mes;
            uiComprometido.EmpleadoCodigo = beComprometido.CodigoEmpleado;
            uiComprometido.EmpleadoNombreCompleto = new LN.Empleado().ObtenerNombreCompleto(beComprometido.CodigoEmpleado);
            uiComprometido.Estado = beComprometido.Estado;

            return uiComprometido;
        }

        private BE.Comprometido UiToBe(BE.UI.Comprometido uiComprometido)
        {
            var beComprometido = new BE.Comprometido();

            beComprometido.IdComprometido = uiComprometido.Id;
            beComprometido.Anho = uiComprometido.Anho;
            beComprometido.Mes = uiComprometido.Mes;
            beComprometido.CodigoEmpleado = uiComprometido.EmpleadoCodigo;
            beComprometido.Estado = uiComprometido.Estado;

            beComprometido.Sala = new BE.Sala()
            {
                IdSala = uiComprometido.SalaId,
                Nombre = uiComprometido.SalaNombre
            };

            return beComprometido;
        } 

        public bool Insertar(ref BE.UI.Comprometido uiComprometido)
        {
            try
            {
                var beComprometido = this.UiToBe(uiComprometido);

                bool rpta = new DA.Comprometido().Insertar(ref beComprometido);
                uiComprometido.Id = beComprometido.IdComprometido;

                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Comprometido uiComprometido)
        {
            try
            {
                var beComprometido = this.UiToBe(uiComprometido);
                return new DA.Comprometido().Actualizar(beComprometido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idComprometido)
        {
            try
            {
                return new DA.Comprometido().Eliminar(idComprometido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Comprometido> Listar(int Anho, int Mes, 
                                            int? idSala = null, string codigoEmpleado = null)
        {
            try
            {
                List<BE.Sala> lstBeSalas = new DA.Sala().Listar();

                List<BE.UI.Comprometido> lstUiComprometidos = new List<BE.UI.Comprometido>();

                List<BE.Comprometido> lstBeComprometidos = new DA.Comprometido().Listar(Anho, Mes, idSala, codigoEmpleado);
                foreach (BE.Comprometido beComprometido in lstBeComprometidos)
                {
                    var uiComprometido = this.BeToUi(beComprometido);

                    var beSala = lstBeSalas.Where(x => x.IdSala == uiComprometido.SalaId).FirstOrDefault();
                    if (beSala != null)
                        uiComprometido.SalaNombre = beSala.Nombre;

                    lstUiComprometidos.Add(uiComprometido);
                }

                return lstUiComprometidos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Comprometido Obtener(int idComprometido)
        {
            try
            {
                var beComprometido = new DA.Comprometido().Obtener(idComprometido);

                var uiComprometido = this.BeToUi(beComprometido);

                var beSala = beComprometido.Sala;
                if (new DA.Sala().Obtener(ref beSala) == true)
                    uiComprometido.SalaNombre = beSala.Nombre;

                return uiComprometido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}