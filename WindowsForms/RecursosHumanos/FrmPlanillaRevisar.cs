﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmPlanillaRevisar : Form
    {

        private int idPlanilla = 0;

        private List<BE.UI.PlanillaDetalle> lstUiPlanillaDetalle = null;

        public FrmPlanillaRevisar()
        {
            try
            {
                InitializeComponent();

                this.lstUiPlanillaDetalle = new List<BE.UI.PlanillaDetalle>();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        private void LimpiarResumen()
        {
            try
            {
                this.txtAnho.Clear();
                this.txtMes.Clear();
                this.txtDias.Clear();

                double sueldoMinumo = 0.0;
                double asignacionFamiliar = 0.0;
                double esSalud = 0.0;
                double primerasExtras = 0.0;
                double posterioresExtras = 0.0;
                double horarioNocturno = 0.0;

                this.txtSueldoMinimo.Text = sueldoMinumo.ToString("N2");
                this.txtAsignacionFamiliar.Text = asignacionFamiliar.ToString("N2") + "%";
                this.txtEsSalud.Text = esSalud.ToString("N2") + "%";
                this.txtPrimerasHorasExtras.Text = primerasExtras.ToString("N2") + "%";
                this.txtPosterioresHorasExtras.Text = posterioresExtras.ToString("N2") + "%";
                this.txtHorarioNocturno.Text = horarioNocturno.ToString("N2") + "%";

                int cantidadEmpleados = 0;
                double totalSueldos = 0.0;
                double totalPagos = 0.0;
                double totalEssalud = 0.0;
                double totalSnp = 0.0;
                double totalAfp = 0.0;

                this.txtCantidadEmpleados.Text = cantidadEmpleados.ToString();
                this.txtTotalSueldos.Text = totalSueldos.ToString("N2");
                this.txtTotalPagos.Text = totalPagos.ToString("N2");
                this.txtTotalEssalud.Text = totalEssalud.ToString("N2");
                this.txtTotalOnp.Text = totalSnp.ToString("N2");
                this.txtTotalAfp.Text = totalAfp.ToString("N2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarCalcularPor()
        {
            try
            {

                var lstCalculoPor = new List<BE.Record>();

                lstCalculoPor.Add(new BE.Record() { Codigo = "D", Nombre = "Dia" });
                lstCalculoPor.Add(new BE.Record() { Codigo = "H", Nombre = "Hora" });
                lstCalculoPor.Add(new BE.Record() { Codigo = "M", Nombre = "Minuto" });

                this.cboCalculoPor.DataSource = lstCalculoPor;
                this.cboCalculoPor.DisplayMember = "Nombre";
                this.cboCalculoPor.ValueMember = "Codigo";

                this.cboCalculoPor.SelectedValue = "M";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoPlanillaDetalle()
        {
            try
            {
                if (this.lstUiPlanillaDetalle == null)
                    return;

                BindingSource source = new BindingSource();
                source.DataSource = this.lstUiPlanillaDetalle;
                this.dgvPlanilla.DataSource = source;

                Util.FormatDatagridview(ref this.dgvPlanilla);

                for (int i = 0; i < this.dgvPlanilla.Columns.Count; i++)
                    this.dgvPlanilla.Columns[i].Visible = false;

                this.dgvPlanilla.Columns["EmpleadoCodigo"].Visible = true;
                this.dgvPlanilla.Columns["EmpleadoCodigo"].HeaderText = "Codigo";
                this.dgvPlanilla.Columns["EmpleadoCodigo"].Width = 80;
                this.dgvPlanilla.Columns["EmpleadoCodigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvPlanilla.Columns["EmpleadoNombre"].Visible = true;
                this.dgvPlanilla.Columns["EmpleadoNombre"].HeaderText = "Apellidos y Nombres";
                this.dgvPlanilla.Columns["EmpleadoNombre"].Width = 150;
                this.dgvPlanilla.Columns["EmpleadoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvPlanilla.Columns["CargoNombre"].Visible = true;
                this.dgvPlanilla.Columns["CargoNombre"].HeaderText = "Cargo";
                this.dgvPlanilla.Columns["CargoNombre"].Width = 150;
                this.dgvPlanilla.Columns["CargoNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvPlanilla.Columns["Base"].Visible = true;
                this.dgvPlanilla.Columns["Base"].HeaderText = "Sueldo";
                this.dgvPlanilla.Columns["Base"].Width = 70;
                this.dgvPlanilla.Columns["Base"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPlanilla.Columns["Base"].DefaultCellStyle.Format = "N2";

                this.dgvPlanilla.Columns["AsignacionFamiliar"].Visible = true;
                this.dgvPlanilla.Columns["AsignacionFamiliar"].HeaderText = "Asignacion Familiar";
                this.dgvPlanilla.Columns["AsignacionFamiliar"].Width = 70;
                this.dgvPlanilla.Columns["AsignacionFamiliar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPlanilla.Columns["AsignacionFamiliar"].DefaultCellStyle.Format = "N2";

                this.dgvPlanilla.Columns["BonoNocturnoCantidad"].Visible = true;
                this.dgvPlanilla.Columns["BonoNocturnoCantidad"].HeaderText = "Cantidad Nocturnas";
                this.dgvPlanilla.Columns["BonoNocturnoCantidad"].Width = 70;
                this.dgvPlanilla.Columns["BonoNocturnoCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPlanilla.Columns["BonoNocturnoCantidad"].DefaultCellStyle.Format = "N2";

                this.dgvPlanilla.Columns["BonoNocturnoTotal"].Visible = true;
                this.dgvPlanilla.Columns["BonoNocturnoTotal"].HeaderText = "Bono Nocturno";
                this.dgvPlanilla.Columns["BonoNocturnoTotal"].Width = 70;
                this.dgvPlanilla.Columns["BonoNocturnoTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPlanilla.Columns["BonoNocturnoTotal"].DefaultCellStyle.Format = "N2";

                this.dgvPlanilla.Columns["BonoHorasExtrasCantidad"].Visible = true;
                this.dgvPlanilla.Columns["BonoHorasExtrasCantidad"].HeaderText = "Cantidad Extras";
                this.dgvPlanilla.Columns["BonoHorasExtrasCantidad"].Width = 70;
                this.dgvPlanilla.Columns["BonoHorasExtrasCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPlanilla.Columns["BonoHorasExtrasCantidad"].DefaultCellStyle.Format = "N2";

                this.dgvPlanilla.Columns["BonoHorasExtrasTotal"].Visible = true;
                this.dgvPlanilla.Columns["BonoHorasExtrasTotal"].HeaderText = "Bono Extras";
                this.dgvPlanilla.Columns["BonoHorasExtrasTotal"].Width = 70;
                this.dgvPlanilla.Columns["BonoHorasExtrasTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPlanilla.Columns["BonoHorasExtrasTotal"].DefaultCellStyle.Format = "N2";

                this.dgvPlanilla.Columns["BonoFeriadoCantidad"].Visible = true;
                this.dgvPlanilla.Columns["BonoFeriadoCantidad"].HeaderText = "Cantidad Feriado";
                this.dgvPlanilla.Columns["BonoFeriadoCantidad"].Width = 70;
                this.dgvPlanilla.Columns["BonoFeriadoCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPlanilla.Columns["BonoFeriadoCantidad"].DefaultCellStyle.Format = "N2";

                this.dgvPlanilla.Columns["BonoFeriadoTotal"].Visible = true;
                this.dgvPlanilla.Columns["BonoFeriadoTotal"].HeaderText = "Bono Feriado";
                this.dgvPlanilla.Columns["BonoFeriadoTotal"].Width = 70;
                this.dgvPlanilla.Columns["BonoFeriadoTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPlanilla.Columns["BonoFeriadoTotal"].DefaultCellStyle.Format = "N2";

                this.dgvPlanilla.Columns["DescuentoTardanzaCantidad"].Visible = true;
                this.dgvPlanilla.Columns["DescuentoTardanzaCantidad"].HeaderText = "Cantidad Tardanza";
                this.dgvPlanilla.Columns["DescuentoTardanzaCantidad"].Width = 70;
                this.dgvPlanilla.Columns["DescuentoTardanzaCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPlanilla.Columns["DescuentoTardanzaCantidad"].DefaultCellStyle.Format = "N2";

                this.dgvPlanilla.Columns["DescuentoTardanzaTotal"].Visible = true;
                this.dgvPlanilla.Columns["DescuentoTardanzaTotal"].HeaderText = "Descuento Tardanza";
                this.dgvPlanilla.Columns["DescuentoTardanzaTotal"].Width = 70;
                this.dgvPlanilla.Columns["DescuentoTardanzaTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPlanilla.Columns["DescuentoTardanzaTotal"].DefaultCellStyle.Format = "N2";

                this.dgvPlanilla.Columns["DescuentoInasistenciaCantidad"].Visible = true;
                this.dgvPlanilla.Columns["DescuentoInasistenciaCantidad"].HeaderText = "Cantidad Inasistencia";
                this.dgvPlanilla.Columns["DescuentoInasistenciaCantidad"].Width = 70;
                this.dgvPlanilla.Columns["DescuentoInasistenciaCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPlanilla.Columns["DescuentoInasistenciaCantidad"].DefaultCellStyle.Format = "N2";

                this.dgvPlanilla.Columns["DescuentoInasistenciaTotal"].Visible = true;
                this.dgvPlanilla.Columns["DescuentoInasistenciaTotal"].HeaderText = "Descuento Inasistencia";
                this.dgvPlanilla.Columns["DescuentoInasistenciaTotal"].Width = 70;
                this.dgvPlanilla.Columns["DescuentoInasistenciaTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvPlanilla.Columns["DescuentoInasistenciaTotal"].DefaultCellStyle.Format = "N2";

     
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarEmpleados()
        {
            try
            {
                var lstEmpleados = new LN.Empleado().Combo();

                lstEmpleados = lstEmpleados.OrderBy(x => x.Nombre).ToList();

                lstEmpleados.Insert(0, new BE.Record() { Codigo = "0", Nombre = "Seleccione" });

                this.cboEmpleado.DataSource = lstEmpleados;
                this.cboEmpleado.DisplayMember = "Nombre";
                this.cboEmpleado.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CalcularPlanillaResumen(int anho, int mes)
        {
            try
            {

                var lnPlanilla = new LN.Planilla(anho, mes);

                BE.Planilla objPlanilla = lnPlanilla.Obtener();
                if (objPlanilla == null)
                {
                    return;
                }

                this.idPlanilla = objPlanilla.ID;
                this.txtAnho.Text = objPlanilla.Anho.ToString();
                string nombreMes = Util.GetNameOfMonth(objPlanilla.Mes);
                this.txtMes.Text = nombreMes;
                this.txtDias.Text = objPlanilla.Dias.ToString();
                this.txtSueldoMinimo.Text = objPlanilla.SueldoMinimo.ToString("N2");
                this.txtAsignacionFamiliar.Text = objPlanilla.AsignacionFamiliar.ToString("N2") + "%";
                this.txtEsSalud.Text = objPlanilla.EsSalud.ToString("N2") + "%";
                this.txtPrimerasHorasExtras.Text = objPlanilla.PrimerasDosHorasExtras.ToString("N2") + "%";
                this.txtPosterioresHorasExtras.Text = objPlanilla.PosterioresDosHorasExtras.ToString("N2") + "%";
                this.txtHorarioNocturno.Text = objPlanilla.Nocturno.ToString("N2") + "%";


                int cantidadEmpleados = 0;
                double totalSueldos = 0.0;
                double totalPagos = 0.0;
                double totalEssalud = 0.0;
                double totalSnp = 0.0;
                double totalAfp = 0.0;

                lnPlanilla.Resumen(out cantidadEmpleados,
                                    out totalSueldos,
                                    out totalPagos,
                                    out totalEssalud,
                                    out totalSnp,
                                    out totalAfp);

                this.txtCantidadEmpleados.Text = cantidadEmpleados.ToString();
                this.txtTotalSueldos.Text = totalSueldos.ToString("N2");
                this.txtTotalPagos.Text = totalPagos.ToString("N2");
                this.txtTotalEssalud.Text = totalEssalud.ToString("N2");
                this.txtTotalOnp.Text = totalSnp.ToString("N2");
                this.txtTotalAfp.Text = totalAfp.ToString("N2");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CalcularPlanillaDetalle(int anho, int mes)
        {
            try
            {
                #region Limpiar
                this.lstUiPlanillaDetalle.Clear();
                #endregion

                //Obtiene calculo por minuto
                this.lstUiPlanillaDetalle = new LN.Planilla(anho, mes).ListarPlantillaDetalle();

                string calcular = this.cboCalculoPor.SelectedValue.ToString();
                switch (calcular)
                {
                    case "H": //Costo por Hora
                        for (int i = 0; i < this.lstUiPlanillaDetalle.Count; i++)
                        {
                            this.lstUiPlanillaDetalle[i].CalcularPor = calcular;

                            this.lstUiPlanillaDetalle[i].BonoNocturnoCantidad /= 60;
                            this.lstUiPlanillaDetalle[i].BonoHorasExtrasCantidad /= 60;
                            this.lstUiPlanillaDetalle[i].BonoFeriadoCantidad /= 60;
                            this.lstUiPlanillaDetalle[i].DescuentoTardanzaCantidad /= 60;
                            this.lstUiPlanillaDetalle[i].DescuentoInasistenciaCantidad /= 60;
                        }
                        break;

                    case "D": //Costo por Hora
                        for (int i = 0; i < this.lstUiPlanillaDetalle.Count; i++)
                        {
                            this.lstUiPlanillaDetalle[i].CalcularPor = calcular;

                            this.lstUiPlanillaDetalle[i].BonoNocturnoCantidad /= 60;
                            this.lstUiPlanillaDetalle[i].BonoHorasExtrasCantidad /= 60;
                            this.lstUiPlanillaDetalle[i].BonoFeriadoCantidad /= 60;
                            this.lstUiPlanillaDetalle[i].DescuentoTardanzaCantidad /= 60;
                            this.lstUiPlanillaDetalle[i].DescuentoInasistenciaCantidad /= 60;

                            this.lstUiPlanillaDetalle[i].BonoNocturnoCantidad /= 8;
                            this.lstUiPlanillaDetalle[i].BonoHorasExtrasCantidad /= 8;
                            this.lstUiPlanillaDetalle[i].BonoFeriadoCantidad /= 8;
                            this.lstUiPlanillaDetalle[i].DescuentoTardanzaCantidad /= 8;
                            this.lstUiPlanillaDetalle[i].DescuentoInasistenciaCantidad /= 8;

                        }
                        break;

                    default:
                        break;
                }


                BindingSource source = new BindingSource();
                source.DataSource = this.lstUiPlanillaDetalle;
                this.dgvPlanilla.DataSource = source;
 
                
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

                this.CboAnho.DataSource = lstAnhos;
                this.CboAnho.DisplayMember = "Nombre";
                this.CboAnho.ValueMember = "Codigo";
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

                this.CbxMes.DataSource = lstMes;
                this.CbxMes.DisplayMember = "Nombre";
                this.CbxMes.ValueMember = "Codigo";

                this.CbxMes.SelectedValue = DateTime.Now.Month.ToString();
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

                this.CargarAnhos();
                this.CargarMes();
                this.CargarCalcularPor();

                this.CboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.CbxMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarEmpleados();

                this.LimpiarResumen();

                this.FormatoPlanillaDetalle();
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
                this.Close();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {

                
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int anho = int.Parse(this.CboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.CbxMes.SelectedValue.ToString());

                this.CalcularPlanillaResumen(anho, mes);
                this.CalcularPlanillaDetalle(anho, mes);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPlanilla.CurrentRow != null)
                {
                    var uiPlanillaDetalle = (BE.UI.PlanillaDetalle)this.dgvPlanilla.CurrentRow.DataBoundItem;

                    var frmPlanillaVista = new FrmPlanillaDetalleView(this.idPlanilla);
                    frmPlanillaVista.MdiParent = this.MdiParent;
                    frmPlanillaVista.Show();
                    frmPlanillaVista.Cargar(uiPlanillaDetalle);
                }
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

        private void cboCalculoPor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int anho = int.Parse(this.CboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.CbxMes.SelectedValue.ToString());

                this.CalcularPlanillaDetalle(anho, mes);
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
                if (this.lstUiPlanillaDetalle.Count == 0)
                    return; 

                if (this.cboEmpleado.SelectedIndex > 0)
                {
                    string codigoEmpleado = this.cboEmpleado.SelectedValue.ToString().Trim();

                    this.txtEmpleadoCodigo.Text = codigoEmpleado;

                    this.dgvPlanilla.Rows.OfType<DataGridViewRow>().Where(x => x.Cells["EmpleadoCodigo"].Value.ToString().Equals(codigoEmpleado)).ToArray<DataGridViewRow>()[0].Selected = true;
                    this.dgvPlanilla.FirstDisplayedScrollingRowIndex = this.dgvPlanilla.SelectedRows[0].Index;
                    this.dgvPlanilla.Update();
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

                    if (this.lstUiPlanillaDetalle.Count == 0)
                        return;

                    this.dgvPlanilla.Rows.OfType<DataGridViewRow>().Where(x => x.Cells["EmpleadoCodigo"].Value.ToString().Equals(codigoEmpleado)).ToArray<DataGridViewRow>()[0].Selected = true;
                    this.dgvPlanilla.FirstDisplayedScrollingRowIndex = this.dgvPlanilla.SelectedRows[0].Index;
                    this.dgvPlanilla.Update();
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

        private void dgvPlanilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0)
                    return;

                var uiPlanillaDetalle = (BE.UI.PlanillaDetalle)this.dgvPlanilla.Rows[e.RowIndex].DataBoundItem;

                var frmPlanillaVista = new FrmPlanillaDetalleView(this.idPlanilla);
                frmPlanillaVista.MdiParent = this.MdiParent;
                frmPlanillaVista.Show();
                frmPlanillaVista.Cargar(uiPlanillaDetalle);

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }
    }
}