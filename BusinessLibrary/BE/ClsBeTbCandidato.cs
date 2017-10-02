using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.BE
{

    public class Candidato : Audit
    {

        private int mIdCandidato = 0;
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
        private bool mContratado = false;
        private Ubigeo mUbigeoNacimiento = null;
        private ClsBeTbCandidatoContacto mContacto = null;
        private List<ClsBeTbCandidatoTelefono> mTelefonos = null;
        private ClsBeTbCandidatoContratacion mContratacion = null;
        private int mIdPostulante = 0;

        public int IdCandidato
        {
            get
            {
                return mIdCandidato;
            }
            set
            {
                mIdCandidato = value;
                mContacto.IdCandidato = value;
                for (int i = 0; i < mTelefonos.Count; i++)
                {
                    mTelefonos[i].IdCandidato = value;
                }
                mContratacion.IdCandidato = value;
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

        public ClsBeTbCandidatoContacto Contacto
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

        public List<ClsBeTbCandidatoTelefono> Telefonos
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

        public ClsBeTbCandidatoContratacion Contratacion
        {
            get
            {
                return mContratacion;
            }

            set
            {
                mContratacion = value;
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

        public bool Contratado
        {
            get
            {
                return mContratado;
            }

            set
            {
                mContratado = value;
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

        public int IdPostulante
        {
            get
            {
                return mIdPostulante;
            }

            set
            {
                mIdPostulante = value;
            }
        }

        public Candidato()
        {
            this.Contacto = new ClsBeTbCandidatoContacto();
            this.Telefonos = new List<ClsBeTbCandidatoTelefono>();
            this.Contratacion = new ClsBeTbCandidatoContratacion();
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }

}
