using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class Bono
    {

        private int pId;
        private string pNombre;
        private string pDescripcion;
        private bool pActivo;
        private bool pCalculado;
        private double pMonto;

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

        public string Nombre
        {
            get
            {
                return pNombre;
            }

            set
            {
                pNombre = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return pDescripcion;
            }

            set
            {
                pDescripcion = value;
            }
        }

        public bool Activo
        {
            get
            {
                return pActivo;
            }

            set
            {
                pActivo = value;
            }
        }

        public bool Calculado
        {
            get
            {
                return pCalculado;
            }

            set
            {
                pCalculado = value;
            }
        }

        public double Monto
        {
            get
            {
                return pMonto;
            }

            set
            {
                pMonto = value;
            }
        }

        public Bono(int ID, string Nombre, string Descripcion, bool Activo, bool Calculado, double Monto)
        {
            this.pId = ID;
            this.pNombre = Nombre;
            this.pDescripcion = Descripcion;
            this.pActivo = Activo;
            this.pCalculado = Calculado;
            this.pMonto = Monto;
        }

        public Bono()
        {
            this.pId = 0;
            this.pNombre = "<Ingrese el nombre>";
            this.pDescripcion = "<Ingrese la descripción>";
            this.pActivo = false;
            this.pCalculado = false;
            this.pMonto = 0.0;
        }
  
    }
    
}
