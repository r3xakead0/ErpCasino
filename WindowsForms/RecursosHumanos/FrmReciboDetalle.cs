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
            var lstEmpleados = new LN.Empleado().Combo();
            var lstCandidatos = new LN.Candidato().Combo();
            lstEmpleados.AddRange(lstCandidatos);
            var lstTrabajador = lstEmpleados.OrderBy(o => o.Codigo).Distinct().ToList();

            this.cboEmpleado.DataSource = lstTrabajador;
            this.cboEmpleado.DisplayMember = "Nombre";
            this.cboEmpleado.ValueMember = "Codigo";
        }

        private void CargarListadoRecibos(int anho = 0, int mes = 0, string codigoEmpleado = "")
        {
            try
            {
                List<BE.UI.ReciboResumenDetalle> lstUiRecibosResumen = null;
                if (anho == 0 || mes == 0 || codigoEmpleado == "")
                {
                    lstUiRecibosResumen = new List<BE.UI.ReciboResumenDetalle>();
                }
                else
                {
                    lstUiRecibosResumen = new LN.Recibo().ResumenDetallado(anho, mes, codigoEmpleado);
                }

                var source = new BindingSource();
                source.DataSource = lstUiRecibosResumen;

                this.dgvRecibos.DataSource = source;

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

        private void FrmAfpComisionMant_Load(object sender, EventArgs e)
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

        private void cboAnhoMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());
                string codEmpleado = this.cboEmpleado.SelectedValue.ToString();

                this.CargarListadoRecibos(anho, mes, codEmpleado);
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
                string codigoEmpleado = this.cboEmpleado.SelectedValue.ToString().Trim();
                
                int anho = int.Parse(this.cboAnho.SelectedValue.ToString());
                int mes = int.Parse(this.cboMes.SelectedValue.ToString());
                    
                this.CargarListadoRecibos(anho, mes, codigoEmpleado);
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }

        }

        #endregion

    }
}
