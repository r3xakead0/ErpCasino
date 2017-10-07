using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{

    public class Cargo
    {

        private int pId;
        private string pNombre;
        private string pDescripcion;
        private double pBono;
        private bool pActivo;

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

        public double Bono
        {
            get
            {
                return pBono;
            }

            set
            {
                pBono = value;
            }
        }

        public Cargo(int ID, string Nombre, string Descripcion, bool Activo, double Bono)
        {
            this.pId = ID;
            this.pNombre = Nombre;
            this.pDescripcion = Descripcion;
            this.pActivo = Activo;
            this.pBono = Bono;
        }

        public Cargo()
        {
            this.pId = 0;
            this.pNombre = "<Ingrese el nombre>";
            this.pDescripcion = "<Ingrese la descripción>";
            this.pActivo = false;
            this.pBono = 0.0;
        }
  
    }
    
}
