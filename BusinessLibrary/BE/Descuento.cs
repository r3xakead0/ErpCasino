using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Descuento
    {

        private int mIdDescuento = 0;
        private string mNombre = "";
        private string mDescripcion = "";
        private double mMonto = 0.0;
        private bool mActivo = false;

        public int IdDescuento
        {
            get
            {
                return mIdDescuento;
            }
            set
            {
                mIdDescuento = value;
            }
        }

        public string Nombre
        {
            get
            {
                return mNombre;
            }
            set
            {
                mNombre = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return mDescripcion;
            }
            set
            {
                mDescripcion = value;
            }
        }

        public double Monto
        {
            get
            {
                return mMonto;
            }
            set
            {
                mMonto = value;
            }
        }

        public bool Activo
        {
            get
            {
                return mActivo;
            }
            set
            {
                mActivo = value;
            }
        }

        public Descuento()
        {

        }
    }
}
