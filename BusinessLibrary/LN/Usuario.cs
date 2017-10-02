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

        public bool Validar(ref BE.UI.Usuario uiUsuario)
        {
            bool exists = false;
            try
            {
                var beUsuario = new BE.Usuario();
                beUsuario.Username = uiUsuario.Username;
                beUsuario.Password = uiUsuario.Password;

                exists = new DA.Usuario().Validar(ref beUsuario);

                if (exists)
                {
                    uiUsuario.ID = beUsuario.IdUsuario;
                    uiUsuario.Username = beUsuario.Username;
                    uiUsuario.Password = beUsuario.Password;
                    uiUsuario.Nombres = beUsuario.Nombre;
                    uiUsuario.Email = beUsuario.Email;
                    uiUsuario.Bloqueado = beUsuario.Bloqueado == true ? "Si" : "No";
                    uiUsuario.Activo = beUsuario.Activo == true ? "Si" : "No";
                }

                return exists;
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
                var beUsuario = new BE.Usuario();
                beUsuario.Username = uiUsuario.Username;
                beUsuario.Password = uiUsuario.Password;
                beUsuario.Nombre = uiUsuario.Nombres;
                beUsuario.Email = uiUsuario.Email;
                beUsuario.Bloqueado = (uiUsuario.Bloqueado == "Si");
                beUsuario.Activo = (uiUsuario.Activo == "Si");
                beUsuario.IdUsuarioCreador = this.idSesion;

                rowsAffected = new DA.Usuario().Insertar(ref beUsuario);

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

                var beUsuario = new BE.Usuario();
                beUsuario.IdUsuario = uiUsuario.ID;
                beUsuario.Username = uiUsuario.Username;
                beUsuario.Password = uiUsuario.Password;
                beUsuario.Nombre = uiUsuario.Nombres;
                beUsuario.Email = uiUsuario.Email;
                beUsuario.Bloqueado = (uiUsuario.Bloqueado == "Si");
                beUsuario.Activo = (uiUsuario.Activo == "Si");
                beUsuario.IdUsuarioCreador = this.idSesion;

                rowsAffected = new DA.Usuario().Actualizar(ref beUsuario);

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
                    var uiUsuario = new BE.UI.Usuario();

                    uiUsuario.ID = beUsuario.IdUsuario;
                    uiUsuario.Username = beUsuario.Username;
                    uiUsuario.Password = beUsuario.Password;
                    uiUsuario.Nombres = beUsuario.Nombre;
                    uiUsuario.Email = beUsuario.Email;
                    uiUsuario.Bloqueado = beUsuario.Bloqueado == true ? "Si" : "No";
                    uiUsuario.Activo = beUsuario.Activo == true ? "Si" : "No";

                    lstUiUsuarios.Add(uiUsuario);
                }

                return lstUiUsuarios;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}