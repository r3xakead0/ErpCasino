using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System.Data;
using System.Collections.Generic;
using System;

namespace ErpCasino.BusinessLibrary.LN
{

    public class Usuario
    {

        int idSesion = 0;

        public Usuario(int idSesion)
        {
            this.idSesion = idSesion;
        }

        private BE.UI.Usuario BeToUi (BE.Usuario beUsuario)
        {
            var uiUsuario = new BE.UI.Usuario();

            uiUsuario.ID = beUsuario.IdUsuario;
            uiUsuario.Username = beUsuario.Username;
            uiUsuario.Password = beUsuario.Password;
            uiUsuario.Nombres = beUsuario.Nombre;
            uiUsuario.Email = beUsuario.Email;
            uiUsuario.Bloqueado = beUsuario.Bloqueado == true ? "Si" : "No";
            uiUsuario.Activo = beUsuario.Activo == true ? "Si" : "No";

            return uiUsuario;
        }

        private BE.Usuario UiToBe(BE.UI.Usuario uiUsuario)
        {
            var beUsuario = new BE.Usuario();

            beUsuario.IdUsuario = uiUsuario.ID;
            beUsuario.Username = uiUsuario.Username;
            beUsuario.Password = uiUsuario.Password;
            beUsuario.Nombre = uiUsuario.Nombres;
            beUsuario.Email = uiUsuario.Email;
            beUsuario.Bloqueado = (uiUsuario.Bloqueado == "Si");
            beUsuario.Activo = (uiUsuario.Activo == "Si");

            return beUsuario;
        }

        public BE.UI.Usuario Validar(string username, string password)
        {
            BE.UI.Usuario uiUsuario = null;
            try
            {
                var beUsuario = new DA.Usuario().Validar(username, password);

                if (beUsuario != null)
                    uiUsuario = this.BeToUi(beUsuario);
                
                return uiUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public bool Insertar(ref BE.UI.Usuario uiUsuario)
        {
            int rowsAffected = 0;

            try
            {
                var beUsuario = this.UiToBe(uiUsuario);
                beUsuario.IdUsuarioCreador = this.idSesion;

                rowsAffected = new DA.Usuario().Insertar(ref beUsuario);
                uiUsuario.ID = beUsuario.IdUsuario;

                return (rowsAffected > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(BE.UI.Usuario uiUsuario)
        {
            int rowsAffected = 0;

            try
            {

                var beUsuario = this.UiToBe(uiUsuario);
                beUsuario.IdUsuarioModificador = this.idSesion;

                rowsAffected = new DA.Usuario().Actualizar(beUsuario);

                return (rowsAffected > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idUsuario)
        {
            int rowsAffected = 0;

            try
            {
                rowsAffected = new DA.Usuario().Eliminar(idUsuario);

                return (rowsAffected > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE.UI.Usuario> Listar()
        {

            List<BE.UI.Usuario> lstUiUsuarios = new List<BE.UI.Usuario>();

            try
            {

                var daUsuario = new DA.Usuario();

                var lstBeUsuarios = daUsuario.Listar();
                foreach (BE.Usuario beUsuario in lstBeUsuarios)
                {
                    var uiUsuario = this.BeToUi(beUsuario);
                    lstUiUsuarios.Add(uiUsuario);
                }

                return lstUiUsuarios;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.Usuario Obtener(int idUsuario)
        {

            BE.UI.Usuario uiUsuario = null;
            try
            {
                var beUsuario = new DA.Usuario().Obtener(idUsuario);
                
                return uiUsuario;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}