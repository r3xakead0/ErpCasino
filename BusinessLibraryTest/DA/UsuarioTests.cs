using Microsoft.VisualStudio.TestTools.UnitTesting;
using DA = ErpCasino.BusinessLibrary.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpCasino.BusinessLibrary.DA.Tests
{
    [TestClass()]
    public class UsuarioTests
    {

        string usernameInput = "Test01";
        string passwordInput = "Test01";
        string nombreInput = "Test 01";
        string emailInput = "Test01@mail.com";

        [TestMethod()]
        public void InsertarTest()
        {
            var uiUsuario = new BE.Usuario();
            uiUsuario.Username = usernameInput;
            uiUsuario.Password = passwordInput;
            uiUsuario.Nombre = nombreInput;
            uiUsuario.Email = emailInput;
            uiUsuario.Bloqueado = false;
            uiUsuario.Activo = true;
            uiUsuario.IdUsuarioCreador = 1;

            int rpta = new DA.Usuario().Insertar(ref uiUsuario);
            Assert.AreEqual<int>(rpta, 1);
        }

        [TestMethod()]
        public void ActualizarTest()
        {

            var daUsuario = new DA.Usuario();
            var uiUsuario = daUsuario.Validar(usernameInput, passwordInput);
            uiUsuario.IdUsuarioModificador = 1;

            int rpta = daUsuario.Actualizar(uiUsuario);
            Assert.AreEqual<int>(rpta, 1);
        }

        [TestMethod()]
        public void ListarTest()
        {
            int rpta = new DA.Usuario().Listar().Count;
            Assert.AreNotEqual<int>(rpta, 0);
        }

        [TestMethod()]
        public void ObtenerTest()
        {
            var daUsuario = new DA.Usuario();
            var uiUsuario = daUsuario.Validar(usernameInput, passwordInput);

            uiUsuario = daUsuario.Obtener(uiUsuario.IdUsuario);
            Assert.IsNotNull(uiUsuario);
        }

        [TestMethod()]
        public void ValidarTest()
        {
            var uiUsuario = new DA.Usuario().Validar(usernameInput, passwordInput);
            Assert.IsNotNull(uiUsuario);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var daUsuario = new DA.Usuario();
            var uiUsuario = daUsuario.Validar(usernameInput, passwordInput);

            int rpta = 0;

            if (uiUsuario != null)
                rpta = daUsuario.Eliminar(uiUsuario.IdUsuario);

            Assert.AreEqual<int>(rpta, 1);
        }
    }
}