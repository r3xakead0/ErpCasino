using BE = ErpCasino.BusinessLibrary.BE;
using DA = ErpCasino.BusinessLibrary.DA;
using System;
using System.Linq;
using System.Reflection;

namespace ErpCasino.BusinessLibrary.LN
{

    public class PlanillaBoleta
    {

        private BE.UI.PlanillaBoleta BeToUi(BE.PlanillaBoleta bePlanillaBoleta)
        {
            var uiPlanillaBoleta = new BE.UI.PlanillaBoleta();

            uiPlanillaBoleta.Id = bePlanillaBoleta.IdPlanillaBoleta;

            //Obtener las propiedades que sean publicas y se puedan escribir
            var lstPropertiesInfosBE = bePlanillaBoleta.GetType().GetProperties()
                .Where(x => x.CanWrite == true && x.PropertyType.IsPublic == true)
                .ToList();

            //Obtener las propuedades que sean publicas y se puedan escribir
            var lstPropertiesInfosUI = uiPlanillaBoleta.GetType().GetProperties()
                .Where(x => x.CanWrite == true && x.PropertyType.IsPublic == true)
                .ToList();

            foreach (PropertyInfo propertyInfoUI in lstPropertiesInfosUI)
            {
                var propertyName = propertyInfoUI.Name;

                PropertyInfo propertyInfoBE = lstPropertiesInfosBE.Where(x => x.Name == propertyName).FirstOrDefault();
                if (propertyInfoBE != null)
                    propertyInfoUI.SetValue(uiPlanillaBoleta, propertyInfoBE.GetValue(bePlanillaBoleta));

            }


            return uiPlanillaBoleta;
        }

        private BE.PlanillaBoleta UiToBe(BE.UI.PlanillaBoleta uiPlanillaBoleta)
        {
            var bePlanillaBoleta = new BE.PlanillaBoleta();

            bePlanillaBoleta.IdPlanillaBoleta = uiPlanillaBoleta.Id;

            //Obtener las propiedades que sean publicas y se puedan escribir
            var lstPropertiesInfosBE = bePlanillaBoleta.GetType().GetProperties()
                .Where(x => x.CanWrite == true && x.PropertyType.IsPublic == true)
                .ToList();

            //Obtener las propuedades que sean publicas y se puedan escribir
            var lstPropertiesInfosUI = uiPlanillaBoleta.GetType().GetProperties()
                .Where(x => x.PropertyType.IsPublic == true)
                .ToList();

            foreach (PropertyInfo propertyInfoBE in lstPropertiesInfosBE)
            {
                var propertyName = propertyInfoBE.Name;

                PropertyInfo propertyInfoUI = lstPropertiesInfosUI.Where(x => x.Name == propertyName).FirstOrDefault();
                if (propertyInfoUI != null)
                    propertyInfoBE.SetValue(bePlanillaBoleta, propertyInfoUI.GetValue(uiPlanillaBoleta));

            }

            return bePlanillaBoleta;
        }

        public bool Registrar(ref BE.UI.PlanillaBoleta uiPlanillaBoleta)
        {
            try
            {

                BE.PlanillaBoleta bePlanillaBoleta = UiToBe(uiPlanillaBoleta);

                int rowsAffected = 0;
                var daPlanillaBoleta = new DA.PlanillaBoleta();
                if (bePlanillaBoleta.IdPlanillaBoleta == 0)
                {
                    rowsAffected = daPlanillaBoleta.Insertar(ref bePlanillaBoleta);
                    if (rowsAffected > 0)
                        uiPlanillaBoleta.Id = bePlanillaBoleta.IdPlanillaBoleta;
                }
                else
                {
                    rowsAffected = daPlanillaBoleta.Actualizar(bePlanillaBoleta);
                }

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.PlanillaBoleta Obtener(int idPlanillaBoleta)
        {
            try
            {
                BE.UI.PlanillaBoleta uiPlanillaBoleta = null;

                var bePlanillaBoleta = new DA.PlanillaBoleta().Obtener(idPlanillaBoleta);
                if (bePlanillaBoleta != null)
                {
                    uiPlanillaBoleta = BeToUi(bePlanillaBoleta);
                }

                return uiPlanillaBoleta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE.UI.PlanillaBoleta Obtener(int anho, 
                                            int mes, 
                                            string codigoEmpleado)
        {
            try
            {
                BE.UI.PlanillaBoleta uiPlanillaBoleta = null;

                var bePlanillaBoleta = new DA.PlanillaBoleta().Obtener(anho, mes, codigoEmpleado);
                if (bePlanillaBoleta != null)
                {
                    uiPlanillaBoleta = BeToUi(bePlanillaBoleta);
                }

                return uiPlanillaBoleta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }

}