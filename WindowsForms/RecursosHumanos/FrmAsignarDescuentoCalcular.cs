using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmAsignarDescuentoCalcular : Form
    {

        private FrmAsignarDescuentoList frmList = null;

        private int Anho = 0;
        private int Mes = 0;

        private List<BE.UI.DescuentoEmpleado> lstUiDescuentosEmpleados = null;

        public FrmAsignarDescuentoCalcular(FrmAsignarDescuentoList frmList)
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

        private void Limpiar()
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();
                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarTiposDescuentos();

                this.lstUiDescuentosEmpleados = new List<BE.UI.DescuentoEmpleado>();
                this.CargarDescuentosEmpleados();

                this.FormatoDescuentosEmpleados();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private double DescuentoInasistencia(string codigoEmpleado)
        {
            try
            {
                double descuentoInasistencia = 0.0;

                double sueldoMinimo = 0.0;
                int diasMes = 0;
                int horasDia = 0;
                using (var beParametros = new BE.Parametros())
                {
                    sueldoMinimo = beParametros.SueldoMinimo;
                    diasMes = beParametros.BaseDias;
                    horasDia = beParametros.BaseHoras;
                }

                double costoMinuto = ((sueldoMinimo / diasMes) / horasDia) / 60;
                double penalidadNormal = costoMinuto * 3;
                double penalidadFeriado = costoMinuto * 5;

                var lnPlanilla = new LN.Planilla(this.Anho, this.Mes);

                var uiAsistenciaResumen = lnPlanilla.ObtenerResumenAsistenciaEmpleado(codigoEmpleado);
                if (uiAsistenciaResumen != null)
                {
                    double descuentoInasistenciaNormal = uiAsistenciaResumen.CantidadInasistenciasNormales * penalidadNormal;
                    double descuentoInasistenciaFeriado = uiAsistenciaResumen.CantidadInasistenciasFeriados * penalidadFeriado;

                    double descuentoInasistenciaPlanilla = 0.0;
                    var uiPlanillDetalle = lnPlanilla.ObtenerPlantillaDetalle(codigoEmpleado);
                    if (uiPlanillDetalle != null)
                        descuentoInasistenciaPlanilla = uiPlanillDetalle.DescuentoInasistenciaTotal;

                    descuentoInasistencia = descuentoInasistenciaNormal 
                                          + descuentoInasistenciaFeriado 
                                          - descuentoInasistenciaPlanilla;
                }
                //else
                //{
                //    DateTime fechaPeriodo = new DateTime(this.Anho, this.Mes, 1);
                //    string mensajeError = $"No encuentra calculo de planilla para el periodo {fechaPeriodo.ToString("yyyy/MM")}";
                //    throw new Exception(mensajeError);
                //}
                uiAsistenciaResumen = null;

                return descuentoInasistencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarAnhos()
        {
            try
            {
                int anhoInicio = 2017;
                int anhoFinal = DateTime.Now.Year + 5;

                var lstAnhos = new List<BE.Record>();
                for (int i = anhoInicio; i < anhoFinal; i++)
                {
                    lstAnhos.Add(new BE.Record() { Codigo = i.ToString(), Nombre = i.ToString() });
                }

                this.cboAnho.DataSource = lstAnhos;
                this.cboAnho.DisplayMember = "Nombre";
                this.cboAnho.ValueMember = "Codigo";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE.Record> ListaTrabajadores()
        {
            try
            {
                List<BE.Record> lstTrabajadores = new List<BE.Record>();

                var lstEmpleados = new LN.Empleado().Combo();
                var lstCandidatos = new LN.Candidato().Combo();

                lstEmpleados.AddRange(lstCandidatos);
                lstTrabajadores = lstEmpleados.OrderBy(o => o.Codigo).Distinct().ToList();

                lstEmpleados = null;
                lstCandidatos = null;

                return lstTrabajadores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarMes()
        {
            try
            {

                var lstMes = new List<BE.Record>();

                lstMes.Add(new BE.Record() { Codigo = "1", Nombre = "Enero" });
                lstMes.Add(new BE.Record() { Codigo = "2", Nombre = "Febrero" });
                lstMes.Add(new BE.Record() { Codigo = "3", Nombre = "Marzo" });
                lstMes.Add(new BE.Record() { Codigo = "4", Nombre = "Abril" });
                lstMes.Add(new BE.Record() { Codigo = "5", Nombre = "Mayo" });
                lstMes.Add(new BE.Record() { Codigo = "6", Nombre = "Junio" });
                lstMes.Add(new BE.Record() { Codigo = "7", Nombre = "Julio" });
                lstMes.Add(new BE.Record() { Codigo = "8", Nombre = "Agosto" });
                lstMes.Add(new BE.Record() { Codigo = "9", Nombre = "Setiembre" });
                lstMes.Add(new BE.Record() { Codigo = "10", Nombre = "Octubre" });
                lstMes.Add(new BE.Record() { Codigo = "11", Nombre = "Noviembre" });
                lstMes.Add(new BE.Record() { Codigo = "12", Nombre = "Diciembre" });

                this.cboMes.DataSource = lstMes;
                this.cboMes.DisplayMember = "Nombre";
                this.cboMes.ValueMember = "Codigo";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarTiposDescuentos()
        {
            try
            {
                var lstTipos = new LN.Descuento().Listar();
                lstTipos = lstTipos.Where(x => x.Calculado == true).ToList();

                lstTipos.Insert(0, new BE.UI.Descuento() { Id = 0, Nombre = "Seleccione" });

                this.cboDescuento.DataSource = lstTipos;
                this.cboDescuento.DisplayMember = "Nombre";
                this.cboDescuento.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDescuentosEmpleados()
        {
            try
            {
                var sorted = new SortableBindingList<BE.UI.DescuentoEmpleado>(this.lstUiDescuentosEmpleados);
                this.dgvDescuentos.DataSource = sorted;

                int nroDescuentos = this.lstUiDescuentosEmpleados.Count;
                this.txtNroDescuentos.Text = nroDescuentos.ToString();

                double totalDescuentos = this.lstUiDescuentosEmpleados.Sum(x => x.Monto);
                this.txtTotal.Text = totalDescuentos.ToString("N2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoDescuentosEmpleados()
        {
            try
            {
                Util.FormatDatagridview(ref this.dgvDescuentos);

                for (int col = 0; col < this.dgvDescuentos.Columns.Count; col++)
                    this.dgvDescuentos.Columns[col].Visible = false;

                this.dgvDescuentos.Columns["Fecha"].Visible = true;
                this.dgvDescuentos.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvDescuentos.Columns["Fecha"].Width = 80;
                this.dgvDescuentos.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvDescuentos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvDescuentos.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvDescuentos.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvDescuentos.Columns["EmpleadoCodigo"].Width = 80;
                this.dgvDescuentos.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvDescuentos.Columns["EmpleadoNombreCompleto"].Visible = true;
                this.dgvDescuentos.Columns["EmpleadoNombreCompleto"].HeaderText = "Empleado";
                this.dgvDescuentos.Columns["EmpleadoNombreCompleto"].Width = 200;
                this.dgvDescuentos.Columns["EmpleadoNombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvDescuentos.Columns["DescuentoNombre"].Visible = true;
                this.dgvDescuentos.Columns["DescuentoNombre"].HeaderText = "Descuento";
                this.dgvDescuentos.Columns["DescuentoNombre"].Width = 100;
                this.dgvDescuentos.Columns["DescuentoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvDescuentos.Columns["Monto"].Visible = true;
                this.dgvDescuentos.Columns["Monto"].HeaderText = "Monto";
                this.dgvDescuentos.Columns["Monto"].Width = 100;
                this.dgvDescuentos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvDescuentos.Columns["Monto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvDescuentos, "EmpleadoNombreCompleto");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Formulario

        private void FrmAsignarDescuentoCalcular_Load(object sender, EventArgs e)
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

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {

                #region Validaciones
                
                if (this.cboDescuento.SelectedIndex == 0)
                {
                    this.cboDescuento.Focus();
                    throw new Exception("Seleccione un tipo de descuento");
                }

                #endregion

                Util.PointerLoad(this);

                #region Calcular

                this.Anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                this.Mes  = int.Parse(this.cboMes.SelectedValue.ToString());
                int dia = DateTime.DaysInMonth(this.Anho, this.Mes);
                DateTime fechaPeriodo = new DateTime(this.Anho, this.Mes, dia);

                var uiDescuento = ((BE.UI.Descuento)this.cboDescuento.SelectedItem);
                int DescuentoId = uiDescuento.Id;
                string DescuentoTipo = uiDescuento.Calculado ? "Calculado" : "Manual"; //Manual o Calculado
                string DescuentoNombre = uiDescuento.Nombre;
                double DescuentoMonto = 0.0;
                uiDescuento = null;

                if (new LN.DescuentoEmpleado().ExisteCalculo(this.Anho, this.Mes, DescuentoId))
                {
                    if (Util.ConfirmationMessage("Ya existe un calculo de descuentos para este periodo. ¿Desea continua?") == false)
                        return;
                }

                List<BE.Record> lstTrabajadores = ListaTrabajadores();

                this.lstUiDescuentosEmpleados = new List<BE.UI.DescuentoEmpleado>();

                foreach (BE.Record beTrabajador in lstTrabajadores)
                {
                    var uiDescuentoEmpleado = new BE.UI.DescuentoEmpleado();

                    uiDescuentoEmpleado.Fecha = fechaPeriodo;
                    uiDescuentoEmpleado.EmpleadoCodigo = beTrabajador.Codigo;
                    uiDescuentoEmpleado.EmpleadoNombreCompleto = beTrabajador.Nombre;
                    uiDescuentoEmpleado.DescuentoID = DescuentoId;
                    uiDescuentoEmpleado.DescuentoTipo = DescuentoTipo;
                    uiDescuentoEmpleado.DescuentoNombre = DescuentoNombre;

                    switch (DescuentoId)
                    {
                        case 1: //Inasistencia
                            DescuentoMonto = this.DescuentoInasistencia(beTrabajador.Codigo);
                            break;
                        default:
                            DescuentoMonto = 0.0;
                            break;
                    }

                    uiDescuentoEmpleado.Monto = DescuentoMonto;
                    uiDescuentoEmpleado.Motivo = "";

                    if (DescuentoMonto > 0.0)
                        lstUiDescuentosEmpleados.Add(uiDescuentoEmpleado);

                }

                #endregion

                #region Mostrar 

                this.txtAnhoMes.Text = fechaPeriodo.ToString("yyyy/MM");
                this.txtTipoDescuento.Text = DescuentoNombre;

                this.CargarDescuentosEmpleados();

                #endregion

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
            finally
            {
                Util.PointerReady(this);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.lstUiDescuentosEmpleados.Count == 0)
                    throw new Exception("Debe realizar un calculo de Descuentos");

                if (Util.ConfirmationMessage("¿Desea guardar los descuentos calculados?") == false)
                    return;

                bool rpta = false;
                var lnDescuentoEmpleado = new LN.DescuentoEmpleado();
                for (int i = 0; i < this.lstUiDescuentosEmpleados.Count; i++)
                {
                    BE.UI.DescuentoEmpleado uiDescuentoEmpleado = this.lstUiDescuentosEmpleados[i];
                    rpta = lnDescuentoEmpleado.Insertar(ref uiDescuentoEmpleado);
                    this.lstUiDescuentosEmpleados[i].ID = uiDescuentoEmpleado.ID;
                }

                Util.InformationMessage("Se guardo los descuentos calculados");

                if (this.frmList != null)
                    this.frmList.CargarListadoDescuentos();

                this.Close();

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
