using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.Configuracion
{
    public partial class FrmEmpresaMant : Form
    {

        private BE.Empresa beEmpresa = null;
         
        public FrmEmpresaMant()
        {
            InitializeComponent();  
        }

        private void FrmEmpresaMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.beEmpresa = new LN.Empresa().Obtener();

                if (this.beEmpresa != null)
                {
                    this.txtNombreComercial.Text = this.beEmpresa.NombreComercial;
                    this.txtRazonSocial.Text = this.beEmpresa.RazonSocial;
                    this.txtRuc.Text = this.beEmpresa.RUC;
                    this.txtDomicilioFiscal.Text = this.beEmpresa.DomicilioFiscal;

                    this.CargarDepartamentos();
                    this.cboDepartamento.SelectedValue = this.beEmpresa.Ubigeo.Departamento.ToString();

                    this.CargarProvincias(beEmpresa.Ubigeo.Departamento);
                    this.cboProvincia.SelectedValue = this.beEmpresa.Ubigeo.Provincia.ToString();

                    this.CargarDistritos(beEmpresa.Ubigeo.Departamento, beEmpresa.Ubigeo.Provincia);
                    this.cboDistrito.SelectedValue = this.beEmpresa.Ubigeo.Distrito.ToString();
                }
                else
                {
                    this.beEmpresa = new BE.Empresa();

                    this.txtNombreComercial.Clear();
                    this.txtRazonSocial.Clear();
                    this.txtRuc.Clear();
                    this.txtDomicilioFiscal.Clear();

                    this.CargarDepartamentos();
                }

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var objDepartamento = (BE.Record)this.cboDepartamento.SelectedItem;
                int codDepartamento = int.Parse(objDepartamento.Codigo);
                this.CargarProvincias(codDepartamento);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                var objDepartamento = (BE.Record)this.cboDepartamento.SelectedItem;
                int codDepartamento = int.Parse(objDepartamento.Codigo);

                var objProvincia = (BE.Record)this.cboProvincia.SelectedItem;
                int codProvincia = int.Parse(objProvincia.Codigo);

                this.CargarDistritos(codDepartamento, codProvincia);

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones 

                if (this.txtRazonSocial.Text.Length == 0)
                {
                    this.txtRazonSocial.Focus();
                    throw new Exception("Ingrese la razon social");
                }

                if (this.txtNombreComercial.Text.Length == 0)
                {
                    this.txtNombreComercial.Focus();
                    throw new Exception("Ingrese el nombre comercial");
                }

                if (this.txtRuc.Text.Length == 0)
                {
                    this.txtRuc.Focus();
                    throw new Exception("Ingrese el número de RUC");
                }

                if (this.txtDomicilioFiscal.Text.Length == 0)
                {
                    this.txtDomicilioFiscal.Focus();
                    throw new Exception("Ingrese el domicilio fiscal");
                }

                if (this.cboDepartamento.SelectedIndex == 0)
                {
                    this.cboDepartamento.Focus();
                    throw new Exception("Seleccione el departamento");
                }

                if (this.cboProvincia.SelectedIndex == 0)
                {
                    this.cboProvincia.Focus();
                    throw new Exception("Seleccione el provincia");
                }

                if (this.cboDistrito.SelectedIndex == 0)
                {
                    this.cboDistrito.Focus();
                    throw new Exception("Seleccione el distrito");
                }

                #endregion

                #region Cargar

                this.beEmpresa.NombreComercial = this.txtNombreComercial.Text;
                this.beEmpresa.RazonSocial = this.txtRazonSocial.Text;
                this.beEmpresa.RUC = this.txtRuc.Text;
                this.beEmpresa.DomicilioFiscal = this.txtDomicilioFiscal.Text;

                var beUbigeo = new BE.Ubigeo();
                beUbigeo.Departamento = int.Parse(this.cboDepartamento.SelectedValue.ToString());
                beUbigeo.Provincia = int.Parse(this.cboProvincia.SelectedValue.ToString());
                beUbigeo.Distrito = int.Parse(this.cboDistrito.SelectedValue.ToString());
                if (new LN.Ubigeo().Obtener(ref beUbigeo) == true)
                    this.beEmpresa.Ubigeo = beUbigeo;

                #endregion

                #region Registrar 

                bool rpta = false;

                var lnEmpresa = new LN.Empresa();
                if (this.beEmpresa.IdEmpresa == 0)
                    rpta = lnEmpresa.Insertar(ref this.beEmpresa);
                else
                    rpta = lnEmpresa.Actualizar(this.beEmpresa);

                if (rpta)
                {
                    Util.InformationMessage("Se registro los datos de la empresa");
                    this.Close();
                }

                #endregion

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #region Metodos 

        private void CargarDepartamentos()
        {
            var lstDepartamentos = new LN.Ubigeo().ListarDepartamentos();
            lstDepartamentos.Insert(0, new BE.Record() { Codigo = "0", Nombre = "Seleccione" });

            this.cboDepartamento.DataSource = lstDepartamentos;
            this.cboDepartamento.DisplayMember = "Nombre";
            this.cboDepartamento.ValueMember = "Codigo";
        }

        private void CargarProvincias(int departamento)
        {
            var lstProvincias = new LN.Ubigeo().ListarProvincias(departamento);
            lstProvincias.Insert(0, new BE.Record() { Codigo = "0", Nombre = "Seleccione" });

            this.cboProvincia.DataSource = lstProvincias;
            this.cboProvincia.DisplayMember = "Nombre";
            this.cboProvincia.ValueMember = "Codigo";
        }

        private void CargarDistritos(int departamento, int provincia)
        {
            var lstProvincias = new LN.Ubigeo().ListarDistritos(departamento, provincia);
            lstProvincias.Insert(0, new BE.Record() { Codigo = "0", Nombre = "Seleccione" });

            this.cboDistrito.DataSource = lstProvincias;
            this.cboDistrito.DisplayMember = "Nombre";
            this.cboDistrito.ValueMember = "Codigo";
        }

        #endregion

    }
}
