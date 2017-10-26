using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class Empresa
    {

        public int IdEmpresa { get; set; }
        public string NombreComercial { get; set; }
        public string RazonSocial { get; set; }
        public string RUC { get; set; }
        public string DomicilioFiscal { get; set; }
        public Ubigeo Ubigeo { get; set; }

    }

}
