using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using ErpCasino.BusinessLibrary.BE;
using ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmPostulanteMant : Form
    {

        public ClsBeTbPostulante bePostulante = null;

        public FrmPostulanteList frmList = null;

        public FrmPostulanteMant()
        {
            InitializeComponent();

            this.DtpFechaNacimiento.Value = DateTime.Now.AddYears(-18);

            this.DgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.DgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            this.DgvHistorial.ReadOnly = true;
            this.DgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DgvHistorial.AllowUserToAddRows = false;
            this.DgvHistorial.AllowUserToDeleteRows = false;
            this.DgvHistorial.MultiSelect = false;
            this.DgvHistorial.AllowDrop = false;
            this.DgvHistorial.RowHeadersVisible = false;    
        }

        #region Metodos

        public void Cargar(ClsBeTbPostulante bePostulante = null)
        {
            try
            {

                this.CargarSexos(true);
                this.CargarEstadosCiviles(true);
                this.CargarTiposDocumentos(true);
                this.CargarTelefonos(true);
                this.CargarReclutamientoEstado();
                this.CargarReclutamientoDetalle();

                this.CargarPaises();

                this.CargarDepartamentos(ref this.CbxDepartamentoNacimiento, true);
                this.CargarProvincias(ref this.CbxProvinciaNacimiento, 0, true);

                this.CargarDepartamentos(ref this.CbxDepartamento, true);
                this.CbxDepartamento.SelectedValue = "15";
                this.CargarProvincias(ref this.CbxProvincia, 15, true);
                this.CbxProvincia.SelectedValue = "1";
                this.CargarDistritos(ref this.CbxDistrito, 15, 1, true);

                if (bePostulante != null)
                {

                    this.bePostulante = bePostulante;

                    //General
                    this.TxtNombres.Text = this.bePostulante.Nombres;
                    this.TxtApellidoPaterno.Text = this.bePostulante.ApellidoPaterno;
                    this.TxtApellidoMaterno.Text = this.bePostulante.ApellidoMaterno;
                    this.DtpFechaNacimiento.Value = this.bePostulante.FechaNacimiento;
                    this.CbxSexo.SelectedValue = this.bePostulante.Sexo.Codigo;
                    this.CbxTipoDocumento.SelectedValue = this.bePostulante.TipoDocumento.Codigo;
                    this.TxtNumeroDocumento.Text = this.bePostulante.NumeroDocumento;
                    this.CbxEstadoCivil.SelectedValue = this.bePostulante.EstadoCivil.Codigo;
                    this.CbxActivo.Checked = this.bePostulante.Activo;

                    this.CbxPaisNacimiento.SelectedValue = this.bePostulante.PaisNacimiento.Codigo;
                    if (this.bePostulante.PaisNacimiento.Codigo != "PER")
                    {
                        this.CbxDepartamentoNacimiento.Enabled = false;
                        this.CbxProvinciaNacimiento.Enabled = false;
                    }
                    else
                    {
                        if (this.bePostulante.UbigeoNacimiento != null)
                        {
                            int codDepartamentoNacimiento = this.bePostulante.UbigeoNacimiento.Departamento;
                            this.CbxDepartamentoNacimiento.SelectedValue = codDepartamentoNacimiento.ToString();

                            this.CargarProvincias(ref this.CbxProvinciaNacimiento, codDepartamentoNacimiento, true);

                            int codProvinciaNacimiento = this.bePostulante.UbigeoNacimiento.Provincia;
                            this.CbxProvinciaNacimiento.SelectedValue = codProvinciaNacimiento.ToString();
                        }
                    }


                    //Contacto
                    if (this.bePostulante.Contacto != null)
                    {
                        int codDepartamento = this.bePostulante.Contacto.Ubigeo.Departamento;
                        this.CbxDepartamento.SelectedValue = codDepartamento.ToString();

                        int codProvincia = this.bePostulante.Contacto.Ubigeo.Provincia;
                        this.CargarProvincias(ref this.CbxProvincia, codDepartamento, true);
                        this.CbxProvincia.SelectedValue = codProvincia.ToString();

                        int codDistrito = this.bePostulante.Contacto.Ubigeo.Distrito;
                        this.CargarDistritos(ref this.CbxDistrito, codDepartamento, codProvincia, true);
                        this.CbxDistrito.SelectedValue = codDistrito.ToString();

                        this.TxtZona.Text = this.bePostulante.Contacto.Zona;
                        this.TxtDireccion.Text = this.bePostulante.Contacto.Direccion;
                        this.TxtReferencia.Text = this.bePostulante.Contacto.Referencia;
                        this.TxtEmail.Text = this.bePostulante.Contacto.Email;
                    }

                    //Telefonos
                    if (this.bePostulante.Telefonos != null)
                    {
                        foreach (var telefono in this.bePostulante.Telefonos)
                        {
                            this.CbxTelefono.SelectedValue = telefono.CodTipoTelefono;
                            this.TxtTelefono.Text = telefono.Numero;

                            break;
                        }
                    }

                    //Reclutamiento
                    if (this.bePostulante.Reclutamiento != null)
                    {
                        this.TxtCargoCurriculum.Text = this.bePostulante.Reclutamiento.CargoCurriculum;
                        this.DtpFechaRecepcion.Value = this.bePostulante.Reclutamiento.FechaRecepcion;
                        this.TxtObservacion.Text = this.bePostulante.Reclutamiento.Observacion;

                        this.CargarReclutamientoEstado(this.bePostulante.IdPostulante);

                        //Historial
                        var lstResultadoHistorial = new List<ClsBeResult>();
                        var historiales = this.bePostulante.Reclutamiento.Historial;
                        foreach (var historial in historiales)
                        {
                            var result = new ClsBeResult()
                            {
                                Id = historial.Estado.Nivel,
                                Campo01 = historial.Estado.Nombre,
                                Campo02 = historial.Acepto == true ? "Si" : "No",
                                Campo03 = historial.Nota
                            };
                            lstResultadoHistorial.Add(result);
                        }
                        this.DgvHistorial.DataSource = lstResultadoHistorial;
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
                    throw new Exception("Ingrese los nombres del postulante");
                }

                if (this.TxtApellidoPaterno.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtApellidoPaterno.Focus();
                    throw new Exception("Ingrese el apellido paterno del postulante");
                }

                if (this.TxtApellidoMaterno.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtApellidoMaterno.Focus();
                    throw new Exception("Ingrese el apellido materno del postulante");
                }

                if (int.Parse(this.TxtEdad.Text) < 18)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.DtpFechaNacimiento.Focus();
                    throw new Exception("El postulante debe tener minimo 18 años");
                }

                if (this.CbxSexo.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxSexo.Focus();
                    throw new Exception("Seleccione el sexo del postulante");
                }

                if (this.CbxTipoDocumento.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxTipoDocumento.Focus();
                    throw new Exception("Seleccione el tipo de documento del postulante");
                }

                if (this.TxtNumeroDocumento.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtNumeroDocumento.Focus();
                    throw new Exception("Ingrese el numero de documento del postulante");
                }

                if (this.CbxPaisNacimiento.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxPaisNacimiento.Focus();
                    throw new Exception("Seleccione el pais de nacimiento del postulante");
                }

                if (this.CbxPaisNacimiento.SelectedValue.ToString() == "PER")
                {
                    if (this.CbxDepartamentoNacimiento.SelectedIndex == 0)
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.CbxDepartamentoNacimiento.Focus();
                        throw new Exception("Seleccione el departamento de nacimiento del postulante");
                    }

                    if (this.CbxProvinciaNacimiento.SelectedIndex == 0)
                    {
                        this.TbcMantenimiento.SelectedTab = selectedTap;
                        this.CbxProvinciaNacimiento.Focus();
                        throw new Exception("Seleccione la provincia de nacimiento del postulante");
                    }
                }

                #endregion

                #region Contacto
                selectedTap = this.TbpConctacto;

                if (this.CbxDepartamento.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxDepartamento.Focus();
                    throw new Exception("Seleccione el departamento de contacto del postulante");
                }

                if (this.CbxProvincia.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxProvincia.Focus();
                    throw new Exception("Seleccione la provincia de contacto del postulante");
                }

                if (this.CbxDistrito.SelectedIndex == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.CbxDepartamento.Focus();
                    throw new Exception("Seleccione el distrito de contacto del postulante");
                }

                if (this.TxtZona.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtZona.Focus();
                    throw new Exception("Ingrese la zona del postulante");
                }

                if (this.TxtDireccion.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtDireccion.Focus();
                    throw new Exception("Ingrese la direccion del postulante");
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
                    throw new Exception("Seleccione el telefono del postulante");
                }

                if (this.TxtTelefono.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtTelefono.Focus();
                    throw new Exception("Ingrese el número de telefono del postulante");
                }

                #endregion

                #region Reclutamiento

                selectedTap = this.TbpReclutamiento;

                if (this.TxtCargoCurriculum.Text.Trim().Length == 0)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.TxtCargoCurriculum.Focus();
                    throw new Exception("Ingrese el cargo del curriculum del postulante");
                }

                if (this.DtpFechaRecepcion.Value > DateTime.Now)
                {
                    this.TbcMantenimiento.SelectedTab = selectedTap;
                    this.DtpFechaRecepcion.Focus();
                    throw new Exception("La fecha de recepción del curriculum del postulante no puede ser mayor a la actual");
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
            var lstPaises = new BusinessLibrary.LN.Pais().Listar();

            this.CbxPaisNacimiento.DataSource = lstPaises;
            this.CbxPaisNacimiento.DisplayMember = "Nombre";
            this.CbxPaisNacimiento.ValueMember = "Codigo";

            this.CbxPaisNacimiento.SelectedValue = "PER";
        }

        private void CargarDepartamentos(ref ComboBox cbx, bool Seleccione = false)
        {
            var lstDepartamentos = new BusinessLibrary.LN.Ubigeo().ListarDepartamentos();

            if (Seleccione == true)
                lstDepartamentos.Insert(0, new BusinessLibrary.BE.Record() { Codigo = "0", Nombre = "Seleccione" });

            cbx.DataSource = lstDepartamentos;
            cbx.DisplayMember = "Nombre";
            cbx.ValueMember = "Codigo";
        }

        private void CargarProvincias(ref ComboBox cbx, int departamento, bool Seleccione = false)
        {
            var lstProvincias = new BusinessLibrary.LN.Ubigeo().ListarProvincias(departamento);

            if (Seleccione == true)
                lstProvincias.Insert(0, new BusinessLibrary.BE.Record() { Codigo = "0", Nombre = "Seleccione" });

            cbx.DataSource = lstProvincias;
            cbx.DisplayMember = "Nombre";
            cbx.ValueMember = "Codigo";
        }

        private void CargarDistritos(ref ComboBox cbx, int departamento, int provincia, bool Seleccione = false)
        {
            var lstProvincias = new BusinessLibrary.LN.Ubigeo().ListarDistritos(departamento, provincia);

            if (Seleccione == true)
                lstProvincias.Insert(0, new BusinessLibrary.BE.Record() { Codigo = "0", Nombre = "Seleccione" });

            cbx.DataSource = lstProvincias;
            cbx.DisplayMember = "Nombre";
            cbx.ValueMember = "Codigo";
        }

        private void CargarSexos(bool Seleccione)
        {
            var lstSexos = new BusinessLibrary.LN.Record().ListarSexos();

            if (Seleccione == true)
                lstSexos.Insert(0, new BusinessLibrary.BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.CbxSexo.DataSource = lstSexos;
            this.CbxSexo.DisplayMember = "Nombre";
            this.CbxSexo.ValueMember = "Codigo";
        }

        private void CargarTiposDocumentos(bool Seleccione)
        {
            var lstTiposDocumentos = new BusinessLibrary.LN.Record().ListarTipoDocumento();

            if (Seleccione == true)
                lstTiposDocumentos.Insert(0, new BusinessLibrary.BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.CbxTipoDocumento.DataSource = lstTiposDocumentos;
            this.CbxTipoDocumento.DisplayMember = "Nombre";
            this.CbxTipoDocumento.ValueMember = "Codigo";
        }

        private void CargarEstadosCiviles(bool Seleccione)
        {
            var lstEstadosCiviles = new BusinessLibrary.LN.Record().ListarEstadoCivil();

            if (Seleccione == true)
                lstEstadosCiviles.Insert(0, new BusinessLibrary.BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.CbxEstadoCivil.DataSource = lstEstadosCiviles;
            this.CbxEstadoCivil.DisplayMember = "Nombre";
            this.CbxEstadoCivil.ValueMember = "Codigo";
        }

        private void CargarTelefonos(bool Seleccione)
        {
            var lstTiposTelefonos = new BusinessLibrary.LN.Record().ListarTipoTelefono();

            if (Seleccione == true)
                lstTiposTelefonos.Insert(0, new BusinessLibrary.BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.CbxTelefono.DataSource = lstTiposTelefonos;
            this.CbxTelefono.DisplayMember = "Nombre";
            this.CbxTelefono.ValueMember = "Codigo";
        }

        private void CargarReclutamientoEstado(int? IdPostulante = null, bool Seleccione = true)
        {
            var lstEstados = new Postulante().ListarEstadosReclutamiento(IdPostulante);

            if (Seleccione == true)
                lstEstados.Insert(0, new ClsBeTbPostulanteEstado() { IdPostulanteEstado = 0, Nombre = "Seleccione" });

            this.CbxEstadoReclutamiento.DataSource = lstEstados;
            this.CbxEstadoReclutamiento.DisplayMember = "Nombre";
            this.CbxEstadoReclutamiento.ValueMember = "IdPostulanteEstado";
        }

        private void CargarReclutamientoDetalle()
        {

            this.DgvHistorial.DataSource = new List<ClsBeResult>();

            this.DgvHistorial.Columns["Id"].Visible = false;

            this.DgvHistorial.Columns["Campo01"].Visible = true;
            this.DgvHistorial.Columns["Campo01"].HeaderText = "Estado";
            this.DgvHistorial.Columns["Campo01"].Width = 150;
            this.DgvHistorial.Columns["Campo01"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            this.DgvHistorial.Columns["Campo02"].Visible = true;
            this.DgvHistorial.Columns["Campo02"].HeaderText = "Acepto";
            this.DgvHistorial.Columns["Campo02"].Width = 50;
            this.DgvHistorial.Columns["Campo02"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.DgvHistorial.Columns["Campo03"].Visible = true;
            this.DgvHistorial.Columns["Campo03"].HeaderText = "Nota";
            this.DgvHistorial.Columns["Campo03"].Width = 150;
            this.DgvHistorial.Columns["Campo03"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            this.DgvHistorial.Columns["Campo04"].Visible = false;
            this.DgvHistorial.Columns["Campo05"].Visible = false;
            this.DgvHistorial.Columns["Campo06"].Visible = false;
            this.DgvHistorial.Columns["Campo07"].Visible = false;
            this.DgvHistorial.Columns["Campo08"].Visible = false;
            this.DgvHistorial.Columns["Campo09"].Visible = false;

            Util.AutoWidthColumn(ref this.DgvHistorial, "Campo03");

        }

        #endregion

        #region Eventos

        #region Formulario
        private void FrmPostulanteMant_Load(object sender, EventArgs e)
        {
            try
            {
                this.bePostulante = new ClsBeTbPostulante();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmPostulanteMant_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                this.ResizeEnd -= FrmPostulanteMant_ResizeEnd;

                if (this.Width < 534)
                    this.Width = 534;

                if (this.Height < 529)
                    this.Height = 529;

                this.ResizeEnd += FrmPostulanteMant_ResizeEnd;
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
                var rpta = Util.ConfirmationMessage("¿Desea salir del mantenimiento de postulante?");

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

                var sexo = (BusinessLibrary.BE.Record)this.CbxSexo.SelectedItem;
                var tipodocumento = (BusinessLibrary.BE.Record)this.CbxTipoDocumento.SelectedItem;
                var estadocivil = (BusinessLibrary.BE.Record)this.CbxEstadoCivil.SelectedItem;
                var paisnacimiento = (BusinessLibrary.BE.Pais)this.CbxPaisNacimiento.SelectedItem;

                if (paisnacimiento.Codigo == "PER")
                {
                    int codDepartamentoNacimiento = int.Parse(((BusinessLibrary.BE.Record)this.CbxDepartamentoNacimiento.SelectedItem).Codigo);
                    int codProvinciaNacimiento = int.Parse(((BusinessLibrary.BE.Record)this.CbxProvinciaNacimiento.SelectedItem).Codigo);
                    int codDistritoNacimiento = 0;
                    var oBeTbUbigeoNacimiento = new BusinessLibrary.BE.Ubigeo()
                    {
                        Departamento = codDepartamentoNacimiento,
                        Provincia = codProvinciaNacimiento,
                        Distrito = codDistritoNacimiento
                    };
                    new BusinessLibrary.LN.Ubigeo().Obtener(ref oBeTbUbigeoNacimiento);
                    this.bePostulante.UbigeoNacimiento = oBeTbUbigeoNacimiento;
                }
                else
                {
                    this.bePostulante.UbigeoNacimiento = null;
                }

                this.bePostulante.Nombres = this.TxtNombres.Text;
                this.bePostulante.ApellidoPaterno = this.TxtApellidoPaterno.Text;
                this.bePostulante.ApellidoMaterno = this.TxtApellidoMaterno.Text;
                this.bePostulante.FechaNacimiento = this.DtpFechaNacimiento.Value;
                this.bePostulante.Sexo = sexo;
                this.bePostulante.TipoDocumento = tipodocumento;
                this.bePostulante.NumeroDocumento = this.TxtNumeroDocumento.Text;
                this.bePostulante.PaisNacimiento = paisnacimiento;
                this.bePostulante.EstadoCivil = estadocivil;
                this.bePostulante.Activo = this.CbxActivo.Checked;

                #endregion

                #region Contacto
                if (this.bePostulante.Contacto == null)
                    this.bePostulante.Contacto = new ClsBeTbPostulanteContacto();

                int codDepartamento = int.Parse(((BusinessLibrary.BE.Record)this.CbxDepartamento.SelectedItem).Codigo);
                int codProvincia = int.Parse(((BusinessLibrary.BE.Record)this.CbxProvincia.SelectedItem).Codigo);
                int codDistrito = int.Parse(((BusinessLibrary.BE.Record)this.CbxDistrito.SelectedItem).Codigo);
                var oBeTbUbigeo = new BusinessLibrary.BE.Ubigeo()
                {
                    Departamento = codDepartamento,
                    Provincia = codProvincia,
                    Distrito = codDistrito
                };
                new BusinessLibrary.LN.Ubigeo().Obtener(ref oBeTbUbigeo);
                this.bePostulante.Contacto.Ubigeo = oBeTbUbigeo;

                this.bePostulante.Contacto.Zona = this.TxtZona.Text;
                this.bePostulante.Contacto.Direccion = this.TxtDireccion.Text;
                this.bePostulante.Contacto.Referencia = this.TxtReferencia.Text;
                this.bePostulante.Contacto.Email = this.TxtEmail.Text;

                //Telefonos
                if (this.bePostulante.Telefonos.Count == 1)
                {
                    this.bePostulante.Telefonos[0].CodTipoTelefono = this.CbxTelefono.SelectedValue.ToString();
                    this.bePostulante.Telefonos[0].Numero = this.TxtTelefono.Text;
                }
                else
                {
                    this.bePostulante.Telefonos.Add(new ClsBeTbPostulanteTelefono()
                    {
                        CodTipoTelefono = this.CbxTelefono.SelectedValue.ToString(),
                        Numero = this.TxtTelefono.Text,
                        IdPostulante = bePostulante.IdPostulante
                    });
                }
                #endregion

                #region Reclutamiento
                if (this.bePostulante.Reclutamiento == null)
                    this.bePostulante.Reclutamiento = new ClsBeTbPostulanteReclutamiento();

                this.bePostulante.Reclutamiento.CargoCurriculum = this.TxtCargoCurriculum.Text;
                this.bePostulante.Reclutamiento.FechaRecepcion = this.DtpFechaRecepcion.Value;
                this.bePostulante.Reclutamiento.Observacion = this.TxtObservacion.Text;

                //Historial
                this.bePostulante.Reclutamiento.Historial.Clear();
                if (this.CbxEstadoReclutamiento.SelectedIndex > 0)
                {
                    var estadoPostulante = (ClsBeTbPostulanteEstado)this.CbxEstadoReclutamiento.SelectedItem;

                    this.bePostulante.Reclutamiento.Historial.Add(new ClsBeTbPostulanteHistorial()
                    {
                        IdPostulante = bePostulante.IdPostulante,
                        Estado = estadoPostulante,
                        Acepto = this.CbxAcepto.Checked,
                        Nota = this.TxtNota.Text
                    });
                }
                #endregion

                int idUsuarioSesion = ((MdiMain)this.MdiParent).uiUsuario.ID;
                bool rpta = false;

                if (bePostulante.IdPostulante == 0)
                {
                    bePostulante.IdUsuarioCreador = idUsuarioSesion;
                    rpta = new Postulante().Insertar(ref bePostulante);

                }
                else
                {
                    bePostulante.IdUsuarioModificador = idUsuarioSesion;
                    rpta = new Postulante().Actualizar(bePostulante);
                }

                if (rpta)
                {
                    Util.InformationMessage("Se guardo los datos del postulante");
                    this.frmList.CargarPostulantes();
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

                var objDepartamento = (BusinessLibrary.BE.Record)this.CbxDepartamentoNacimiento.SelectedItem;
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

                var objDepartamento = (BusinessLibrary.BE.Record)this.CbxDepartamento.SelectedItem;
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

                var objDepartamento = (BusinessLibrary.BE.Record)this.CbxDepartamento.SelectedItem;
                int codDepartamento = int.Parse(objDepartamento.Codigo);

                var objProvincia = (BusinessLibrary.BE.Record)this.CbxProvincia.SelectedItem;
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

        #endregion

    }
}
