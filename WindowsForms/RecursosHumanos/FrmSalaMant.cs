using System;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmSalaMant : Form
    {

        private FrmSalaList frmList = null;

        private BE.Sala beSala = new BE.Sala();

        public FrmSalaMant(FrmSalaList frmList)
        {
            try
            {
                InitializeComponent();
                this.frmList = frmList;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        public void Cargar(BE.UI.Sala uiSala = null)
        {
            try
            {

                if (uiSala != null)
                {

                    if (uiSala.ID == 0)
                        return;

                    this.beSala = new LN.Sala().Obtener(uiSala.ID);

                    if (this.beSala == null)
                        return;

                    this.txtNombre.Text = this.beSala.Nombre;
                    this.txtDescripcion.Text = this.beSala.Descripcion;
                    this.txtZona.Text = this.beSala.Zona;
                    this.txtDireccion.Text = this.beSala.Direccion;
                    this.txtReferencia.Text = this.beSala.Referencia;

                    if (this.beSala.Ubigeo != null)
                    {
                        this.CargarDepartamentos();
                        this.cboDepartamento.SelectedValue = this.beSala.Ubigeo.Departamento.ToString();
                        this.cboDepartamento.Enabled = true;

                        this.CargarProvincias(this.beSala.Ubigeo.Departamento);
                        this.cboProvincia.SelectedValue = this.beSala.Ubigeo.Provincia.ToString();
                        this.cboProvincia.Enabled = true;

                        this.CargarDistritos(this.beSala.Ubigeo.Departamento, this.beSala.Ubigeo.Provincia);
                        this.cboDistrito.SelectedValue = this.beSala.Ubigeo.Distrito.ToString();
                        this.cboDistrito.Enabled = true;
                    }

                    this.chkActivo.Checked = this.beSala.Activo;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void Limpiar()
        {
            try
            {
                //Limpiar objeto
                this.beSala = new BE.Sala();

                //Limpiar controles de edicion
                this.txtNombre.Clear();
                this.txtDescripcion.Clear();
                this.txtZona.Clear();
                this.txtDireccion.Clear();
                this.txtReferencia.Clear();

                this.CargarDepartamentos();
                this.cboProvincia.Enabled = true;
                this.CargarProvincias(0);
                this.cboProvincia.Enabled = false;
                this.CargarDistritos(0, 0);
                this.cboDistrito.Enabled = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        #region Formulario

        private void FrmSalaMant_Load(object sender, EventArgs e)
        {
            try
            {
                this.Limpiar();
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
                int departamento = int.Parse(this.cboDepartamento.SelectedValue.ToString());

                if (departamento > 0)
                {
                    this.CargarProvincias(departamento);
                    this.cboProvincia.Enabled = true;
                }
                else
                {
                    this.CargarProvincias(0);
                    this.cboProvincia.Enabled = false;
                    this.CargarDistritos(0,0);
                    this.cboDistrito.Enabled = false;
                }
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
                int departamento = int.Parse(this.cboDepartamento.SelectedValue.ToString());
                int provincia = int.Parse(this.cboProvincia.SelectedValue.ToString());

                if (departamento > 0 && provincia > 0)
                {
                    this.CargarDistritos(departamento, provincia);
                    this.cboDistrito.Enabled = true;
                }
                else
                {
                    this.CargarDistritos(0, 0);
                    this.cboDistrito.Enabled = false;
                }
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

                #region Validaciones del formulario

                if (this.cboDepartamento.SelectedIndex == 0)
                {
                    this.cboDepartamento.Focus();
                    throw new Exception("Seleccione un departamento");
                }

                if (this.cboProvincia.SelectedIndex == 0)
                {
                    this.cboProvincia.Focus();
                    throw new Exception("Seleccione una provincia");
                }

                if (this.cboDistrito.SelectedIndex == 0)
                {
                    this.cboProvincia.Focus();
                    throw new Exception("Seleccione un distrito");
                }

                if (this.txtNombre.Text.Trim().Length == 0)
                {
                    this.txtNombre.Focus();
                    throw new Exception("Ingrese el nombre de la sala");
                }

                if (this.txtZona.Text.Trim().Length == 0)
                {
                    this.txtZona.Focus();
                    throw new Exception("Ingrese la zona");
                }

                if (this.txtDireccion.Text.Trim().Length == 0)
                {
                    this.txtDireccion.Focus();
                    throw new Exception("Ingrese la direccion");
                }

                #endregion

                #region Guardar

                this.beSala.Nombre = this.txtNombre.Text;
                this.beSala.Descripcion = this.txtDescripcion.Text;
                this.beSala.Zona = this.txtZona.Text;
                this.beSala.Direccion = this.txtDireccion.Text;
                this.beSala.Referencia = this.txtReferencia.Text;

                this.beSala.Activo = this.chkActivo.Checked;

                var beUbigeo = new BE.Ubigeo();
                beUbigeo.Departamento = int.Parse(this.cboDepartamento.SelectedValue.ToString());
                beUbigeo.Provincia = int.Parse(this.cboProvincia.SelectedValue.ToString());
                beUbigeo.Distrito = int.Parse(this.cboDistrito.SelectedValue.ToString());
                if (new LN.Ubigeo().Obtener(ref beUbigeo) == true)
                {
                    this.beSala.Ubigeo = beUbigeo;
                }

                bool rpta = false;
                string msg = "";
                var lnSala = new LN.Sala();
                if (this.beSala.IdSala == 0) //Nuevo
                {
                    rpta = lnSala.Insertar(ref this.beSala);
                    if (true)
                        msg = "Se registro una nuevo Sala";
                }
                else  //Actualizar
                {
                    rpta = lnSala.Actualizar(this.beSala);
                    if (true)
                        msg = "Se actualizo la Sala";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarListadoSalas();
                    this.Close();
                }
                    
                #endregion

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {

                var rpta = Util.ConfirmationMessage($"¿Desea salir del formulario { this.Text }?");

                if (rpta == false)
                    return;

                this.Close();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }


        #endregion

    }
}
