using System;

namespace ErpCasino.BusinessLibrary.BE.UI
{
    public class Observacion 
    {

        private int pId;
        private string pNombre;
        private string pDescripcion;
        private Activo pActivo;

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

        public Activo Activo
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

        public Observacion(int ID, string Nombre, string Descripcion, Activo Activo)
        {
            this.pId = ID;
            this.pNombre = Nombre;
            this.pDescripcion = Descripcion;
            this.pActivo = Activo;
        }

        public Observacion()
        {
            this.pId = 0;
            this.pNombre = "<Ingrese el nombre>";
            this.pDescripcion = "<Ingrese la descripción>";
            this.pActivo = Activo.Si;
        }

       
    }
    
}
