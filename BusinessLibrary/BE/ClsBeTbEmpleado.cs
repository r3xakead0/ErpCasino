using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbEmpleado : Audit, ICloneable
    {

        private int mIdEmpleado = 0;
        private string mCodigo = "";
        private string mNombres = "";
        private string mApellidoPaterno = "";
        private string mApellidoMaterno = "";
        private DateTime mFechaNacimiento = DateTime.Now.AddYears(-18);
        private Record mSexo = null;
        private Record mTipoDocumento = null;
        private string mNumeroDocumento = "";
        private Pais mPaisNacimiento = null;
        private Record mEstadoCivil = null;
        private bool mActivo = false;
        private Ubigeo mUbigeoNacimiento = null;
        private ClsBeTbEmpleadoContacto mContacto = null;
        private ClsBeTbEmpleadoRecurso mRecurso = null;
        private List<ClsBeTbEmpleadoTelefono> mTelefonos = null;
        private int mIdCandidato = 0;

        public int IdEmpleado
        {
            get
            {
                return mIdEmpleado;
            }
            set
            {
                mIdEmpleado = value;
                this.mContacto.IdEmpleado = value;
                this.mRecurso.IdEmpleado = value;
                for (int i = 0; i < mTelefonos.Count; i++)
                {
                    this.mTelefonos[i].IdEmpleado = value;
                }
            }
        }

        public string Codigo
        {
            get
            {
                return mCodigo;
            }
            set
            {
                mCodigo = value;
            }
        }

        public string Nombres
        {
            get
            {
                return mNombres;
            }
            set
            {
                mNombres = value;
            }
        }

        public string ApellidoPaterno
        {
            get
            {
                return mApellidoPaterno;
            }
            set
            {
                mApellidoPaterno = value;
            }
        }

        public string ApellidoMaterno
        {
            get
            {
                return mApellidoMaterno;
            }
            set
            {
                mApellidoMaterno = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return mFechaNacimiento;
            }
            set
            {
                mFechaNacimiento = value;
            }
        }

        public Record Sexo
        {
            get
            {
                return mSexo;
            }
            set
            {
                mSexo = value;
            }
        }

        public Record TipoDocumento
        {
            get
            {
                return mTipoDocumento;
            }
            set
            {
                mTipoDocumento = value;
            }
        }

        public string NumeroDocumento
        {
            get
            {
                return mNumeroDocumento;
            }
            set
            {
                mNumeroDocumento = value;
            }
        }

        public Pais PaisNacimiento
        {
            get
            {
                return mPaisNacimiento;
            }
            set
            {
                mPaisNacimiento = value;
            }
        }

        public Record EstadoCivil
        {
            get
            {
                return mEstadoCivil;
            }
            set
            {
                mEstadoCivil = value;
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

        public ClsBeTbEmpleadoContacto Contacto
        {
            get
            {
                return mContacto;
            }
            set
            {
                mContacto = value;
            }
        }

        public ClsBeTbEmpleadoRecurso Recurso
        {
            get
            {
                return mRecurso;
            }
            set
            {
                mRecurso = value;
            }
        }

        public List<ClsBeTbEmpleadoTelefono> Telefonos
        {
            get
            {
                return mTelefonos;
            }
            set
            {
                mTelefonos = value;
            }
        }

        public Ubigeo UbigeoNacimiento
        {
            get
            {
                return mUbigeoNacimiento;
            }

            set
            {
                mUbigeoNacimiento = value;
            }
        }

        public int IdCandidato
        {
            get
            {
                return mIdCandidato;
            }

            set
            {
                mIdCandidato = value;
            }
        }

        public ClsBeTbEmpleado()
        {
            this.Contacto = new ClsBeTbEmpleadoContacto();
            this.Recurso = new ClsBeTbEmpleadoRecurso();
            this.Telefonos = new List<ClsBeTbEmpleadoTelefono>();
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }

}
