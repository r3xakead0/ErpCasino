using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmInasistenciaMant : Form
    {

        private FrmInasistenciaList frmList = null;
        private BE.UI.Inasistencia beInasistencia = null;

        public FrmInasistenciaMant(FrmInasistenciaList frmList)
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

        public void Cargar(BE.UI.Inasistencia beInasistencia)
        {
            try
            {

                if (beInasistencia != null)
                {

                    this.beInasistencia = beInasistencia;

                    this.dtpFecha.Value = this.beInasistencia.Fecha;
                    this.cboEmpleado.SelectedValue = this.beInasistencia.EmpleadoCodigo;
                    this.cboTipos.SelectedValue = this.beInasistencia.TipoCodigo;
                    this.txtAsunto.Text = this.beInasistencia.Asunto;
                    this.txtDetalle.Text = this.beInasistencia.Detalle;
                    this.txtCertificado.Text = this.beInasistencia.Certificado;
 
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
                this.beInasistencia = new BE.UI.Inasistencia();

                //Limpiar controles de edicion
                this.dtpFecha.Value = DateTime.Now;

                this.txtAsunto.Clear();
                this.txtDetalle.Clear();
                this.txtCertificado.Clear();

                this.CargarEmpleados();
                this.CargarTipos();

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

        private void CargarTipos()
        {
            var lstTipos = new LN.Record().ListarTiposInasistencias();

            lstTipos.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.cboTipos.DataSource = lstTipos;
            this.cboTipos.DisplayMember = "Nombre";
            this.cboTipos.ValueMember = "Codigo";
        }

        #region Formulario

        private void FrmInasistenciaMant_Load(object sender, EventArgs e)
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
                    throw new Exception("Seleccione un empleado");
                }

                if (this.cboTipos.SelectedIndex == 0)
                {
                    this.cboTipos.Focus();
                    throw new Exception("Seleccione un tipo de inasistencia");
                }

                if (this.txtAsunto.Text.Trim().Length == 0)
                {
                    this.txtAsunto.Focus();
                    throw new Exception("Ingrese el asunto de la inasistencia");
                }

                if (this.txtDetalle.Text.Trim().Length == 0)
                {
                    this.txtDetalle.Focus();
                    throw new Exception("Ingrese el detalle de la inasistencia");
                }

                #endregion

                #region Guardar
 
                this.beInasistencia.Fecha = this.dtpFecha.Value;
                this.beInasistencia.EmpleadoCodigo = this.cboEmpleado.SelectedValue.ToString();
                this.beInasistencia.TipoCodigo = this.cboTipos.SelectedValue.ToString();
                this.beInasistencia.Asunto = this.txtAsunto.Text;
                this.beInasistencia.Detalle = this.txtDetalle.Text;
                this.beInasistencia.Certificado = this.txtCertificado.Text;

                int idUsuarioSesion = ((MdiMain)this.MdiParent).uiUsuario.ID;

                bool rpta = false;
                string msg = "";
                var lnInasistencia = new LN.Inasistencia();
                if (this.beInasistencia.Id == 0) //Nuevo
                {
                    rpta = lnInasistencia.Insertar(ref this.beInasistencia, idUsuarioSesion);
                    if (true)
                        msg = "Se registro el nuevo adelanto";
                }
                else  //Actualizar
                {
                    rpta = lnInasistencia.Actualizar(this.beInasistencia, idUsuarioSesion);
                    if (true)
                        msg = "Se actualizo el adelanto";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarListadoInasistencias();
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
