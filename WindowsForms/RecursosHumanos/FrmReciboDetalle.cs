using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmReciboDetalle : Form
    {

        public FrmReciboDetalle()
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

        #region Metodos

        public void Cargar(int anho, int mes, string codigoEmpleado)
        {
            try
            {
                this.cboAnho.SelectedValue = anho.ToString();
                this.cboMes.SelectedValue = mes.ToString();

                this.cboEmpleado.SelectedValue = codigoEmpleado;

                var uiTrabajador = (BE.UI.Trabajador)this.cboEmpleado.SelectedItem;
                if (uiTrabajador != null)
                    this.txtTipo.Text = uiTrabajador.Tipo.ToString();
                else
                    this.txtTipo.Clear();

                this.CargarListadoRecibos(anho, mes, codigoEmpleado);
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

                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarEmpleados()
        {
            var lstUiEmpleados = new LN.Empleado().ListaSimple();
            var lstUiCandidatos = new LN.Candidato().ListaSimple();

            lstUiEmpleados.AddRange(lstUiCandidatos);
            var lstUiTrabajadores = lstUiEmpleados.OrderBy(o => o.ApellidosNombres).ToList();

            this.cboEmpleado.DataSource = lstUiTrabajadores;
            this.cboEmpleado.DisplayMember = "ApellidosNombres";
            this.cboEmpleado.ValueMember = "Codigo";
        }

        private void CargarListadoRecibos(int anho = 0, int mes = 0, string codigoEmpleado = "")
        {
            try
            {
                double totBase = 0.0; //Sueldo
                double totBonos = 0.0;
                double totDescuentos = 0.0;
                double totGeneral = 0.0;

                List<BE.UI.Recibo> lstUiRecibosResumen = new List<BE.UI.Recibo>();

                if (anho > 0 || mes > 0 || codigoEmpleado.Length > 0)
                {
                    lstUiRecibosResumen = new LN.Recibo().ResumenDetallado(anho, mes, codigoEmpleado);

                    //totBase = lstUiRecibosResumen.Where(x => x.Tipo.Equals("Sueldo")).Sum(x => x.Monto);
                    totBonos = lstUiRecibosResumen.Where(x => x.Tipo.Equals("Bono")).Sum(x => x.Total);
                    totDescuentos = lstUiRecibosResumen.Where(x => x.Tipo.Equals("Descuento")).Sum(x => x.Total);

                    if (this.txtTipo.Text == BE.UI.TipoTrabajadorEnum.Candidato.ToString())
                    {
                        var beCandidatoContratacion = new LN.Candidato().ObtenerContratacion(codigoEmpleado);
                        if (beCandidatoContratacion != null)
                            totBase = beCandidatoContratacion.Sueldo;
                    }

                    totGeneral = totBase + totBonos - totDescuentos;
                }

                var sorted = new SortableBindingList<BE.UI.Recibo>(lstUiRecibosResumen);
                this.dgvRecibos.DataSource = sorted;

                this.txtTotalSueldo.Text = totBase.ToString("N2");
                this.txtTotalBonos.Text = totBonos.ToString("N2");
                this.txtTotalDescuentos.Text = totDescuentos.ToString("N2");
                this.txtTotalGeneral.Text = totGeneral.ToString("N2");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormatoListadoRecibos()
        {
            try
            {

                Util.FormatDatagridview(ref this.dgvRecibos);

                for (int i = 0; i < this.dgvRecibos.Columns.Count; i++)
                    this.dgvRecibos.Columns[i].Visible = false;

                this.dgvRecibos.Columns["Tipo"].Visible = true;
                this.dgvRecibos.Columns["Tipo"].HeaderText = "Tipo";
                this.dgvRecibos.Columns["Tipo"].Width = 100;
                this.dgvRecibos.Columns["Tipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgvRecibos.Columns["Concepto"].Visible = true;
                this.dgvRecibos.Columns["Concepto"].HeaderText = "Concepto";
                this.dgvRecibos.Columns["Concepto"].Width = 200;
                this.dgvRecibos.Columns["Concepto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                this.dgvRecibos.Columns["Fecha"].Visible = true;
                this.dgvRecibos.Columns["Fecha"].HeaderText = "Fecha";
                this.dgvRecibos.Columns["Fecha"].Width = 80;
                this.dgvRecibos.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvRecibos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

                this.dgvRecibos.Columns["Monto"].Visible = true;
                this.dgvRecibos.Columns["Monto"].HeaderText = "Monto";
                this.dgvRecibos.Columns["Monto"].Width = 100;
                this.dgvRecibos.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvRecibos.Columns["Monto"].DefaultCellStyle.Format = "N2";

                Util.AutoWidthColumn(ref this.dgvRecibos, "Concepto");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region Formulario

        private void FrmReciboDetalle_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarAnhos();
                this.CargarMes();

                this.cboAnho.SelectedValue = DateTime.Now.Year.ToString();
                this.cboMes.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarEmpleados();

                this.CargarListadoRecibos();
                this.FormatoListadoRecibos();

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void FrmReciboDetalle_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                Util.AutoWidthColumn(ref this.dgvRecibos, "Concepto");
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

        private void cboAnhoMesEmpleado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());

                var uiTrabajador = (BE.UI.Trabajador)this.cboEmpleado.SelectedItem;
                string codEmpleado = uiTrabajador.Codigo;

                this.txtTipo.Text = uiTrabajador.Tipo.ToString();

                this.CargarListadoRecibos(anho, mes, codEmpleado);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnExportarAsistenciasCsv_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Comma-separated Values (*.csv)|*.csv";
                sfd.FileName = "export.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Util.PointerLoad(this);
                    Util.DatagridviewToCsv(this.dgvRecibos, sfd.FileName);
                    Util.InformationMessage("Se exporto correctamente el archivo CSV");
                }
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());
                string codigoTrabajador = this.cboEmpleado.SelectedValue.ToString();

                var frmPlanillaVista = new FrmImpresion();
                frmPlanillaVista.MdiParent = this.MdiParent;
                frmPlanillaVista.Show();
                frmPlanillaVista.ImpresionRecibo(anho, mes, codigoTrabajador);

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

    }
}
