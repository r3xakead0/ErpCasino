using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class Usuario 
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Bloqueado { get; set; } //SI|NO
        public string Activo { get; set; } //SI|NO
    }

}
