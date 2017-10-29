using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarObservacionMant : Form
    {

        #region "Patron Singleton"

        private static FrmAsignarObservacionMant frmInstance = null;

        public static FrmAsignarObservacionMant Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmAsignarObservacionMant();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmAsignarObservacionList frmList = null;

        private BE.UI.ObservacionEmpleado uiObservacionEmpleado = null;

        public FrmAsignarObservacionMant()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        public void Cargar(BE.UI.ObservacionEmpleado uiObservacionEmpleado = null)
        {
            try
            {

                if (uiObservacionEmpleado != null)
                {

                    this.uiObservacionEmpleado = uiObservacionEmpleado;

                    this.dtpFecha.Value = this.uiObservacionEmpleado.Fecha;
                    this.cboSala.SelectedValue = this.uiObservacionEmpleado.SalaID;
                    this.txtEmpleadoCodigo.Text = this.uiObservacionEmpleado.EmpleadoCodigo;
                    this.cboEmpleado.SelectedValue = this.uiObservacionEmpleado.EmpleadoCodigo;
                    this.cboObservacion.SelectedValue = this.uiObservacionEmpleado.ObservacionID;
                    this.txtDescripcion.Text = this.uiObservacionEmpleado.ObservacionDescripcion;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Limpiar()
        {
            try
            {
                //Limpiar objeto
                this.uiObservacionEmpleado = new BE.UI.ObservacionEmpleado();

                //Limpiar controles de edicion
                this.dtpFecha.Value = DateTime.Now;
                this.CargarSalas();
                this.txtEmpleadoCodigo.Clear();
                this.CargarEmpleados();
                this.CargarTiposObservaciones();
                this.txtDescripcion.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarEmpleados()
        {
            var lstEmpleados = new LN.Empleado().Combo();
            var lstCandidatos = new LN.Candidato().Combo();
            lstEmpleados.AddRange(lstCandidatos);
            var lstTrabajador = lstEmpleados.OrderBy(o => o.Codigo).Distinct().ToList();

            lstTrabajador.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.cboEmpleado.DataSource = lstTrabajador;
            this.cboEmpleado.DisplayMember = "Nombre";
            this.cboEmpleado.ValueMember = "Codigo";
        }

        private void CargarSalas()
        {
            try
            {

                var lstBeSalas = new LN.Sala().ListaSimple();

                lstBeSalas.Insert(0, new BE.Sala() { IdSala = 0, Nombre = "Seleccione" });

                this.cboSala.DataSource = lstBeSalas;
                this.cboSala.DisplayMember = "Nombre";
                this.cboSala.ValueMember = "IdSala";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarTiposObservaciones()
        {
            try
            {
                int idUsuario = 0;

                var lstTipos = new LN.Observacion(idUsuario).Listar();

                lstTipos.Insert(0, new BE.UI.Observacion() { Id = 0, Nombre = "Seleccione", Descripcion = "" });

                this.cboObservacion.DataSource = lstTipos;
                this.cboObservacion.DisplayMember = "Nombre";
                this.cboObservacion.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Formulario

        private void FrmAfpComisionMant_Load(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones

                if (this.cboEmpleado.SelectedIndex == 0)
                {
                    this.cboEmpleado.Focus();
                    throw new Exception("Seleccione un Empleado");
                }

                if (this.cboSala.SelectedIndex == 0)
                {
                    this.cboSala.Focus();
                    throw new Exception("Seleccione una Sala");
                }

                if (this.cboObservacion.SelectedIndex == 0)
                {
                    this.cboObservacion.Focus();
                    throw new Exception("Seleccione un Tipo de Observación");
                }

                if (this.txtDescripcion.Text.Trim().Length == 0)
                {
                    this.txtDescripcion.Focus();
                    throw new Exception("Ingrese la Observación");
                }
                
                #endregion

                #region Guardar
 
                this.uiObservacionEmpleado.Fecha = this.dtpFecha.Value;
                this.uiObservacionEmpleado.EmpleadoCodigo = ((BE.Record)this.cboEmpleado.SelectedItem).Codigo;
                this.uiObservacionEmpleado.EmpleadoNombreCompleto = ((BE.Record)this.cboEmpleado.SelectedItem).Nombre;
                this.uiObservacionEmpleado.SalaID = ((BE.Sala)this.cboSala.SelectedItem).IdSala;
                this.uiObservacionEmpleado.SalaNombre = ((BE.Sala)this.cboSala.SelectedItem).Nombre;
                this.uiObservacionEmpleado.ObservacionID = ((BE.UI.Observacion)this.cboObservacion.SelectedItem).Id;
                this.uiObservacionEmpleado.ObservacionNombre = ((BE.UI.Observacion)this.cboObservacion.SelectedItem).Nombre;
                this.uiObservacionEmpleado.ObservacionDescripcion = this.txtDescripcion.Text.Trim();

                bool rpta = false;
                string msg = "";
                var lnObservacionEmpleado = new LN.ObservacionEmpleado();
                if (this.uiObservacionEmpleado.ID == 0) //Nuevo
                {
                    rpta = lnObservacionEmpleado.Insertar(ref this.uiObservacionEmpleado);
                    if (true)
                        msg = "Se registro la nueva observación";
                }
                else  //Actualizar
                {
                    rpta = lnObservacionEmpleado.Actualizar(this.uiObservacionEmpleado);
                    if (true)
                        msg = "Se actualizo la observación";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarListadoObservaciones();
                    this.Close();
                }
                    
                #endregion

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void cboEmpleado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.cboEmpleado.SelectedIndex > 0)
                {
                    string codigoEmpleado = this.cboEmpleado.SelectedValue.ToString().Trim();
                    this.txtEmpleadoCodigo.Text = codigoEmpleado;
                }
                else
                {
                    this.txtEmpleadoCodigo.Clear();
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void txtEmpleadoCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                string codigoEmpleado = this.txtEmpleadoCodigo.Text.Trim();

                var lst = (List<BE.Record>)this.cboEmpleado.DataSource;

                if (lst.Where(x => x.Codigo == codigoEmpleado).Count() > 0)
                {
                    this.txtEmpleadoCodigo.Text = codigoEmpleado;
                    this.cboEmpleado.SelectedValue = codigoEmpleado;
                }
                else
                {
                    this.txtEmpleadoCodigo.Clear();
                    this.cboEmpleado.SelectedIndex = 0;
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
