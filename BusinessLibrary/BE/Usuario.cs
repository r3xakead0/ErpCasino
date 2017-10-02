using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Usuario : Audit
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool Bloqueado { get; set; }
        public bool Activo { get; set; }
    }

}
