using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmLiquidacionMant : Form
    {

        private FrmLiquidacionList frmList = null;

        private BE.UI.Liquidacion uiLiquidacion = new BE.UI.Liquidacion();

        public FrmLiquidacionMant(FrmLiquidacionList frmList)
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

        private string DiferenciaFechas(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                string diferenciaMeses = "";
                int mesesDif = (fechaFinal.Month + fechaFinal.Year * 12) - (fechaInicio.Month + fechaInicio.Year * 12);
                if (mesesDif == 1)
                {
                    diferenciaMeses += "1 mes";
                }
                else if (mesesDif > 1)
                {
                    diferenciaMeses += mesesDif.ToString() + " meses";
                }

                string espacio = "";

                string diferenciaDias = "";
                DateTime fechaFinal2 = new DateTime(fechaFinal.Year, fechaFinal.Month, fechaInicio.Day);
                int diasDif = (int)fechaFinal.Subtract(fechaFinal2).TotalDays;
                if (diasDif == 1)
                {
                    espacio = " ";
                    diferenciaDias += "1 día";
                }
                else if (diasDif > 1)
                {
                    espacio = " ";
                    diferenciaDias += diasDif + " días";
                }

                return diferenciaMeses + espacio + diferenciaDias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cargar(BE.UI.Liquidacion beLiquidacion)
        {
            try
            {

                if (beLiquidacion != null)
                {

                    this.uiLiquidacion = beLiquidacion;

                    //this.dtpFecha.Value = this.beLiquidacion.Fecha;
                    //this.cboEmpleado.SelectedValue = this.beLiquidacion.CodigoEmpleado;
                    //this.cboTipos.SelectedValue = this.beLiquidacion.CodigoTipo;
                    //this.cboBancos.SelectedValue = this.beLiquidacion.IdBanco;
                    //this.txtNumero.Text = this.beLiquidacion.Numero;
                    //this.txtMonto.Text = this.beLiquidacion.Monto.ToString("N2");

                    //string codTipoBanco = "BAN";
                    //string codTipoSeleccionado = this.beLiquidacion.CodigoTipo;
                    //this.cboBancos.Enabled = codTipoSeleccionado.Equals(codTipoBanco);

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
                this.uiLiquidacion = new BE.UI.Liquidacion();

                //Datos
                this.txtEmpleadoCodigo.Clear();
                foreach (Control ctrl in this.grpDatos.Controls)
                {
                    if (ctrl is DateTimePicker)
                    {
                        ((DateTimePicker)ctrl).Value = DateTime.Now;
                    }
                }

                this.CargarEmpleados();
                this.CargarMotivosCese();

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

        private void CargarMotivosCese()
        {
            var lstMotivosCese = new LN.Empleado().Combo();

            lstMotivosCese.Insert(0, new BE.Record() { Codigo = "", Nombre = "Seleccione" });

            this.cboEmpleado.DataSource = lstMotivosCese;
            this.cboEmpleado.DisplayMember = "Nombre";
            this.cboEmpleado.ValueMember = "Codigo";
        }

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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones
                if (this.cboEmpleado.SelectedIndex == 0)
                {
                    this.cboEmpleado.Focus();
                    throw new Exception("Seleccione un empleado");
                }

                if (this.cboMotivoCese.SelectedIndex == 0)
                {
                    this.cboMotivoCese.Focus();
                    throw new Exception("Seleccione un motivo de cese");
                }
                #endregion

                #region Guardar

                //this.beLiquidacion.Fecha = this.dtpFecha.Value;
                //this.beLiquidacion.CodigoEmpleado = this.cboEmpleado.SelectedValue.ToString();
                //this.beLiquidacion.CodigoTipo = this.cboTipos.SelectedValue.ToString();
                //this.beLiquidacion.Numero = this.txtNumero.Text;
                //this.beLiquidacion.Monto = double.Parse(this.txtMonto.Text);
                //this.beLiquidacion.IdBanco = int.Parse(this.cboBancos.SelectedValue.ToString());

                bool rpta = false;
                string msg = "";
                var lnAdelanto = new LN.Liquidacion();
                if (this.uiLiquidacion.IdLiquidacion == 0) //Nuevo
                {
                    rpta = lnAdelanto.Insertar(ref this.uiLiquidacion);
                    if (true)
                        msg = "Se registro la nueva liquidación";
                }
                else  //Actualizar
                {
                    rpta = lnAdelanto.Actualizar(this.uiLiquidacion);
                    if (true)
                        msg = "Se actualizo la liquidación";
                }

                if (rpta == true)
                {
                    Util.InformationMessage(msg);
                    this.frmList.CargarListadoLiquidaciones();
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
        
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cboEmpleado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var beRecord = (BE.Record)this.cboEmpleado.SelectedItem;
                this.txtEmpleadoCodigo.Text = beRecord.Codigo;

                if (beRecord.Codigo.Length > 0)
                {
                    var beEmpleado =new LN.Empleado().Obtener(beRecord.Codigo);
                    if (beEmpleado != null)
                    {
                        this.txtSueldo.Text = beEmpleado.Recurso.Sueldo.ToString("N2");
                    }
                }
               
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dtpPeriodoLaboral_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var fecIni = this.dtpPeriodoLaboralInicial.Value;
                var fecFin = this.dtpPeriodoLaboralFinal.Value;
                this.txtTiempoServicio.Text = this.DiferenciaFechas(fecIni, fecFin);

                this.dtpPeriodoLiquidarFinal.Value = fecFin;
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dtpDepositoBancario_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var fecIni = this.dtpDepositoBancarioInicial.Value;
                var fecFin = this.dtpDepositoBancarioFinal.Value;
                this.txtTiempoDeposito.Text = this.DiferenciaFechas(fecIni, fecFin);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void dtpPeriodoLiquidar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var fecIni = this.dtpPeriodoLiquidarInicial.Value;
                var fecFin = this.dtpPeriodoLiquidarFinal.Value;
                this.txtTiempoLiquidar.Text = this.DiferenciaFechas(fecIni, fecFin);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
    }
}
