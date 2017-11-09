using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using LN = ErpCasino.BusinessLibrary.LN;

namespace ErpCasino.WindowsForms.RecursosHumanos
{
    public partial class FrmImpresion : Form
    {

        #region "Patron Singleton"

        private static FrmImpresion frmInstance = null;

        public static FrmImpresion Instance()
        {

            if (frmInstance == null || frmInstance.IsDisposed == true)
            {
                frmInstance = new FrmImpresion();
            }

            frmInstance.BringToFront();

            return frmInstance;
        }

        #endregion

        public FrmImpresion()
        {
            InitializeComponent();
        }

        private void FrmImpresion_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ImpresionBoleta(int anho, int mes, string codigoEmpleado)
        {

            try
            {
                string impresion = @"\RecursosHumanos\Impresos\ImpresionBoleta.rpt";

                ReportDocument rpt = new ReportDocument();

                rpt.Load(Application.StartupPath + impresion);

                //Obtener datos de conexion a Base de datos
                var Conexion = new LN.Conexion();

                //Cargar con la configuracion de Crystal Report
                //==================================================================================
                //Configuramos la Base de Datos
                TableLogOnInfo ConInfo = new TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = Conexion.Usuario;
                ConInfo.ConnectionInfo.Password = Conexion.Clave;
                ConInfo.ConnectionInfo.DatabaseName = Conexion.BaseDatos;
                ConInfo.ConnectionInfo.ServerName = Conexion.Servidor;
                for (int i = 0; i <= rpt.Database.Tables.Count - 1; i++)
                {
                    rpt.Database.Tables[i].ApplyLogOnInfo(ConInfo);
                }

                ParameterFieldDefinitions crParameterFieldDefinitions = default(ParameterFieldDefinitions);
                ParameterFieldDefinition crParameter1 = default(ParameterFieldDefinition);
                ParameterFieldDefinition crParameter2 = default(ParameterFieldDefinition);
                ParameterFieldDefinition crParameter3 = default(ParameterFieldDefinition);
                ParameterValues crParameter1Values = new ParameterValues();
                ParameterValues crParameter2Values = new ParameterValues();
                ParameterValues crParameter3Values = new ParameterValues();
                ParameterDiscreteValue crDiscrete1Value = new ParameterDiscreteValue();
                ParameterDiscreteValue crDiscrete2Value = new ParameterDiscreteValue();
                ParameterDiscreteValue crDiscrete3Value = new ParameterDiscreteValue();

                //'Get the collection of parameters from the report
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                //'Access the specified parameter from the collection
                crParameter1 = crParameterFieldDefinitions["@Anho"];
                crParameter2 = crParameterFieldDefinitions["@Mes"];
                crParameter3 = crParameterFieldDefinitions["@CodigoEmpleado"];

                //'Get the current values from the parameter field.  At this point
                //'there are zero values set.
                crParameter1Values = crParameter1.CurrentValues;
                crParameter2Values = crParameter2.CurrentValues;
                crParameter3Values = crParameter3.CurrentValues;

                //'Set the current values for the parameter field
                crDiscrete1Value = new ParameterDiscreteValue();
                crDiscrete1Value.Value = anho;

                crDiscrete2Value = new ParameterDiscreteValue();
                crDiscrete2Value.Value = mes;

                crDiscrete3Value = new ParameterDiscreteValue();
                crDiscrete3Value.Value = codigoEmpleado;

                //'Add the first current value for the parameter field
                crParameter1Values.Add(crDiscrete1Value);
                crParameter2Values.Add(crDiscrete2Value);
                crParameter3Values.Add(crDiscrete3Value);

                //'All current parameter values must be applied for the parameter field.
                crParameter1.ApplyCurrentValues(crParameter1Values);
                crParameter2.ApplyCurrentValues(crParameter2Values);
                crParameter3.ApplyCurrentValues(crParameter3Values);

                crvVisorInforme.ReportSource = rpt;
                crvVisorInforme.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImpresionVacacion(string codigoEmpleado)
        {

            try
            {
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImpresionCts(int anho, int periodo, string codigoEmpleado)
        {

            try
            {
                string impresion = @"\RecursosHumanos\Impresos\ImpresionCts.rpt";

                ReportDocument rpt = new ReportDocument();

                rpt.Load(Application.StartupPath + impresion);

                //Obtener datos de conexion a Base de datos
                var Conexion = new LN.Conexion();

                //Cargar con la configuracion de Crystal Report
                //==================================================================================
                //Configuramos la Base de Datos
                TableLogOnInfo ConInfo = new TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = Conexion.Usuario;
                ConInfo.ConnectionInfo.Password = Conexion.Clave;
                ConInfo.ConnectionInfo.DatabaseName = Conexion.BaseDatos;
                ConInfo.ConnectionInfo.ServerName = Conexion.Servidor;
                for (int i = 0; i <= rpt.Database.Tables.Count - 1; i++)
                {
                    rpt.Database.Tables[i].ApplyLogOnInfo(ConInfo);
                }

                ParameterFieldDefinitions crParameterFieldDefinitions = default(ParameterFieldDefinitions);
                ParameterFieldDefinition crParameter1 = default(ParameterFieldDefinition);
                ParameterFieldDefinition crParameter2 = default(ParameterFieldDefinition);
                ParameterFieldDefinition crParameter3 = default(ParameterFieldDefinition);
                ParameterValues crParameter1Values = new ParameterValues();
                ParameterValues crParameter2Values = new ParameterValues();
                ParameterValues crParameter3Values = new ParameterValues();
                ParameterDiscreteValue crDiscrete1Value = new ParameterDiscreteValue();
                ParameterDiscreteValue crDiscrete2Value = new ParameterDiscreteValue();
                ParameterDiscreteValue crDiscrete3Value = new ParameterDiscreteValue();

                //'Get the collection of parameters from the report
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                //'Access the specified parameter from the collection
                crParameter1 = crParameterFieldDefinitions["@Anho"];
                crParameter2 = crParameterFieldDefinitions["@Periodo"];
                crParameter3 = crParameterFieldDefinitions["@CodigoEmpleado"];

                //'Get the current values from the parameter field.  At this point
                //'there are zero values set.
                crParameter1Values = crParameter1.CurrentValues;
                crParameter2Values = crParameter2.CurrentValues;
                crParameter3Values = crParameter3.CurrentValues;

                //'Set the current values for the parameter field
                crDiscrete1Value = new ParameterDiscreteValue();
                crDiscrete1Value.Value = anho;

                crDiscrete2Value = new ParameterDiscreteValue();
                crDiscrete2Value.Value = periodo;

                crDiscrete3Value = new ParameterDiscreteValue();
                crDiscrete3Value.Value = codigoEmpleado;

                //'Add the first current value for the parameter field
                crParameter1Values.Add(crDiscrete1Value);
                crParameter2Values.Add(crDiscrete2Value);
                crParameter3Values.Add(crDiscrete3Value);

                //'All current parameter values must be applied for the parameter field.
                crParameter1.ApplyCurrentValues(crParameter1Values);
                crParameter2.ApplyCurrentValues(crParameter2Values);
                crParameter3.ApplyCurrentValues(crParameter3Values);

                crvVisorInforme.ReportSource = rpt;
                crvVisorInforme.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ImpresionGratificacion(int anho, int periodo, string codigoEmpleado)
        {

            try
            {
                string impresion = @"\RecursosHumanos\Impresos\ImpresionGratificacion.rpt";

                ReportDocument rpt = new ReportDocument();

                rpt.Load(Application.StartupPath + impresion);

                //Obtener datos de conexion a Base de datos
                var Conexion = new LN.Conexion();

                //Cargar con la configuracion de Crystal Report
                //==================================================================================
                //Configuramos la Base de Datos
                TableLogOnInfo ConInfo = new TableLogOnInfo();
                ConInfo.ConnectionInfo.UserID = Conexion.Usuario;
                ConInfo.ConnectionInfo.Password = Conexion.Clave;
                ConInfo.ConnectionInfo.DatabaseName = Conexion.BaseDatos;
                ConInfo.ConnectionInfo.ServerName = Conexion.Servidor;
                for (int i = 0; i <= rpt.Database.Tables.Count - 1; i++)
                {
                    rpt.Database.Tables[i].ApplyLogOnInfo(ConInfo);
                }

                ParameterFieldDefinitions crParameterFieldDefinitions = default(ParameterFieldDefinitions);
                ParameterFieldDefinition crParameter1 = default(ParameterFieldDefinition);
                ParameterFieldDefinition crParameter2 = default(ParameterFieldDefinition);
                ParameterFieldDefinition crParameter3 = default(ParameterFieldDefinition);
                ParameterValues crParameter1Values = new ParameterValues();
                ParameterValues crParameter2Values = new ParameterValues();
                ParameterValues crParameter3Values = new ParameterValues();
                ParameterDiscreteValue crDiscrete1Value = new ParameterDiscreteValue();
                ParameterDiscreteValue crDiscrete2Value = new ParameterDiscreteValue();
                ParameterDiscreteValue crDiscrete3Value = new ParameterDiscreteValue();

                //'Get the collection of parameters from the report
                crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                //'Access the specified parameter from the collection
                crParameter1 = crParameterFieldDefinitions["@Anho"];
                crParameter2 = crParameterFieldDefinitions["@Periodo"];
                crParameter3 = crParameterFieldDefinitions["@CodigoEmpleado"];

                //'Get the current values from the parameter field.  At this point
                //'there are zero values set.
                crParameter1Values = crParameter1.CurrentValues;
                crParameter2Values = crParameter2.CurrentValues;
                crParameter3Values = crParameter3.CurrentValues;

                //'Set the current values for the parameter field
                crDiscrete1Value = new ParameterDiscreteValue();
                crDiscrete1Value.Value = anho;

                crDiscrete2Value = new ParameterDiscreteValue();
                crDiscrete2Value.Value = periodo;

                crDiscrete3Value = new ParameterDiscreteValue();
                crDiscrete3Value.Value = codigoEmpleado;

                //'Add the first current value for the parameter field
                crParameter1Values.Add(crDiscrete1Value);
                crParameter2Values.Add(crDiscrete2Value);
                crParameter3Values.Add(crDiscrete3Value);

                //'All current parameter values must be applied for the parameter field.
                crParameter1.ApplyCurrentValues(crParameter1Values);
                crParameter2.ApplyCurrentValues(crParameter2Values);
                crParameter3.ApplyCurrentValues(crParameter3Values);

                crvVisorInforme.ReportSource = rpt;
                crvVisorInforme.Refresh();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
