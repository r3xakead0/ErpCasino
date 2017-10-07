using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class Comprometido
    {

        private int pId;
        private int pAnho;
        private int pMes;
        private int pSalaId;
        private string pSalaNombre;
        private string pEmpleadoCodigo;
        private string pEmpleadoNombreCompleto;
        private bool pEstado;

        public int Id
        {
            get
            {
                return pId;
            }

            set
            {
                pId = value;
            }
        }

        public int Anho
        {
            get
            {
                return pAnho;
            }

            set
            {
                pAnho = value;
            }
        }

        public int Mes
        {
            get
            {
                return pMes;
            }

            set
            {
                pMes = value;
            }
        }

        public int SalaId
        {
            get
            {
                return pSalaId;
            }

            set
            {
                pSalaId = value;
            }
        }

        public string SalaNombre
        {
            get
            {
                return pSalaNombre;
            }

            set
            {
                pSalaNombre = value;
            }
        }

        public string EmpleadoCodigo
        {
            get
            {
                return pEmpleadoCodigo;
            }

            set
            {
                pEmpleadoCodigo = value;
            }
        }

        public string EmpleadoNombreCompleto
        {
            get
            {
                return pEmpleadoNombreCompleto;
            }

            set
            {
                pEmpleadoNombreCompleto = value;
            }
        }

        public bool Estado
        {
            get
            {
                return pEstado;
            }

            set
            {
                pEstado = value;
            }
        }

        public Comprometido(int Id, int Anho, int Mes, 
                        int SalaId, string SalaNombre, string EmpleadoCodigo, 
                        string EmpleadoNombreCompleto, bool Estado)
        {
            this.pId = Id;
            this.pAnho = Anho;
            this.pMes = Mes;
            this.pSalaId = SalaId;
            this.pSalaNombre = SalaNombre;
            this.pEmpleadoCodigo = EmpleadoCodigo;
            this.pEmpleadoNombreCompleto = EmpleadoNombreCompleto;
            this.pEstado = Estado;
        }

        public Comprometido()
        {
            this.pId = 0;
            this.pAnho = 0;
            this.pMes = 0;
            this.pSalaId = 0;
            this.pSalaNombre = "";
            this.pEmpleadoCodigo = "";
            this.pEmpleadoNombreCompleto = "";
            this.pEstado = false;
        }
  
    }
    
}
