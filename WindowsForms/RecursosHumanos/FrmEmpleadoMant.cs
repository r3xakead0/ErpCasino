using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE =ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmEmpleadoMant : Form
    {

        public BE.ClsBeTbEmpleado beEmpleadoGeneral = null;

        public FrmEmpleadoList frmList = null;

        private bool contratarPostulante = false;

        public FrmEmpleadoMant()
        {
            InitializeComponent();

            this.DtpFechaNacimiento.Value = DateTime.Now.AddYears(-18);
        }

        #region Metodos

        private void Cargar()
        {
            try
            {
                this.CargarSexos(true);
                this.CargarEstadosCiviles(true);
                this.CargarTiposDocumentos(true);
                this.CargarTelefonos(true);
                this.CargarAreas(true);
                this.CargarCargos(true);
                this.CargarSalas();
                this.CargarBancos(ref this.CbxBanco, true);
                this.CargarBancos(ref this.CbxBancoCTS, true);
                this.CargarAfps(true);
                this.CargarComisionesAFP(true);
                this.CargarPaises();
                this.CargarTiposRetencionJudicial();

                this.CargarDepartamentos(ref this.CbxDepartamentoNacimiento, true);
                this.CargarProvincias(ref this.CbxProvinciaNacimiento, 0, true);

                this.CargarDepartamentos(ref this.CbxDepartamento, true);
                this.CbxDepartamento.SelectedValue = "15";
                this.CargarProvincias(ref this.CbxProvincia, 15, true);
                this.CbxProvincia.SelectedValue = "1";
                this.CargarDistritos(ref this.CbxDistrito, 15, 1, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Contratar(BE.Candidato beCandidato)
        {
            try
            {

                #region Validaciones

                if (beCandidato == null)
                    return;

                if (beCandidato.Contacto == null)
                    return;

                if (beCandidato.Telefonos == null)
                    return;

                if (beCandidato.Contratacion == null)
                    return;

                #endregion

                #region Convertir datos generales

                var beEmpleado = new BE.ClsBeTbEmpleado();
                beEmpleado.IdEmpleado = 0;
                beEmpleado.Codigo = beCandidato.Codigo;
                beEmpleado.Nombres = beCandidato.Nombres;
                beEmpleado.ApellidoPaterno = beCandidato.ApellidoPaterno;
                beEmpleado.ApellidoMaterno = beCandidato.ApellidoMaterno;
                beEmpleado.FechaNacimiento = beCandidato.FechaNacimiento;
                beEmpleado.NumeroDocumento = beCandidato.NumeroDocumento;
                beEmpleado.Activo = true;
                beEmpleado.UbigeoNacimiento = beCandidato.UbigeoNacimiento;
                beEmpleado.PaisNacimiento = beCandidato.PaisNacimiento;
                beEmpleado.Sexo = beCandidato.Sexo;
                beEmpleado.EstadoCivil = beCandidato.EstadoCivil;
                beEmpleado.TipoDocumento = beCandidato.TipoDocumento;
                beEmpleado.IdCandidato = beCandidato.IdCandidato;

                #endregion

                #region Convertir datos contacto

                beEmpleado.Contacto = new BE.ClsBeTbEmpleadoContacto();
                beEmpleado.Contacto.IdEmpleado = 0;
                beEmpleado.Contacto.Zona = beCandidato.Contacto.Zona;
                beEmpleado.Contacto.Direccion = beCandidato.Contacto.Direccion;
                beEmpleado.Contacto.Referencia = beCandidato.Contacto.Referencia;
                beEmpleado.Contacto.Email = beCandidato.Contacto.Email;
                beEmpleado.Contacto.Ubigeo = beCandidato.Contacto.Ubigeo;

                var lstBeEmpleadoTelefonos = new List<BE.ClsBeTbEmpleadoTelefono>();
                foreach (BE.ClsBeTbCandidatoTelefono beCandidatoTelefono in beCandidato.Telefonos)
                {
                    var beEmpleadoTelefono = new BE.ClsBeTbEmpleadoTelefono();

                    beEmpleadoTelefono.IdEmpleadoTelefono = 0;
                    beEmpleadoTelefono.IdEmpleado = 0;
                    beEmpleadoTelefono.CodTipoTelefono = beCandidatoTelefono.CodTipoTelefono;
                    beEmpleadoTelefono.Numero = beCandidatoTelefono.Numero;

                    lstBeEmpleadoTelefonos.Add(beEmpleadoTelefono);
                }
                beEmpleado.Telefonos = lstBeEmpleadoTelefonos;

                #endregion

                #region Inicializar datos de RRHH

                beEmpleado.Recurso = new BE.ClsBeTbEmpleadoRecurso();

                #endregion

                this.Cargar(beEmpleado);

                contratarPostulante = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Cargar(BE.ClsBeTbEmpleado beEmpleado)
        {
            try
            {

                this.Cargar();

                if (beEmpleado != null)
                {

                    this.beEmpleadoGeneral = beEmpleado;

                    #region General

                    this.TxtCodigo.Text = this.beEmpleadoGeneral.Codigo;
                    this.TxtNombres.Text = this.beEmpleadoGeneral.Nombres;
                    this.TxtApellidoPaterno.Text = this.beEmpleadoGeneral.ApellidoPaterno;
                    this.TxtApellidoMaterno.Text = this.beEmpleadoGeneral.ApellidoMaterno;
                    this.DtpFechaNacimiento.Value = this.beEmpleadoGeneral.FechaNacimiento;
                    this.CbxSexo.SelectedValue = this.beEmpleadoGeneral.Sexo.Codigo;
                    this.CbxTipoDocumento.SelectedValue = this.beEmpleadoGeneral.TipoDocumento.Codigo;
                    this.TxtNumeroDocumento.Text = this.beEmpleadoGeneral.NumeroDocumento;
                    this.CbxEstadoCivil.SelectedValue = this.beEmpleadoGeneral.EstadoCivil.Codigo;
                    this.CbxActivo.Checked = this.beEmpleadoGeneral.Activo;

                    this.CbxPaisNacimiento.SelectedValue = this.beEmpleadoGeneral.PaisNacimiento.Codigo;
                    if (this.beEmpleadoGeneral.PaisNacimiento.Codigo != "PER")
                    {
                        this.CbxDepartamentoNacimiento.Enabled = false;
                        this.CbxProvinciaNacimiento.Enabled = false;
                    }
                    else
                    {
                        if (this.beEmpleadoGeneral.UbigeoNacimiento != null)
                        {
                            int codDepartamentoNacimiento = this.beEmpleadoGeneral.UbigeoNacimiento.Departamento;
                            this.CbxDepartamentoNacimiento.SelectedValue = codDepartamentoNacimiento.ToString();

                            this.CargarProvincias(ref this.CbxProvinciaNacimiento, codDepartamentoNacimiento, true);

                            int codProvinciaNacimiento = this.beEmpleadoGeneral.UbigeoNacimiento.Provincia;
                            this.CbxProvinciaNacimiento.SelectedValue = codProvinciaNacimiento.ToString();
                        }
                    }

                    #endregion

                    #region Contacto

                    if (this.beEmpleadoGeneral.Contacto != null)
                    {
                        int codDepartamento = this.beEmpleadoGeneral.Contacto.Ubigeo.Departamento;
                        this.CbxDepartamento.SelectedValue = codDepartamento.ToString();

                        int codProvincia = this.beEmpleadoGeneral.Contacto.Ubigeo.Provincia;
                        this.CargarProvincias(ref this.CbxProvincia, codDepartamento, true);
                        this.CbxProvincia.SelectedValue = codProvincia.ToString();

                        int codDistrito = this.beEmpleadoGeneral.Contacto.Ubigeo.Distrito;
                        this.CargarDistritos(ref this.CbxDistrito, codDepartamento, codProvincia, true);
                        this.CbxDistrito.SelectedValue = codDistrito.ToString();

                        this.TxtZona.Text = this.beEmpleadoGeneral.Contacto.Zona;
                        this.TxtDireccion.Text = this.beEmpleadoGeneral.Contacto.Direccion;
                        this.TxtReferencia.Text = this.beEmpleadoGeneral.Contacto.Referencia;
                        this.TxtEmail.Text = this.beEmpleadoGeneral.Contacto.Email;
                    }

                    #region Telefonos

                    if (this.beEmpleadoGeneral.Telefonos != null)
                    {
                        foreach (var telefono in beEmpleadoGeneral.Telefonos)
                        {
                            this.CbxTelefono.SelectedValue = telefono.CodTipoTelefono;
                            this.TxtTelefono.Text = telefono.Numero;

                            break;
                        }
                    }

                    #endregion

                    #endregion

                    #region Recurso

                    if (this.beEmpleadoGeneral.Recurso != null)
                    {
                        this.CbxArea.SelectedValue = this.beEmpleadoGeneral.Recurso.Area.IdArea;
                        this.CbxCargo.SelectedValue = this.beEmpleadoGeneral.Recurso.Cargo.IdCargo;
                        this.cboSala.SelectedValue = this.beEmpleadoGeneral.Recurso.Sala.IdSala;
                        this.DtpFechaInicio.Value = this.beEmpleadoGeneral.Recurso.FechaInicio;
                        this.CbxCesado.Checked = this.beEmpleadoGeneral.Recurso.Cesado;
                        this.DtpFechaCese.Value = this.beEmpleadoGeneral.Recurso.FechaCese == null ? DateTime.Now : (DateTime)this.beEmpleadoGeneral.Recurso.FechaCese;
                        this.TxtNumeroHijos.Text = this.beEmpleadoGeneral.Recurso.NumeroHijos.ToString();
                        this.TxtSueldo.Text = this.beEmpleadoGeneral.Recurso.Sueldo.ToString("N2");

                        #region Banco

                        this.CbxBanco.SelectedValue = this.beEmpleadoGeneral.Recurso.Banco.IdBanco;
                        this.TxtCuentaBanco.Text = this.beEmpleadoGeneral.Recurso.CuentaBanco;
                        this.TxtCci.Text = this.beEmpleadoGeneral.Recurso.CCI;

                        #endregion

                        #region Pension SNP - AFP

                        this.CbxOnp.Checked = this.beEmpleadoGeneral.Recurso.ONP;
                        if (this.beEmpleadoGeneral.Recurso.ONP == false)
                        {
                            this.CbxAfp.SelectedValue = this.beEmpleadoGeneral.Recurso.Afp.IdAfp;
                            this.TxtCuspp.Text = this.beEmpleadoGeneral.Recurso.CUSPP;
                            this.CbxComisionAFP.SelectedValue = this.beEmpleadoGeneral.Recurso.CodComision;
                        }

                        #endregion

                        #region CTS

                        if (this.beEmpleadoGeneral.Recurso.BancoCTS != null)
                            this.CbxBancoCTS.SelectedValue = this.beEmpleadoGeneral.Recurso.BancoCTS.IdBanco;

                        this.TxtCuentaCTS.Text = this.beEmpleadoGeneral.Recurso.CuentaCTS;

                        #endregion
                       
                        #region Retencion Judicial

                        double retencionJudicial = 0.0;
                        if (this.beEmpleadoGeneral.Recurso.RetencionJudicialNominal > 0.0)
                        {
                            this.cboRetencionJudicial.SelectedValue = "N";
                            retencionJudicial = this.beEmpleadoGeneral.Recurso.RetencionJudicialNominal;
                        }
                        else if (this.beEmpleadoGeneral.Recurso.RetencionJudicialPorcentual > 0.0)
                        {
                            this.cboRetencionJudicial.SelectedValue = "P";
                            retencionJudicial = this.beEmpleadoGeneral.Recurso.RetencionJudicialPorcentual;
                        }
                        this.txtRetencionJudicial.Text = retencionJudicial.ToString("N2");

                        #endregion

                    }

                    #endregion

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ValidacionesFormulario()
        {
            try
            {
                #region Validaciones del formulario
                TabPage selectedTap = null;

                #region General
                selectedTap = this.TbpGeneral;

                if (this.TxtCodigo.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtCodigo.Focus();
                    throw new Exception("Ingrese el codigo del empleado");
                }
                else 
                {
                    int idEmpleado = beEmpleadoGeneral.IdEmpleado;
                    string codEmpleado = this.TxtCodigo.Text.Trim();
                    var beEmpleado = new BE.ClsBeTbEmpleado() { IdEmpleado = idEmpleado, Codigo = codEmpleado };
                    if (new LN.Empleado().ValidarCodigo(beEmpleado))
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.TxtCodigo.Focus();
                        throw new Exception("El codigo de empleado ya existe");
                    }
                }

                if (this.TxtNombres.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtNombres.Focus();
                    throw new Exception("Ingrese los nombres del empleado");
                }

                if (this.TxtApellidoPaterno.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtApellidoPaterno.Focus();
                    throw new Exception("Ingrese el apellido paterno del empleado");
                }

                if (this.TxtApellidoMaterno.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtApellidoMaterno.Focus();
                    throw new Exception("Ingrese el apellido materno del empleado");
                }

                if (int.Parse(this.TxtEdad.Text) < 18)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.DtpFechaNacimiento.Focus();
                    throw new Exception("El empleado debe tener minimo 18 años");
                }

                if (this.CbxSexo.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxSexo.Focus();
                    throw new Exception("Seleccione el sexo del empleado");
                }

                if (this.CbxTipoDocumento.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxTipoDocumento.Focus();
                    throw new Exception("Seleccione el tipo de documento del empleado");
                }

                if (this.TxtNumeroDocumento.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtNumeroDocumento.Focus();
                    throw new Exception("Ingrese el numero de documento del empleado");
                }

                if (this.CbxPaisNacimiento.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxPaisNacimiento.Focus();
                    throw new Exception("Seleccione el pais de nacimiento del empleado");
                }

                if (this.CbxPaisNacimiento.SelectedValue.ToString() == "PER")
                {
                    if (this.CbxDepartamentoNacimiento.SelectedIndex == 0)
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.CbxDepartamentoNacimiento.Focus();
                        throw new Exception("Seleccione el departamento de nacimiento del empleado");
                    }

                    if (this.CbxProvinciaNacimiento.SelectedIndex == 0)
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.CbxProvinciaNacimiento.Focus();
                        throw new Exception("Seleccione la provincia de nacimiento del empleado");
                    }
                }

                #endregion

                #region Contacto
                selectedTap = this.TbpConctacto;

                if (this.CbxDepartamento.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxDepartamento.Focus();
                    throw new Exception("Seleccione el departamento de contacto del empleado");
                }

                if (this.CbxProvincia.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxProvincia.Focus();
                    throw new Exception("Seleccione la provincia de contacto del empleado");
                }

                if (this.CbxDistrito.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxDepartamento.Focus();
                    throw new Exception("Seleccione el distrito de contacto del empleado");
                }

                if (this.TxtZona.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtZona.Focus();
                    throw new Exception("Ingrese la zona del empleado");
                }

                if (this.TxtEmail.Text.Trim().Length > 0)
                {
                    if (Util.IsValidEmail(this.TxtEmail.Text.Trim()) == false)
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.TxtEmail.Focus();
                        throw new Exception("Ingrese un correo electronico valido");
                    }
                }

                if (this.CbxTelefono.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxTelefono.Focus();
                    throw new Exception("Seleccione el telefono del empleado");
                }

                if (this.TxtTelefono.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtTelefono.Focus();
                    throw new Exception("Ingrese el número de telefono del empleado");
                }

                #endregion

                #region Recurso

                selectedTap = this.TbpRecurso;

                if (this.CbxArea.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxArea.Focus();
                    throw new Exception("Seleccione el area del empleado");
                }

                if (this.CbxCargo.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxCargo.Focus();
                    throw new Exception("Seleccione el cargo del empleado");
                }

                if (this.cboSala.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.cboSala.Focus();
                    throw new Exception("Seleccione el sala del empleado");
                }

                if (this.TxtNumeroHijos.Text.Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtNumeroHijos.Focus();
                    throw new Exception("Ingrese el numero de hijos del empleado");
                }
                else
                {
                    int rptaNroHijos = 0;
                    if (int.TryParse(this.TxtNumeroHijos.Text, out rptaNroHijos) == false)
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.TxtNumeroHijos.Focus();
                        throw new Exception("Ingrese el numero de hijos del empleado");
                    }
                }

                if (this.cboRetencionJudicial.SelectedValue.ToString().Equals("N")) //RJ Nominal
                {
                    double nominal = 0.0;
                    if (double.TryParse(this.txtRetencionJudicial.Text, out nominal) == false)
                        nominal = 0.0;

                    if (nominal == 0.0)
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.txtRetencionJudicial.Focus();
                        throw new Exception("Ingrese el monto de la retención judicial");
                    }
                }
                else if (this.cboRetencionJudicial.SelectedValue.ToString().Equals("P")) //RJ Porcentual
                {
                    double porcentual = 0.0;
                    if (double.TryParse(this.txtRetencionJudicial.Text, out porcentual) == false)
                        porcentual = 0.0;

                    if (porcentual == 0.0)
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.txtRetencionJudicial.Focus();
                        throw new Exception("Ingrese el porcentaje de la retención judicial");
                    }
                    else if (porcentual > 100.0)
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.txtRetencionJudicial.Focus();
                        throw new Exception("El porcentaje de la retención judicial no debe ser mayor al 100%");
                    }
                }

                //FALTA

                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarPaises()
        {
            var lstPaises = new LN.Pais().Listar();

            this.CbxPaisNacimiento.DataSource = lstPaises;
            this.CbxPaisNacimiento.DisplayMember = "Nombre";
            this.CbxPaisNacimiento.ValueMember = "Codigo";

            this.CbxPaisNacimiento.SelectedValue = "PER";
        }

        private void CargarTiposRetencionJudicial()
        {
            try
            {
                var lstTiposRJ = new List<BE.Record>();

                lstTiposRJ.Add(new BE.Record() { Codigo = "", Nombre = "Ninguno" });
                lstTiposRJ.Add(new BE.Record() { Codigo = "N", Nombre = "Nominal" });
                lstTiposRJ.Add(new BE.Record() { Codigo = "P", Nombre = "Porcentual" });

                this.cboRetencionJudicial.DataSource = lstTiposRJ;
                this.cboRetencionJudicial.DisplayMember = "Nombre";
                this.cboRetencionJudicial.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void CargarDepartamentos(ref ComboBox cbx, bool Seleccione = false)
        {
            var lstDepartamentos = new LN.Ubigeo().ListarDepartamentos();

            if (Seleccione == true)
                lstDepartamentos.Insert(0, new BE.Record() { Codigo = "0", Nombre = "Seleccione" });

            cbx.DataSource = lstDepartamentos;
            cbx.DisplayMember = "Nombre";
            cbx.ValueMember = "Codigo";
        }

        private void CargarProvincias(ref ComboBox cbx, int departamento, bool Seleccione = false)
        {
            var lstProvincias = new LN.Ubigeo().ListarProvincias(departamento);

            if (Seleccione == true)
                lstProvincias.Insert(0, new BE.Record() { Codigo = "0", Nombre = "Seleccione" });

            cbx.DataSource = lstProvincias;
            cbx.DisplayMember = "Nombre";
            cbx.ValueMember = "Codigo";
        }

        private void CargarDistritos(ref ComboBox cbx, int departamento, int provincia, bool Seleccione = false)
        {
            var lstProvincias = new LN.Ubigeo().ListarDistritos(departamento, provincia);

            if (Seleccione == true)
                lstProvincias.Insert(0, new BE.Record() { Codigo = "0", Nombre = "Seleccione" });

            cbx.DataSource = lstProvincias;
            cbx.DisplayMember = "Nombre";
            cbx.ValueMember = "Codigo";
        }

        private void CargarSexos(bool Seleccione)
        {
            var lstSexos = new LN.Record().ListarSexos();

            if (Seleccione == true)
                lstSexos.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.CbxSexo.DataSource = lstSexos;
            this.CbxSexo.DisplayMember = "Nombre";
            this.CbxSexo.ValueMember = "Codigo";
        }

        private void CargarTiposDocumentos(bool Seleccione)
        {
            var lstTiposDocumentos = new LN.Record().ListarTipoDocumento();

            if (Seleccione == true)
                lstTiposDocumentos.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.CbxTipoDocumento.DataSource = lstTiposDocumentos;
            this.CbxTipoDocumento.DisplayMember = "Nombre";
            this.CbxTipoDocumento.ValueMember = "Codigo";
        }

        private void CargarEstadosCiviles(bool Seleccione)
        {
            var lstEstadosCiviles = new LN.Record().ListarEstadoCivil();

            if (Seleccione == true)
                lstEstadosCiviles.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.CbxEstadoCivil.DataSource = lstEstadosCiviles;
            this.CbxEstadoCivil.DisplayMember = "Nombre";
            this.CbxEstadoCivil.ValueMember = "Codigo";
        }

        private void CargarComisionesAFP(bool Seleccione)
        {
            var lstComisionesAFP = new LN.Record().ListarComisionesAFP();

            if (Seleccione == true)
                lstComisionesAFP.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.CbxComisionAFP.DataSource = lstComisionesAFP;
            this.CbxComisionAFP.DisplayMember = "Nombre";
            this.CbxComisionAFP.ValueMember = "Codigo";
        }

        private void CargarTelefonos(bool Seleccione)
        {
            var lstTiposTelefonos = new LN.Record().ListarTipoTelefono();

            if (Seleccione == true)
                lstTiposTelefonos.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.CbxTelefono.DataSource = lstTiposTelefonos;
            this.CbxTelefono.DisplayMember = "Nombre";
            this.CbxTelefono.ValueMember = "Codigo";
        }

        private void CargarCargos(bool Seleccione)
        {
            var lstCargos = new LN.Cargo().ListarCombo();

            if (Seleccione == true)
                lstCargos.Insert(0, new BE.UI.Cargo() { Id = 0, Nombre = "Seleccione", Descripcion = "" });

            this.CbxCargo.DataSource = lstCargos;
            this.CbxCargo.DisplayMember = "Nombre";
            this.CbxCargo.ValueMember = "Id";
        }

        private void CargarAreas(bool Seleccione)
        {
            var lstrAreas = new LN.Area().ListarCombo();

            if (Seleccione == true)
                lstrAreas.Insert(0, new BE.Area() { IdArea = 0, Nombre = "Seleccione" });

            this.CbxArea.DataSource = lstrAreas;
            this.CbxArea.DisplayMember = "Nombre";
            this.CbxArea.ValueMember = "IdArea";
        }

        private void CargarSalas(bool Seleccione = true)
        {
            var lstBeSalas = new LN.Sala().ListaSimple();

            if (Seleccione == true)
                lstBeSalas.Insert(0, new BE.Sala() { IdSala = 0, Nombre = "Seleccione" });

            this.cboSala.DataSource = lstBeSalas;
            this.cboSala.DisplayMember = "Nombre";
            this.cboSala.ValueMember = "IdSala";
        }

        private void CargarBancos(ref ComboBox cbo, bool Seleccione)
        {
            var lstrBancos = new LN.Banco().Listar();

            if (Seleccione == true)
                lstrBancos.Insert(0, new BE.Banco() { IdBanco = 0, Nombre = "Seleccione" });

            cbo.DataSource = lstrBancos;
            cbo.DisplayMember = "Nombre";
            cbo.ValueMember = "IdBanco";
        }

        private void CargarAfps(bool Seleccione)
        {
            var lstrAfps = new LN.Afp().ListarCombo();

            if (Seleccione == true)
                lstrAfps.Insert(0, new BE.Afp() { IdAfp = 0, Nombre = "Seleccione" });

            this.CbxAfp.DataSource = lstrAfps;
            this.CbxAfp.DisplayMember = "Nombre";
            this.CbxAfp.ValueMember = "IdAfp";
        }

        #endregion

        #region Formulario

        private void FrmEmpleadoMant_Load(object sender, EventArgs e)
        {
            try
            {
                this.beEmpleadoGeneral = new BE.ClsBeTbEmpleado();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmEmpleadoMant_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                this.ResizeEnd -= FrmEmpleadoMant_ResizeEnd;

                if (this.Width < 534)
                    this.Width = 534;

                if (this.Height < 548)
                    this.Height = 548;

                this.ResizeEnd += FrmEmpleadoMant_ResizeEnd;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                this.ValidacionesFormulario();

                #region General

                var sexo = (BE.Record)this.CbxSexo.SelectedItem;
                var tipodocumento = (BE.Record)this.CbxTipoDocumento.SelectedItem;
                var estadocivil = (BE.Record)this.CbxEstadoCivil.SelectedItem;
                var paisnacimiento = (BE.Pais)this.CbxPaisNacimiento.SelectedItem;

                int codDepartamentoNacimiento = int.Parse(((BE.Record)this.CbxDepartamentoNacimiento.SelectedItem).Codigo);
                int codProvinciaNacimiento = int.Parse(((BE.Record)this.CbxProvinciaNacimiento.SelectedItem).Codigo);
                int codDistritoNacimiento = 0;
                var oBeTbUbigeoNacimiento = new BE.Ubigeo()
                {
                    Departamento = codDepartamentoNacimiento,
                    Provincia = codProvinciaNacimiento,
                    Distrito = codDistritoNacimiento
                };
                new LN.Ubigeo().Obtener(ref oBeTbUbigeoNacimiento);
                this.beEmpleadoGeneral.UbigeoNacimiento = oBeTbUbigeoNacimiento;

                this.beEmpleadoGeneral.Codigo = this.TxtCodigo.Text;
                this.beEmpleadoGeneral.Nombres = this.TxtNombres.Text;
                this.beEmpleadoGeneral.ApellidoPaterno = this.TxtApellidoPaterno.Text;
                this.beEmpleadoGeneral.ApellidoMaterno = this.TxtApellidoMaterno.Text;
                this.beEmpleadoGeneral.FechaNacimiento = this.DtpFechaNacimiento.Value;
                this.beEmpleadoGeneral.Sexo = sexo;
                this.beEmpleadoGeneral.TipoDocumento = tipodocumento;
                this.beEmpleadoGeneral.NumeroDocumento = this.TxtNumeroDocumento.Text;
                this.beEmpleadoGeneral.PaisNacimiento = paisnacimiento;
                this.beEmpleadoGeneral.EstadoCivil = estadocivil;
                this.beEmpleadoGeneral.Activo = this.CbxActivo.Checked;

                #endregion

                #region Contacto

                if (this.beEmpleadoGeneral.Contacto == null)
                    this.beEmpleadoGeneral.Contacto = new BE.ClsBeTbEmpleadoContacto();

                int codDepartamento = int.Parse(((BE.Record)this.CbxDepartamento.SelectedItem).Codigo);
                int codProvincia = int.Parse(((BE.Record)this.CbxProvincia.SelectedItem).Codigo);
                int codDistrito = int.Parse(((BE.Record)this.CbxDistrito.SelectedItem).Codigo);
                var oBeTbUbigeo = new BE.Ubigeo()
                {
                    Departamento = codDepartamento,
                    Provincia = codProvincia,
                    Distrito = codDistrito
                };
                new LN.Ubigeo().Obtener(ref oBeTbUbigeo);
                this.beEmpleadoGeneral.Contacto.Ubigeo = oBeTbUbigeo;

                this.beEmpleadoGeneral.Contacto.Zona = this.TxtZona.Text;
                this.beEmpleadoGeneral.Contacto.Direccion = this.TxtDireccion.Text;
                this.beEmpleadoGeneral.Contacto.Referencia = this.TxtReferencia.Text;
                this.beEmpleadoGeneral.Contacto.Email = this.TxtEmail.Text;

                //Telefonos
                if (this.beEmpleadoGeneral.Telefonos.Count == 1)
                {
                    this.beEmpleadoGeneral.Telefonos[0].CodTipoTelefono = this.CbxTelefono.SelectedValue.ToString();
                    this.beEmpleadoGeneral.Telefonos[0].Numero = this.TxtTelefono.Text;
                }
                else
                {
                    this.beEmpleadoGeneral.Telefonos.Add(new BE.ClsBeTbEmpleadoTelefono()
                    {
                        CodTipoTelefono = this.CbxTelefono.SelectedValue.ToString(),
                        Numero = this.TxtTelefono.Text,
                        IdEmpleado = beEmpleadoGeneral.IdEmpleado
                    });
                }
                #endregion

                #region Recurso

                var beArea = (BE.Area)this.CbxArea.SelectedItem;
                var beSala = (BE.Sala)this.cboSala.SelectedItem;
                var beBancoPago = (BE.Banco)this.CbxBanco.SelectedItem;
                var beBancoCts = (BE.Banco)this.CbxBancoCTS.SelectedItem;

                var uiCargo = (BE.UI.Cargo)this.CbxCargo.SelectedItem;
                var beCargo = new BE.Cargo();
                beCargo.IdCargo = uiCargo.Id;
                beCargo.Nombre = uiCargo.Nombre;
                beCargo.Descripcion = uiCargo.Descripcion;
                beCargo.Activo = uiCargo.Activo;
                beCargo.Bono = uiCargo.Bono;
                uiCargo = null;

                if (this.beEmpleadoGeneral.Recurso == null)
                    this.beEmpleadoGeneral.Recurso = new BE.ClsBeTbEmpleadoRecurso() { IdEmpleado = beEmpleadoGeneral.IdEmpleado };

                this.beEmpleadoGeneral.Recurso.Area = beArea;
                this.beEmpleadoGeneral.Recurso.Cargo = beCargo;
                this.beEmpleadoGeneral.Recurso.Sala = beSala;
                this.beEmpleadoGeneral.Recurso.FechaInicio = this.DtpFechaInicio.Value;

                this.beEmpleadoGeneral.Recurso.Cesado = this.CbxCesado.Checked;
                if (this.beEmpleadoGeneral.Recurso.Cesado == true)
                    this.beEmpleadoGeneral.Recurso.FechaCese = this.DtpFechaCese.Value;
                else
                    this.beEmpleadoGeneral.Recurso.FechaCese = null;

                this.beEmpleadoGeneral.Recurso.NumeroHijos = int.Parse(this.TxtNumeroHijos.Text);
                this.beEmpleadoGeneral.Recurso.Banco = beBancoPago;
                this.beEmpleadoGeneral.Recurso.CuentaBanco = this.TxtCuentaBanco.Text;
                this.beEmpleadoGeneral.Recurso.CCI = this.TxtCci.Text;
                this.beEmpleadoGeneral.Recurso.BancoCTS = beBancoCts;
                this.beEmpleadoGeneral.Recurso.CuentaCTS = this.TxtCuentaCTS.Text;

                double dSueldo = 0.0;
                if(double.TryParse(this.TxtSueldo.Text, out dSueldo) == false)
                    dSueldo = 0.0;
                this.beEmpleadoGeneral.Recurso.Sueldo = dSueldo;

                this.beEmpleadoGeneral.Recurso.ONP = this.CbxOnp.Checked;
                if (this.beEmpleadoGeneral.Recurso.ONP == false)
                {
                    var afp = (BE.Afp)this.CbxAfp.SelectedItem;
                    var comision = (BE.Record)this.CbxComisionAFP.SelectedItem;

                    this.beEmpleadoGeneral.Recurso.Afp = afp;
                    this.beEmpleadoGeneral.Recurso.CUSPP = this.TxtCuspp.Text;
                    this.beEmpleadoGeneral.Recurso.CodComision = comision.Codigo;
                }

                if (this.cboRetencionJudicial.SelectedValue.ToString().Equals("N")) //RJ Nominal
                {
                    double dRjNominal = double.Parse(this.txtRetencionJudicial.Text);
                    this.beEmpleadoGeneral.Recurso.RetencionJudicialNominal = dRjNominal;
                }
                else if (this.cboRetencionJudicial.SelectedValue.ToString().Equals("P")) //RJ Porcentual
                {
                    double dRjPorcentual = double.Parse(this.txtRetencionJudicial.Text);
                    this.beEmpleadoGeneral.Recurso.RetencionJudicialPorcentual = dRjPorcentual;
                }

                #endregion

                var lnEmpleado = new LN.Empleado();

                #region Validar Codigo y Documento

                if (lnEmpleado.ValidarCodigo(beEmpleadoGeneral) == true)
                {
                    this.TxtCodigo.Focus();
                    throw new Exception("El codigo de empleado ya existe");
                }

                if (lnEmpleado.ValidarDocumento(beEmpleadoGeneral) == true)
                {
                    this.TxtNumeroDocumento.Focus();
                    throw new Exception("El tipo y numero de documento de empleado ya existe");
                }

                #endregion

                int idUsuarioSesion = ((MdiMain)this.MdiParent).uiUsuario.ID;

                bool rpta = false;
                if (beEmpleadoGeneral.IdEmpleado == 0)
                {
                    beEmpleadoGeneral.IdUsuarioCreador = idUsuarioSesion;
                    rpta = lnEmpleado.Insertar(ref beEmpleadoGeneral);

                    if (rpta)
                    {
                        if (this.contratarPostulante)
                            rpta = new LN.Postulante().Contratar(beEmpleadoGeneral.IdCandidato);
                    }
                } 
                else
                {
                    beEmpleadoGeneral.IdUsuarioModificador = idUsuarioSesion;
                    rpta = lnEmpleado.Actualizar(beEmpleadoGeneral);
                }

                if (rpta)
                {
                    Util.InformationMessage("Se guardo los datos del empleado");

                    int idEmpleado = beEmpleadoGeneral.IdEmpleado;
                    string filtro = this.frmList.cboTipoFiltro.SelectedValue.ToString();
                    string valor = this.frmList.cboFiltro.SelectedValue.ToString();
                    this.frmList.CargarEmpleados(filtro, valor, idEmpleado);

                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }


        private void CbxCesado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.DtpFechaCese.Enabled = this.CbxCesado.Checked;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void CbxOnp_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.CbxAfp.Enabled = !this.CbxOnp.Checked;
                this.TxtCuspp.Enabled = !this.CbxOnp.Checked;
                this.CbxComisionAFP.Enabled = !this.CbxOnp.Checked;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void CbxPaisNacimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                bool activo = (this.CbxPaisNacimiento.SelectedValue.ToString() == "PER");

                this.CbxDepartamentoNacimiento.Enabled = activo;
                this.CbxProvinciaNacimiento.Enabled = activo;

                if (!activo)
                {
                    this.CbxDepartamentoNacimiento.SelectedIndex = 0;
                    CargarProvincias(ref this.CbxProvinciaNacimiento, 0, true);
                }

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void CbxDepartamentoNacimiento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                var objDepartamento = (BE.Record)this.CbxDepartamentoNacimiento.SelectedItem;
                int codDepartamento = int.Parse(objDepartamento.Codigo);
                this.CargarProvincias(ref this.CbxProvinciaNacimiento, codDepartamento, true);

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void CbxDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                var objDepartamento = (BE.Record)this.CbxDepartamento.SelectedItem;
                int codDepartamento = int.Parse(objDepartamento.Codigo);
                this.CargarProvincias(ref this.CbxProvincia, codDepartamento, true);

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void CbxProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                var objDepartamento = (BE.Record)this.CbxDepartamento.SelectedItem;
                int codDepartamento = int.Parse(objDepartamento.Codigo);

                var objProvincia = (BE.Record)this.CbxProvincia.SelectedItem;
                int codProvincia = int.Parse(objProvincia.Codigo);

                this.CargarDistritos(ref this.CbxDistrito, codDepartamento, codProvincia, true);

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void TxtNumeroHijos_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void DtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var birthdate = this.DtpFechaNacimiento.Value;
                var today = DateTime.UtcNow;
                var age = today.Year - birthdate.Year;
                if (birthdate > today.AddYears(-age)) age--;
                this.TxtEdad.Text = age.ToString();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void TxtSueldo_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                TxtSueldo.SelectAll();
            });
        }

        private void TxtNumeroHijos_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                TxtNumeroHijos.SelectAll();
            });
        }

        private void TxtNumeroHijos_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.TxtNumeroHijos.Text.Length == 0)
                    this.TxtNumeroHijos.Text = "0";
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void TxtSueldo_Leave(object sender, EventArgs e)
        {
            try
            {
                double sueldo = 0.0;

                if (this.TxtSueldo.Text.Length > 0)
                    sueldo = double.Parse(this.TxtSueldo.Text);

                this.TxtSueldo.Text = sueldo.ToString("N2");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void txtRetencionJudicial_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                txtRetencionJudicial.SelectAll();
            });
        }

        private void txtRetencionJudicial_Leave(object sender, EventArgs e)
        {
            try
            {
                double retencion = 0.0;

                if (this.txtRetencionJudicial.Text.Length > 0)
                    retencion = double.Parse(this.txtRetencionJudicial.Text);

                this.txtRetencionJudicial.Text = retencion.ToString("N2");
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboRetencionJudicial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboRetencionJudicial.SelectedIndex == 0)
                {
                    this.txtRetencionJudicial.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

    }
}
