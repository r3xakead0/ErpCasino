using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class MetaSala
    {

        private int pId;
        private int pSalaId;
        private string pSalaNombre;
        private int pAnho;
        private int pMes;
        private int pCantidadPersonal;
        private double pMontoPersonal;
        private double pMontoGrupal;
        private bool pCumplido;

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

        public int CantidadPersonal
        {
            get
            {
                return pCantidadPersonal;
            }

            set
            {
                pCantidadPersonal = value;
            }
        }

        public double MontoPersonal
        {
            get
            {
                return pMontoPersonal;
            }

            set
            {
                pMontoPersonal = value;
            }
        }

        public double MontoGrupal
        {
            get
            {
                return pMontoGrupal;
            }

            set
            {
                pMontoGrupal = value;
            }
        }

        public bool Cumplido
        {
            get
            {
                return pCumplido;
            }

            set
            {
                pCumplido = value;
            }
        }

        public MetaSala(int Id, int SalaId, string SalaNombre, int Anho, int Mes,
                        int CantidadPersonal, double MontoPersonal, double MontoGrupal, bool Cumplido)
        {
            this.pId = Id;
            this.pSalaId = SalaId;
            this.pSalaNombre = SalaNombre;
            this.pAnho = Anho;
            this.pMes = Mes;
            this.pCantidadPersonal = CantidadPersonal;
            this.pMontoPersonal = MontoPersonal;
            this.pMontoGrupal = MontoGrupal;
            this.pCumplido = Cumplido;
        }

        public MetaSala()
        {
            this.pId = 0;
            this.pSalaId = 0;
            this.pSalaNombre = "";
            this.pAnho = 0;
            this.pMes = 0;
            this.pCantidadPersonal = 0;
            this.pMontoPersonal = 0.0;
            this.pMontoGrupal = 0.0;
            this.pCumplido = false;
        }
  
    }
    
}
