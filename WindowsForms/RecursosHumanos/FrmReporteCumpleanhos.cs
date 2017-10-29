using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmReporteCumpleanhos : Form
    {

        #region "Patron Singleton"

        private static FrmReporteCumpleanhos frmInstance = null;

        public static FrmReporteCumpleanhos Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmReporteCumpleanhos();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmReporteCumpleanhos()
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

        private void CargarMeses()
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

                this.cboMeses.DataSource = lstMes;
                this.cboMeses.DisplayMember = "Nombre";
                this.cboMeses.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarTiposEmpleados()
        {
            try
            {

                var lstBeTipos = new List<BE.Record>();

                lstBeTipos.Add(new BE.Record() { Codigo = "0", Nombre = "Todos" });
                lstBeTipos.Add(new BE.Record() { Codigo = "1", Nombre = "Candidato" });
                lstBeTipos.Add(new BE.Record() { Codigo = "2", Nombre = "Empleado" });

                this.cboTipoEmpleado.DataSource = lstBeTipos;
                this.cboTipoEmpleado.DisplayMember = "Nombre";
                this.cboTipoEmpleado.ValueMember = "Codigo";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Formulario

        private void FrmReporteCumpleanhos_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarMeses();
                this.cboMeses.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarTiposEmpleados();
            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {

                int nroMes = int.Parse(this.cboMeses.SelectedValue.ToString());
                int tipoEmpleado = int.Parse(this.cboTipoEmpleado.SelectedValue.ToString());

                var frmReporte = FrmReporte.Instance();
                frmReporte.MdiParent = this.MdiParent;
                frmReporte.Show();

                frmReporte.ReporteCumpleaños(nroMes, tipoEmpleado);

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion
    }
}
