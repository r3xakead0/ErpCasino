using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmCandidatoMant : Form
    {

        public BE.Candidato beCandidatoGeneral = null;

        public FrmCandidatoList frmList = null;

        private bool contratarPostulante = false;

        public FrmCandidatoMant()
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

                this.CargarPaises();

                this.CargarDepartamentos(ref this.CbxDepartamentoNacimiento, true);
                this.CargarProvincias(ref this.CbxProvinciaNacimiento, 0, true);

                this.CargarDepartamentos(ref this.CbxDepartamento, true);
                this.CbxDepartamento.SelectedValue = "15";
                this.CargarProvincias(ref this.CbxProvincia, 15, true);
                this.CbxProvincia.SelectedValue = "1";
                this.CargarDistritos(ref this.CbxDistrito, 15, 1, true);

                this.CargarDocumentos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Contratar(BE.ClsBeTbPostulante bePostulante)
        {
            try
            {
                #region Validaciones

                if (bePostulante == null)
                    return;

                if (bePostulante.Contacto == null)
                    return;

                if (bePostulante.Telefonos == null)
                    return;

                if (bePostulante.Reclutamiento == null)
                    return;

                #endregion

                #region Convertir datos generales

                var beCandidato = new BE.Candidato();
                beCandidato.IdCandidato = 0;
                beCandidato.Codigo = "";
                beCandidato.Nombres = bePostulante.Nombres;
                beCandidato.ApellidoPaterno = bePostulante.ApellidoPaterno;
                beCandidato.ApellidoMaterno = bePostulante.ApellidoMaterno;
                beCandidato.FechaNacimiento = bePostulante.FechaNacimiento;
                beCandidato.NumeroDocumento = bePostulante.NumeroDocumento;
                beCandidato.Activo = true;
                beCandidato.UbigeoNacimiento = bePostulante.UbigeoNacimiento;
                beCandidato.PaisNacimiento = bePostulante.PaisNacimiento;
                beCandidato.Sexo = bePostulante.Sexo;
                beCandidato.EstadoCivil = bePostulante.EstadoCivil;
                beCandidato.TipoDocumento = bePostulante.TipoDocumento;
                beCandidato.IdPostulante = bePostulante.IdPostulante;

                #endregion

                #region Convertir datos contacto

                beCandidato.Contacto = new BE.ClsBeTbCandidatoContacto();
                beCandidato.Contacto.IdCandidato = 0;
                beCandidato.Contacto.Zona = bePostulante.Contacto.Zona;
                beCandidato.Contacto.Direccion = bePostulante.Contacto.Direccion;
                beCandidato.Contacto.Referencia = bePostulante.Contacto.Referencia;
                beCandidato.Contacto.Email = bePostulante.Contacto.Email;
                beCandidato.Contacto.Ubigeo = bePostulante.Contacto.Ubigeo;

                var lstBeCandidatoTelefonos = new List<BE.ClsBeTbCandidatoTelefono>();
                foreach (BE.ClsBeTbPostulanteTelefono bePostulanteTelefono in bePostulante.Telefonos)
                {
                    var beCandidatoTelefono = new BE.ClsBeTbCandidatoTelefono();

                    beCandidatoTelefono.IdCandidatoTelefono = 0;
                    beCandidatoTelefono.IdCandidato = 0;
                    beCandidatoTelefono.CodTipoTelefono = bePostulanteTelefono.CodTipoTelefono;
                    beCandidatoTelefono.Numero = bePostulanteTelefono.Numero;

                    lstBeCandidatoTelefonos.Add(beCandidatoTelefono);
                }
                beCandidato.Telefonos = lstBeCandidatoTelefonos;

                #endregion

                #region Inicializar datos de contratacion

                beCandidato.Contratacion = new BE.ClsBeTbCandidatoContratacion();

                #endregion

                this.Cargar(beCandidato);

                this.contratarPostulante = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cargar(BE.Candidato beCandidato = null)
        {
            try
            {

                this.Cargar();

                if (beCandidato != null)
                {

                    this.beCandidatoGeneral = beCandidato;

                    //General
                    this.TxtCodigo.Text = this.beCandidatoGeneral.Codigo;
                    this.TxtNombres.Text = this.beCandidatoGeneral.Nombres;
                    this.TxtApellidoPaterno.Text = this.beCandidatoGeneral.ApellidoPaterno;
                    this.TxtApellidoMaterno.Text = this.beCandidatoGeneral.ApellidoMaterno;
                    this.DtpFechaNacimiento.Value = this.beCandidatoGeneral.FechaNacimiento;
                    this.CbxSexo.SelectedValue = this.beCandidatoGeneral.Sexo.Codigo;
                    this.CbxTipoDocumento.SelectedValue = this.beCandidatoGeneral.TipoDocumento.Codigo;
                    this.TxtNumeroDocumento.Text = this.beCandidatoGeneral.NumeroDocumento;
                    this.CbxEstadoCivil.SelectedValue = this.beCandidatoGeneral.EstadoCivil.Codigo;
                    this.CbxActivo.Checked = this.beCandidatoGeneral.Activo;

                    this.CbxPaisNacimiento.SelectedValue = this.beCandidatoGeneral.PaisNacimiento.Codigo;
                    if (this.beCandidatoGeneral.PaisNacimiento.Codigo != "PER")
                    {
                        this.CbxDepartamentoNacimiento.Enabled = false;
                        this.CbxProvinciaNacimiento.Enabled = false;
                    }
                    else
                    {
                        if (this.beCandidatoGeneral.UbigeoNacimiento != null)
                        {
                            int codDepartamentoNacimiento = this.beCandidatoGeneral.UbigeoNacimiento.Departamento;
                            this.CbxDepartamentoNacimiento.SelectedValue = codDepartamentoNacimiento.ToString();

                            this.CargarProvincias(ref this.CbxProvinciaNacimiento, codDepartamentoNacimiento, true);

                            int codProvinciaNacimiento = this.beCandidatoGeneral.UbigeoNacimiento.Provincia;
                            this.CbxProvinciaNacimiento.SelectedValue = codProvinciaNacimiento.ToString();
                        }
                    }

                    //Contacto
                    if (this.beCandidatoGeneral.Contacto != null)
                    {
                        int codDepartamento = this.beCandidatoGeneral.Contacto.Ubigeo.Departamento;
                        this.CbxDepartamento.SelectedValue = codDepartamento.ToString();

                        int codProvincia = this.beCandidatoGeneral.Contacto.Ubigeo.Provincia;
                        this.CargarProvincias(ref this.CbxProvincia, codDepartamento, true);
                        this.CbxProvincia.SelectedValue = codProvincia.ToString();

                        int codDistrito = this.beCandidatoGeneral.Contacto.Ubigeo.Distrito;
                        this.CargarDistritos(ref this.CbxDistrito, codDepartamento, codProvincia, true);
                        this.CbxDistrito.SelectedValue = codDistrito.ToString();

                        this.TxtZona.Text = this.beCandidatoGeneral.Contacto.Zona;
                        this.TxtDireccion.Text = this.beCandidatoGeneral.Contacto.Direccion;
                        this.TxtReferencia.Text = this.beCandidatoGeneral.Contacto.Referencia;
                        this.TxtEmail.Text = this.beCandidatoGeneral.Contacto.Email;
                    }

                    //Telefonos
                    if (this.beCandidatoGeneral.Telefonos != null)
                    {
                        foreach (var telefono in beCandidatoGeneral.Telefonos)
                        {
                            this.CbxTelefono.SelectedValue = telefono.CodTipoTelefono;
                            this.TxtTelefono.Text = telefono.Numero;

                            break;
                        }
                    }

                    //Contratacion
                    if (this.beCandidatoGeneral.Contratacion != null)
                    {
                        this.DtpInicioInduccion.Value = this.beCandidatoGeneral.Contratacion.InduccionFechaInicio;
                        if (this.beCandidatoGeneral.Contratacion.InduccionFechaFin != null)
                        {
                            this.DtpFinInduccion.Value = (DateTime)this.beCandidatoGeneral.Contratacion.InduccionFechaFin;
                            this.CbxConcluyoInduccion.Checked = true;
                        }
                        this.CbxAproboInduccion.Checked = this.beCandidatoGeneral.Contratacion.Induccion;
                        this.CbxAproboDisciplinario.Checked = this.beCandidatoGeneral.Contratacion.Disciplina;
                        this.CbxAproboAdministrativo.Checked = this.beCandidatoGeneral.Contratacion.Informe;

                        this.CbxAproboDocumentos.CheckedChanged -= CbxAproboDocumentos_CheckedChanged;
                        this.ClbDocumentos.ItemCheck -= ClbDocumentos_ItemCheck;
                        this.CbxAproboDocumentos.Checked = this.beCandidatoGeneral.Contratacion.Documentacion;
                        if (this.beCandidatoGeneral.Contratacion.Documentacion == true)
                        {
                            for (int x = 0; x < this.ClbDocumentos.Items.Count; x++)
                            {
                                this.ClbDocumentos.SetItemChecked(x, true);
                            }
                        }
                        this.ClbDocumentos.ItemCheck += ClbDocumentos_ItemCheck;
                        this.CbxAproboDocumentos.CheckedChanged += CbxAproboDocumentos_CheckedChanged;
                        this.TxtObservacion.Text = this.beCandidatoGeneral.Contratacion.Observacion;
                    }

                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
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

                if (this.TxtNombres.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtNombres.Focus();
                    throw new Exception("Ingrese los nombres del candidato");
                }
                else
                {
                    string codEmpleado = this.TxtCodigo.Text.Trim();

                    int idCandidato = this.beCandidatoGeneral.IdCandidato;
                    var beCandidato = new BE.Candidato() { IdCandidato = idCandidato, Codigo = codEmpleado };
                    if (new LN.Candidato().ValidarCodigo(beCandidato))
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.TxtCodigo.Focus();
                        throw new Exception("El codigo de candidato ya existe");
                    }
                    beCandidato = null;

                    int idEmpleado = 0;
                    var beEmpleado = new BE.ClsBeTbEmpleado() { IdEmpleado = idEmpleado, Codigo = codEmpleado };
                    if (new LN.Empleado().ValidarCodigo(beEmpleado))
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.TxtCodigo.Focus();
                        throw new Exception("El codigo de empleado ya existe");
                    }
                    beEmpleado = null;
                }

                if (this.TxtApellidoPaterno.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtApellidoPaterno.Focus();
                    throw new Exception("Ingrese el apellido paterno del candidato");
                }

                if (this.TxtApellidoMaterno.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtApellidoMaterno.Focus();
                    throw new Exception("Ingrese el apellido materno del candidato");
                }

                if (int.Parse(this.TxtEdad.Text) < 18)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.DtpFechaNacimiento.Focus();
                    throw new Exception("El candidato debe tener minimo 18 años");
                }

                if (this.CbxSexo.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxSexo.Focus();
                    throw new Exception("Seleccione el sexo del candidato");
                }

                if (this.CbxTipoDocumento.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxTipoDocumento.Focus();
                    throw new Exception("Seleccione el tipo de documento del candidato");
                }

                if (this.TxtNumeroDocumento.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtNumeroDocumento.Focus();
                    throw new Exception("Ingrese el numero de documento del candidato");
                }

                if (this.CbxPaisNacimiento.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxPaisNacimiento.Focus();
                    throw new Exception("Seleccione el pais de nacimiento del candidato");
                }

                if (this.CbxDepartamentoNacimiento.SelectedValue.ToString() == "PER")
                {
                    if (this.CbxDepartamentoNacimiento.SelectedIndex == 0)
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.CbxDepartamentoNacimiento.Focus();
                        throw new Exception("Seleccione el departamento de nacimiento del candidato");
                    }

                    if (this.CbxProvinciaNacimiento.SelectedIndex == 0)
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.CbxProvinciaNacimiento.Focus();
                        throw new Exception("Seleccione la provincia de nacimiento del candidato");
                    }
                }

                #endregion

                #region Contacto
                selectedTap = this.TbpConctacto;

                if (this.CbxDepartamento.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxDepartamento.Focus();
                    throw new Exception("Seleccione el departamento de contacto del candidato");
                }

                if (this.CbxProvincia.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxProvincia.Focus();
                    throw new Exception("Seleccione la provincia de contacto del candidato");
                }

                if (this.CbxDistrito.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxDepartamento.Focus();
                    throw new Exception("Seleccione el distrito de contacto del candidato");
                }

                if (this.TxtZona.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtZona.Focus();
                    throw new Exception("Ingrese la zona del candidato");
                }

                if (this.TxtDireccion.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtDireccion.Focus();
                    throw new Exception("Ingrese la direccion del candidato");
                }

                if (this.TxtReferencia.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtReferencia.Focus();
                    throw new Exception("Ingrese la referencia del candidato");
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
                    throw new Exception("Seleccione el telefono del candidato");
                }

                if (this.TxtTelefono.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtTelefono.Focus();
                    throw new Exception("Ingrese el número de telefono del candidato");
                }

                #endregion

                #region Contratacion

                selectedTap = this.TbpContratacion;

                if (this.DtpInicioInduccion.Value > this.DtpFinInduccion.Value)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.DtpInicioInduccion.Focus();
                    throw new Exception("La fecha de inicio es mayor a la fecha final de inducción");
                }

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

        private void CargarTelefonos(bool Seleccione)
        {
            var lstTiposTelefonos = new LN.Record().ListarTipoTelefono();

            if (Seleccione == true)
                lstTiposTelefonos.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.CbxTelefono.DataSource = lstTiposTelefonos;
            this.CbxTelefono.DisplayMember = "Nombre";
            this.CbxTelefono.ValueMember = "Codigo";
        }

        private void CargarDocumentos()
        {
            this.ClbDocumentos.Items.Clear();
            this.ClbDocumentos.Items.Add("Documento 1", false);
            this.ClbDocumentos.Items.Add("Documento 2", false);
            this.ClbDocumentos.Items.Add("Documento 3", false);
            this.ClbDocumentos.Items.Add("Documento 4", false);
            this.ClbDocumentos.Items.Add("Documento 5", false);
        }

        #endregion

        #region Eventos

        #region Formulario
        private void FrmCandidatoMant_Load(object sender, EventArgs e)
        {
            try
            {
                this.beCandidatoGeneral = new BE.Candidato();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmCandidatoMant_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                this.ResizeEnd -= FrmCandidatoMant_ResizeEnd;

                if (this.Width < 534)
                    this.Width = 534;

                if (this.Height < 548)
                    this.Height = 548;

                this.ResizeEnd += FrmCandidatoMant_ResizeEnd;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        #endregion

        #region Botones
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                var rpta = Util.ConfirmationMessage("¿Desea salir del mantenimiento de candidato?");

                if (rpta == false)
                    return;

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

                if (paisnacimiento.Codigo == "PER")
                {
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
                    this.beCandidatoGeneral.UbigeoNacimiento = oBeTbUbigeoNacimiento;
                }
                else
                {
                    this.beCandidatoGeneral.UbigeoNacimiento = null;
                }

                this.beCandidatoGeneral.Codigo = this.TxtCodigo.Text;
                this.beCandidatoGeneral.Nombres = this.TxtNombres.Text;
                this.beCandidatoGeneral.ApellidoPaterno = this.TxtApellidoPaterno.Text;
                this.beCandidatoGeneral.ApellidoMaterno = this.TxtApellidoMaterno.Text;
                this.beCandidatoGeneral.FechaNacimiento = this.DtpFechaNacimiento.Value;
                this.beCandidatoGeneral.Sexo = sexo;
                this.beCandidatoGeneral.TipoDocumento = tipodocumento;
                this.beCandidatoGeneral.NumeroDocumento = this.TxtNumeroDocumento.Text;
                this.beCandidatoGeneral.PaisNacimiento = paisnacimiento;
                this.beCandidatoGeneral.EstadoCivil = estadocivil;
                this.beCandidatoGeneral.Activo = this.CbxActivo.Checked;

                #endregion

                #region Contacto
                if (this.beCandidatoGeneral.Contacto == null)
                    this.beCandidatoGeneral.Contacto = new BE.ClsBeTbCandidatoContacto();

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
                this.beCandidatoGeneral.Contacto.Ubigeo = oBeTbUbigeo;

                this.beCandidatoGeneral.Contacto.Zona = this.TxtZona.Text;
                this.beCandidatoGeneral.Contacto.Direccion = this.TxtDireccion.Text;
                this.beCandidatoGeneral.Contacto.Referencia = this.TxtReferencia.Text;
                this.beCandidatoGeneral.Contacto.Email = this.TxtEmail.Text;

                //Telefonos
                if (this.beCandidatoGeneral.Telefonos.Count == 1)
                {
                    this.beCandidatoGeneral.Telefonos[0].CodTipoTelefono = this.CbxTelefono.SelectedValue.ToString();
                    this.beCandidatoGeneral.Telefonos[0].Numero = this.TxtTelefono.Text;
                }
                else
                {
                    this.beCandidatoGeneral.Telefonos.Add(new BE.ClsBeTbCandidatoTelefono()
                    {
                        CodTipoTelefono = this.CbxTelefono.SelectedValue.ToString(),
                        Numero = this.TxtTelefono.Text,
                        IdCandidato = beCandidatoGeneral.IdCandidato
                    });
                }
                #endregion

                #region Contratacion
                if (this.beCandidatoGeneral.Contratacion == null)
                    this.beCandidatoGeneral.Contratacion = new BE.ClsBeTbCandidatoContratacion() { IdCandidato = beCandidatoGeneral.IdCandidato };

                this.beCandidatoGeneral.Contratacion.InduccionFechaInicio = this.DtpInicioInduccion.Value;
                if (this.CbxConcluyoInduccion.Checked)
                    this.beCandidatoGeneral.Contratacion.InduccionFechaFin = this.DtpFinInduccion.Value;
                else
                    this.beCandidatoGeneral.Contratacion.InduccionFechaFin = null;
                this.beCandidatoGeneral.Contratacion.Induccion = this.CbxAproboInduccion.Checked;
                this.beCandidatoGeneral.Contratacion.Disciplina = this.CbxAproboDisciplinario.Checked;
                this.beCandidatoGeneral.Contratacion.Informe = this.CbxAproboAdministrativo.Checked;
                this.beCandidatoGeneral.Contratacion.Documentacion = this.CbxAproboDocumentos.Checked;
                this.beCandidatoGeneral.Contratacion.Observacion = this.TxtObservacion.Text;
                #endregion

                int idUsuarioSesion = ((MdiMain)this.MdiParent).uiUsuario.ID;

                bool rpta = false;

                var lnCanditato = new LN.Candidato();
                if (beCandidatoGeneral.IdCandidato == 0)
                {
                    beCandidatoGeneral.IdUsuarioCreador = idUsuarioSesion;
                    rpta = lnCanditato.Insertar(ref beCandidatoGeneral);

                    if (rpta)
                    {
                        if (this.contratarPostulante == true)
                            rpta = new LN.Postulante().Contratar(beCandidatoGeneral.IdPostulante);
                    }
                }
                else
                {
                    beCandidatoGeneral.IdUsuarioModificador = idUsuarioSesion;
                    rpta = lnCanditato.Actualizar(beCandidatoGeneral);
                }

                if (rpta)
                {
                    Util.InformationMessage("Se guardo los datos del candidato");
                    this.frmList.CargarCandidatos();
                    this.Close();
                }
 
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
        #endregion

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

        private void CbxConcluyoInduccion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.DtpFinInduccion.Enabled = CbxConcluyoInduccion.Checked;

                if (CbxAproboInduccion.Checked == true && CbxConcluyoInduccion.Checked == false)
                {
                    CbxAproboInduccion.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void CbxAproboInduccion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DtpFinInduccion.Enabled == false)
                {
                    CbxAproboInduccion.CheckedChanged -= CbxAproboInduccion_CheckedChanged;
                    CbxAproboInduccion.Checked = false;
                    CbxAproboInduccion.CheckedChanged += CbxAproboInduccion_CheckedChanged;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void DtpFinInduccion_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (DtpFinInduccion.Value < DtpInicioInduccion.Value)
                {
                    DtpFinInduccion.ValueChanged -= DtpFinInduccion_ValueChanged;
                    DtpFinInduccion.Value = DateTime.Now;
                    DtpFinInduccion.ValueChanged += DtpFinInduccion_ValueChanged;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void DtpInicioInduccion_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (DtpFinInduccion.Value < DtpInicioInduccion.Value)
                {
                    DtpInicioInduccion.ValueChanged -= DtpFinInduccion_ValueChanged;
                    DtpInicioInduccion.Value = DtpFinInduccion.Value;
                    DtpInicioInduccion.ValueChanged += DtpFinInduccion_ValueChanged;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void CbxAproboDocumentos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ClbDocumentos.Items.Count != ClbDocumentos.CheckedItems.Count)
                {
                    CbxAproboDocumentos.CheckedChanged -= CbxAproboDocumentos_CheckedChanged;
                    CbxAproboDocumentos.Checked = false;
                    CbxAproboDocumentos.CheckedChanged += CbxAproboDocumentos_CheckedChanged;
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void ClbDocumentos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                this.BeginInvoke(new Action(() =>
                {
                    CbxAproboDocumentos.CheckedChanged -= CbxAproboDocumentos_CheckedChanged;
                    CbxAproboDocumentos.Checked = (ClbDocumentos.Items.Count == ClbDocumentos.CheckedItems.Count);
                    CbxAproboDocumentos.CheckedChanged += CbxAproboDocumentos_CheckedChanged;
                }));
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

    }
}