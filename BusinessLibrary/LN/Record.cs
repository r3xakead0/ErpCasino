using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Record 
    {

        public List<BE.Record> ListarComisionesAFP()
        {

            List<BE.Record> lst = new List<BE.Record>();

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.ComisionAFP);

                lst = this.Convertir(dt);

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Record ObtenerComisionAFP(string codigo)
        {

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.ComisionAFP);

                List<BE.Record> lstRecord = this.Convertir(dt);

                var beRecord = lstRecord.FirstOrDefault(obj => obj.Codigo == codigo);

                return beRecord;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<BE.Record> ListarTiposInasistencias()
        {

            List<BE.Record> lst = new List<BE.Record>();

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.TipoInasistencia);

                lst = this.Convertir(dt);

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Record ObtenerSexo(string codigo)
        {

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.Sexo);

                List<BE.Record> lstRecord = this.Convertir(dt);

                var beRecord = lstRecord.FirstOrDefault(obj => obj.Codigo == codigo);

                return beRecord;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Record> ListarSexos()
        {

            List<BE.Record> lst = new List<BE.Record>();

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.Sexo);

                lst = this.Convertir(dt);

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Record ObtenerTipoInasistencia(string codigo)
        {

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.TipoInasistencia);

                List<BE.Record> lstRecord = this.Convertir(dt);

                var beRecord = lstRecord.FirstOrDefault(obj => obj.Codigo == codigo);

                return beRecord;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Record> ListarTiposAdelantos()
        {

            List<BE.Record> lst = new List<BE.Record>();

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.TipoAdelanto);

                lst = this.Convertir(dt);

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Record ObtenerTipoAdelanto(string codigo)
        {

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.TipoAdelanto);

                List<BE.Record> lstRecord = this.Convertir(dt);

                var beRecord = lstRecord.FirstOrDefault(obj => obj.Codigo == codigo);

                return beRecord;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Record ObtenerEstadoCivil(string codigo)
        {

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.EstadoCivil);

                List<BE.Record> lstRecord = this.Convertir(dt);

                var beRecord = lstRecord.FirstOrDefault(obj => obj.Codigo == codigo);

                return beRecord;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Record> ListarEstadoCivil()
        {

            List<BE.Record> lst = new List<BE.Record>();

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.EstadoCivil);

                lst = this.Convertir(dt);

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.Record ObtenerTipoDocumento(string codigo)
        {

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.TipoDocumento);

                List<BE.Record> lstRecord = this.Convertir(dt);

                var beRecord = lstRecord.FirstOrDefault(obj => obj.Codigo == codigo);

                return beRecord;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Record> ListarTipoDocumento()
        {

            List<BE.Record> lst = new List<BE.Record>();

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.TipoDocumento);

                lst = this.Convertir(dt);

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.Record> ListarTipoTelefono()
        {

            List<BE.Record> lst = new List<BE.Record>();

            try
            {

                var daCategoria = new DA.Categoria();

                DataTable dt = daCategoria.Listar((int)BE.TipoEnum.TipoTelefono);

                lst = this.Convertir(dt);

                return lst;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE.Record> Convertir(DataTable dt)
        {
            List<BE.Record> lst = new List<BE.Record>();

            foreach (DataRow item in dt.Rows)
            {
                var beRecord = new BE.Record();
                beRecord.Codigo = item["Codigo"].ToString();
                beRecord.Nombre = item["Nombre"].ToString();
                lst.Add(beRecord);
            }

            return lst;
        }


    }

}