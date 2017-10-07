using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class MetaSala
    {

        private BE.UI.MetaSala BeToUi(BE.MetaSala beMetaSala)
        {
            var uiMetaSala = new BE.UI.MetaSala();

            uiMetaSala.Id = beMetaSala.IdMetaSala;
            uiMetaSala.SalaId = beMetaSala.Sala.IdSala;
            uiMetaSala.SalaNombre = beMetaSala.Sala.Nombre;
            uiMetaSala.Anho = beMetaSala.Anho;
            uiMetaSala.Mes = beMetaSala.Mes;
            uiMetaSala.CantidadPersonal = beMetaSala.CantidadPersonal;
            uiMetaSala.MontoPersonal = beMetaSala.MontoPersonal;
            uiMetaSala.MontoGrupal = beMetaSala.MontoGrupal;
            uiMetaSala.Cumplido = beMetaSala.Cumplido;

            return uiMetaSala;
        }

        private BE.MetaSala UiToBe(BE.UI.MetaSala uiMetaSala)
        {
            var beMetaSala = new BE.MetaSala();

            beMetaSala.IdMetaSala = uiMetaSala.Id;
            beMetaSala.Anho = uiMetaSala.Anho;
            beMetaSala.Mes = uiMetaSala.Mes;
            beMetaSala.CantidadPersonal = uiMetaSala.CantidadPersonal;
            beMetaSala.MontoPersonal = uiMetaSala.MontoPersonal;
            beMetaSala.MontoGrupal = uiMetaSala.MontoGrupal;
            beMetaSala.Cumplido = uiMetaSala.Cumplido;

            beMetaSala.Sala = new BE.Sala()
            {
                IdSala = uiMetaSala.SalaId,
                Nombre = uiMetaSala.SalaNombre
            };

            return beMetaSala;
        } 

        public bool Insertar(ref BE.UI.MetaSala uiMetaSala)
        {
            try
            {
                var beMetaSala = this.UiToBe(uiMetaSala);

                bool rpta = new DA.MetaSala().Insertar(ref beMetaSala);
                uiMetaSala.Id = beMetaSala.IdMetaSala;

                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.MetaSala uiMetaSala)
        {
            try
            {
                var beMetaSala = this.UiToBe(uiMetaSala);
                return new DA.MetaSala().Actualizar(beMetaSala);
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
                return new DA.MetaSala().Eliminar(idMetaSala);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.MetaSala> Listar()
        {
            try
            {
                List<BE.Sala> lstBeSalas = new DA.Sala().Listar();

                List<BE.UI.MetaSala> lstUiMetaSalas = new List<BE.UI.MetaSala>();

                List<BE.MetaSala> lstBeMetaSalas = new DA.MetaSala().Listar();
                foreach (BE.MetaSala beMetaSala in lstBeMetaSalas)
                {
                    var uiMetaSala = this.BeToUi(beMetaSala);

                    var beSala = lstBeSalas.Where(x => x.IdSala == uiMetaSala.SalaId).FirstOrDefault();
                    if (beSala != null)
                        uiMetaSala.SalaNombre = beSala.Nombre;

                    lstUiMetaSalas.Add(uiMetaSala);
                }

                return lstUiMetaSalas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.MetaSala Obtener(int idSala, int anho, int mes)
        {
            try
            {
                var beMetaSala = new DA.MetaSala().Obtener(idSala, anho, mes);

                var uiMetaSala = this.BeToUi(beMetaSala);

                var beSala = beMetaSala.Sala;
                if (new DA.Sala().Obtener(ref beSala) == true)
                    uiMetaSala.SalaNombre = beSala.Nombre;

                return uiMetaSala;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}