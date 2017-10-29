using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using BE = ErpCasino.BusinessLibrary.BE;
using LN = ErpCasino.BusinessLibrary.LN;
using System.Collections.Generic;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmReporteAsistencias : Form
    {

        #region "Patron Singleton"

        private static FrmReporteAsistencias frmInstance = null;

        public static FrmReporteAsistencias Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmReporteAsistencias();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmReporteAsistencias()
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

        private void CargarAnhos()
        {
            try
            {

                var lstAnhos = new List<BE.Record>();

                int anhoInicio = 2017;
                int anhoActual = DateTime.Now.Year;

                for (int i = anhoInicio; i <= anhoActual; i++)
                {
                    lstAnhos.Add(new BE.Record() { Codigo = i.ToString(), Nombre = i.ToString() });
                }
                
                this.cboAnhos.DataSource = lstAnhos;
                this.cboAnhos.DisplayMember = "Nombre";
                this.cboAnhos.ValueMember = "Codigo";
            }
            catch (Exception ex)
            {
                throw ex;
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

        private void CargarSalas()
        {
            try
            {

                var lstBeSalas = new LN.Sala().ListaSimple();

                lstBeSalas.Insert(0, new BE.Sala() { IdSala = 0, Nombre = "Todas" });

                this.cboSalas.DataSource = lstBeSalas;
                this.cboSalas.DisplayMember = "Nombre";
                this.cboSalas.ValueMember = "IdSala";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Formulario

        private void FrmReporteAsistencias_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarAnhos();
                this.cboAnhos.SelectedValue = DateTime.Now.Year.ToString();

                this.CargarMeses();
                this.cboMeses.SelectedValue = DateTime.Now.Month.ToString();

                this.CargarSalas();
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

                int anho = int.Parse(this.cboAnhos.SelectedValue.ToString());
                int nroMes = int.Parse(this.cboMeses.SelectedValue.ToString());
                int idSala = int.Parse(this.cboSalas.SelectedValue.ToString());

                var frmReporte = FrmReporte.Instance();
                frmReporte.MdiParent = this.MdiParent;
                frmReporte.Show();

                frmReporte.ReporteAsistencias(anho,nroMes, idSala);

            }
            catch (Exception ex)
            {
                Util.ErrorMessage(ex.Message);
            }
        }

        #endregion

    }
}
