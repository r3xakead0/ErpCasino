using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmVacacionMant : Form
    {

        #region "Patron Singleton"

        private static FrmVacacionMant frmInstance = null;

        public static FrmVacacionMant Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmVacacionMant();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmVacacionList frmList = null;

        private BE.UI.Vacacion beVacacion = new BE.UI.Vacacion();

        public FrmVacacionMant()
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

        public void Cargar(BE.UI.Vacacion beVacacion = null)
        {
            try
            {

                if (beVacacion != null)
                {

                    this.beVacacion = beVacacion;

                   

                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        /// <summary>
        /// Cargar solo empleados que cumplan mas de 1 año de ingreso o de vacaciones
        /// </summary>
        private void CargarEmpleados()
        {
            var lstUiEmpleados = new LN.Empleado().Listar();

            this.cboEmpleado.DataSource = lstUiEmpleados;
            this.cboEmpleado.DisplayMember = "Nombre";
            this.cboEmpleado.ValueMember = "Codigo";
        }


        #region Formulario

        private void FrmVacacionMant_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarEmpleados();

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

                
                #endregion

                #region Guardar
 
               
                bool rpta = false;
                string msg = "";
                var lnVacacion = new LN.Vacacion();
                if (this.beVacacion.Id == 0) //Nuevo
                {
                    rpta = lnVacacion.Insertar(ref this.beVacacion);
                    if (true)
                        msg = "Se registro el nuevo Vacacion";
                }
                else  //Actualizar
                {
                    rpta = lnVacacion.Actualizar(this.beVacacion);
                    if (true)
                        msg = "Se actualizo el Vacacion";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarListadoVacaciones();
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

                var rpta = Util.ConfirmationMessage("¿Desea salir del formulario de mantenimiento de Vacacion?");

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

                var beEmpleado = lst.FirstOrDefault(x => x.Codigo.Contains(codigoEmpleado));

                if (beEmpleado != null)
                {
                    this.txtEmpleadoCodigo.Text = beEmpleado.Codigo;
                    this.cboEmpleado.SelectedValue = beEmpleado.Codigo;
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

    }
}
